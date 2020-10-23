package com.imop.lj.gameserver.exam.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;

/**
 *  Generated by MessageCodeGenerator,don't modify please.
 *  Need to register in<code>GameMessageRecognizer#init</code>
 */
public class ExamMsgMappingProvider implements MessageMappingProvider {

	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
		map.put(MessageType.CG_EXAM_APPLY, CGExamApply.class);
		map.put(MessageType.CG_EXAM_USE_ITEM, CGExamUseItem.class);
		map.put(MessageType.CG_EXAM_CHOSE, CGExamChose.class);
		return map;
	}

}
