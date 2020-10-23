package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求离开帮派竞赛
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLeaveCorpswar extends CGMessage{
	
	
	public CGLeaveCorpswar (){
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
		return MessageType.CG_LEAVE_CORPSWAR;
	}
	
	@Override
	public String getTypeName() {
		return "CG_LEAVE_CORPSWAR";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleLeaveCorpswar(this.getSession().getPlayer(), this);
	}
}