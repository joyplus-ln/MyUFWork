package com.imop.lj.tools.log;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FilenameFilter;
import java.io.OutputStreamWriter;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.ILogReason;
import com.imop.lj.common.LogReasons.LogDesc;
import com.imop.lj.common.LogReasons.ReasonDesc;

/**
 * 按照svn:shared\docs\技术\技术文档\日志规范.doc 生成reason_list表的初始化sql的脚本工具: 先查找
 * {@value #packageName} 包中所有以Log结尾的类,同时在{@value #reasonParentClass}
 * 找到相同类名的Reason定义后生成插入的sql语句</li>
 *
 *
 */
@SuppressWarnings("unchecked")
public class LogReasonListSqlGenerator {
	
	public static final String OutFile = "..\\game_tools\\target\\reason_list.sql";//"D:\\log_reason.sql";
	
	private static final String packageName = "com.imop.lj.logserver.model";
	private static final String reasonParentClass = "com.imop.lj.common.LogReasons";
	
	public static void genReasonListSql() throws Exception {
		// 查找package中所有已Log结尾的文件
		final String _resourcePackage = packageName.replace(".", "/");
		URL _resource = Thread.currentThread().getContextClassLoader()
				.getResource(_resourcePackage);
		File _directory = new File(_resource.getFile());
		File[] _listFiles = _directory.listFiles(new FilenameFilter() {
			@Override
			public boolean accept(File dir, String name) {
				return (name.endsWith("Log.class"));
			}
		});
		List<SqlReasonDesc> _sqlDescs = new ArrayList<SqlReasonDesc>();
		for (File _file : _listFiles) {
			final String _className = _file.getName().substring(0,
					_file.getName().indexOf("."));
			final String _reasonName = reasonParentClass + "$" + _className
					+ "Reason";
			final Class _class = Class.forName(packageName + "." + _className);
			final Class _reasonClass = Class.forName(_reasonName);
			LogDesc _logReason = (LogDesc) _reasonClass
					.getAnnotation(LogReasons.LogDesc.class);
			String _logDesc = _logReason.desc();
			if (_logDesc == null || (_logDesc = _logDesc.trim()).length() == 0) {
				throw new IllegalStateException(
						"The LogDesc.desc() mest be set.");
			}

			String _tableName = (_className.substring(0, 1).toLowerCase() + _className
					.substring(1)).replaceAll("([A-Z]{1})", "_$1")
					.toLowerCase();
			String _type = invokeMethod(_class.newInstance(), "getType",
					new Class[0], new Object[0]).toString();
			String _logField = "reason";
			SqlReasonDesc _reasonDescs = new SqlReasonDesc();
			_reasonDescs.tableName = _tableName;
			_reasonDescs.type = _type;
			_reasonDescs.logField = _logField;
			_reasonDescs.logDesc = _logDesc;

			Enum[] _enums = (Enum[]) invokeStaticMethod(_reasonClass, "values",
					new Class[0], new Object[0]);
			for (Enum _enum : _enums) {
				ReasonDesc _reasonDesc = _enum.getClass()
						.getField(_enum.name()).getAnnotation(ReasonDesc.class);
				SqlReasonDesc.SqlReason _reason = new SqlReasonDesc.SqlReason();
				if (_reasonDesc == null) {
					System.err.println(_enum.name()
							+ " does not have ReasonDesc Annotation");
					return;
				}
				_reason.desc = _reasonDesc.value();
				_reason.reason = ((ILogReason) _enum).getReason() + "";
				_reasonDescs.sqlReasons.add(_reason);
			}
			_sqlDescs.add(_reasonDescs);
		}
		StringBuilder _sb = new StringBuilder();
		_sb.append("-- --init reason_list table----\r\n");
		String _insertTemp = "insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (%s,'%s','%s','%s',%s,'%s');";
		for (SqlReasonDesc _sqlReason : _sqlDescs) {
			_sb.append("-- --" + _sqlReason.tableName + " begin----\r\n");
			for (SqlReasonDesc.SqlReason _reason : _sqlReason.sqlReasons) {
				_sb.append(String.format(_insertTemp, _sqlReason.type,
						_sqlReason.tableName, _sqlReason.logDesc,
						_sqlReason.logField, _reason.reason, _reason.desc));
				_sb.append("\r\n");
			}
			_sb.append("-- --" + _sqlReason.tableName + " end----\r\n\r\n");

			// // 打印日志原因，供文档使用
			// _sb.append(_sqlReason.tableName + "\r\n");
			// _sb.append("编号   描述" + "\r\n");
			// for (SqlReasonDesc.SqlReason _reason : _sqlReason.sqlReasons) {
			// _sb.append(_reason.reason + "  " + _reason.desc + "\r\n");
			// }
			// _sb.append("\r\n");

		}

		File output = new File(OutFile);
		if(output.exists())
		{
			output.delete();
		}

		inputFile(output, _sb.toString());

//		System.out.println(_sb.toString());

		System.out.println("SQL Generate Successful.");
	}

	public static void main(String[] args) throws Exception {
		LogReasonListSqlGenerator.genReasonListSql();
	}

	// 将SQL插入到文件中
	private static void inputFile(File file, String content)
			throws Exception {
		BufferedWriter writer = null;
		try {

			writer = new BufferedWriter(new OutputStreamWriter(
					new FileOutputStream(file, true), "UTF-8"));

			writer.write("use `tr_${server_id}_log`;");
			writer.newLine();
			writer.write("DROP TABLE IF EXISTS `reason_list`; CREATE TABLE `reason_list` (   `log_uid` int(10) unsigned NOT NULL AUTO_INCREMENT,   `log_type` int(10) unsigned NOT NULL,   `log_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,   `log_table` varchar(255) NOT NULL,   `log_desc` varchar(255) NOT NULL,   `log_field` varchar(255) NOT NULL,   `reason` int(10) NOT NULL,   `reason_name` varchar(255) NOT NULL,   PRIMARY KEY (`log_uid`) ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;");
			writer.newLine();
			writer.write("truncate reason_list;");
			writer.newLine();
			writer.write(content);
			writer.flush();
		} finally {
			writer.close();
		}
	}

	public static Object invokeMethod(Object obj, String methodName,
			Class[] paramTypes, Object[] params) throws Exception {
		return obj.getClass().getMethod(methodName, paramTypes).invoke(obj,
				params);
	}

	public static Object invokeStaticMethod(Class clazz, String methodName,
			Class[] paramTypes, Object[] params) throws Exception {
		return clazz.getMethod(methodName, paramTypes).invoke(clazz, params);
	}

	private static class SqlReasonDesc {
		public String tableName;
		public String type;
		public String logField;
		public String logDesc;
		public List<SqlReason> sqlReasons = new ArrayList<SqlReason>();

		private static class SqlReason {
			public String reason;
			public String desc;
		}
	}
}