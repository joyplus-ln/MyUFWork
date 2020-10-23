package com.imop.lj.gameserver.map.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;

/**
 *  Generated by MessageCodeGenerator,don't modify please.
 *  Need to register in<code>GameMessageRecognizer#init</code>
 */
public class MapMsgMappingProvider implements MessageMappingProvider {

	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
		map.put(MessageType.CG_MAP_PLAYER_ENTER, CGMapPlayerEnter.class);
		map.put(MessageType.CG_MAP_PLAYER_MOVE, CGMapPlayerMove.class);
		map.put(MessageType.CG_MAP_FIGHT_NPC, CGMapFightNpc.class);
		return map;
	}

}
