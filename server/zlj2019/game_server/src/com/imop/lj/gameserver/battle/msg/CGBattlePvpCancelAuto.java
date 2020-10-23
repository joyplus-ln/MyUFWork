package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * PVP请求需要手动战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattlePvpCancelAuto extends CGMessage{
	
	
	public CGBattlePvpCancelAuto (){
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
		return MessageType.CG_BATTLE_PVP_CANCEL_AUTO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BATTLE_PVP_CANCEL_AUTO";
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handleBattlePvpCancelAuto(this.getSession().getPlayer(), this);
	}
}