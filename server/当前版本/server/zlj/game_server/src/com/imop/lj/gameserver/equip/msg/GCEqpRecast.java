package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 重铸装备结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpRecast extends GCMessage{
	
	/** 1成功2失败 */
	private int result;

	public GCEqpRecast (){
	}
	
	public GCEqpRecast (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 1成功2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1成功2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EQP_RECAST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_RECAST";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}