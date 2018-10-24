using System;
using UnityEngine;
using XLua;

[System.Serializable]
public class Injection
{
    public string name;
    public GameObject value;
}
public class PropertyChangedEventArgs : EventArgs
{
    public string name;
    public object value;
}

[AddComponentMenu("Game/StrayFogXLuaLevel")]
[LuaCallCSharp]
public class StrayFogXLuaLevel : AbsLevel
{
    public TextAsset luaScript;
    public Injection[] injections;   
    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second 

    private Action luaStart;
    private Action luaUpdate;
    private Action luaOnDestroy;

    private LuaTable scriptEnv;

    [CSharpCallLua]
    public interface ICalc
    {
        event EventHandler<PropertyChangedEventArgs> PropertyChanged;

        int Add(int a, int b);
        int Mult { get; set; }

        object this[int index] { get; set; }
    }

    [CSharpCallLua]
    public delegate ICalc CalcNew(int mult, params string[] args);

    private string script = @"
                local calc_mt = {
                    __index = {
                        Add = function(self, a, b)
                            return (a + b) * self.Mult
                        end,
                        
                        get_Item = function(self, index)
                            return self.list[index + 1]
                        end,

                        set_Item = function(self, index, value)
                            self.list[index + 1] = value
                            self:notify({name = index, value = value})
                        end,
                        
                        add_PropertyChanged = function(self, delegate)
	                        if self.notifylist == nil then
		                        self.notifylist = {}
	                        end
	                        table.insert(self.notifylist, delegate)
                            print('add',delegate)
                        end,
                                                
                        remove_PropertyChanged = function(self, delegate)
                            for i=1, #self.notifylist do
		                        if CS.System.Object.Equals(self.notifylist[i], delegate) then
			                        table.remove(self.notifylist, i)
			                        break
		                        end
	                        end
                            print('remove', delegate)
                        end,

                        notify = function(self, evt)
	                        if self.notifylist ~= nil then
		                        for i=1, #self.notifylist do
			                        self.notifylist[i](self, evt)
		                        end
	                        end	
                        end,
                    }
                }

                Calc = {
	                New = function (mult, ...)
                        print(...)
                        return setmetatable({Mult = mult, list = {'aaaa','bbbb','cccc'}}, calc_mt)
                    end
                }
	        ";
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        scriptEnv = StrayFogGamePools.xLuaManager.luaEnv.NewTable();

        // 为每个脚本设置一个独立的环境，可一定程度上防止脚本间全局变量、函数冲突
        LuaTable meta = StrayFogGamePools.xLuaManager.luaEnv.NewTable();
        meta.Set("__index", StrayFogGamePools.xLuaManager.luaEnv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("self", this);
        foreach (var injection in injections)
        {
            scriptEnv.Set(injection.name, injection.value);
        }

        StrayFogGamePools.xLuaManager.luaEnv.DoString(luaScript.text, "StrayFogXLuaLevel", scriptEnv);

        Action luaAwake = scriptEnv.Get<Action>("awake");
        scriptEnv.Get("start", out luaStart);
        scriptEnv.Get("update", out luaUpdate);
        scriptEnv.Get("ondestroy", out luaOnDestroy);

        if (luaAwake != null)
        {
            luaAwake();
        }

        Test(StrayFogGamePools.xLuaManager.luaEnv);//调用了带可变参数的delegate，函数结束都不会释放delegate，即使置空并调用GC
    }

    // Use this for initialization
    void Start()
    {
        if (luaStart != null)
        {
            luaStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (luaUpdate != null)
        {
            luaUpdate();
        }
        if (Time.time - StrayFogXLuaLevel.lastGCTime > GCInterval)
        {
            StrayFogGamePools.xLuaManager.luaEnv.Tick();
            StrayFogXLuaLevel.lastGCTime = Time.time;
        }
    }

    void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
            luaOnDestroy();
        }
        luaOnDestroy = null;
        luaUpdate = null;
        luaStart = null;
        scriptEnv.Dispose();
        injections = null;
    }

    void Test(LuaEnv luaenv)
    {
        luaenv.DoString(script);
        CalcNew calc_new = luaenv.Global.GetInPath<CalcNew>("Calc.New");
        ICalc calc = calc_new(10, "hi", "john"); //constructor
        Debug.Log("sum(*10) =" + calc.Add(1, 2));
        calc.Mult = 100;
        Debug.Log("sum(*100)=" + calc.Add(1, 2));

        Debug.Log("list[0]=" + calc[0]);
        Debug.Log("list[1]=" + calc[1]);

        calc.PropertyChanged += Notify;
        calc[1] = "dddd";
        Debug.Log("list[1]=" + calc[1]);

        calc.PropertyChanged -= Notify;

        calc[1] = "eeee";
        Debug.Log("list[1]=" + calc[1]);
    }

    void Notify(object sender, PropertyChangedEventArgs e)
    {
        Debug.Log(string.Format("{0} has property changed {1}={2}", sender, e.name, e.value));
    }
}
//ArgumentException: method arguments are incompatible