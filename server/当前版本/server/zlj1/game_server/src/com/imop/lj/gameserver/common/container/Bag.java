package com.imop.lj.gameserver.common.container;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.role.Role;

/**
 *
 * 有容量上限的容器，容器中每一个元素占据一个index，每一个容器有一个id，并且属于一个Role
 *
 *
 * @param <T>
 *            容器盛装的物品类型
 * @param <O>
 *            容器所有者类型
 */
public interface Bag<T extends Containable, O extends Role> {

	/**
	 * @return 容器类型
	 */
	BagType getBagType();

	/**
	 * @return 容器的容量上限
	 */
	int getCapacity();

	/**
	 * 所有者
	 *
	 * @return
	 */
	O getOwner();

	/**
	 * 通过索引获得其中的对象
	 *
	 * @param index
	 *            索引,范围[0, getCapacity()-1]
	 * @return 如果此索引位置没有被占用，返回count为0的T的对象
	 */
	T getByIndex(int index);

	/**
	 * 触发加载后的事件
	 */
	void onLoad();

	/**
	 * 触发改便后的事件
	 */
	void onChanged();

	/**
	 * 包的类型，背包id尽量连续取值，而且不应该超出Short.MAX_VALUE，因为消息中的bagId都是short型的<br/>
	 * 对包裹类型的引用尽量使用此枚举而不是使用bagId，在序列化和反序列化数据时才使用bagId
	 */
	public static enum BagType implements IndexedEnum {
		/** 非法背包，或者尚未指定的背包 */
		NULL(0, 0),
		/** 主道具包背包 */
		PRIM(1, LangConstants.BAG_NAME_PRIM),
		/** 临时包裹 */
		TEMP(2, LangConstants.BAG_NAME_TEMP),
		/** 武将身上装备包 */
		PET_EQUIP(3, LangConstants.BAG_NAME_PET_EQUIP),
		/** 武将身上的宝石包 */
		PET_GEM(4, LangConstants.BAG_NAME_PET_GEM),
		/** 仓库 */
		STORE(5, LangConstants.BAG_NAME_STORE),
		/** 仙符背包 */
		SKILL_EFFECT_BAG(6, LangConstants.SKILL_EFFECT_BAG),
		
		;

		private BagType(int index, int nameLangId) {
			this.index = index;
			this.nameLangId = nameLangId;
		}

		public final int index;
		/** 包的名字的LangId */
		public final int nameLangId;

		public int getNameLangId() {
			return nameLangId;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<BagType> values = IndexedEnumUtil.toIndexes(BagType.values());

		public static BagType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}


}
