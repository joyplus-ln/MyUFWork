package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 炼化
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseArtifice extends CGMessage{
	
	/** 骑宠唯一Id */
	private long petId;
	
	public CGPetHorseArtifice (){
	}
	
	public CGPetHorseArtifice (
			long petId ){
			this.petId = petId;
	}
	
	@Override
	protected boolean readImpl() {

	// 骑宠唯一Id
	long _petId = readLong();
	//end



			this.petId = _petId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 骑宠唯一Id
	writeLong(petId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_HORSE_ARTIFICE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_HORSE_ARTIFICE";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetHorseArtifice(this.getSession().getPlayer(), this);
	}
}