package com.imop.lj.gameserver.item.container;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.ReasonDesc;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 仓库
 * 
 */
public class StoreBag extends CommonBag {

	public StoreBag(Human owner, BagType bagType, int capacity) {
		super(owner, bagType, capacity);
	}

	/**
	 * 获得包裹中还可以添加的指定道具的个数,已经考虑了道具叠加的情况和道具的绑定情况
	 * 
	 * @param template
	 *            道具模板
	 * @return
	 */
	public int getMaxCanAdd(ItemTemplate template, boolean isBind) {
		int count = 0;
		final int overlap = template.getMaxOverlap();
		for (Item item : items) {
			if (Item.isEmpty(item)) {
				count += overlap;
			} else if (Globals.getItemService().canOverlapOn(item, template.getId())) {
				count += (overlap - item.getOverlap());
			}
		}
		return count;
	}

	/**
	 * 取得指定的道具还可以叠加的总数,考虑道具的绑定状态
	 * 
	 * @param templateId
	 *            道具模板ID
	 * @return
	 */
	private int getCanOverlapCount(int templateId, boolean isBind) {
		int left = 0;
		for (Item item : this.items) {
			if (Globals.getItemService().canOverlapOn(item, templateId)
					&& item.isBind() == isBind) {//新增绑定状态必须相同才能叠加
				left += (item.getTemplate().getMaxOverlap() - item.getOverlap());
			}
		}
		return left;
	}

	/**
	 * 检查要放下count个模板为template的道具需要多少个槽位
	 * 
	 * @param template
	 * @param count
	 * @return
	 */
	@Override
	public int getNeedSlot(ItemTemplate template, int count, boolean isBind) {
		// 还可以叠加几个，这些不占新槽位
		int canOverlapCount = getCanOverlapCount(template.getId(), isBind);
		if (count <= canOverlapCount) {
			return 0;
		} else {
			int leftCount = count - canOverlapCount;
			int maxovlp = template.getMaxOverlap();
			return (leftCount + maxovlp - 1) / maxovlp;
		}
	}

	/**
	 * 获取背包中的空格个数
	 * 
	 * @return
	 */
	@Override
	public int getEmptySlotCount() {
		int count = 0;
		for (Item item : items) {
			if (item.isEmpty()) {
				count++;
			}
		}
		return count;
	}

	/**
	 * 向包中添加一定数量的某种道具，尽可能叠加，留下更多空位<br />
	 * 要么全放下，要么一个也不放
	 * 
	 * @param template
	 *            添加的道具模板
	 * @param count
	 *            添加的道具数
	 * @param reason
	 *            添加的原因
	 * @param detailReason
	 *            添加原因的详细说明
	 * @return
	 */
	@Override
	public Collection<Item> add(ItemTemplate template, int count, ItemGenLogReason reason, String detailReason, boolean isBind) {
		if (count == 0) {
			return Collections.emptyList();
		}
		// 不能全放下，一个也不放
		if (getMaxCanAdd(template, isBind) < count) {
			return Collections.emptyList();
		}

		boolean needSendLog = true;
		String genKey = "";
		try {
			do {
				// 记录道具产生日志
				genKey = KeyUtil.UUIDKey();
				Globals.getLogService().sendItemGenLog(owner, reason, detailReason, template.getId(), template.getName(), count, 0, "", genKey);
				// 增加物品增加原因到reasonDetail
				String countChangeReason = " [StoreGenReason:" + reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class).value() + "] ";
				detailReason = detailReason == null ? countChangeReason : detailReason + countChangeReason;
			} while (false);
		} catch (Exception e) {
			Loggers.itemLogger.error(LogUtils.buildLogInfoStr(owner.getUUID() + "", "记录向仓库中添加一定数量物品日志时出错"), e);
		}
		List<Item> updateList = new ArrayList<Item>();
		int left = count;
		// 在可以叠加的情况下,优先叠加
		if (template.canOverlap()) {
			left = addToOverlapSlot(template, left, ItemLogReason.COUNT_ADD, detailReason, genKey, updateList, needSendLog, isBind);
		}
		// 还没全放下,就添加到空格中
		if (left > 0) {
			left = addToEmptySlot(template, left, ItemLogReason.COUNT_ADD, detailReason, genKey, updateList, needSendLog, isBind);
		}
		// 还没全放下，肯定出错了
		if (left != 0) {
			Loggers.itemLogger.error(LogUtils.buildLogInfoStr(owner.getUUID() + "",
					String.format("仓库出现添加道具不完全的异常， itemId=%d count=%d left=%d", template.getId(), count, left)));
		}

