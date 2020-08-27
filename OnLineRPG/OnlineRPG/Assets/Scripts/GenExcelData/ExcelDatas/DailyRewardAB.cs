// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the FrameWork Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
//  Build Time：2020-08-11 12:28:52.564
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using BetaFramework;

/// <summary>
/// 表
/// </summary>
public class DailyRewardAB : BaseSheet<DailyRewardAB_Data>
{
    public DailyRewardData GetDailyRewardMonthReward()
    {
        int year = AppEngine.SSystemManager.GetSystem<DailySystem>().Year.Value;
        int mon = AppEngine.SSystemManager.GetSystem<DailySystem>().Mon.Value;
        for (int i = 0; i < dataList.Count; i++)
        {
            if (dataList[i].Year == year && dataList[i].Month == mon)
            {
                return new DailyRewardData(dataList[i]);
            }
        }

        return new DailyRewardData(dataList[0]);
    }
}

public class DailyRewardData
{
    public int[] coins;
    public int[] stars;
    public string[] pets;

    public DailyRewardData(DailyRewardAB_Data data)
    {
        coins = new[] {data.Coin1, data.Coin2, data.Coin3, data.Coin4};
        stars = new[] {data.Star1, data.Star2, data.Star3, data.Star4};
        pets = new[] {data.Pet1, data.Pet2, data.Pet3, data.Pet4};
    }
}