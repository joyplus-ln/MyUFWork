package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.nvn.handler.NvnHandlerFactory;

/**
 * 请求nvn面板信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGNvnOpenPanel extends CGMessage{
	
	
	public CGNvnOpenPanel (){
	}
	
	
	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_NVN_OPEN_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_NVN_OPEN_PANEL";
	}


	@Override
	public void execute() {
		NvnHandlerFactory.getHandler().handleNvnOpenPanel(this.getSession().getPlayer(), this);
	}
}