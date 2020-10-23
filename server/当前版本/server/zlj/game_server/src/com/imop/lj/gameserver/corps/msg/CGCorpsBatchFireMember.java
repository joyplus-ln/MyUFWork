package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 批量踢出成员
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsBatchFireMember extends CGMessage{
	
	/** 成员IDLIST */
	private long[] targetIds;
	
	public CGCorpsBatchFireMember (){
	}
	
	public CGCorpsBatchFireMember (
			long[] targetIds ){
			this.targetIds = targetIds;
	}
	
	@Override
	protected boolean readImpl() {

	// 成员IDLIST
	int targetIdsSize = readUnsignedShort();
	long[] _targetIds = new long[targetIdsSize];
	int targetIdsIndex = 0;
	for(targetIdsIndex=0; targetIdsIndex<targetIdsSize; targetIdsIndex++){
		_targetIds[targetIdsIndex] = readLong();
	}//end



			this.targetIds = _targetIds;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 成员IDLIST
	writeShort(targetIds.length);
	int targetIdsSize = targetIds.length;
	int targetIdsIndex = 0;
	for(targetIdsIndex=0; targetIdsIndex<targetIdsSize; targetIdsIndex++){
		writeLong(targetIds [ targetIdsIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CORPS_BATCH_FIRE_MEMBER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPS_BATCH_FIRE_MEMBER";
	}

	public long[] getTargetIds(){
		return targetIds;
	}

	public void setTargetIds(long[] targetIds){
		this.targetIds = targetIds;
	}	


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCorpsBatchFireMember(this.getSession().getPlayer(), this);
	}
}