using XLua;
public class StrayFogXLuaManager : AbsSingleMonoBehaviour
{
    /// <summary>
    /// lua引擎
    /// </summary>
    public LuaEnv luaEnv  { get; private set; }

    #region OnAfterConstructor
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        luaEnv = new LuaEnv();
        base.OnAfterConstructor();
    }
    #endregion

}
