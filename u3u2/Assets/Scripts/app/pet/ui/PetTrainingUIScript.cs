﻿using System.Collections.Generic;
using app.model;
using UnityEngine;
using UnityEngine.UI;
using app.db;
using app.net;
using app.utils;
using app.zone;

namespace app.pet
{
    internal class PetTrainingResItemUI
    {
        private Text baseValueTxt = null;
        private Text addValueTxt = null;
        private GameObject fullTips = null;
        private Text tempValueTxt = null;
        private GameObject upArrow = null;
        private GameObject downArrow = null;

        public PetTrainingResItemUI(GameObject ui)
        {
            baseValueTxt = ui.transform.Find("baseValue").GetComponent<Text>();
            addValueTxt = ui.transform.Find("addValue").GetComponent<Text>();
            fullTips = ui.transform.Find("fullTips").gameObject;
            tempValueTxt = ui.transform.Find("tempValue").GetComponent<Text>();
            upArrow = ui.transform.Find("upArrow").gameObject;
            downArrow = ui.transform.Find("downArrow").gameObject;

            fullTips.SetActive(false);
            upArrow.SetActive(false);
            downArrow.SetActive(false);
        }

        public void SetData(int total, int trainingAdd, int tempValue, int max, bool hasTempValue)
        {
            string addValueColor = trainingAdd >= 0 ? ColorUtil.GREEN : ColorUtil.RED;
            string tempValueColor = tempValue >= 0 ? ColorUtil.GREEN : ColorUtil.RED;
            string trainingAddStr = trainingAdd.ToString();
            if (trainingAdd >= 0)
            {
                trainingAddStr = " +" + trainingAddStr;
            }
            string tempValueStr = tempValue.ToString();
            if (tempValue >= 0)
            {
                tempValueStr = "+" + tempValueStr;
            }

            baseValueTxt.text = (total - trainingAdd).ToString();

            if (trainingAdd != 0)
            {
                addValueTxt.text = "<color=" + addValueColor + ">" + trainingAddStr + "</color>";
            }
            else
            {
                addValueTxt.text = "";
            }

            if (hasTempValue)
            {
                tempValueTxt.text = "<color=" + tempValueColor + ">" + tempValueStr + "</color>";
                upArrow.SetActive(tempValue >= 0);
                downArrow.SetActive(tempValue < 0);
            }
            else
            {
                tempValueTxt.text = "";
                upArrow.SetActive(false);
                downArrow.SetActive(false);
            }


            fullTips.SetActive(trainingAdd >= max);
        }
    }

    public class PetTrainingUIScript
    {
        private PetTrainingUI mUI = null;
        private Pet mPet = null;

        private List<PetTrainingResItemUI> mReses = new List<PetTrainingResItemUI>();
        private List<MoneyItemScript> mCosts = new List<MoneyItemScript>();

        public PetTrainingUIScript(PetTrainingUI ui)
        {
            mUI = ui;
            mReses.Add(new PetTrainingResItemUI(ui.qiangzhuang));
            mReses.Add(new PetTrainingResItemUI(ui.minjie));
            mReses.Add(new PetTrainingResItemUI(ui.zhili));
            mReses.Add(new PetTrainingResItemUI(ui.xinyang));
            mReses.Add(new PetTrainingResItemUI(ui.naili));

            mCosts.Add(new MoneyItemScript(ui.chujiCost));
            mCosts.Add(new MoneyItemScript(ui.zhongjiCost));
            mCosts.Add(new MoneyItemScript(ui.gaojiCost));

            ui.peiyangBtn.SetClickCallBack(OnPeiYangClick);
            ui.tihuanBtn.SetClickCallBack(OnTiHuanClick);

            PlayerModel.Ins.addChangeEvent(PlayerModel.UPDATE_VIP_INFO,updateVIPTrain);
        }

