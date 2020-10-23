package com.imop.lj.gameserver.ringtask.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;

/**
 *  Generated by MessageCodeGenerator,don't modify please.
 *  Need to register in<code>GameMessageRecognizer#init</code>
 */
public class RingtaskMsgMappingProvider implements MessageMappingProvider {

	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
		map.put(MessageType.CG_RINGTASK_ACCEPT, CGRingtaskAccept.class);
		map.put(MessageType.CG_GIVE_UP_RINGTASK, CGGiveUpRingtask.class);
		map.put(MessageType.CG_FINISH_RINGTASK, CGFinishRingtask.class);
		return map;
	}

}
