﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;



public delegate void WCAddOnePageCallBack(int startIndex, int count);
public class UIWrapContent : MonoBehaviour
{

    private int itemSize = 100;  //每个itemsize大小  之后会强制计算为  Item的宽度 


    public GameObject mObjItem;

    protected Transform mTrans;
    protected ScrollRect mScroll;
    protected bool mHorizontal = false;
    /// <summary>
    /// 总行数或总列数
    /// </summary>
    private int mTotleColNum;

    private RectTransform mRect;
    private GridLayoutGroup grid;
    private Text mTextPageNum;
    private Vector2 mDragdelta;
    private RectTransform mScrollRectTrans;
    private Vector3 mZero;
    private int mCurPageNum = 1;
    private int mMaxPageNum;
    private int mShowMaxPage;
    private int mRectOff;

    private GameObject mDefaultItem;
    private GameObject mItemParent;
    private int mPerpageNum = 5;
    private int mTotalNum = 100;
    /// <summary>
    /// 初始化 Item 的页数
    /// </summary>
    public int mInitPageNum;
    private WCAddOnePageCallBack m_cbupdateitem;
    private WCAddOnePageCallBack m_cbinititem;
    private int currentNum;
    /// <summary>
    /// UI列表
    /// </summary>
    private List<GameObject> m_ItemList = new List<GameObject>();

    public WCAddOnePageCallBack AddOnePageCB
    {
        get
        {
            return m_cbupdateitem;
        }

        set
        {
            m_cbupdateitem = value;
        }
    }

    public List<GameObject> ItemList
    {
        get
        {
            return m_ItemList;
        }

        set
        {
            m_ItemList = value;
        }
    }

    #region Init

    public void Init(GameObject objItem)
    {
        mObjItem = objItem.gameObject;
    }

    public void Init(WCAddOnePageCallBack addOnePageCBv, int perpageNumv, int totalNumv,
        WCAddOnePageCallBack cbinititem)
    {
        Init(mObjItem, gameObject, addOnePageCBv, perpageNumv, totalNumv, cbinititem);
    }

    /// <summary>
    /// 目前只支持横向的排列   ~~~
    /// </summary>
    /// <param name="defaultItemv">Item GameObj</param>
    /// <param name="itemParentv">Item 父节点</param>
    /// <param name="addOnePageCBv">更新数据回调函数</param>
    /// <param name="perpageNumv">每页数目</param>     每页数目要看 界面排了多少item 然后传多少  否则会计算页数出现偏差~~~
    /// <param name="totalNumv">总共数目</param>
    /// <param name="initPageNum">初始化时 初始化几页</param>
    public void Init(GameObject defaultItemv,
        GameObject itemParentv, WCAddOnePageCallBack addOnePageCBv, int perpageNumv,
        int totalNumv, WCAddOnePageCallBack cbinititem, int initItemPage = 3)
    {

        defaultItemv.SetActive(false);

        mDefaultItem = defaultItemv;
        mItemParent = itemParentv;
        AddOnePageCB = addOnePageCBv;
        mInitPageNum = initItemPage;
        mPerpageNum = perpageNumv;
        mTotalNum = totalNumv;
        currentNum = 0;
        m_cbinititem = cbinititem;

        mTrans = transform;
        mScroll = transform.parent.GetComponent<ScrollRect>();
        if (mScroll == null)
        {
            ClientLog.LogError("UIWrapContent父节点没找到 ScrollRect 组件");
            return;
        }

        mRect = mScroll.GetComponent<RectTransform>();
        grid = transform.GetComponent<GridLayoutGroup>();
        mTextPageNum = transform.parent.Find("pageNum").GetComponent<Text>();

        EventTriggerListener.Get(mRect.gameObject).onEndDrag = RectOnEndDrag;

        mHorizontal = mScroll.horizontal;
        mZero = transform.localPosition;
        //开始初始化的个数
        int l = perpageNumv * initItemPage;
        mShowMaxPage = mTotalNum / perpageNumv;
        if (mTotalNum % perpageNumv > 0) mShowMaxPage++;
        //计算列数
        mTotleColNum = l / grid.constraintCount + l % grid.constraintCount;



        int j;
        if (mHorizontal)
        {
            itemSize = (int)mDefaultItem.GetComponent<RectTransform>().sizeDelta.x;
            //计算总长度
            j = mTotleColNum * itemSize + (mTotleColNum - 1) * (int)grid.spacing.x;
            //总长度除以页数长度为页数  
            j = j / (int)mRect.sizeDelta.x;
            if (j % mRect.sizeDelta.x > 20) j++;

            mRectOff = (int)mRect.sizeDelta.x;
        }
        else
        {
            j = mTotleColNum * itemSize + (mTotleColNum - 1) * (int)grid.spacing.y;
            j = j / (int)mRect.sizeDelta.x;
            if (j % mRect.sizeDelta.y > 0) j++;
            mRectOff = (int)mRect.sizeDelta.y;
        }
        UpdatePage();
        mMaxPageNum = j;
        if (mScroll != null)
            mScroll.onValueChanged.AddListener(OnMove);
        ItemList.Clear();
        AddPage(initItemPage, false);

    }

