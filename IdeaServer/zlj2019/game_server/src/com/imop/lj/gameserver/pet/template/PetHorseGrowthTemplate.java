package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.pet.PetDef.PetQuality;


/**
 * 骑宠成长率
 */
@ExcelRowBinding
public class PetHorseGrowthTemplate extends PetHorseGrowthTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if (PetQuality.valueOf(id) == null) {
			throw new TemplateConfigException(sheetName, id, "成长品质Id非法！");
		}
	}

}