package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 宠物普通技能主效果
 * 
 */
public class PetNormalMain extends AttackCoef {

	public PetNormalMain(int effectId) {
		super(effectId);
	}

	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=(X%攻击力+增量*技能等级) * (1 + 骑宠加成)
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());

		double baseAttack = 0d;
		boolean isDefault = this.getEffectTpl().isDefaultAttack();
		boolean isStrength = this.getEffectTpl().isPhsicalAttack();
		boolean isMagic = this.getEffectTpl().isMagicAttack();
		if(isDefault){
			//默认-取面板攻击
			baseAttack = BattleCalculateHelper.getBaseAttack(attacker);
		}else if(isStrength){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.STRENGTH );
		}else if(isMagic){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.INTELLECT );
		}
		
		double skillCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		//镶嵌的仙符效果取效果等级
		int skillLevel = isEmbedEffect() ? getEffectLevel() : getSkillLevel();
		
		//骑宠加成
		boolean isPetHorseAdd = attacker.getPetHorseAddMap().containsValue(this.skillId);
		double part3 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								attacker.getPetHorseSkillLevel(), attacker.getPetHorseAddTpl(attacker, this.skillId))
						) * attacker.getPetHorseSkillLevel()
				: 0;
		
		int finalAtk = (int)( ( baseCoef * baseAttack + skillCoef * skillLevel ) * (1 + part3));
		return finalAtk;
	}
	
}