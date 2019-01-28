/// <summary>
/// StrayFogSQLite表实体帮助类【DbSQLite】
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
    #region CloseDb 关闭所有用到的SQLite数据库
    /// <summary>
    /// 关闭所有用到的SQLite数据库
    /// </summary>
    public static void CloseSQLite()
    {
        if (msStrayFogSQLiteHelperMaping.Count > 0)
        {
            foreach (StrayFogSQLiteHelper db in msStrayFogSQLiteHelperMaping.Values)
            {
                db.Close();
            }
        }
    }
    #endregion
}
