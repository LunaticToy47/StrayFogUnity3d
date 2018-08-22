using System.Collections.Generic;
    /// <summary>
    /// SQLite实体
    /// </summary>
    public enum enSQLiteEntityClassify
    {
        /// <summary>
        /// 表格
        /// </summary>        
        Table,
        /// <summary>
        /// 视图
        /// </summary>
        View
    }
/// <summary>
/// SQLite表格
/// </summary>
public class SQLiteEntity
{
    /// <summary>
    /// SQLite表格
    /// </summary>
    /// <param name="_name">表格名称</param>
    /// <param name="_classify">表格分类</param>
    /// <param name="_isDetermainant">是否是行列式</param>
    public SQLiteEntity(string _name, enSQLiteEntityClassify _classify, bool _isDetermainant)
    {
        name = _name;
        classify = _classify;
        isDetermainant = _isDetermainant;
        string prefix = _classify.ToString() + "_";
        if (_name.StartsWith(prefix))
        {
            className = _name;
        }
        else
        {
            className = prefix + _name;
        }
        properties = new List<SQLiteEntityProperty>();
    }
    /// <summary>
    /// 分类
    /// </summary>
    public enSQLiteEntityClassify classify { get; private set; }
    /// <summary>
    /// 类名称
    /// </summary>
    public string className { get; private set; }
    /// <summary>
    /// 表格名称
    /// </summary>
    public string name { get; private set; }
    /// <summary>
    /// 是否是行列式
    /// </summary>
    public bool isDetermainant { get; private set; }
    /// <summary>
    /// 属性组
    /// </summary>
    public List<SQLiteEntityProperty> properties { get; private set; }
}
