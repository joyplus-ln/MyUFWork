package com.imop.lj.gameserver.scene;

import com.imop.lj.gameserver.common.listener.Listenable;
import com.imop.lj.gameserver.human.Human;

/**
 * 场景事件监听适配器
 *
 * @author haijiang.jin
 *
 */
public class SceneListenerAdapter implements SceneListener {
	@Override
	public void afterHumanEnter(Scene scene, Human human) {
	}

	@Override
	public void beforeHumanLeave(Scene scene, Human human) {
	}

	@Override
	public void leaveOnLogoutSaving(Scene scene, Human human) {
	}

	@Override
	public void onDeleted(Listenable<?> listening) {
	}

	@Override
	public void onRegisted(Listenable<?> listening) {
	}

	@Override
	public int priority() {
		return 0;
	}
}
