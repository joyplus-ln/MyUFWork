package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 洗炼装备结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpRefinery extends GCMessage{
	
	/** 1成功2失败 */
	private int result;

	public GCEqpRefinery (){
	}
	
	public GCEqpRefinery (
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
		return MessageType.GC_EQP_REFINERY;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_REFINERY";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}