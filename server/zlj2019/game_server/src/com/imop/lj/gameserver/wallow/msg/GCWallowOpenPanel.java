package com.imop.lj.gameserver.wallow.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 打开防沉迷填写面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWallowOpenPanel extends GCMessage{
	

	public GCWallowOpenPanel (){
	}
	

	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_WALLOW_OPEN_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_WALLOW_OPEN_PANEL";
	}
}