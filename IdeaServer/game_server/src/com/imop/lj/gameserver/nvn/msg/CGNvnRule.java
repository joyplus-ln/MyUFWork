package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.nvn.handler.NvnHandlerFactory;

/**
 * nvn联赛规则
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGNvnRule extends CGMessage{
	
	
	public CGNvnRule (){
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
		return MessageType.CG_NVN_RULE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_NVN_RULE";
	}


	@Override
	public void execute() {
		NvnHandlerFactory.getHandler().handleNvnRule(this.getSession().getPlayer(), this);
	}
}