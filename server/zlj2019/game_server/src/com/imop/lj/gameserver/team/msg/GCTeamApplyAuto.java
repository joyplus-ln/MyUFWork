package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 自动申请加入队伍
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamApplyAuto extends GCMessage{
	
	/** 是否自动申请，0否1是 */
	private int isAuto;
	/** 目标Id */
	private int targetId;

	public GCTeamApplyAuto (){
	}
	
	public GCTeamApplyAuto (
			int isAuto,
			int targetId ){
			this.isAuto = isAuto;
			this.targetId = targetId;
	}

	@Override
	protected boolean readImpl() {

	// 是否自动申请，0否1是
	int _isAuto = readInteger();
	//end


	// 目标Id
	int _targetId = readInteger();
	//end



		this.isAuto = _isAuto;
		this.targetId = _targetId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否自动申请，0否1是
	writeInteger(isAuto);


	// 目标Id
	writeInteger(targetId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TEAM_APPLY_AUTO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TEAM_APPLY_AUTO";
	}

	public int getIsAuto(){
		return isAuto;
	}
		
	public void setIsAuto(int isAuto){
		this.isAuto = isAuto;
	}

	public int getTargetId(){
		return targetId;
	}
		
	public void setTargetId(int targetId){
		this.targetId = targetId;
	}
}