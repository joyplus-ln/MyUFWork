package com.imop.lj.gameserver.goodactivity.userdatamodel.impl;

import com.imop.lj.gameserver.common.event.PlayerChargeDiamondEvent;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.TotalChargeBuyUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 一元购类型充值活动玩家数据对象类
 * @author yu.zhao
 *
 */
public class TotalChargeBuyUserDataModel extends AbstractGoodActivityUserDataModel {

	public static EventType BIND_EVENT_TYPE = EventType.PlayerChargeDiamondEvent;
	
	/** 累计充值数 */
	protected int totalCharge;
	
	public TotalChargeBuyUserDataModel(TotalChargeBuyUserGoodActivity userActivity) {
		super(userActivity);
	}
	
	@Override
	public EventType getBindEventType() {
		return BIND_EVENT_TYPE;
	}
	
	@Override
	public boolean onPlayerDoEvent(Event<?> e) {
		boolean updateFlag = false;
		if (!isCareEvent(e)) {
			return updateFlag;
		}
		
		PlayerChargeDiamondEvent event = (PlayerChargeDiamondEvent) e;
		int chargeNum = event.getChargeDiamond();
		if (chargeNum <= 0) {
			return updateFlag;
		}
		
		updateFlag = onCharge(chargeNum);
		return updateFlag;
	}
	
	/**
	 * 充值时更新数据
	 * @param chargeNum
	 * @return
	 */
	protected boolean onCharge(int chargeNum) {
		// 累计充值数
		totalCharge += chargeNum;
		// 存库
		save();
		// 充了就得计数，并创建玩家数据，所以直接返回true
		return true;
	}
	
	@Override
	public int getCurNum(int targetId) {
		return totalCharge;
	}
	
	@Override
	public String paramToJsonStr() {
		// 需要记录充值数
		return totalCharge + "";
	}
	
	@Override
	public void paramFromJson(String jsonStr) {
		if (null == jsonStr || jsonStr.equalsIgnoreCase("")) {
			return;
		}
		totalCharge = Integer.parseInt(jsonStr);
	}
	
	@Override
	public boolean needHideOnNothingToDo() {
		return true;
	}
}
