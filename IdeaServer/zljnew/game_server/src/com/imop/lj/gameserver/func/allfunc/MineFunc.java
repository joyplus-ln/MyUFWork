package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class MineFunc extends AbstractFunc {

	public MineFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}

	@Override
	public boolean canOpen() {
		// 判断玩家是否有此功能
		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
	}

	@Override
	public boolean canShowEffect() {
		// TODO 自动生成的方法存根
		return false;
	}

	@Override
	public int getShowNum() {
		// TODO 自动生成的方法存根
		return 0;
	}

	@Override
	public long getCountDownTime() {
		// TODO 自动生成的方法存根
		return 0;
	}

}