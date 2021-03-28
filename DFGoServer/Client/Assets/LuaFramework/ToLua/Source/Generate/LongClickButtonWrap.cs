﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LongClickButtonWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LongClickButton), typeof(UnityEngine.UI.Button));
		L.RegFunction("OnPointerDown", new LuaCSFunction(OnPointerDown));
		L.RegFunction("OnPointerUp", new LuaCSFunction(OnPointerUp));
		L.RegFunction("OnPointerExit", new LuaCSFunction(OnPointerExit));
		L.RegFunction("OnPointerClick", new LuaCSFunction(OnPointerClick));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Delay", new LuaCSFunction(get_Delay), new LuaCSFunction(set_Delay));
		L.RegVar("OnLongClickDown", new LuaCSFunction(get_OnLongClickDown), new LuaCSFunction(set_OnLongClickDown));
		L.RegVar("OnLongClickUp", new LuaCSFunction(get_OnLongClickUp), new LuaCSFunction(set_OnLongClickUp));
		L.RegVar("OnLongClickExit", new LuaCSFunction(get_OnLongClickExit), new LuaCSFunction(set_OnLongClickExit));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerDown(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LongClickButton obj = (LongClickButton)ToLua.CheckObject<LongClickButton>(L, 1);
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject<UnityEngine.EventSystems.PointerEventData>(L, 2);
			obj.OnPointerDown(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerUp(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LongClickButton obj = (LongClickButton)ToLua.CheckObject<LongClickButton>(L, 1);
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject<UnityEngine.EventSystems.PointerEventData>(L, 2);
			obj.OnPointerUp(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerExit(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LongClickButton obj = (LongClickButton)ToLua.CheckObject<LongClickButton>(L, 1);
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject<UnityEngine.EventSystems.PointerEventData>(L, 2);
			obj.OnPointerExit(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerClick(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LongClickButton obj = (LongClickButton)ToLua.CheckObject<LongClickButton>(L, 1);
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject<UnityEngine.EventSystems.PointerEventData>(L, 2);
			obj.OnPointerClick(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Delay(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LongClickButton obj = (LongClickButton)o;
			float ret = obj.Delay;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Delay on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnLongClickDown(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LongClickButton obj = (LongClickButton)o;
			LongClickButton.LongClickEvent ret = obj.OnLongClickDown;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index OnLongClickDown on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnLongClickUp(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LongClickButton obj = (LongClickButton)o;
			LongClickButton.LongClickEventEx ret = obj.OnLongClickUp;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index OnLongClickUp on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnLongClickExit(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LongClickButton obj = (LongClickButton)o;
			LongClickButton.LongClickEvent ret = obj.OnLongClickExit;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index OnLongClickExit on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Delay(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LongClickButton obj = (LongClickButton)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.Delay = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Delay on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnLongClickDown(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LongClickButton obj = (LongClickButton)o;
			LongClickButton.LongClickEvent arg0 = (LongClickButton.LongClickEvent)ToLua.CheckObject<LongClickButton.LongClickEvent>(L, 2);
			obj.OnLongClickDown = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index OnLongClickDown on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnLongClickUp(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LongClickButton obj = (LongClickButton)o;
			LongClickButton.LongClickEventEx arg0 = (LongClickButton.LongClickEventEx)ToLua.CheckObject<LongClickButton.LongClickEventEx>(L, 2);
			obj.OnLongClickUp = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index OnLongClickUp on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnLongClickExit(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LongClickButton obj = (LongClickButton)o;
			LongClickButton.LongClickEvent arg0 = (LongClickButton.LongClickEvent)ToLua.CheckObject<LongClickButton.LongClickEvent>(L, 2);
			obj.OnLongClickExit = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index OnLongClickExit on a nil value");
		}
	}
}
