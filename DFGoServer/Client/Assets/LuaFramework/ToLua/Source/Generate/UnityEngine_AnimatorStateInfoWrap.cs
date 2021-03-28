﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_AnimatorStateInfoWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AnimatorStateInfo), null);
		L.RegFunction("IsName", new LuaCSFunction(IsName));
		L.RegFunction("IsTag", new LuaCSFunction(IsTag));
		L.RegFunction("New", new LuaCSFunction(_CreateUnityEngine_AnimatorStateInfo));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("fullPathHash", new LuaCSFunction(get_fullPathHash), null);
		L.RegVar("shortNameHash", new LuaCSFunction(get_shortNameHash), null);
		L.RegVar("normalizedTime", new LuaCSFunction(get_normalizedTime), null);
		L.RegVar("length", new LuaCSFunction(get_length), null);
		L.RegVar("speed", new LuaCSFunction(get_speed), null);
		L.RegVar("speedMultiplier", new LuaCSFunction(get_speedMultiplier), null);
		L.RegVar("tagHash", new LuaCSFunction(get_tagHash), null);
		L.RegVar("loop", new LuaCSFunction(get_loop), null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_AnimatorStateInfo(IntPtr L)
	{
		UnityEngine.AnimatorStateInfo obj = new UnityEngine.AnimatorStateInfo();
		ToLua.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsName(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)ToLua.CheckObject(L, 1, TypeTraits<UnityEngine.AnimatorStateInfo>.type);
			string arg0 = ToLua.CheckString(L, 2);
			bool o = obj.IsName(arg0);
			LuaDLL.lua_pushboolean(L, o);
			ToLua.SetBack(L, 1, obj);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsTag(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)ToLua.CheckObject(L, 1, TypeTraits<UnityEngine.AnimatorStateInfo>.type);
			string arg0 = ToLua.CheckString(L, 2);
			bool o = obj.IsTag(arg0);
			LuaDLL.lua_pushboolean(L, o);
			ToLua.SetBack(L, 1, obj);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fullPathHash(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)o;
			int ret = obj.fullPathHash;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fullPathHash on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shortNameHash(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)o;
			int ret = obj.shortNameHash;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index shortNameHash on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_normalizedTime(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)o;
			float ret = obj.normalizedTime;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index normalizedTime on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_length(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)o;
			float ret = obj.length;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index length on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_speed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)o;
			float ret = obj.speed;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index speed on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_speedMultiplier(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)o;
			float ret = obj.speedMultiplier;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index speedMultiplier on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tagHash(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)o;
			int ret = obj.tagHash;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index tagHash on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loop(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimatorStateInfo obj = (UnityEngine.AnimatorStateInfo)o;
			bool ret = obj.loop;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index loop on a nil value");
		}
	}
}
