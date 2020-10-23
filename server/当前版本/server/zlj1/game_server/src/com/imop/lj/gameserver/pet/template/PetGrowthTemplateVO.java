package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宠物成长率
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetGrowthTemplateVO extends TemplateObject {

	/** 普通宠权重 */
	@ExcelCellBinding(offset = 1)
	protected int normalWeight;

	/** 变异宠权重 */
	@ExcelCellBinding(offset = 2)
	protected int transformWeight;

	/** 成长率加成 */
	@ExcelCellBinding(offset = 3)
	protected int add;

	/** 成长率名称多语言Id */
	@ExcelCellBinding(offset = 4)
	protected long nameLangId;

	/** 成长率名称 */
	@ExcelCellBinding(offset = 5)
	protected String name;

	/** 宠物评分 */
	@ExcelCellBinding(offset = 6)
	protected int petScore;


	public int getNormalWeight() {
		return this.normalWeight;
	}

	public void setNormalWeight(int normalWeight) {
		if (normalWeight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[普通宠权重]normalWeight的值不得小于0");
		}
		this.normalWeight = normalWeight;
	}
	
	public int getTransformWeight() {
		return this.transformWeight;
	}

	public void setTransformWeight(int transformWeight) {
		if (transformWeight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[变异宠权重]transformWeight的值不得小于0");
		}
		this.transformWeight = transformWeight;
	}
	
	public int getAdd() {
		return this.add;
	}

	public void setAdd(int add) {
		if (add < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[成长率加成]add的值不得小于0");
		}
		this.add = add;
	}
	
	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getPetScore() {
		return this.petScore;
	}

	public void setPetScore(int petScore) {
		if (petScore < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[宠物评分]petScore的值不得小于0");
		}
		this.petScore = petScore;
	}
	

	@Override
	public String toString() {
		return "PetGrowthTemplateVO[normalWeight=" + normalWeight + ",transformWeight=" + transformWeight + ",add=" + add + ",nameLangId=" + nameLangId + ",name=" + name + ",petScore=" + petScore + ",]";

	}
}