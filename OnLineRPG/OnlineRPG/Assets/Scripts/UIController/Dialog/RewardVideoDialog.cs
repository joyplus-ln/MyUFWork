﻿using System;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.UI;

public class RewardVideoDialog : UIWindowBase
{
    public GameObject claimButton;
    public Text DescriptionText;

    public override void OnOpen()
    {
        base.OnOpen();
        int rewardCoin = (int)objs[0];
        DescriptionText.text = string.Format("Watch a quick video to\nreceive <color=#81191C>{0} FREE COINS!</color>", rewardCoin);
    }

    public void ClickVideo()
    {
        DataManager.ProcessData.advideosource = RewardSource.closeShopAD;
        Close();
    }

    public void CloseButton()
    {
        Close();
    }

}