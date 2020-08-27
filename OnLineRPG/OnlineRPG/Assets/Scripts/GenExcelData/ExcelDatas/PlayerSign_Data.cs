// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the FrameWork Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
//  Build Time：2019-12-23 17:55:44.088
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 表数据
/// </summary>
public class PlayerSign_Data : BaseExcelData
{
    
    /// <summary>
    /// 宝箱样式
    /// </summary>
    public int BoxStyle;

    /// <summary>
    /// 奖励宝箱id
    /// </summary>
    public string RewardId;

    public int GetRowsCount()
    {
        return 10;
    }
    public int GetColumnsCount()
    {
        return 3;
    }
    public void Init(Dictionary<string, object> data)
    {
        
        ID = Convert.ToString(data["ID"]);
        BoxStyle = Convert.ToInt32(data["BoxStyle"]);
        RewardId = Convert.ToString(data["RewardId"]);
    }
    override public string ToString()
    {
        return string.Format("ID={0},BoxStyle={1},RewardId={2}", ID, BoxStyle, RewardId);
    }
}