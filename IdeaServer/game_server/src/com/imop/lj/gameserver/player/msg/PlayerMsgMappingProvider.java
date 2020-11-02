package com.imop.lj.gameserver.player.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;

/**
 *  Generated by MessageCodeGenerator,don't modify please.
 *  Need to register in<code>GameMessageRecognizer#init</code>
 */
public class PlayerMsgMappingProvider implements MessageMappingProvider {

	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
		map.put(MessageType.CG_PLAYER_LOGIN, CGPlayerLogin.class);
		map.put(MessageType.CG_PLAYER_COOKIE_LOGIN, CGPlayerCookieLogin.class);
		map.put(MessageType.CG_ROLE_TEMPLATE, CGRoleTemplate.class);
		map.put(MessageType.CG_ROLE_RANDOM_NAME, CGRoleRandomName.class);
		map.put(MessageType.CG_CREATE_ROLE, CGCreateRole.class);
		map.put(MessageType.CG_PLAYER_ENTER, CGPlayerEnter.class);
		map.put(MessageType.CG_ENTER_SCENE, CGEnterScene.class);
		map.put(MessageType.CG_PLAYER_CHARGE_DIAMOND, CGPlayerChargeDiamond.class);
		map.put(MessageType.CG_PLAYER_QUERY_ACCOUNT, CGPlayerQueryAccount.class);
		map.put(MessageType.CG_REPORT_PLAYER, CGReportPlayer.class);
		map.put(MessageType.CG_ACCOUNT_ACTIVATIONCODE, CGAccountActivationcode.class);
		map.put(MessageType.CG_IOS_ANDROID_CHARGE, CGIosAndroidCharge.class);
		map.put(MessageType.CG_GET_SMS_CHECKCODE, CGGetSmsCheckcode.class);
		map.put(MessageType.CG_CHECK_SMS_CHECKCODE, CGCheckSmsCheckcode.class);
		map.put(MessageType.CG_SMS_CHECKCODE_PANEL, CGSmsCheckcodePanel.class);
		map.put(MessageType.CG_GET_SMS_CHECKCODE_REWARD, CGGetSmsCheckcodeReward.class);
		map.put(MessageType.CG_PLAYER_TOKEN_LOGIN, CGPlayerTokenLogin.class);
		map.put(MessageType.CG_CHARGE_GEN_ORDERID, CGChargeGenOrderid.class);
		map.put(MessageType.CG_IOSCHARGE_CHECK, CGIoschargeCheck.class);
		return map;
	}

}