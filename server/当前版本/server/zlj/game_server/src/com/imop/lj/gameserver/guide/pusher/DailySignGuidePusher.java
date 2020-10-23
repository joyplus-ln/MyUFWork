package com.imop.lj.gameserver.guide.pusher;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.guide.AbstractGuidePusher;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.human.Human;

public class DailySignGuidePusher extends AbstractGuidePusher {
	
	public DailySignGuidePusher() {
		super(GuideType.DAILY_SIGN);
	}

	@Override
	public boolean checkCond(Human human) {
		if (isFinishedGuide(human)) {
			return false;
		}
		
		// 当前是否开启了对应的功能按钮
		return Globals.getFuncService().hasOpenedFunc(human, getGuideType().getFuncType());
	}

}
