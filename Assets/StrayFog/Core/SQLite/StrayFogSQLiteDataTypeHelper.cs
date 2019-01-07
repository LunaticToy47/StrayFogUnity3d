using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
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
    #region 分隔符 readonly 变量
    /// <summary>
    /// 一维数组分隔符
    /// </summary>
    static readonly string[] msrOneArraySeparate = new string[] { @"|" };
    /// <summary>
    /// 元素分隔符
    /// </summary>
    static readonly string[] msrElementSeparate = new string[] { @"," };
    #endregion

    #region readonly 变量
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
    #endregion

    #region GetSQLiteDataTypeCSCodeColumnNameSequence 获得SQLiteDataTypeCS列名称代码序列
    /// <summary>
    /// 获得SQLiteDataTypeCS列名称代码序列
    /// </summary>
    /// <returns>列名称代码序列</returns>
    public static string GetSQLiteDataTypeCSCodeColumnNameSequence()
    {
        StringBuilder sbSeq = new StringBuilder();
        foreach (CodeAttribute a in msrSQLiteDataTypeArrayDimensionCodeAttributeMaping.Values)
        {
            foreach (CodeAttribute t in msrSQLiteDataTypeCodeAttributeMaping.Values)
            {
                sbSeq.AppendFormat("{0}{1}Col\t", t.csTypeName, a.sqliteTypeName);
            }
        }
        if (sbSeq.Length > 0)
        {
            sbSeq = sbSeq.Remove(sbSeq.Length - 1, 1);
        }
        return sbSeq.ToString();
    }
    #endregion

    #region GetSQLiteDataTypeCSCodeColumnTypeSequence 获得SQLiteDataTypeCS列类型代码序列
    /// <summary>
    /// 获得SQLiteDataTypeCS列类型代码序列
    /// </summary>
    /// <returns>列类型代码序列</returns>
    public static string GetSQLiteDataTypeCSCodeColumnTypeSequence()
    {
        StringBuilder sbSeq = new StringBuilder();
        foreach (CodeAttribute a in msrSQLiteDataTypeArrayDimensionCodeAttributeMaping.Values)
        {
            foreach (CodeAttribute t in msrSQLiteDataTypeCodeAttributeMaping.Values)
            {
                sbSeq.AppendFormat("{0}{1}\t", t.csTypeName, a.csTypeName);
            }
        }
        if (sbSeq.Length > 0)
        {
            sbSeq = sbSeq.Remove(sbSeq.Length - 1, 1);
        }
        return sbSeq.ToString();
    }
    #endregion

    #region GetSQLiteDataTypeCSCodeColumnDescSequence 获得SQLiteDataTypeCS列描述代码序列
    /// <summary>
    /// 获得SQLiteDataTypeCS列描述代码序列
    /// </summary>
    /// <returns>列类别代码序列</returns>
    public static string GetSQLiteDataTypeCSCodeColumnDescSequence()
    {
        StringBuilder sbSeq = new StringBuilder();
        foreach (CodeAttribute a in msrSQLiteDataTypeArrayDimensionCodeAttributeMaping.Values)
        {
            foreach (CodeAttribute t in msrSQLiteDataTypeCodeAttributeMaping.Values)
            {
                sbSeq.AppendFormat("{0}{1}\t", t.csTypeName, a.alias);
            }
        }
        if (sbSeq.Length > 0)
        {
            sbSeq = sbSeq.Remove(sbSeq.Length - 1, 1);
        }
        return sbSeq.ToString();
    }
    #endregion

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

    #region GetCSTypeColumnValue 获得CS类型列值
    /// <summary>
    /// 获得CS类型列值
    /// </summary>
    /// <param name="_xlsValue">xls表列值</param>
    /// <param name="_propertyInfo">属性</param>
    /// <param name="_SQLiteDataType">代码类型</param>
    /// <param name="_SQLiteDataTypeArrayDimension">数组维度</param>
    /// <returns>转换后的列值</returns>
    public static object GetXlsCSTypeColumnValue(object _xlsValue,PropertyInfo _propertyInfo, enSQLiteDataType _SQLiteDataType, enSQLiteDataTypeArrayDimension _SQLiteDataTypeArrayDimension)
    {
        string[] tempArray = null;
        ArrayList oneResult = new ArrayList();
        string dt = DateTime.MinValue.ToString();
        string guid = Guid.NewGuid().ToString();
        switch (_SQLiteDataTypeArrayDimension)
        {
            case enSQLiteDataTypeArrayDimension.TwoDimensionArray:
                break;
            case enSQLiteDataTypeArrayDimension.OneDimensionArray:
                if (_xlsValue != null)
                {
                    tempArray = _xlsValue.ToString().Split(msrOneArraySeparate, StringSplitOptions.RemoveEmptyEntries);
                    if (tempArray != null)
                    {
                        for (int i = 0; i < tempArray.Length; i++)
                        {
                            oneResult.Add(Convert.ChangeType(OnGetValue(tempArray[i], _SQLiteDataType), _propertyInfo.PropertyType.GetElementType()));
                        }
                    }
                }
                _xlsValue = oneResult.ToArray(_propertyInfo.PropertyType.GetElementType());
                break;
            default:
                _xlsValue = OnGetValue(_xlsValue, _SQLiteDataType);
                break;
        }
        return _xlsValue;
    }
    #endregion

    #region OnGetValue 获得指定类型的值
    /// <summary>
    /// 获得指定类型的值
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_SQLiteDataType">类型</param>
    /// <returns>值</returns>
    static object OnGetValue(object _value, enSQLiteDataType _SQLiteDataType)
    {
        switch (_SQLiteDataType)
        {
            case enSQLiteDataType.Boolean:
                if (_value == null)
                {
                    _value = false;
                }
                else
                {
                    _value = Convert.ToBoolean(_value.ToString() == "0" ? false : true);
                }
                break;
            case enSQLiteDataType.Byte:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToByte(_value);
                }
                break;
            case enSQLiteDataType.Char:
                if (_value == null)
                {
                    _value = char.MinValue;
                }
                else
                {
                    _value = Convert.ToChar(_value);
                }
                break;
            case enSQLiteDataType.DateTime:
                if (_value == null)
                {
                    _value = DateTime.Now;
                }
                else
                {
                    _value = Convert.ToDateTime(_value);
                }
                break;
            case enSQLiteDataType.Decimal:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToDecimal(_value);
                }
                break;
            case enSQLiteDataType.Double:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToDouble(_value);
                }
                break;
            case enSQLiteDataType.Guid:
                if (_value == null)
                {
                    _value = Guid.NewGuid();
                }
                else
                {
                    _value = new Guid(_value.ToString());
                }
                break;
            case enSQLiteDataType.Int16:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToInt16(_value);
                }
                break;
            case enSQLiteDataType.Int32:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToInt32(_value);
                }
                break;
            case enSQLiteDataType.Int64:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToInt64(_value);
                }
                break;
            case enSQLiteDataType.SByte:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToSByte(_value);
                }
                break;
            case enSQLiteDataType.Single:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToSingle(_value);
                }
                break;
            case enSQLiteDataType.String:
                if (_value == null)
                {
                    _value = string.Empty;
                }
                else
                {
                    _value = Convert.ToString(_value);
                }
                break;
            case enSQLiteDataType.UInt16:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToUInt16(_value);
                }
                break;
            case enSQLiteDataType.UInt32:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToUInt32(_value);
                }
                break;
            case enSQLiteDataType.UInt64:
                if (_value == null)
                {
                    _value = 0;
                }
                else
                {
                    _value = Convert.ToUInt64(_value);
                }
                break;
            case enSQLiteDataType.Vector2:
                _value = ToVectorX(_value, 2, msrElementSeparate);
                break;
            case enSQLiteDataType.Vector3:
                _value = ToVectorX(_value, 3, msrElementSeparate);
                break;
            case enSQLiteDataType.Vector4:
                _value = ToVectorX(_value, 4, msrElementSeparate);
                break;
        }
        return _value;
    }
    #endregion

    #region ToVectorX 值转为VectorX
    /// <summary>
    /// 值转为VectorX
    /// </summary>
    /// <param name="_src">源值</param>
    /// <param name="_dimension">Vector向量维度</param>
    /// <param name="_separator">分隔符</param>
    /// <returns>转换后的值</returns>
    static object ToVectorX(object _src, int _dimension, string[] _separator)
    {
        object result = null;
        Vector4 v4 = Vector4.zero;
        #region 读值
        string[] values = new string[0];
        if (_src != null)
        {
            values = _src.ToString().Split(_separator, StringSplitOptions.RemoveEmptyEntries);
        }
        if (values.Length > 0)
        {
            v4.x = float.Parse(values[0]);
        }
        if (values.Length > 1)
        {
            v4.y = float.Parse(values[1]);
        }
        if (values.Length > 2)
        {
            v4.z = float.Parse(values[2]);
        }
        if (values.Length > 3)
        {
            v4.w = float.Parse(values[3]);
        }
        #endregion
        switch (_dimension)
        {
            case 2:
                result = (Vector2)v4;
                break;
            case 3:
                result = (Vector3)v4;
                break;
            case 4:
                result = v4;
                break;
        }
        return result;
    }
    #endregion
}