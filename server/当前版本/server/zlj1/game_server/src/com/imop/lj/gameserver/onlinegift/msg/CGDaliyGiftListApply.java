package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.onlinegift.handler.OnlinegiftHandlerFactory;

/**
 * 申请每日签到奖励信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDaliyGiftListApply extends CGMessage{
	
	
	public CGDaliyGiftListApply (){
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
		return MessageType.CG_DALIY_GIFT_LIST_APPLY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_DALIY_GIFT_LIST_APPLY";
	}


	@Override
	public void execute() {
		OnlinegiftHandlerFactory.getHandler().handleDaliyGiftListApply(this.getSession().getPlayer(), this);
	}
}