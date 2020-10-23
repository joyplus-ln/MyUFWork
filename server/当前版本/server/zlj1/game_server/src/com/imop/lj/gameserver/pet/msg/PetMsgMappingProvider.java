package com.imop.lj.gameserver.pet.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;

/**
 *  Generated by MessageCodeGenerator,don't modify please.
 *  Need to register in<code>GameMessageRecognizer#init</code>
 */
public class PetMsgMappingProvider implements MessageMappingProvider {

	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
		map.put(MessageType.CG_PET_ADD_POINT, CGPetAddPoint.class);
		map.put(MessageType.CG_PET_CHANGE_FIGHT_STATE, CGPetChangeFightState.class);
		map.put(MessageType.CG_PET_CHANGE_NAME, CGPetChangeName.class);
		map.put(MessageType.CG_PET_FIRE, CGPetFire.class);
		map.put(MessageType.CG_PET_REFRESH_TALENT_SKILL, CGPetRefreshTalentSkill.class);
		map.put(MessageType.CG_PET_STUDY_NORMAL_SKILL, CGPetStudyNormalSkill.class);
		map.put(MessageType.CG_PET_REJUVEN, CGPetRejuven.class);
		map.put(MessageType.CG_PET_VARIATION, CGPetVariation.class);
		map.put(MessageType.CG_PET_ARTIFICE, CGPetArtifice.class);
		map.put(MessageType.CG_PET_TRAIN, CGPetTrain.class);
		map.put(MessageType.CG_PET_TRAIN_UPDATE, CGPetTrainUpdate.class);
		map.put(MessageType.CG_PET_PERCEPT_ADD_EXP, CGPetPerceptAddExp.class);
		map.put(MessageType.CG_PET_HORSE_RIDE, CGPetHorseRide.class);
		map.put(MessageType.CG_PET_HORSE_CHANGE_NAME, CGPetHorseChangeName.class);
		map.put(MessageType.CG_PET_HORSE_FIRE, CGPetHorseFire.class);
		map.put(MessageType.CG_PET_HORSE_REJUVEN, CGPetHorseRejuven.class);
		map.put(MessageType.CG_PET_HORSE_ARTIFICE, CGPetHorseArtifice.class);
		map.put(MessageType.CG_PET_HORSE_TRAIN, CGPetHorseTrain.class);
		map.put(MessageType.CG_PET_HORSE_TRAIN_UPDATE, CGPetHorseTrainUpdate.class);
		map.put(MessageType.CG_PET_HORSE_PERCEPT_ADD_EXP, CGPetHorsePerceptAddExp.class);
		map.put(MessageType.CG_PET_OPEN_FRIEND_PANEL, CGPetOpenFriendPanel.class);
		map.put(MessageType.CG_PET_FRIEND_INFO, CGPetFriendInfo.class);
		map.put(MessageType.CG_PET_FRIEND_CHANGE_ARRAY, CGPetFriendChangeArray.class);
		map.put(MessageType.CG_PET_FRIEND_PUTON_ARRAY, CGPetFriendPutonArray.class);
		map.put(MessageType.CG_PET_FRIEND_OFF_ARRAY, CGPetFriendOffArray.class);
		map.put(MessageType.CG_PET_FRIEND_CHANGE_POSITION, CGPetFriendChangePosition.class);
		map.put(MessageType.CG_PET_FRIEND_UNLOCK, CGPetFriendUnlock.class);
		map.put(MessageType.CG_PET_RESET_POINT, CGPetResetPoint.class);
		map.put(MessageType.CG_PET_LEADER_STUDY_SKILL, CGPetLeaderStudySkill.class);
		map.put(MessageType.CG_PET_SKILL_EFFECT_OPEN_POSITION, CGPetSkillEffectOpenPosition.class);
		map.put(MessageType.CG_PET_EMBED_SKILL_EFFECT, CGPetEmbedSkillEffect.class);
		map.put(MessageType.CG_PET_SKILL_EFFECT_UPLEVEL, CGPetSkillEffectUplevel.class);
		map.put(MessageType.CG_PET_UNEMBED_SKILL_EFFECT, CGPetUnembedSkillEffect.class);
		return map;
	}

}
