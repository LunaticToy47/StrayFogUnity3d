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
/// StrayFogSQLiteDataTypeHelper帮助类
/// </summary>
public sealed class StrayFogSQLiteDataTypeHelper
{
    /// <summary>
    /// SQLite数据类别映射
    /// </summary>
    static readonly Dictionary<enSQLiteDataType, CodeAttribute> msrSQLiteDataTypeCodeAttributeMaping =
                        typeof(enSQLiteDataType).EnumToAttribute<enSQLiteDataType, CodeAttribute>();
    /// <summary>
    /// SQLite数据类别数组维度映射
    /// </summary>
    static readonly Dictionary<enSQLiteDataTypeArrayDimension, CodeAttribute> msrSQLiteDataTypeArrayDimensionCodeAttributeMaping =
                        typeof(enSQLiteDataTypeArrayDimension).EnumToAttribute<enSQLiteDataTypeArrayDimension, CodeAttribute>();

    #region ResolveCSDataType 解析列CS数据类型
    /// <summary>
    /// CSDataType映射
    /// </summary>
    static Dictionary<int, enSQLiteDataType> msCSDataTypeMaping = new Dictionary<int, enSQLiteDataType>();
    /// <summary>
    /// CSDataTypeArrayDimension映射
    /// </summary>
    static Dictionary<int, enSQLiteDataTypeArrayDimension> msCSDataTypeArrayDimensionMaping = new Dictionary<int, enSQLiteDataTypeArrayDimension>();
    /// <summary>
    /// 解析列CS数据类型
    /// </summary>
    /// <param name="_csTypeValue">cs列类型值</param>
    /// <param name="_dataType">数据类型</param>
    /// <param name="_dataTypeArrayDimension">数据数组类型</param>
    /// <returns>true:有匹配的类型,false:无匹配的类型</returns>
    public static bool ResolveCSDataType(string _csTypeValue, ref enSQLiteDataType _dataType, ref enSQLiteDataTypeArrayDimension _dataTypeArrayDimension)
    {
        int hashCode = _csTypeValue.GetHashCode();
        string typeValue = string.Empty;
        string dimValue = string.Empty;
        typeValue = dimValue = _csTypeValue;
        foreach (KeyValuePair<enSQLiteDataTypeArrayDimension, CodeAttribute> key in msrSQLiteDataTypeArrayDimensionCodeAttributeMaping)
        {
            if (!string.IsNullOrEmpty(key.Value.csTypeName))
            {
                typeValue = typeValue.Replace(key.Value.csTypeName, "");
            }
        }
        dimValue = dimValue.Replace(typeValue, "");

        if (!msCSDataTypeMaping.ContainsKey(hashCode))
        {
            foreach (KeyValuePair<enSQLiteDataType, CodeAttribute> key in msrSQLiteDataTypeCodeAttributeMaping)
            {
                if (typeValue.ToUpper().Equals(key.Value.csTypeName.ToUpper()))
                {
                    _dataType = key.Key;
                    msCSDataTypeMaping.Add(hashCode, key.Key);
                    break;
                }
            }
        }
        else
        {
            _dataType = msCSDataTypeMaping[hashCode];
        }

        if (!msCSDataTypeArrayDimensionMaping.ContainsKey(hashCode))
        {
            foreach (KeyValuePair<enSQLiteDataTypeArrayDimension, CodeAttribute> key in msrSQLiteDataTypeArrayDimensionCodeAttributeMaping)
            {
                if (string.IsNullOrEmpty(dimValue) || dimValue.ToUpper().Equals(key.Value.csTypeName.ToUpper()))
                {
                    _dataTypeArrayDimension = key.Key;
                    msCSDataTypeArrayDimensionMaping.Add(hashCode, key.Key);
                    break;
                }
            }
        }
        else
        {
            _dataTypeArrayDimension = msCSDataTypeArrayDimensionMaping[hashCode];
        }
        return msCSDataTypeMaping.ContainsKey(hashCode) && msCSDataTypeArrayDimensionMaping.ContainsKey(hashCode);
    }
    #endregion

