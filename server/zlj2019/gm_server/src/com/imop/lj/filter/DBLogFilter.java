package com.imop.lj.filter;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.sys.SysUserService;

/**
 *
 * 更换到日志数据 Filter
 *
 */
public class DBLogFilter implements Filter {


	private SysUserService sysUserService;

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	@Override
	public void destroy() {
		// TODO Auto-generated method stub
	}


	@Override
	public void doFilter(ServletRequest arg0, ServletResponse arg1,
			FilterChain arg2) throws IOException, ServletException {

		HttpServletRequest request = (HttpServletRequest) arg0;
		HttpServletResponse response = (HttpServletResponse) arg1;
		LoginUser obj = (LoginUser) request.getSession().getAttribute(
				"loginUser");
		if (obj == null) {
			String path = request.getContextPath()+ "/";;
			PrintWriter pw = response.getWriter();
			pw.print("<script>this.parent.location.href='" + path
					+ "index.jsp';</script>");
			request.getSession().invalidate();
			return;
		} else {
			try {
				obj.setLoginRegionId(obj.getLoginRegionId());
				if(obj.getLoginServerId().indexOf("log_")==-1){
					obj.setLoginServerId("log_"+obj.getLoginServerId());
				}else{
					obj.setLoginServerId(obj.getLoginServerId());
				}

				LoginUserService.pushUser(obj);
				arg2.doFilter(arg0, arg1);
			} finally {
				LoginUserService.popUser();
				if(obj.getLoginServerId().indexOf("log_")!=-1){
					obj.setLoginServerId(obj.getLoginServerId().replace("log_", ""));
				}else{
					obj.setLoginServerId(obj.getLoginServerId());
				}
				obj.setLoginRegionId(obj.getLoginRegionId());
			}
		}

	}



	@Override
	public void init(FilterConfig arg0) throws ServletException {
		// TODO Auto-generated method stub

	}

}