		return updateList;
	}

	/**
	 * 向非空格中叠加道具，忽略空格，考虑道具的绑定状态，尽力放置，如果放不下返回剩下的个数
	 * 
	 * @param updateList
	 *            需要跟新的Item的list
	 * @return 放不下剩下的个数
	 */
	private int addToOverlapSlot(ItemTemplate template, int count, ItemLogReason reason, String reasonDetail, String genKey, List<Item> updateList,
			boolean needSendLog, boolean isBind) {
		if (count == 0) {
			return 0;
		}
		int left = count;
		for (Item item : items) {
			if (left == 0) {
				break;
			}
			if (Globals.getItemService().canOverlapOn(item, template.getId())) {
				// 找到已经存在的位置, 绑定状态和添加的物品状态一致，不需要重新设置绑定状态
				if (template.getMaxOverlap() > item.getOverlap()) {
					int capacity = template.getMaxOverlap() - item.getOverlap();
					if (capacity >= left) {
						// 可以全部放入
						item.changeOverlap(item.getOverlap() + left, reason, reasonDetail, genKey, needSendLog);
						left = 0;
						updateList.add(item);
						break;
					} else {
						// 只能放一部分
						item.changeOverlap(template.getMaxOverlap(), reason, reasonDetail, genKey, needSendLog);
						left -= capacity;
						updateList.add(item);
					}
				}
			}
		}
		return left;
	}

	/**
	 * 向空格中增加道具，不叠加，考虑道具的绑定状态，尽力放置，如果放不下返回剩下的个数
	 * 
	 * @param updateList
	 *            需要跟新的Item的list
	 * @return 放不下剩下的个数
	 */
	private int addToEmptySlot(ItemTemplate template, int count, ItemLogReason reason, String reasonDetail, String genKey, List<Item> updateList,
			boolean needSendLog, boolean isBind) {
		int left = count;
		if (count == 0) {
			return 0;
		}
		for (Item item : items) {
			if (left == 0) {
				break;
			}
			if (item.isEmpty()) { // 只检查空的格子
				// 产生一个新的激活的物品实例
				Item newItem = Globals.getItemService().newActivatedInstance(owner, template, getBagType(), item.getIndex(), isBind);
				newItem.setModified();
				this.items[newItem.getIndex()] = newItem;
				if (template.getMaxOverlap() >= left) {
					// 可以全部放入
					newItem.changeOverlap(left, reason, reasonDetail, genKey, needSendLog);
					left = 0;
					updateList.add(newItem);
					break;
				} else {
					// 只能放一部分
					newItem.changeOverlap(template.getMaxOverlap(), reason, reasonDetail, genKey, needSendLog);
					left -= template.getMaxOverlap();
					updateList.add(newItem);
				}
			}
		}
		return left;
	}

	@Override
	public Collection<Item> removeItem(int templateId, int count, ItemLogReason reason, String detailReason, boolean bindFirst) {
		throw new UnsupportedOperationException();
	}
	
//	/**
//	 * 拆分道具
//	 * 
//	 * @param index
//	 *            索引
//	 * @param count
//	 *            拆出来的数量
//	 * @return 需要跟新的道具
//	 */
//	public List<Item> split(int index, final int count) {
//		Item item = getByIndex(index);
//		if (Item.isEmpty(item)) {
//			return Collections.emptyList();
//		}
//		// 不可以叠加
//		if (!item.canOverlap()) {
//			return Collections.emptyList();
//		}
//		// 检查拆出来的个数
//		if (count >= item.getOverlap() || count < 1) {
//			return Collections.emptyList();
//		}
//		Item emptyItem = getEmptySlot();
//		// 没有地方拆分
//		if (emptyItem == null) {
//			return Collections.emptyList();
//		}
//		List<Item> updateList = new ArrayList<Item>();
//		// 减少原来的叠加数
//		item.changeOverlap(item.getOverlap() - count, ItemLogReason.SPLITTED, "", "", true);
//		updateList.add(item);
//
//		// 记录道具产出日志
//		String genKey = KeyUtil.UUIDKey();
//		try {
//			Globals.getLogService().sendItemGenLog(owner, ItemGenLogReason.SPLIT, "", item.getTemplateId(), item.getName(), count, 0, "", genKey);
//		} catch (Exception e) {
//			Loggers.itemLogger.error(LogUtils.buildLogInfoStr(owner.getUUID() + "", "记录道 具产出日志时出错"), e);
//		}
//
//		String countChangeReason = " [genReason:" + ItemGenLogReason.SPLIT + "] ";
//		// 产生一个新的激活的物品实例
//		Item newItem = Globals.getItemService().newActivatedInstance(owner, item.getTemplate(), getBagType(), emptyItem.getIndex());
//		newItem.setModified();
//		// 设置物品的绑定状态
//		this.items[newItem.getIndex()] = newItem;
//		newItem.changeOverlap(count, ItemLogReason.COUNT_ADD, countChangeReason, genKey, true);
//		// 添加到新拆分的物品
//		updateList.add(newItem);
//		return updateList;
//	}

	@Override
	public void setResetBagNum(int newCapacity) {
//		this.owner.setStoreBagNum(newCapacity);
	}
}
