package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 获取当前用户的拜师信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOvermanInfo extends CGMessage{
	
	
	public CGOvermanInfo (){
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
		return MessageType.CG_OVERMAN_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OVERMAN_INFO";
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleOvermanInfo(this.getSession().getPlayer(), this);
	}
}