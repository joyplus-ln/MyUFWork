package com.imop.lj.gameserver.mall.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;

/**
 *  Generated by MessageCodeGenerator,don't modify please.
 *  Need to register in<code>GameMessageRecognizer#init</code>
 */
public class MallMsgMappingProvider implements MessageMappingProvider {

	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
		map.put(MessageType.CG_ITEM_LIST_BY_CATALOGID, CGItemListByCatalogid.class);
		map.put(MessageType.CG_TIME_LIMIT_ITEM_LIST, CGTimeLimitItemList.class);
		map.put(MessageType.CG_BUY_NORMAL_ITEM, CGBuyNormalItem.class);
		map.put(MessageType.CG_BUY_TIME_LIMIT_ITEM, CGBuyTimeLimitItem.class);
		return map;
	}

}
