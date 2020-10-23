package com.imop.lj.gameserver.exam.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 使用物品结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCExamUseItem extends GCMessage{
	
	/** 申请的科举类型 */
	private int examType;
	/** 物品使用结果 1成功,2失败 */
	private int result;

	public GCExamUseItem (){
	}
	
	public GCExamUseItem (
			int examType,
			int result ){
			this.examType = examType;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 申请的科举类型
	int _examType = readInteger();
	//end


	// 物品使用结果 1成功,2失败
	int _result = readInteger();
	//end



		this.examType = _examType;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 申请的科举类型
	writeInteger(examType);


	// 物品使用结果 1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EXAM_USE_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EXAM_USE_ITEM";
	}

	public int getExamType(){
		return examType;
	}
		
	public void setExamType(int examType){
		this.examType = examType;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}