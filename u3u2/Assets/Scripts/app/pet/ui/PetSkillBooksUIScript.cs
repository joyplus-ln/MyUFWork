﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using app.item;
using app.net;
using app.human;
using app.tips;
using app.bag;

namespace app.pet
{
    internal class PetSkillBookListItemScript : CommonItemScript
    {

        private UnityAction<ItemDetailData, GameObject> mclickHandler;



        public PetSkillBookListItemScript(PetSkillBookListItemUI ui, UnityAction<ItemDetailData> clickitemhand, UnityAction<ItemDetailData, GameObject> clickHandler = null)
            : base(ui, clickitemhand)
        {
            setClickFor(CommonItemClickFor.OnlyCallBack);
            mclickHandler = clickHandler;
            PetSkillBookListItemUI itemUIBehav = (PetSkillBookListItemUI)ui;
            itemUIBehav.btn.AddClickCallBack(OnSkillBookBgClicked);
        }
        
        /// <summary>
        /// 技能书背景点击
        /// </summary>
        /// <param name="obj"></param>
        private void OnSkillBookBgClicked(GameObject obj)
        {
            GameObject go = obj.transform.parent.Find("bg/select").gameObject;
            if (mclickHandler != null)
                mclickHandler(itemData, go);
        }
    }
    
    public class PetSkillBooksUIScript
    {
        public delegate void OnSkillBookSelected(ItemDetailData data);
        
        private PetSkillBooksUI mUI = null;
        private OnSkillBookSelected mOnSkillBookSelected = null;

        private List<PetSkillBookListItemScript> mItems = new List<PetSkillBookListItemScript>();
        private PetInfo mPetInfo = null;
        private UnityAction mOnHide = null;
        /// <summary>
        /// 添加骑宠
        /// </summary>
        private int mBooksType = 0;

        public int BooksType
        {
            get
            {
                return mBooksType;
            }
            set
            {
                mBooksType = value;
            }
        }

        /// <summary>
        /// 上一次选中的技能书
        /// </summary>
        private GameObject mLastObj;

        public PetSkillBooksUIScript(PetSkillBooksUI ui, OnSkillBookSelected onSkillBookSelected, UnityAction onHide)
        {
            mUI = ui;
            mUI.closeBtn.SetClickCallBack(HideUI);
            mUI.listItem.gameObject.SetActive(false);
            mOnSkillBookSelected = onSkillBookSelected;
            mOnHide = onHide;
            BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, ItemListUpdated);
        }

        public void UpdatePanel(PetInfo petInfo)
        {
            mPetInfo = petInfo;
            SetEmpty();

            List<ItemDetailData> books = Human.Instance.BagModel.getItemListByType(mBooksType);
            int len = books.Count;
            for (int i = 0; i < len; i++)
            {
                if (mBooksType == ItemDefine.ItemTypeDefine.LEADER_SKILL_BOOK)
                {
                    if (!PetJobType.ContainJob(books[i].leaderSkillBookItemTemplate.jobLimit, PetModel.Ins.getLeader().getJob()))
                    {
                        continue;
                    }

                    GameObject item = GameObject.Instantiate(mUI.listItem.gameObject);
                    item.name = books[i].leaderSkillBookItemTemplate.Id.ToString();
                    item.transform.SetParent(mUI.listItem.gameObject.transform.parent);
                    item.transform.localScale = mUI.listItem.gameObject.transform.localScale;
                    PetSkillBookListItemUI itemUIBehav = item.GetComponent<PetSkillBookListItemUI>();
                    itemUIBehav.ScrollRect = mUI.scrollrect;
                    PetSkillBookListItemScript listItemScript = new PetSkillBookListItemScript(itemUIBehav, OnSkillBookIconClicked, OnSkillBookClicked);
                    listItemScript.setData(books[i]);
                    item.SetActive(true);
                    mItems.Add(listItemScript);
                }
                else if (mBooksType == ItemDefine.ItemTypeDefine.SKILL_BOOK || mBooksType == ItemDefine.ItemTypeDefine.QICHONG_SKILL_BOOK)
                {
                    PetSkillInfo skillInfo = GetSkillInfo(books[i].petSkillBookItemTemplate.skillTplId);
                    if ((skillInfo == null && books[i].petSkillBookItemTemplate.bookLevel == 1) || (skillInfo != null && books[i].petSkillBookItemTemplate.bookLevel == skillInfo.level + 1))
                    {
                        GameObject item = GameObject.Instantiate(mUI.listItem.gameObject);
                        item.name = books[i].petSkillBookItemTemplate.Id.ToString();
                        item.transform.SetParent(mUI.listItem.gameObject.transform.parent);
                        item.transform.localScale = mUI.listItem.gameObject.transform.localScale;
                        PetSkillBookListItemUI itemUIBehav = item.GetComponent<PetSkillBookListItemUI>();
                        PetSkillBookListItemScript listItemScript = new PetSkillBookListItemScript(itemUIBehav,OnSkillBookIconClicked, OnSkillBookClicked);
                        listItemScript.setData(books[i]);
                        item.SetActive(true);
                        mItems.Add(listItemScript);
                    }
                }
            }
        }

