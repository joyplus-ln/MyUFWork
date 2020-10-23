﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UGUIConfig
{
    private static Canvas uiCanvas;
    public static Canvas UICanvas
    {
        get { return UGUIConfig.uiCanvas; }
        set { UGUIConfig.uiCanvas = value; }
    }

    public static Dictionary<WndType, Canvas> canvasList;

    public static Dictionary<WndType, Camera> cameraList;

    private static Camera uiCamera;
    public static Camera UICamera
    {
        get { return UGUIConfig.uiCamera; }
        set { UGUIConfig.uiCamera = value; }
    }

    private static EventSystem eventSystem;
    public static EventSystem EventSystem
    {
        get { return eventSystem; }
        set { eventSystem = value; }
    }

    public static int designWidth = 960;
    public static int designHeight = 640;
    public static float widthHeightRadio = 1.5f;

    /*
    public static int DeviceWidth
    {
        get { return deviceWidth; }
    }

    public static int DeviceHeight
    {
        get { return deviceHeight; }
    }
    */

    private static int mUISpaceW;
    private static int mUISpaceH;

    private static int mScreenW;
    private static int mScreenH;
    
    private static int mZoneViewportW;
    private static int mZoneViewportH;

    public static int UISpaceWidth
    {
        get { return mUISpaceW; }
    }

    public static int UISpaceHeight
    {
        get { return mUISpaceH; }
    }

    public static int ScreenWidth
    {
        get { return mScreenW; }
    }

    public static int ScreenHeight
    {
        get { return mScreenH; }
    }
    
    public static int ZoneViewportWidth
    {
        get { return mZoneViewportW; }
    }
    
    public static int ZoneViewportHeight
    {
        get { return mZoneViewportH; }
    }
    
    public static Transform InvisibleTransform { get; private set; }

    //private static int deviceWidth;
    //private static int deviceHeight;

    public static void init()
    {
        Canvas uicanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        UICanvas = (uicanvas);

        Camera uicamera = GameObject.Find("Canvas/UICamera").GetComponent<Camera>();
        UICamera = uicamera;
        //创建每一层的canvas
        Vector2 anchorMin = Vector2.zero;
        Vector2 anchorMax = Vector2.zero;
        Vector2 offsetMin = Vector2.zero;
        Vector2 offsetMax = Vector2.zero;
        Array wndTypes = Enum.GetValues(typeof(WndType));
        
        foreach(WndType wndType in wndTypes)
        {
            if (canvasList == null)
            {
                canvasList = new Dictionary<WndType, Canvas>();
            }
            if (cameraList == null)
            {
                cameraList = new Dictionary<WndType, Camera>();
            }
            Canvas cv;

            if (wndType == WndType.MAINUI)
            {
                cv = uiCanvas;
                anchorMin = cv.GetComponent<RectTransform>().anchorMin;
                anchorMax = cv.GetComponent<RectTransform>().anchorMax;
                offsetMin = cv.GetComponent<RectTransform>().offsetMin;
                offsetMax = cv.GetComponent<RectTransform>().offsetMax;
                //cv.renderMode = RenderMode.ScreenSpaceCamera;
                cv.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
                cv.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            else
            {
                cv = GameObject.Instantiate(uiCanvas);
                cv.name = "wndCanvas_" + wndType;
                //cv.renderMode = RenderMode.ScreenSpaceCamera;
                //cv.sortingOrder = i;
                GameObject.DontDestroyOnLoad(cv);
                /*
                Transform defaultImage = cv.transform.FindChild("DefaultImage");
                if (defaultImage != null)
                {
                    GameObject.DestroyImmediate(defaultImage.gameObject, true);
                    defaultImage = null;
                }
                */
                cv.GetComponent<RectTransform>().anchorMin = anchorMin;
                cv.GetComponent<RectTransform>().anchorMax = anchorMax;
                cv.GetComponent<RectTransform>().offsetMin = offsetMin;
                cv.GetComponent<RectTransform>().offsetMax = offsetMax;
                cv.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
                cv.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                cv.GetComponent<RectTransform>().sizeDelta = new Vector2(UGUIConfig.designWidth, UGUIConfig.designHeight);
                cv.transform.localScale = uicanvas.transform.localScale;
            }
            cv.gameObject.layer = LayerConfig.MainUI + (int)wndType;
            cv.pixelPerfect = false;
            Camera ca = cv.GetComponentInChildren<Camera>();
            if (wndType != WndType.MAINUI)
            {
                ca.orthographicSize = uicamera.orthographicSize;
                if (wndType == WndType.BUBBLES)
                {
                    CanvasGroup cvGroup = cv.gameObject.AddComponent<CanvasGroup>();
                    cvGroup.interactable = false;
                    cvGroup.blocksRaycasts = false;
                }
            }
            //ca.nearClipPlane = -10;
            //ca.farClipPlane = 10;
            ca.gameObject.layer = LayerConfig.MainUI + (int)wndType;
            //ca.cullingMask = 0;
            //ca.cullingMask = (int)Math.Pow(2, (double)ca.gameObject.layer);
            ca.cullingMask = 1 << ca.gameObject.layer;
            ca.depth = (int)wndType + 2;
            Vector3 v3 = cv.GetComponent<RectTransform>().anchoredPosition3D;
            v3.z = -((int)wndType) * ClientConstantDef.PER_LAYER_Z_DEPTH;
            cv.GetComponent<RectTransform>().anchoredPosition3D = v3;
            canvasList.Add(wndType, cv);
            cameraList.Add(wndType, ca);
            
            if (wndType == WndType.INVISIBLE)
            {
                ca.cullingMask = 0;
                ca.gameObject.SetActive(false);
                cv.gameObject.GetComponent<GraphicRaycaster>().enabled = false;
                //cv.gameObject.SetActive(false);
                InvisibleTransform = cv.gameObject.transform;
            }
        }
        RectTransform sizerLT = GameObject.Find("InitCanvas/ScreenSizer/LT").GetComponent<RectTransform>();
        RectTransform sizerLB = GameObject.Find("InitCanvas/ScreenSizer/LB").GetComponent<RectTransform>();
        RectTransform sizerRB = GameObject.Find("InitCanvas/ScreenSizer/RB").GetComponent<RectTransform>();

        mUISpaceW = (int)(sizerRB.localPosition.x - sizerLB.localPosition.x);
        mUISpaceH = (int)(sizerLT.localPosition.y - sizerLB.localPosition.y);
        
        mScreenW = Screen.width;
        mScreenH = Screen.height;
        
        mZoneViewportH = 10 * app.zone.ZoneDef.MAP_PIXEL_ONE_UNIT;
        mZoneViewportW = (int)(mZoneViewportH * ((float)mUISpaceW / (float)mUISpaceH));
        GameSimpleEventCore.ins.DispatchEvent("init_screen_size", new int[]{mZoneViewportW, mZoneViewportH});
        
        /*
        deviceWidth = (int)Mathf.Max(Screen.width, Screen.height);
        deviceHeight = (int)Mathf.Min(Screen.width, Screen.height);
        float devicef = (deviceWidth * 1.0f / deviceHeight * 1.0f);
        if (devicef > widthHeightRadio)
        {
            screenWidth = deviceWidth;
            screenHeight = (int)(deviceWidth / widthHeightRadio * 1.0f);
        }
        else
        {
            screenWidth = (int)(widthHeightRadio * deviceHeight * 1.0f);
            screenHeight = deviceHeight;
        }
        */
    }
    
    public static void Destroy()
    {
        Array wndTypes = Enum.GetValues(typeof(WndType));
        
        foreach(WndType wndType in wndTypes)
        {
            GameObject.DestroyImmediate(cameraList[wndType].gameObject, true);
            GameObject.DestroyImmediate(canvasList[wndType].gameObject, true);
        }
        cameraList.Clear();
        canvasList.Clear();
    }

    public static Canvas GetCanvasByWndType(WndType wndtype)
    {
        if (canvasList != null)
        {
            Canvas cv = null;
            canvasList.TryGetValue(wndtype, out cv);
            return cv;
        }
        return null;
    }

    public static Camera GetCameraByWndType(WndType wndtype)
    {
        if (cameraList != null)
        {
            Camera ca = null;
            cameraList.TryGetValue(wndtype, out ca);
            return ca;
        }
        return null;
    }

    /// <summary>
    /// 获得当前是否点击在UI上
    /// </summary>
    /// <returns></returns>
    public static bool IsPointUI()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.Android:
                if (Input.touchCount > 0)
                {
                    return EventSystem.current!=null&&EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
                };
                break;
            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.WindowsEditor:
                return EventSystem.current!=null&&EventSystem.current.IsPointerOverGameObject();
            default:
                return false;
        }
        return false;
    }

    /// <summary>
    /// 显示三个相机
    /// </summary>
    public static void ShowSanCamers()
    {
        Camera temp = null;
        if (cameraList.TryGetValue(WndType.FirstWND,out temp))
        {
            temp.gameObject.SetActive(true);
        }
        if (cameraList.TryGetValue(WndType.SecondWND, out temp))
        {
            temp.gameObject.SetActive(true);
        }
        if (cameraList.TryGetValue(WndType.PopWND, out temp))
        {
            temp.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 隐藏三个相机
    /// </summary>
    public static void HideSanCamers()
    {
        Camera temp = null;
        if (cameraList.TryGetValue(WndType.FirstWND, out temp))
        {
            temp.gameObject.SetActive(false);
        }
        if (cameraList.TryGetValue(WndType.SecondWND, out temp))
        {
            temp.gameObject.SetActive(false);
        }
        if (cameraList.TryGetValue(WndType.PopWND, out temp))
        {
            temp.gameObject.SetActive(false);
        }
    }

    //public static bool CheckGuiRaycastObjects()
    //{
    //    PointerEventData eventData = new PointerEventData(Main.Instance.eventSystem);
    //    eventData.pressPosition = Input.mousePosition;
    //    eventData.position = Input.mousePosition;
    //    List<RaycastResult> list = new List<RaycastResult>();
    //    Main.Instance.graphicRaycaster.Raycast(eventData,list); 
    //    //ClientLog.Log(list.Count); 
    //    return list.Count > 0;
    //}

    /*
    /// <summary>
    /// //移除默认的图片
    /// </summary>
    public static void RemoveGameDefaultImage()
    {
        if (canvasList == null)
        {
            return;
        }
        foreach (KeyValuePair<WndType, Canvas> pair in canvasList)
        {
            Transform defaultImage = pair.Value.transform.FindChild("DefaultImage");
            if (defaultImage != null)
            {
                GameObject.DestroyImmediate(defaultImage.gameObject, true);
                defaultImage = null;
            }
        }
    }
    */
}