package com.imop.lj.gameserver.corps.function.member;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.human.Human;

public class SetMemberJobNormal extends AbstractCorpsMemberFunction {

	@Override
	public CorpsMemberTypeEnum getType() {
		return CorpsMemberTypeEnum.SET_MEMBER_JOB_NORMAL;
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().setMemberJob(human, target, MemberJob.MEMBER);
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.SET_MEMBER_TYPE_NORMAL;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.SET_MEMBER_TYPE_NORMAL;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return isAvailable(human, target) == null;
	}


	@Override
	public String isAvailable(Human human, Long target) {
		if(Globals.getCorpsService().canUseSetMemberJob(human, target, MemberJob.MEMBER)){
			return null;
		}else{
			return "is no available";
		}
	}
}