        /// <summary>
        /// 技能书Icon点击
        /// </summary>
        /// <param name="obj"></param>
        private void OnSkillBookIconClicked(ItemDetailData data)
        {
            if (data != null)
                ItemTips.Ins.ShowTips(data,false,TipsBtnType.NOTSHOW);
        }

        private PetSkillInfo GetSkillInfo(int skillId)
        {
            if (mBooksType == ItemDefine.ItemTypeDefine.SKILL_BOOK || mBooksType == ItemDefine.ItemTypeDefine.QICHONG_SKILL_BOOK)
            {
                if (mPetInfo != null)
                {
                    int len = mPetInfo.skillList.Length;
                    for (int i = 0; i < len; i++)
                    {
                        if (mPetInfo.skillList[i].skillId == skillId)
                        {
                            return mPetInfo.skillList[i];
                        }
                    }
                }
            }
            else if (mBooksType == ItemDefine.ItemTypeDefine.LEADER_SKILL_BOOK)
            {
                return PetModel.Ins.GetLeaderSkillInfo(skillId);
            }

            return null;
        }

        public void SetEmpty()
        {
            int len = mItems.Count;
            for (int i = 0; i < len; i++)
            {
                GameObject.DestroyImmediate(mItems[i].UI.gameObject, true);
                mItems[i].UI = null;
            }
            mItems.Clear();
        }

        private void OnSkillBookClicked(ItemDetailData itemData,GameObject obj)
        {
            if (mLastObj != null)
            {
                mLastObj.SetActive(false);
            }
            obj.SetActive(true);
            mLastObj = obj;
            if (this.mOnSkillBookSelected != null)
            {
                this.mOnSkillBookSelected(itemData);
            }
        }

        public void HideUI()
        {
            if (mUI.gameObject.activeSelf)
            {
                SetEmpty();
                mUI.gameObject.SetActive(false);
                if (mOnHide != null)
                {
                    mOnHide();
                }
            }
        }
        
        public void Destroy()
        {
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }

        private void ItemListUpdated(RMetaEvent e)
        {
            List<KeyValuePair<CommonItemData, int>> list = (List<KeyValuePair<CommonItemData, int>>)e.data;
            int changedListLen = list.Count;
            int bookItemsListLen = mItems.Count;
            for (int i = 0; i < changedListLen; i++)
            {
                if (list[i].Value == -1)
                {
                    for (int j = 0; j < bookItemsListLen; j++)
                    {
                        if (list[i].Key.uuid == mItems[j].itemData.commonItemData.uuid)
                        {
                            GameObject.DestroyImmediate(mItems[j].UI.gameObject, true);
                            mItems.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
        }

    }
}
