package com.imop.lj.common.model;

import com.imop.lj.common.Reloadable.IResult;
import com.imop.lj.core.util.IKeyWordsFilter;

/**
 * 定义禁词的重新加载
 *
  *
 *
 */
public class DirtyReloadable {

	/**
	 * 禁词重新加载的结果
	 *
	  *
	 *
	 */
	public static class Result implements IResult {
		public final IKeyWordsFilter filter;
		public final IKeyWordsFilter namefilter;

		public Result(IKeyWordsFilter filter, IKeyWordsFilter namefilter) {
			this.filter = filter;
			this.namefilter = namefilter;
		}
	}
}
