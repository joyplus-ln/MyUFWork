package com.imop.lj.logserver;

import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.mina.core.service.IoHandlerAdapter;
import org.apache.mina.core.session.IoSession;
import org.slf4j.Logger;

import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.logserver.common.Globals;
import com.imop.lj.logserver.dao.LogDao;

/**
 * 简单的日志消息处理器
 *
  *
 *
 */
public class SampleMessageHandler extends IoHandlerAdapter {
	private static Logger logger = org.slf4j.LoggerFactory.getLogger(SampleMessageHandler.class);

	@Override
	public void exceptionCaught(IoSession session, Throwable cause) throws Exception {
		if (logger.isErrorEnabled()) {
			logger.error(ErrorsUtil.error("LOGSERVER_EXCEPTION", "#GS.SampleMessageHandler.exceptionCaught", cause
					.toString()), cause);
		}
	}

	@Override
	public void messageReceived(IoSession session, Object obj) throws Exception {
		if (obj instanceof BaseLogMessage) {
			BaseLogMessage msg = (BaseLogMessage) obj;
			handleRecord(msg);
		}
	}

	/**
	 * 记录日志
	 *
	 * @param msg
	 */
	private void handleRecord(BaseLogMessage msg) {
		String _logName = LogDao.getLogNameByBeanClass(msg.getClass());
		if (_logName == null) {
			throw new IllegalStateException("Can't find the log name for class [" + msg.getClass() + "]");
		}

		SimpleDateFormat format = new SimpleDateFormat("yyyy_MM_dd");
		String timeStamp = format.format(new Date());
		msg.setTableName(_logName + "_" + timeStamp);
		msg.setCreateTime(System.currentTimeMillis());
		// 放入消息队列
		Globals.getMsgQueue().put(msg);
	}

}
