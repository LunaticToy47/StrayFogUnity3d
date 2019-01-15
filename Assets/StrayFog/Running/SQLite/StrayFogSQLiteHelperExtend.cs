public partial class StrayFogSQLiteHelper
{
    #region Db库
    /// <summary>
    /// SQLiteHelper
    /// </summary>
    static StrayFogSQLiteHelper mSqlHelper = null;
    /// <summary>
    /// SQL帮助类
    /// </summary>
    public static StrayFogSQLiteHelper sqlHelper { get { if (mSqlHelper == null) { mSqlHelper = new StrayFogSQLiteHelper(string.Format("data source={0}", StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().dbSource)); } return mSqlHelper; } }
    #endregion
}
