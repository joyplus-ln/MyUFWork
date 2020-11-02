package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.TimeEventTemplate;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.util.StringUtils;


@ExcelRowBinding
public class SysPowerGiveTimeTemplate extends SysPowerGiveTimeTemplateVO {
	
	private int[] timeEventIds;	

	@Override
	public void setGivePowerTimeIds(String givePowerTimeIds) {
		super.setGivePowerTimeIds(givePowerTimeIds);
		timeEventIds = StringUtils.getIntArray(givePowerTimeIds, ";");
	}

	@Override
	public void check() throws TemplateConfigException {
//		if(this.getId() != 1)
//		{
//			throw new TemplateConfigException(this.getSheetName(), getId(), "单行配置id必须为1");
//		}	
		for(int timeEventId :timeEventIds )
		{
			if (!templateService.isTemplateExist(timeEventId,
					TimeEventTemplate.class)) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(),
						"timeEventId=" + timeEventId + "不存在于timeEvent模板中");
			}	
		}
	}

	public int[] getTimeEventIds() {
		return timeEventIds;
	}
	

}