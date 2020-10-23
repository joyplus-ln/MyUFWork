package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 宠物出战or休息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetChangeFightState extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 出战状态，0休息，1出战 */
	private int state;
	
	public CGPetChangeFightState (){
	}
	
	public CGPetChangeFightState (
			long petId,
			int state ){
			this.petId = petId;
			this.state = state;
	}
	
	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 出战状态，0休息，1出战
	int _state = readInteger();
	//end



			this.petId = _petId;
			this.state = _state;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 出战状态，0休息，1出战
	writeInteger(state);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_CHANGE_FIGHT_STATE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_CHANGE_FIGHT_STATE";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getState(){
		return state;
	}
		
	public void setState(int state){
		this.state = state;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetChangeFightState(this.getSession().getPlayer(), this);
	}
}