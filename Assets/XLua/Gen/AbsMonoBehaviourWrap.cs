#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class AbsMonoBehaviourWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(AbsMonoBehaviour);
			Utils.BeginObjectRegister(type, L, translator, 0, 38, 7, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CopyFrom", _m_CopyFrom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clone", _m_Clone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ModifyGlobalId", _m_ModifyGlobalId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Recycle", _m_Recycle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExportSerializable", _m_ExportSerializable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ImportSerializable", _m_ImportSerializable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "isStatus", _m_isStatus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToggleStatus", _m_ToggleStatus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExportSynchronize", _m_ExportSynchronize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ImportSynchronize", _m_ImportSynchronize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToggleTimeScale", _m_ToggleTimeScale);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SyncTimeScale", _m_SyncTimeScale);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadXLua", _m_LoadXLua);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeClone", _e_OnBeforeClone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterClone", _e_OnAfterClone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeCopyFrom", _e_OnBeforeCopyFrom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterCopyFrom", _e_OnAfterCopyFrom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeDisposing", _e_OnBeforeDisposing);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterDisposing", _e_OnAfterDisposing);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeModifyGlobalId", _e_OnBeforeModifyGlobalId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterModifyGlobalId", _e_OnAfterModifyGlobalId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeRecycle", _e_OnBeforeRecycle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterRecycle", _e_OnAfterRecycle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeExportSerializable", _e_OnBeforeExportSerializable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterExportSerializable", _e_OnAfterExportSerializable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeImportSerializable", _e_OnBeforeImportSerializable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterImportSerializable", _e_OnAfterImportSerializable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeToggleStatus", _e_OnBeforeToggleStatus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterToggleStatus", _e_OnAfterToggleStatus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeExportSynchronize", _e_OnBeforeExportSynchronize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterExportSynchronize", _e_OnAfterExportSynchronize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeImportSynchronize", _e_OnBeforeImportSynchronize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterImportSynchronize", _e_OnAfterImportSynchronize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeToggleTimeScale", _e_OnBeforeToggleTimeScale);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterToggleTimeScale", _e_OnAfterToggleTimeScale);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeSyncTimeScale", _e_OnBeforeSyncTimeScale);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterSyncTimeScale", _e_OnAfterSyncTimeScale);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "globalId", _g_get_globalId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "currentStatus", _g_get_currentStatus);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "deltaTime", _g_get_deltaTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "time", _g_get_time);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fixedDeltaTime", _g_get_fixedDeltaTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fixedTime", _g_get_fixedTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isIgnoreTimeScale", _g_get_isIgnoreTimeScale);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "AbsMonoBehaviour does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CopyFrom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IClone __from = (IClone)translator.GetObject(L, 2, typeof(IClone));
                    
                    gen_to_be_invoked.CopyFrom( __from );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        object gen_ret = gen_to_be_invoked.Clone(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ModifyGlobalId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int __toId = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.ModifyGlobalId( __toId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Recycle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.Recycle(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float __delay = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.Recycle( __delay );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.Recycle!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExportSerializable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        byte[] gen_ret = gen_to_be_invoked.ExportSerializable(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ImportSerializable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] __data = LuaAPI.lua_tobytes(L, 2);
                    long __startIndex = LuaAPI.lua_toint64(L, 3);
                    
                        long gen_ret = gen_to_be_invoked.ImportSerializable( __data, __startIndex );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_isStatus(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int __status = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.isStatus( __status );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToggleStatus(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int __destStatus = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.ToggleStatus( __destStatus );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int __destStatus = LuaAPI.xlua_tointeger(L, 2);
                    float __delay = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.ToggleStatus( __destStatus, __delay );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.ToggleStatus!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExportSynchronize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        byte[] gen_ret = gen_to_be_invoked.ExportSynchronize(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ImportSynchronize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] __data = LuaAPI.lua_tobytes(L, 2);
                    long __startIndex = LuaAPI.lua_toint64(L, 3);
                    
                        long gen_ret = gen_to_be_invoked.ImportSynchronize( __data, __startIndex );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToggleTimeScale(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool __isIgnoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.ToggleTimeScale( __isIgnoreTimeScale );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SyncTimeScale(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ITime __syncTime = (ITime)translator.GetObject(L, 2, typeof(ITime));
                    
                    gen_to_be_invoked.SyncTimeScale( __syncTime );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadXLua(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<LoadXLuaResult> __onComplete = translator.GetDelegate<System.Action<LoadXLuaResult>>(L, 2);
                    
                    gen_to_be_invoked.LoadXLua( __onComplete );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_globalId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.globalId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_currentStatus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.currentStatus);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_deltaTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.deltaTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_time(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.time);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fixedDeltaTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.fixedDeltaTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fixedTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.fixedTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isIgnoreTimeScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isIgnoreTimeScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeClone(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerClone gen_delegate = translator.GetDelegate<EventHandlerClone>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerClone!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeClone += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeClone -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeClone!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterClone(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerClone gen_delegate = translator.GetDelegate<EventHandlerClone>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerClone!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterClone += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterClone -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterClone!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeCopyFrom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerCopyFrom gen_delegate = translator.GetDelegate<EventHandlerCopyFrom>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerCopyFrom!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeCopyFrom += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeCopyFrom -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeCopyFrom!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterCopyFrom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerCopyFrom gen_delegate = translator.GetDelegate<EventHandlerCopyFrom>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerCopyFrom!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterCopyFrom += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterCopyFrom -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterCopyFrom!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeDisposing(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerDispose gen_delegate = translator.GetDelegate<EventHandlerDispose>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerDispose!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeDisposing += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeDisposing -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeDisposing!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterDisposing(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerDispose gen_delegate = translator.GetDelegate<EventHandlerDispose>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerDispose!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterDisposing += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterDisposing -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterDisposing!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeModifyGlobalId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerModifyGlobalId gen_delegate = translator.GetDelegate<EventHandlerModifyGlobalId>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerModifyGlobalId!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeModifyGlobalId += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeModifyGlobalId -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeModifyGlobalId!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterModifyGlobalId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerModifyGlobalId gen_delegate = translator.GetDelegate<EventHandlerModifyGlobalId>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerModifyGlobalId!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterModifyGlobalId += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterModifyGlobalId -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterModifyGlobalId!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeRecycle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerRecycle gen_delegate = translator.GetDelegate<EventHandlerRecycle>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerRecycle!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeRecycle += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeRecycle -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeRecycle!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterRecycle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerRecycle gen_delegate = translator.GetDelegate<EventHandlerRecycle>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerRecycle!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterRecycle += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterRecycle -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterRecycle!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeExportSerializable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerExportSerializable gen_delegate = translator.GetDelegate<EventHandlerExportSerializable>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerExportSerializable!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeExportSerializable += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeExportSerializable -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeExportSerializable!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterExportSerializable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerExportSerializable gen_delegate = translator.GetDelegate<EventHandlerExportSerializable>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerExportSerializable!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterExportSerializable += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterExportSerializable -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterExportSerializable!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeImportSerializable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerImportSerializable gen_delegate = translator.GetDelegate<EventHandlerImportSerializable>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerImportSerializable!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeImportSerializable += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeImportSerializable -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeImportSerializable!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterImportSerializable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerImportSerializable gen_delegate = translator.GetDelegate<EventHandlerImportSerializable>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerImportSerializable!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterImportSerializable += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterImportSerializable -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterImportSerializable!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeToggleStatus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerToggleStatus gen_delegate = translator.GetDelegate<EventHandlerToggleStatus>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerToggleStatus!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeToggleStatus += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeToggleStatus -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeToggleStatus!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterToggleStatus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerToggleStatus gen_delegate = translator.GetDelegate<EventHandlerToggleStatus>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerToggleStatus!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterToggleStatus += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterToggleStatus -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterToggleStatus!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeExportSynchronize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerExportSynchronize gen_delegate = translator.GetDelegate<EventHandlerExportSynchronize>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerExportSynchronize!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeExportSynchronize += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeExportSynchronize -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeExportSynchronize!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterExportSynchronize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerExportSynchronize gen_delegate = translator.GetDelegate<EventHandlerExportSynchronize>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerExportSynchronize!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterExportSynchronize += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterExportSynchronize -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterExportSynchronize!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeImportSynchronize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerImportSynchronize gen_delegate = translator.GetDelegate<EventHandlerImportSynchronize>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerImportSynchronize!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeImportSynchronize += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeImportSynchronize -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeImportSynchronize!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterImportSynchronize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerImportSynchronize gen_delegate = translator.GetDelegate<EventHandlerImportSynchronize>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerImportSynchronize!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterImportSynchronize += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterImportSynchronize -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterImportSynchronize!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeToggleTimeScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerTimeScale gen_delegate = translator.GetDelegate<EventHandlerTimeScale>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerTimeScale!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeToggleTimeScale += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeToggleTimeScale -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeToggleTimeScale!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterToggleTimeScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerTimeScale gen_delegate = translator.GetDelegate<EventHandlerTimeScale>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerTimeScale!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterToggleTimeScale += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterToggleTimeScale -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterToggleTimeScale!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeSyncTimeScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerSyncTimeScale gen_delegate = translator.GetDelegate<EventHandlerSyncTimeScale>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerSyncTimeScale!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeSyncTimeScale += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeSyncTimeScale -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnBeforeSyncTimeScale!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnAfterSyncTimeScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			AbsMonoBehaviour gen_to_be_invoked = (AbsMonoBehaviour)translator.FastGetCSObj(L, 1);
                EventHandlerSyncTimeScale gen_delegate = translator.GetDelegate<EventHandlerSyncTimeScale>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need EventHandlerSyncTimeScale!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnAfterSyncTimeScale += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnAfterSyncTimeScale -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to AbsMonoBehaviour.OnAfterSyncTimeScale!");
            return 0;
        }
        
		
		
    }
}
