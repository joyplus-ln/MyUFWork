﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_TextAnchorWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UnityEngine.TextAnchor));
		L.RegVar("UpperLeft", new LuaCSFunction(get_UpperLeft), null);
		L.RegVar("UpperCenter", new LuaCSFunction(get_UpperCenter), null);
		L.RegVar("UpperRight", new LuaCSFunction(get_UpperRight), null);
		L.RegVar("MiddleLeft", new LuaCSFunction(get_MiddleLeft), null);
		L.RegVar("MiddleCenter", new LuaCSFunction(get_MiddleCenter), null);
		L.RegVar("MiddleRight", new LuaCSFunction(get_MiddleRight), null);
		L.RegVar("LowerLeft", new LuaCSFunction(get_LowerLeft), null);
		L.RegVar("LowerCenter", new LuaCSFunction(get_LowerCenter), null);
		L.RegVar("LowerRight", new LuaCSFunction(get_LowerRight), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(IntToEnum));
		L.EndEnum();
		TypeTraits<UnityEngine.TextAnchor>.Check = CheckType;
		StackTraits<UnityEngine.TextAnchor>.Push = Push;
	}

	static void Push(IntPtr L, UnityEngine.TextAnchor arg)
	{
		ToLua.Push(L, arg);
	}

	static Type TypeOf_UnityEngine_TextAnchor = typeof(UnityEngine.TextAnchor);

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(TypeOf_UnityEngine_TextAnchor, L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UpperLeft(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.TextAnchor.UpperLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UpperCenter(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.TextAnchor.UpperCenter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UpperRight(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.TextAnchor.UpperRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MiddleLeft(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.TextAnchor.MiddleLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MiddleCenter(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.TextAnchor.MiddleCenter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MiddleRight(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.TextAnchor.MiddleRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LowerLeft(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.TextAnchor.LowerLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LowerCenter(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.TextAnchor.LowerCenter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LowerRight(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.TextAnchor.LowerRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tointeger(L, 1);
		UnityEngine.TextAnchor o = (UnityEngine.TextAnchor)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}
