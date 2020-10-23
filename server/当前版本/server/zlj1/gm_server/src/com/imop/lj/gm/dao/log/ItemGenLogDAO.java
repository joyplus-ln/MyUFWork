package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.ItemGenLog;

/**
 * 物品产生日志DAO
 *
 * @author linfan
 *
 */
public class ItemGenLogDAO extends GenericDAO {

	/**
	 * @param order
	 * @param sortType
	 * @param endTimel
	 * @param startTimel
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<ItemGenLog> getItemGenLogList(final String roleID,
			final String date, final String reason, final String templeteID,
			final String sortType, final String order, final long startTimel,
			final long endTimel, final String itemGenId) {
		return (List<ItemGenLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from item_gen_log_" + date
								+ " where 1=1");
						sql.append(StringUtils.isBlank(roleID) ? ""
								: " and char_id = :charId");
						if (StringUtils.isNotBlank(reason)
								&& !"-1".equals(reason)) {
							sql.append(" and reason = :reason");
						}
						sql.append(StringUtils.isBlank(templeteID) ? ""
								: " and template_id = :itemTmplId");
						sql.append(StringUtils.isBlank(itemGenId) ? ""
								: " and item_gen_id = :itemGenId");
						if (startTimel != -1) {
							sql.append(" and  log_time >= :startTime");
						}
						if (endTimel != -1) {
							sql.append(" and  log_time <= :endTime");
						}
						if (StringUtils.isNotBlank(sortType)) {
							sql.append(" order by " + sortType + " " + order);
						}
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(roleID)) {
							query.setString("charId", roleID.trim());
						}
						if (StringUtils.isNotBlank(reason)
								&& !"-1".equals(reason)) {
							query.setString("reason", reason.trim());
						}
						if (StringUtils.isNotBlank(templeteID)) {
							query.setString("itemTmplId", templeteID.trim());
						}
						if (StringUtils.isNotBlank(itemGenId)) {
							query.setString("itemGenId", itemGenId.trim());
						}
						if (startTimel != -1) {
							query.setLong("startTime", startTimel);
						}
						if (endTimel != -1) {
							query.setLong("endTime", endTimel);
						}
						LogTypeUtils.addLogQueryScalar(query, ItemGenLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(ItemGenLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

}