        public void updatePanel(Pet pet)
        {
            mPet = pet;

            if (mPet == null)
            {
                mUI.gameObject.SetActive(false);
            }
            else
            {
                mUI.gameObject.SetActive(true);
                //int totalTempValue = 0;
                bool hasTempValue = false;
                for (int i = 0; i < 5; i++)
                {
                    //mReses[i].SetData(mPet.PropertyManager.getAProperty(PetAProperty._BEGIN + i + 1), mPet.PetInfo.trainPropArr[i], mPet.PetInfo.trainTmpPropArr[i]);
                    //totalTempValue += mPet.PetInfo.trainTmpPropArr[i];
                    if (!hasTempValue && mPet.PetInfo.trainTmpPropArr[i] != 0)
                    {
                        hasTempValue = true;
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    mReses[i].SetData(mPet.PropertyManager.getPetIntProp(PetAProperty._BEGIN + i + 1), mPet.PetInfo.trainPropArr[i], mPet.PetInfo.trainTmpPropArr[i], mPet.PetInfo.trainMax, hasTempValue);
                }

                if (hasTempValue)
                {
                    if (!mUI.tihuanBtn.IsInteractable())
                    {
                        ColorUtil.DeGray(mUI.tihuanBtn);
                        mUI.tihuanBtn.interactable = true;
                    }
                }
                else
                {
                    if (mUI.tihuanBtn.IsInteractable())
                    {
                        mUI.tihuanBtn.interactable = false;
                        ColorUtil.Gray(mUI.tihuanBtn);
                    }
                }
                UpdateCosts();
                updateVIPTrain();
            }
        }

        public void updateVIPTrain(RMetaEvent e = null)
        {
            int zhongjiTrainOpenVIPLevel =
                VipConfigTemplateDB.Instance.GetVipTeQuanOpenLevel(VIPTeQuanIdDef.PET_ZHONGJI_TRAIN);
            mUI.zhongjiLabel.text = "中级培养\n(VIP" + zhongjiTrainOpenVIPLevel + "开启)";
            if (PlayerModel.Ins.GetMyVipLevel() >= zhongjiTrainOpenVIPLevel)
            {
                //开启
                //mUI.zhongjiCheckBox.SetActive(true);
                mUI.peiyangTypeGroup.toggleList[1].interactable = true;
                ColorUtil.DeGray(mUI.zhongjiCheckBox);
            }
            else
            {
                //没开启
                //mUI.zhongjiCheckBox.SetActive(false);
                mUI.peiyangTypeGroup.toggleList[1].interactable = false;
                ColorUtil.Gray(mUI.zhongjiCheckBox);
            }

            int gaojiTrainOpenVIPLevel =
                VipConfigTemplateDB.Instance.GetVipTeQuanOpenLevel(VIPTeQuanIdDef.PET_GAOJI_TRAIN);
            mUI.gaojiLabel.text = "高级培养\n(VIP" + gaojiTrainOpenVIPLevel + "开启)";
            if (PlayerModel.Ins.GetMyVipLevel() >= gaojiTrainOpenVIPLevel)
            {
                //开启
                //mUI.gaojiCheckBox.SetActive(true);
                mUI.peiyangTypeGroup.toggleList[2].interactable = true;
                ColorUtil.DeGray(mUI.gaojiCheckBox);
            }
            else
            {
                //没开启
                //mUI.gaojiCheckBox.SetActive(false);
                mUI.peiyangTypeGroup.toggleList[2].interactable = false;
                ColorUtil.Gray(mUI.gaojiCheckBox);
            }
        }

        private void UpdateCosts()
        {
            if (PetModel.Ins.IsChongWu)
            {
                PetTrainCostTemplate chujiCostTpl = PetTrainCostTemplateDB.Instance.getTemplate(1);
                mCosts[0].SetMoney(chujiCostTpl.currencyTypeId, chujiCostTpl.currencyNum);
                PetTrainCostTemplate zhongjiCostTpl = PetTrainCostTemplateDB.Instance.getTemplate(2);
                mCosts[1].SetMoney(zhongjiCostTpl.currencyTypeId, zhongjiCostTpl.currencyNum);
                PetTrainCostTemplate gaojiCostTpl = PetTrainCostTemplateDB.Instance.getTemplate(3);
                mCosts[2].SetMoney(gaojiCostTpl.currencyTypeId, gaojiCostTpl.currencyNum);
            }
            else
            {
                PetHorseTrainCostTemplate chujiCostTpl = PetHorseTrainCostTemplateDB.Instance.getTemplate(1);
                mCosts[0].SetMoney(chujiCostTpl.currencyTypeId, chujiCostTpl.currencyNum);
                PetHorseTrainCostTemplate zhongjiCostTpl = PetHorseTrainCostTemplateDB.Instance.getTemplate(2);
                mCosts[1].SetMoney(zhongjiCostTpl.currencyTypeId, zhongjiCostTpl.currencyNum);
                PetHorseTrainCostTemplate gaojiCostTpl = PetHorseTrainCostTemplateDB.Instance.getTemplate(3);
                mCosts[2].SetMoney(gaojiCostTpl.currencyTypeId, gaojiCostTpl.currencyNum);
            }
        }

        private void OnPeiYangClick()
        {
            //for (int i = 0; i < mUI.peiyangTypeGroup.toggleList.Count;i++ )
            //{
            //    if (mUI.peiyangTypeGroup.toggleList[i].isOn)
            //    {
            //        if (!mCosts[i].IsEnough)
            //        {
            //            ZoneBubbleManager.ins.BubbleSysMsg("货币不足，无法培养");
            //            return;
            //        }

            //    }
            //}
            if (PetModel.Ins.IsChongWu)
            {
                int traintype = mUI.peiyangTypeGroup.index + 1;
                PetTrainCostTemplate tpl = PetTrainCostTemplateDB.Instance.getTemplate(traintype);
                MoneyCheck.Ins.Check(tpl.currencyTypeId,tpl.currencyNum,sureHandler);
            }
            else
            {
                int traintype = mUI.peiyangTypeGroup.index + 1;
                PetHorseTrainCostTemplate tpl = PetHorseTrainCostTemplateDB.Instance.getTemplate(traintype);
                MoneyCheck.Ins.Check(tpl.currencyTypeId,tpl.currencyNum,sureHandler);
            }
        }

        private void sureHandler(RMetaEvent e)
        {
            if (PetModel.Ins.IsChongWu)
            {
                PetCGHandler.sendCGPetTrain(mPet.Id, mUI.peiyangTypeGroup.index + 1);
            }
            else
            {
                PetCGHandler.sendCGPetHorseTrain(mPet.Id, mUI.peiyangTypeGroup.index + 1);
            }
        }

        private void OnTiHuanClick()
        {
            if (PetModel.Ins.IsChongWu)
            {
                PetCGHandler.sendCGPetTrainUpdate(mPet.Id);
            }
            else
            {
                PetCGHandler.sendCGPetHorseTrainUpdate(mPet.Id);
            }
        }
        
        public void Destroy()
        {
            int len = mCosts.Count;
            for (int i = 0; i < len; i++)
            {
                mCosts[i].Destroy();
                mCosts[i] = null;
            }
            mCosts.Clear();
            mCosts = null;
            PlayerModel.Ins.removeChangeEvent(PlayerModel.UPDATE_VIP_INFO, updateVIPTrain);
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }
    }
}