
using System;
namespace app.net
{
/**
 * 商品信息表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTradeCommodityList :BaseMessage
{
	/** 商品信息 */
	private TradeInfo[] tradeList;
	/** 当前页数 */
	private int pageNum;
	/** 总页数 */
	private int totalPageNum;

	public GCTradeCommodityList ()
	{
	}

	protected override void ReadImpl()
	{

	// 商品信息
	int tradeListSize = ReadShort();
	TradeInfo[] _tradeList = new TradeInfo[tradeListSize];
	int tradeListIndex = 0;
	TradeInfo _tradeListTmp = null;
	for(tradeListIndex=0; tradeListIndex<tradeListSize; tradeListIndex++){
		_tradeListTmp = new TradeInfo();
		_tradeList[tradeListIndex] = _tradeListTmp;
	// 卖家ID
	long _tradeList_sellerId = ReadLong();	_tradeListTmp.sellerId = _tradeList_sellerId;
		// 买家ID
	long _tradeList_buyerId = ReadLong();	_tradeListTmp.buyerId = _tradeList_buyerId;
		// 商品类型
	int _tradeList_commodityType = ReadInt();	_tradeListTmp.commodityType = _tradeList_commodityType;
		// 交易状态
	int _tradeList_tradeStatus = ReadInt();	_tradeListTmp.tradeStatus = _tradeList_tradeStatus;
		// 商品详细信息
	string _tradeList_commodityJson = ReadString();	_tradeListTmp.commodityJson = _tradeList_commodityJson;
		// 摊位坐标
	int _tradeList_boothIndex = ReadInt();	_tradeListTmp.boothIndex = _tradeList_boothIndex;
		// 货币类型
	int _tradeList_currencyType = ReadInt();	_tradeListTmp.currencyType = _tradeList_currencyType;
		// 货币数量
	int _tradeList_currencyNum = ReadInt();	_tradeListTmp.currencyNum = _tradeList_currencyNum;
		// 商品数量
	int _tradeList_commodityNum = ReadInt();	_tradeListTmp.commodityNum = _tradeList_commodityNum;
		// 交易创建时间
	long _tradeList_startTime = ReadLong();	_tradeListTmp.startTime = _tradeList_startTime;
		// 交易过期时间
	long _tradeList_overDueTime = ReadLong();	_tradeListTmp.overDueTime = _tradeList_overDueTime;
		}
	//end

	// 当前页数
	int _pageNum = ReadInt();
	// 总页数
	int _totalPageNum = ReadInt();


		this.tradeList = _tradeList;
		this.pageNum = _pageNum;
		this.totalPageNum = _totalPageNum;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TRADE_COMMODITY_LIST;
	}
	
	public override string getEventType()
	{
		return TradeGCHandler.GCTradeCommodityListEvent;
	}
	

	public TradeInfo[] getTradeList(){
		return tradeList;
	}


	public int getPageNum(){
		return pageNum;
	}
		

	public int getTotalPageNum(){
		return totalPageNum;
	}
		

}
}