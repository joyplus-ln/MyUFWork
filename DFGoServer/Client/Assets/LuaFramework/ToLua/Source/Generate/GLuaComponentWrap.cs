﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GLuaComponentWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GLuaComponent), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("Add", new LuaCSFunction(Add));
		L.RegFunction("Get", new LuaCSFunction(Get));
		L.RegFunction("AddClick", new LuaCSFunction(AddClick));
		L.RegFunction("RemoveClick", new LuaCSFunction(RemoveClick));
		L.RegFunction("ClearClick", new LuaCSFunction(ClearClick));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("table", new LuaCSFunction(get_table), new LuaCSFunction(set_table));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject<UnityEngine.GameObject>(L, 1);
			LuaTable arg1 = ToLua.CheckLuaTable(L, 2);
			LuaInterface.LuaTable o = GLuaComponent.Add(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject<UnityEngine.GameObject>(L, 1);
			LuaTable arg1 = ToLua.CheckLuaTable(L, 2);
			LuaInterface.LuaTable o = GLuaComponent.Get(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GLuaComponent obj = (GLuaComponent)ToLua.CheckObject<GLuaComponent>(L, 1);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject<UnityEngine.GameObject>(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			obj.AddClick(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveClick(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GLuaComponent obj = (GLuaComponent)ToLua.CheckObject<GLuaComponent>(L, 1);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject<UnityEngine.GameObject>(L, 2);
			obj.RemoveClick(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearClick(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GLuaComponent obj = (GLuaComponent)ToLua.CheckObject<GLuaComponent>(L, 1);
			obj.ClearClick();
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
	static int get_table(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GLuaComponent obj = (GLuaComponent)o;
			LuaInterface.LuaTable ret = obj.table;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index table on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_table(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GLuaComponent obj = (GLuaComponent)o;
			LuaTable arg0 = ToLua.CheckLuaTable(L, 2);
			obj.table = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index table on a nil value");
		}
	}
}
