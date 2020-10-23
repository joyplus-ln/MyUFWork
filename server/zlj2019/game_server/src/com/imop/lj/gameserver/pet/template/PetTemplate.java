package com.imop.lj.gameserver.pet.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.enemy.template.SkillItem;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.pet.PetDef.GeneType;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;
import com.imop.lj.gameserver.pet.PetDef.PetGrowthColor;
import com.imop.lj.gameserver.pet.PetDef.PetPetKind;
import com.imop.lj.gameserver.pet.PetDef.PetPetType;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.PetDef.Sex;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 武将模板
 * 
 */
@ExcelRowBinding
public class PetTemplate extends PetTemplateVO {
	
	private List<SkillItem> validSkillList = new ArrayList<SkillItem>();
	
	@Override
	public void check() throws TemplateConfigException {
		if (PetType.valueOf(typeId) == null) {
			throw new TemplateConfigException(sheetName, id, "typeId not exist! " + typeId);
		}
		if (PetPetType.valueOf(petpetTypeId) == null) {
			throw new TemplateConfigException(sheetName, id, "宠物类型不存在! " + petpetTypeId);
		}
		if (PetPetKind.valueOf(petpetKindId) == null) {
			throw new TemplateConfigException(sheetName, id, "宠物类别不存在! " + petpetKindId);
		}
		if (catchItemId > 0) {
			if (null == templateService.get(catchItemId, ItemTemplate.class)) {
				throw new TemplateConfigException(sheetName, id, "捕捉道具ID不存在! " + catchItemId);
			}
			if (catchItemNum <= 0) {
				throw new TemplateConfigException(sheetName, id, "捕捉道具数量非法! " + catchItemNum);
			}
		}
		for (SkillItem esi : this.skillList) {
			int skillId = esi.getSkillId(); 
			if (skillId > 0) {
				if (templateService.get(skillId, SkillTemplate.class) == null) {
					throw new TemplateConfigException(sheetName, id, "skillId not exist! " + skillId);
				}
				//技能
				validSkillList.add(esi);
			}
		}
		
		if (getPetType() == PetType.LEADER) {
			if (getJobType() == null) {
				throw new TemplateConfigException(sheetName, id, "主将职业类型非法! " + this.getJobId());
			}
			if (getSex() == null) {
				throw new TemplateConfigException(sheetName, id, "主将性别类型非法! " + this.getSexId());
			}
		}
		
		//体验期的宠物或骑宠
		if(this.leasehold > 0){
			if(GeneType.valueOf(this.initGene) == null){
				throw new TemplateConfigException(sheetName, id, "是否初始化变异非法! " + this.initGene);
			}
			if(PetGrowthColor.valueOf(this.initGrowth) == null){
				throw new TemplateConfigException(sheetName, id, "初始成长率非法! " + this.initGrowth);
			}
			
			if(Currency.valueOf(this.leaseCurrencyType) == null){
				throw new TemplateConfigException(sheetName, id, "租借货币类型 非法! " + this.leaseCurrencyType);
			}
			
			if(templateService.get(this.leaseItemId, ItemTemplate.class) == null){
				throw new TemplateConfigException(sheetName, id, "续租道具Id非法! " + this.leaseItemId);
			}
		}
		
	}
	
	public PetType getPetType() {
		return PetType.valueOf(typeId);
	}
	
	public PetAttackType getPetAttackType() {
		return PetAttackType.valueOf(this.getAttackTypeId());
	}
	
	public JobType getJobType() {
		return JobType.valueOf(this.getJobId());
	}
	
	public Sex getSex() {
		return Sex.valueOf(this.getSexId());
	}
	
	/**
	 * 获取技能信息列表
	 * @return
	 */
	public List<SkillItem> getValidSkillList() {
		return validSkillList;
	}
	
	public PetPetType getPetPetType() {
		return PetPetType.valueOf(petpetTypeId);
	}
	
	public boolean isGoodPet() {
		PetPetType t = getPetPetType();
		return t == PetPetType.GOOD || t == PetPetType.BEST;
	}
	
	public boolean isBestPet() {
		PetPetType t = getPetPetType();
		return t == PetPetType.BEST;
	}
	
	/**
	 * 是否是体验骑宠
	 * @return
	 */
	public boolean isExper(){
		if(this.leasehold > 0){
			return true;
		}
		return false;
	}
}