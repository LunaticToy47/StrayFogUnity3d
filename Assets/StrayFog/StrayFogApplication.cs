/// <summary>
/// 注册引导事件句柄
/// </summary>
/// <param name="_guide">引导</param>
public delegate void RegisterGuideEventHandle(UIGuideRegister _guide);
/// <summary>
/// 引擎应用程序
/// </summary>
public abstract class StrayFogApplication : AbsSingleScriptableObject<StrayFogApplication>
{
    #region Db库
    /// <summary>
    /// SQLiteHelper
    /// </summary>
    SQLiteHelper mSqlHelper = null;
    /// <summary>
    /// SQL帮助类
    /// </summary>
    public SQLiteHelper sqlHelper { get { if (mSqlHelper == null) { mSqlHelper = new SQLiteHelper(StrayFogSetting.current.dbConnectionString); } return mSqlHelper; } }
    /// <summary>
    /// 关闭数据库
    /// </summary>
    void CloseDb()
    {
        if (mSqlHelper != null)
        {
            mSqlHelper.Close();
            mSqlHelper = null;
        }
    }
    #endregion

    #region LoadAssetAtPath 从指定路径加载资源
    /// <summary>
    /// 从指定路径加载资源
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="_assetPath">资源路径</param>
    /// <param name="_type">资源类别</param>
    /// <returns>资源</returns>
    public abstract UnityEngine.Object LoadAssetAtPath(string _assetPath, System.Type _type);
    #endregion

    #region OnApplicationQuit
    /// <summary>
    /// OnApplicationQuit
    /// </summary>
    void OnApplicationQuit()
    {
        CloseDb();
    }
    #endregion

    #region OnGuideRegister 引导注册事件
    /// <summary>
    /// 注册引导事件
    /// </summary>
    public event RegisterGuideEventHandle OnRegisterGuide;
    /// <summary>
    /// 注册引导
    /// </summary>
    /// <param name="_guide">引导</param>
    public void RegisterGuide(UIGuideRegister _guide)
    {
        if (OnRegisterGuide != null)
        {
            OnRegisterGuide(_guide);
        }
    }
    #endregion
}