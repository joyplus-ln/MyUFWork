﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_Rendering_LightShadowResolutionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UnityEngine.Rendering.LightShadowResolution));
		L.RegVar("FromQualitySettings", new LuaCSFunction(get_FromQualitySettings), null);
		L.RegVar("Low", new LuaCSFunction(get_Low), null);
		L.RegVar("Medium", new LuaCSFunction(get_Medium), null);
		L.RegVar("High", new LuaCSFunction(get_High), null);
		L.RegVar("VeryHigh", new LuaCSFunction(get_VeryHigh), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(IntToEnum));
		L.EndEnum();
		TypeTraits<UnityEngine.Rendering.LightShadowResolution>.Check = CheckType;
		StackTraits<UnityEngine.Rendering.LightShadowResolution>.Push = Push;
	}

	static void Push(IntPtr L, UnityEngine.Rendering.LightShadowResolution arg)
	{
		ToLua.Push(L, arg);
	}

	static Type TypeOf_UnityEngine_Rendering_LightShadowResolution = typeof(UnityEngine.Rendering.LightShadowResolution);

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(TypeOf_UnityEngine_Rendering_LightShadowResolution, L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FromQualitySettings(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Rendering.LightShadowResolution.FromQualitySettings);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Low(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Rendering.LightShadowResolution.Low);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Medium(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Rendering.LightShadowResolution.Medium);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_High(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Rendering.LightShadowResolution.High);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_VeryHigh(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Rendering.LightShadowResolution.VeryHigh);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tointeger(L, 1);
		UnityEngine.Rendering.LightShadowResolution o = (UnityEngine.Rendering.LightShadowResolution)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}
