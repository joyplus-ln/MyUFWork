package com.imop.lj.gameserver.scene.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;

/**
 *  Generated by MessageCodeGenerator,don't modify please.
 *  Need to register in<code>GameMessageRecognizer#init</code>
 */
public class SceneMsgMappingProvider implements MessageMappingProvider {

	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
		map.put(MessageType.CG_SCENE_PLAYER_ENTER, CGScenePlayerEnter.class);
		map.put(MessageType.CG_SCENE_PLAYER_MOVE, CGScenePlayerMove.class);
		return map;
	}

}