    #endregion

    #region 添加页 

    /// <summary>
    /// 添加页
    /// </summary>
    private void AddPage(int pagenum = 1, bool isInit = true)
    {

        if (mDefaultItem == null || mItemParent == null)
        {
            return;
        }

        if (currentNum >= mTotalNum)
        {
            //已经到最后了
            return;
        }

        int addNum = 0;
        if (currentNum + mPerpageNum > mTotalNum)
        {
            addNum = mTotalNum - currentNum;
            if (isInit)
                mMaxPageNum++;
        }
        else
        {
            addNum = mPerpageNum * pagenum;
            //初始化的数量不能大于最大数量
            if (addNum > mTotalNum)
            {
                addNum = mTotalNum;
            }
            if (isInit)
                mMaxPageNum += pagenum;
        }

        for (int i = currentNum; i < currentNum + addNum; i++)
        {
            if (ItemList == null)
            {
                ItemList = new List<GameObject>();
            }
            if (i >= ItemList.Count)
            {
                GameObject newItem = GameObject.Instantiate(mDefaultItem) as GameObject;
                newItem.transform.SetParent(mItemParent.transform);
                newItem.transform.localScale = Vector3.one;
                ItemList.Add(newItem);
                //newItem.SetActive(true);
                if (m_cbinititem != null)
                    m_cbinititem(i, addNum);
            }
            ItemList[i].SetActive(true);
        }
        //多余的隐藏
        for (int i = currentNum + addNum; i < ItemList.Count; i++)
        {
            ItemList[i].SetActive(false);
        }
        if (m_cbupdateitem != null)
        {
            //回调增加一页
            m_cbupdateitem(currentNum, addNum);
        }
        currentNum = currentNum + addNum;

        //mScrollItemNumChanged = (addNum > 0);
    }

    #endregion

    int m_ncha = 20;  //由于用坐标计算页数 无法控制精准 最大允许的误差 在20以内 切页

    protected virtual void OnMove(Vector2 v2)
    {

        //int i = 1;
        //int num = 0;
        int result = 0;
        if (mHorizontal)
        {
            //当前位置 - 零点位置 等于偏移位置  width初始值为0 即没有偏移 往右滑x会逐渐增大  这里用的是局部坐标不同于UGUI显示的xyz
            int width = Mathf.Abs((int)transform.localPosition.x) - Mathf.Abs((int)mZero.x);
            int c = mRectOff / 2;
            result = width / c;
            if (mRectOff - width % c < m_ncha)
            {
                result += 1;
            }
            if (result == 0)
            {
                result = 1;
            }
            else
            {
                result = (result + 1) / 2 + 1;
            }
        }
        //Debug.Log("i:" + i + ",transform.localPosition.x:" + transform.localPosition.x + ",mRectOff:" + Mathf.Abs((int)mRectOff));
        if (result != mCurPageNum)
        {
            if (mHorizontal)
            {
                mCurPageNum = result;
            }
            else
            {

            }

            UpdatePage();
        }

    }

    private void RectOnEndDrag(PointerEventData data)
    {
        if (currentNum < mTotalNum && mCurPageNum == mMaxPageNum)
        {
            //Debug.Log("该添加页了");
            AddPage();
        }
    }

    private void UpdatePage()
    {
        if (mCurPageNum > mShowMaxPage) mCurPageNum = mShowMaxPage;
        mTextPageNum.text = mCurPageNum + "/" + mShowMaxPage;
    }

}
