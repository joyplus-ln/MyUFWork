package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 每日累计充值
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityDayTotalChargeTargetTemplateVO extends GoodActivityTargetTemplate {

	/** 充值天数 */
	@ExcelCellBinding(offset = 12)
	protected int dayNum;

	/** 充值数量 */
	@ExcelCellBinding(offset = 13)
	protected int chargeNum;


	public int getDayNum() {
		return this.dayNum;
	}

	public void setDayNum(int dayNum) {
		if (dayNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[充值天数]dayNum不可以为0");
		}
		if (dayNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[充值天数]dayNum的值不得小于1");
		}
		this.dayNum = dayNum;
	}
	
	public int getChargeNum() {
		return this.chargeNum;
	}

	public void setChargeNum(int chargeNum) {
		if (chargeNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[充值数量]chargeNum不可以为0");
		}
		if (chargeNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[充值数量]chargeNum的值不得小于1");
		}
		this.chargeNum = chargeNum;
	}
	

	@Override
	public String toString() {
		return "GoodActivityDayTotalChargeTargetTemplateVO[dayNum=" + dayNum + ",chargeNum=" + chargeNum + ",]";

	}
}