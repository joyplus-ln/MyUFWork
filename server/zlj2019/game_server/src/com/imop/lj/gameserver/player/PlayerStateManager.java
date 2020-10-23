package com.imop.lj.gameserver.player;

import java.util.concurrent.TimeUnit;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.common.HeartBeatListener;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.core.util.Assert;

/**
 * 玩家状态管理器，管理玩家登陆、退出、切换场景等大的状态
 *
 */
public class PlayerStateManager implements HeartBeatListener {
	/** 无超时时间 */
	public static final int STATE_NO_OVERTIME = 0;

	/** 所属玩家 */
	private Player player;
	/** 当前状态 */
	private volatile PlayerState state;
	/** 状态到期时间 */
	private long deadLine;
	/** 到期后返回的状态 */
	private PlayerState newState;
	/** */
	private PlayerStateExitCallback exitCallback;

	public PlayerStateManager(Player player) {
		this.player = player;
		this.state = PlayerState.init;
		this.deadLine = Long.MAX_VALUE;
		this.newState = null;
	}

	/**
	 * 判断当前状态下是否能处理指定类型的客户端发过来的消息
	 *
	 * @param messageType
	 * @return
	 */
	//FIXME 
	public boolean canProcess(IMessage msg) {
		if (!(msg instanceof CGMessage)) {
			return true;
		}
		short messageType = msg.getType();
		switch (player.getState()) {
			case init:
			case connected:
				if(messageType == MessageType.CG_PLAYER_LOGIN
						||messageType == MessageType.CG_PLAYER_COOKIE_LOGIN
						||messageType == MessageType.CG_PLAYER_TOKEN_LOGIN
//						||messageType == MessageType.CG_TEST
//						||messageType == MessageType.CG_TEST_LONG
//						||messageType == MessageType.CG_TEST_MODEL
//						||messageType == MessageType.CG_TEST_MODEL_LIST
//						||messageType == MessageType.CG_TEST_MUTI_LIST
						)
				{
					return true;
				}
				break;
			case waitingselectrole:
				if(messageType == MessageType.CG_ROLE_TEMPLATE
						||messageType == MessageType.CG_ROLE_RANDOM_NAME
						||messageType == MessageType.CG_CREATE_ROLE
						||messageType == MessageType.CG_PLAYER_ENTER
						||messageType == MessageType.CG_ACCOUNT_ACTIVATIONCODE
						)
				{
					return true;
				}
			case auth:
			case loadingrolelist:
			case loading:
			case logouting:
			case logouted:
				// 这几个状态下不处理任何客户端消息
				break;
			case incoming:
				if (messageType == MessageType.CG_ENTER_SCENE) {
					return true;
				}
				break;
			case entering:
			case gaming:
				if (messageType != MessageType.CG_ENTER_SCENE) {
					return true;
				}
				break;
			default:
				break;
		}
		return false;
	}

	/**
	 * 判断是否需要向当前状态下的玩家发送指定类型的消息
	 *
	 * @param messageType
	 * @return
	 */
	public boolean needSend(short messageType) {
		switch (this.getState()) {
			case logouting:
				return false;
			default:
				break;
		}
		return true;
	}

	public boolean setState(PlayerState state) {
		return this.enterState(state, PlayerStateManager.STATE_NO_OVERTIME,
				state, PlayerStateContext.EMPTY_CONTEXT);
	}

	public PlayerState getState() {
		return state;
	}

	/**
	 * 进入指定状态
	 *
	 * @param targetState
	 *            期望进入的状态
	 * @param overTime
	 *            超时时间（秒）
	 * @param overTimeState
	 *            超时后返回的状态，若设置了超时时间，这里必须不为null
	 * @param stateContext
	 *            设置状态的上下文
	 * @return 如果成功设置了状态返回真
	 */
	public boolean enterState(PlayerState targetState, int overTime,
			PlayerState overTimeState, PlayerStateContext stateContext) {
		if (!this.state.canEnter(targetState)) {
			Loggers.stateLogger.warn(String.format(
					"Can't change state from [%s] to [%s]!", this.state,
					targetState));
			return false;
		}
		if (overTime > 0) {
			Assert.notNull(overTimeState);
			deadLine = Globals.getTimeService().now()
					+ TimeUnit.SECONDS.toMillis(overTime);
			this.newState = overTimeState;
		} else {
			deadLine = Long.MAX_VALUE;
			newState = null;
		}
		this.state = targetState;
		return true;
	}

	@Override
	public void onHeartBeat() {
		if (deadLine != Long.MAX_VALUE && newState != null) {
			if (Globals.getTimeService().timeUp(deadLine)) {
				this.setState(this.newState);
				if (exitCallback != null) {
					exitCallback.onExitCurState();
					exitCallback = null;
				}
			}
		}
	}
}
