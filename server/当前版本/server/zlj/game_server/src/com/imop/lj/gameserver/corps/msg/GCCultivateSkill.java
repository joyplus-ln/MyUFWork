package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回请求修炼技能结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCultivateSkill extends GCMessage{
	
	/** 升级结果,1成功,2失败 */
	private int result;

	public GCCultivateSkill (){
	}
	
	public GCCultivateSkill (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 升级结果,1成功,2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 升级结果,1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CULTIVATE_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CULTIVATE_SKILL";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}