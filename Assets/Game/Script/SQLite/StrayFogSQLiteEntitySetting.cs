/// <summary>
/// SQLite表实体设定
/// </summary>
public class StrayFogSQLiteEntitySetting
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_id">id</param>
    /// <param name="_name">实体名称</param>
    /// <param name="_xlsFileName">xls文件名称</param>
    /// <param name="_isDeterminant">是否是行列式</param>
    /// <param name="_classify">实体分类</param>
    /// <param name="_xlsColumnNameIndex">XLS表列名称索引</param>
    /// <param name="_xlsColumnDataIndex">XLS表列值索引</param>
    /// <param name="_xlsColumnTypeIndex">XLS表列类型索引</param>
    /// <param name="_xlsDataStartRowIndex">XLS表数据起始行索引</param>
    public StrayFogSQLiteEntitySetting(int _id, string _name, string _xlsFileName, bool _isDeterminant, enSQLiteEntityClassify _classify,
        int _xlsColumnNameIndex, int _xlsColumnDataIndex, int _xlsColumnTypeIndex, int _xlsDataStartRowIndex)
    {
        id = _id;
        name = _name;
        xlsFileName = _xlsFileName;
        isDeterminant = _isDeterminant;
        classify = _classify;
        xlsColumnNameIndex = _xlsColumnNameIndex;
        xlsColumnDataIndex = _xlsColumnDataIndex;
        xlsColumnTypeIndex = _xlsColumnTypeIndex;
        xlsDataStartRowIndex = _xlsDataStartRowIndex;
    }
    /// <summary>
    /// 实体id
    /// </summary>
    public int id { get; private set; }
    /// <summary>
    /// 实体名称
    /// </summary>
    public string name { get; private set; }
    /// <summary>
    /// 实体XLS表名称
    /// </summary>
    public string xlsFileName { get; private set; }
    /// <summary>
    /// 是否是行列式表
    /// </summary>
    public bool isDeterminant { get; private set; }
    /// <summary>
    /// 实体分类
    /// </summary>
    public enSQLiteEntityClassify classify { get; private set; }
    /// <summary>
    /// XLS表列名称索引
    /// </summary>
    public int xlsColumnNameIndex { get; private set; }
    /// <summary>
    /// XLS表列值索引
    /// </summary>
    public int xlsColumnDataIndex { get; private set; }
    /// <summary>
    /// XLS表列类型索引
    /// </summary>
    public int xlsColumnTypeIndex { get; private set; }
    /// <summary>
    /// XLS表数据起始行索引
    /// </summary>
    public int xlsDataStartRowIndex { get; private set; }
}
