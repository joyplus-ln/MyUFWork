package com.imop.lj.gameserver.treasuremap.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.treasuremap.handler.TreasuremapHandlerFactory;

/**
 * 完成任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishTreasuremap extends CGMessage{
	
	
	public CGFinishTreasuremap (){
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
		return MessageType.CG_FINISH_TREASUREMAP;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FINISH_TREASUREMAP";
	}


	@Override
	public void execute() {
		TreasuremapHandlerFactory.getHandler().handleFinishTreasuremap(this.getSession().getPlayer(), this);
	}
}