    #region ResolveSQLiteDataType 解析列CS数据类型
    /// <summary>
    /// SQLiteDataType映射
    /// </summary>
    static Dictionary<int, enSQLiteDataType> msSQLiteDataTypeMaping = new Dictionary<int, enSQLiteDataType>();
    /// <summary>
    /// SQLiteDataTypeArrayDimension映射
    /// </summary>
    static Dictionary<int, enSQLiteDataTypeArrayDimension> msSQLiteDataTypeArrayDimensionMaping = new Dictionary<int, enSQLiteDataTypeArrayDimension>();
    /// <summary>
    /// 解析列CS数据类型
    /// </summary>
    /// <param name="_sqliteTypeValue">cs列类型值</param>
    /// <param name="_dataType">数据类型</param>
    /// <param name="_dataTypeArrayDimension">数据数组类型</param>
    /// <returns>true:有匹配的类型,false:无匹配的类型</returns>
    public static bool ResolveSQLiteDataType(string _sqliteTypeValue, ref enSQLiteDataType _dataType, ref enSQLiteDataTypeArrayDimension _dataTypeArrayDimension)
    {
        int hashCode = _sqliteTypeValue.GetHashCode();
        string typeValue = string.Empty;
        string dimValue = string.Empty;
        typeValue = dimValue = _sqliteTypeValue;
        foreach (KeyValuePair<enSQLiteDataTypeArrayDimension, CodeAttribute> key in msrSQLiteDataTypeArrayDimensionCodeAttributeMaping)
        {
            if (!string.IsNullOrEmpty(key.Value.sqliteTypeName))
            {
                typeValue = typeValue.Replace(key.Value.sqliteTypeName, "");
            }
        }
        dimValue = dimValue.Replace(typeValue, "");

        if (!msSQLiteDataTypeMaping.ContainsKey(hashCode))
        {
            foreach (KeyValuePair<enSQLiteDataType, CodeAttribute> key in msrSQLiteDataTypeCodeAttributeMaping)
            {
                if (typeValue.ToUpper().Equals(key.Value.sqliteTypeName.ToUpper()))
                {
                    _dataType = key.Key;
                    msSQLiteDataTypeMaping.Add(hashCode, key.Key);
                    break;
                }
            }
        }
        else
        {
            _dataType = msSQLiteDataTypeMaping[hashCode];
        }

        if (!msSQLiteDataTypeArrayDimensionMaping.ContainsKey(hashCode))
        {
            foreach (KeyValuePair<enSQLiteDataTypeArrayDimension, CodeAttribute> key in msrSQLiteDataTypeArrayDimensionCodeAttributeMaping)
            {
                if (string.IsNullOrEmpty(dimValue) || dimValue.ToUpper().Equals(key.Value.sqliteTypeName.ToUpper()))
                {
                    _dataTypeArrayDimension = key.Key;
                    msSQLiteDataTypeArrayDimensionMaping.Add(hashCode, key.Key);
                    break;
                }
            }
        }
        else
        {
            _dataTypeArrayDimension = msSQLiteDataTypeArrayDimensionMaping[hashCode];
        }

        return msSQLiteDataTypeMaping.ContainsKey(hashCode) && msSQLiteDataTypeArrayDimensionMaping.ContainsKey(hashCode);
    }
    #endregion

    #region GetSQLiteDataTypeName 获得SQLite数据类型名称
    /// <summary>
    /// 获得SQLite数据类型名称
    /// </summary>
    /// <param name="_dataType">数据类型</param>
    /// <param name="_dataTypeArrayDimension">数组维度</param>
    /// <returns>SQLite数据类型名称</returns>
    public static string GetSQLiteDataTypeName(enSQLiteDataType _dataType, enSQLiteDataTypeArrayDimension _dataTypeArrayDimension)
    {
        return msrSQLiteDataTypeCodeAttributeMaping[_dataType].sqliteTypeName + msrSQLiteDataTypeArrayDimensionCodeAttributeMaping[_dataTypeArrayDimension].sqliteTypeName;
    }
    #endregion

    #region GetCSDataTypeName 获得CS数据类型名称
    /// <summary>
    /// 获得CS数据类型名称
    /// </summary>
    /// <param name="_dataType">数据类型</param>
    /// <param name="_dataTypeArrayDimension">数组维度</param>
    /// <returns>SQLite数据类型名称</returns>
    public static string GetCSDataTypeName(enSQLiteDataType _dataType, enSQLiteDataTypeArrayDimension _dataTypeArrayDimension)
    {
        return msrSQLiteDataTypeCodeAttributeMaping[_dataType].csTypeName + msrSQLiteDataTypeArrayDimensionCodeAttributeMaping[_dataTypeArrayDimension].csTypeName;
    }
    #endregion

    #region GetEntityClassName 获得实体类名称
    /// <summary>
    /// 获得实体类名称
    /// </summary>
    /// <param name="_entityName">实体名称</param>
    /// <param name="_entityClassify">实体分类</param>
    /// <returns>脚本类名称</returns>
    public static string GetEntityClassName(string _entityName, enSQLiteEntityClassify _entityClassify)
    {
        string className = _entityName;
        string prefix = _entityClassify.ToString() + "_";
        if (_entityName.StartsWith(prefix))
        {
            className = _entityName;
        }
        else
        {
            className = prefix + _entityName;
        }
        return className;
    }
    #endregion    
}
