﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class DG_Tweening_Core_TweenerCore_string_string_DG_Tweening_Plugins_Options_StringOptionsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>), typeof(DG.Tweening.Tweener), "TweenerCore_string_string_DG_Tweening_Plugins_Options_StringOptions");
		L.RegFunction("ChangeStartValue", new LuaCSFunction(ChangeStartValue));
		L.RegFunction("ChangeEndValue", new LuaCSFunction(ChangeEndValue));
		L.RegFunction("ChangeValues", new LuaCSFunction(ChangeValues));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("startValue", new LuaCSFunction(get_startValue), new LuaCSFunction(set_startValue));
		L.RegVar("endValue", new LuaCSFunction(get_endValue), new LuaCSFunction(set_endValue));
		L.RegVar("changeValue", new LuaCSFunction(get_changeValue), new LuaCSFunction(set_changeValue));
		L.RegVar("plugOptions", new LuaCSFunction(get_plugOptions), new LuaCSFunction(set_plugOptions));
		L.RegVar("getter", new LuaCSFunction(get_getter), new LuaCSFunction(set_getter));
		L.RegVar("setter", new LuaCSFunction(get_setter), new LuaCSFunction(set_setter));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeStartValue(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<string>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> o = obj.ChangeStartValue(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<object>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				object arg0 = ToLua.ToVarObject(L, 2);
				DG.Tweening.Tweener o = obj.ChangeStartValue(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, float>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> o = obj.ChangeStartValue(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<object, float>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				object arg0 = ToLua.ToVarObject(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				DG.Tweening.Tweener o = obj.ChangeStartValue(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>.ChangeStartValue");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeEndValue(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<string>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> o = obj.ChangeEndValue(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<object>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				object arg0 = ToLua.ToVarObject(L, 2);
				DG.Tweening.Tweener o = obj.ChangeEndValue(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, bool>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				bool arg1 = LuaDLL.lua_toboolean(L, 3);
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> o = obj.ChangeEndValue(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, float>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> o = obj.ChangeEndValue(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<object, bool>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				object arg0 = ToLua.ToVarObject(L, 2);
				bool arg1 = LuaDLL.lua_toboolean(L, 3);
				DG.Tweening.Tweener o = obj.ChangeEndValue(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<object, float>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				object arg0 = ToLua.ToVarObject(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				DG.Tweening.Tweener o = obj.ChangeEndValue(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<string, float, bool>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				bool arg2 = LuaDLL.lua_toboolean(L, 4);
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> o = obj.ChangeEndValue(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<object, float, bool>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				object arg0 = ToLua.ToVarObject(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				bool arg2 = LuaDLL.lua_toboolean(L, 4);
				DG.Tweening.Tweener o = obj.ChangeEndValue(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>.ChangeEndValue");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeValues(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3 && TypeChecker.CheckTypes<string, string>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				string arg1 = ToLua.ToString(L, 3);
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> o = obj.ChangeValues(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<object, object>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				object arg0 = ToLua.ToVarObject(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				DG.Tweening.Tweener o = obj.ChangeValues(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<string, string, float>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				string arg1 = ToLua.ToString(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> o = obj.ChangeValues(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<object, object, float>(L, 2))
			{
				DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)ToLua.CheckObject<DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>>(L, 1);
				object arg0 = ToLua.ToVarObject(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				DG.Tweening.Tweener o = obj.ChangeValues(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>.ChangeValues");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			string ret = obj.startValue;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index startValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_endValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			string ret = obj.endValue;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index endValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_changeValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			string ret = obj.changeValue;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index changeValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_plugOptions(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			DG.Tweening.Plugins.Options.StringOptions ret = obj.plugOptions;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index plugOptions on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_getter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			DG.Tweening.Core.DOGetter<string> ret = obj.getter;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index getter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_setter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			DG.Tweening.Core.DOSetter<string> ret = obj.setter;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index setter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.startValue = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index startValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_endValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.endValue = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index endValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_changeValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.changeValue = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index changeValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_plugOptions(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			DG.Tweening.Plugins.Options.StringOptions arg0 = StackTraits<DG.Tweening.Plugins.Options.StringOptions>.Check(L, 2);
			obj.plugOptions = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index plugOptions on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_getter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			DG.Tweening.Core.DOGetter<string> arg0 = (DG.Tweening.Core.DOGetter<string>)ToLua.CheckDelegate<DG.Tweening.Core.DOGetter<string>>(L, 2);

			if (!object.ReferenceEquals(obj.getter, arg0))
			{
				if (obj.getter != null) obj.getter.SubRef();
				obj.getter = arg0;
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index getter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_setter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions> obj = (DG.Tweening.Core.TweenerCore<string,string,DG.Tweening.Plugins.Options.StringOptions>)o;
			DG.Tweening.Core.DOSetter<string> arg0 = (DG.Tweening.Core.DOSetter<string>)ToLua.CheckDelegate<DG.Tweening.Core.DOSetter<string>>(L, 2);

			if (!object.ReferenceEquals(obj.setter, arg0))
			{
				if (obj.setter != null) obj.setter.SubRef();
				obj.setter = arg0;
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index setter on a nil value");
		}
	}
}
