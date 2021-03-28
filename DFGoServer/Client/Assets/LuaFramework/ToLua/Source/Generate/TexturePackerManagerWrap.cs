﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class TexturePackerManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TexturePackerManager), typeof(System.Object));
		L.RegFunction("GetInstance", new LuaCSFunction(GetInstance));
		L.RegFunction("Init", new LuaCSFunction(Init));
		L.RegFunction("AddPathAndComplete", new LuaCSFunction(AddPathAndComplete));
		L.RegFunction("AddPath", new LuaCSFunction(AddPath));
		L.RegFunction("RemovePath", new LuaCSFunction(RemovePath));
		L.RegFunction("ClearPath", new LuaCSFunction(ClearPath));
		L.RegFunction("CreateAssetPacker", new LuaCSFunction(CreateAssetPacker));
		L.RegFunction("GetSprite", new LuaCSFunction(GetSprite));
		L.RegFunction("New", new LuaCSFunction(_CreateTexturePackerManager));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegFunction("OnAssetPackCompleteDelegate", new LuaCSFunction(TexturePackerManager_OnAssetPackCompleteDelegate));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTexturePackerManager(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				TexturePackerManager obj = new TexturePackerManager();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: TexturePackerManager.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			TexturePackerManager o = TexturePackerManager.GetInstance();
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
			obj.Init();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddPathAndComplete(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string[] arg1 = ToLua.CheckStringArray(L, 3);
				obj.AddPathAndComplete(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string[] arg1 = ToLua.CheckStringArray(L, 3);
				TexturePackerManager.OnAssetPackCompleteDelegate arg2 = (TexturePackerManager.OnAssetPackCompleteDelegate)ToLua.CheckDelegate<TexturePackerManager.OnAssetPackCompleteDelegate>(L, 4);
				obj.AddPathAndComplete(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5)
			{
				TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string[] arg1 = ToLua.CheckStringArray(L, 3);
				TexturePackerManager.OnAssetPackCompleteDelegate arg2 = (TexturePackerManager.OnAssetPackCompleteDelegate)ToLua.CheckDelegate<TexturePackerManager.OnAssetPackCompleteDelegate>(L, 4);
				bool arg3 = LuaDLL.luaL_checkboolean(L, 5);
				obj.AddPathAndComplete(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: TexturePackerManager.AddPathAndComplete");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddPath(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			obj.AddPath(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemovePath(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			obj.RemovePath(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearPath(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.ClearPath(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateAssetPacker(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				obj.CreateAssetPacker(arg0);
				return 0;
			}
			else if (count == 3)
			{
				TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				TexturePackerManager.OnAssetPackCompleteDelegate arg1 = (TexturePackerManager.OnAssetPackCompleteDelegate)ToLua.CheckDelegate<TexturePackerManager.OnAssetPackCompleteDelegate>(L, 3);
				obj.CreateAssetPacker(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				TexturePackerManager.OnAssetPackCompleteDelegate arg1 = (TexturePackerManager.OnAssetPackCompleteDelegate)ToLua.CheckDelegate<TexturePackerManager.OnAssetPackCompleteDelegate>(L, 3);
				bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
				obj.CreateAssetPacker(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: TexturePackerManager.CreateAssetPacker");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSprite(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			TexturePackerManager obj = (TexturePackerManager)ToLua.CheckObject<TexturePackerManager>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			UnityEngine.Sprite o = obj.GetSprite(arg0, arg1);
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TexturePackerManager_OnAssetPackCompleteDelegate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<TexturePackerManager.OnAssetPackCompleteDelegate>.Create(func);
				ToLua.Push(L, arg1);
				func.Dispose();
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<TexturePackerManager.OnAssetPackCompleteDelegate>.Create(func, self);
				ToLua.Push(L, arg1);
				func.Dispose();
				self.Dispose();
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}
