package com.imop.lj.gameserver.sealdemon.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.map.template.MapTemplate;

@ExcelRowBinding
public class SealDemonMapTemplate extends SealDemonMapTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		//地图是否存在
		MapTemplate map = templateService.get(this.getMapId(), MapTemplate.class);
		if (map == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "地图不存在！mapID="+this.getMapId());
		}
	}

}
