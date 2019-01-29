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
    /// 数组分隔符
    /// </summary>
    static readonly string[] msrArraySeparate = new string[] { @"|" };
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
    /// SQLiteDataType设定
    /// </summary>
    class SQLiteDataTypeSetting
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dataType">数据类型</param>
        /// <param name="_dim">维度</param>
        /// <param name="_isMatch">是否匹配</param>
        /// <param name="_typeName">类型名称</param>
        public SQLiteDataTypeSetting(enSQLiteDataType _dataType, enSQLiteDataTypeArrayDimension _dim, bool _isMatch, string _typeName)
        {
            dataType = _dataType;
            dim = _dim;
            isMatch = _isMatch;
            typeName = _typeName;
        }
        /// <summary>
        /// 数据类型
        /// </summary>
        public enSQLiteDataType dataType { get; private set; }
        /// <summary>
        /// 维度
        /// </summary>
        public enSQLiteDataTypeArrayDimension dim { get; private set; }
        /// <summary>
        /// 是否匹配
        /// </summary>
        public bool isMatch { get; private set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string typeName { get; private set; }
    }
    /// <summary>
    /// CSDataType映射
    /// </summary>
    static Dictionary<int, SQLiteDataTypeSetting> msCSDataTypeSettingMaping = new Dictionary<int, SQLiteDataTypeSetting>();    
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
        if (!msCSDataTypeSettingMaping.ContainsKey(hashCode))
        {
            foreach (enSQLiteDataTypeArrayDimension dim in msrSQLiteDataTypeArrayDimensionCodeAttributeMaping.Keys)
            {
                foreach (enSQLiteDataType type in msrSQLiteDataTypeCodeAttributeMaping.Keys)
                {
                    if (GetCSDataTypeName(type, dim).Equals(_csTypeValue))
                    {
                        msCSDataTypeSettingMaping.Add(hashCode, new SQLiteDataTypeSetting(type, dim, true, _csTypeValue));
                        break;
                    }
                }
            }
            if (!msCSDataTypeSettingMaping.ContainsKey(hashCode))
            {
                msCSDataTypeSettingMaping.Add(hashCode, new SQLiteDataTypeSetting(enSQLiteDataType.String, enSQLiteDataTypeArrayDimension.NoArray, false, _csTypeValue));
            }
        }
        _dataType = msCSDataTypeSettingMaping[hashCode].dataType;
        _dataTypeArrayDimension = msCSDataTypeSettingMaping[hashCode].dim;
        return msCSDataTypeSettingMaping[hashCode].isMatch;
    }
    #endregion

    #region ResolveSQLiteDataType 解析列CS数据类型
    /// <summary>
    /// CSDataType映射
    /// </summary>
    static Dictionary<int, SQLiteDataTypeSetting> msSQLiteDataTypeSettingMaping = new Dictionary<int, SQLiteDataTypeSetting>();
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
        if (!msSQLiteDataTypeSettingMaping.ContainsKey(hashCode))
        {
            foreach (enSQLiteDataTypeArrayDimension dim in msrSQLiteDataTypeArrayDimensionCodeAttributeMaping.Keys)
            {
                foreach (enSQLiteDataType type in msrSQLiteDataTypeCodeAttributeMaping.Keys)
                {
                    if (GetSQLiteDataTypeName(type, dim).Equals(_sqliteTypeValue))
                    {
                        msSQLiteDataTypeSettingMaping.Add(hashCode, new SQLiteDataTypeSetting(type, dim, true, _sqliteTypeValue));
                        break;
                    }
                }
            }
            if (!msSQLiteDataTypeSettingMaping.ContainsKey(hashCode))
            {
                msSQLiteDataTypeSettingMaping.Add(hashCode, new SQLiteDataTypeSetting(enSQLiteDataType.String, enSQLiteDataTypeArrayDimension.NoArray, false, _sqliteTypeValue));
            }
        }
        _dataType = msSQLiteDataTypeSettingMaping[hashCode].dataType;
        _dataTypeArrayDimension = msSQLiteDataTypeSettingMaping[hashCode].dim;
        return msSQLiteDataTypeSettingMaping[hashCode].isMatch;
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
        return string.Format("{1}{0}{1}", msrSQLiteDataTypeCodeAttributeMaping[_dataType].sqliteTypeName, msrSQLiteDataTypeArrayDimensionCodeAttributeMaping[_dataTypeArrayDimension].sqliteTypeName);
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
        string[] tempArray = new string[0];
        string[] tempArrayTwo = new string[0];
        ArrayList oneResult = new ArrayList();
        ArrayList twoResult = new ArrayList();
        int step = 1;
        switch (_SQLiteDataTypeArrayDimension)
        {
            case enSQLiteDataTypeArrayDimension.TwoDimensionArray:
                if (_xlsValue != null)
                {
                    tempArrayTwo = _xlsValue.ToString().Split(msrArraySeparate, StringSplitOptions.RemoveEmptyEntries);
                    if (tempArrayTwo != null)
                    {
                        switch (_SQLiteDataType)
                        {
                            case enSQLiteDataType.Vector2:
                                step = 2;
                                break;
                            case enSQLiteDataType.Vector3:
                                step = 3;
                                break;
                            case enSQLiteDataType.Vector4:
                                step = 4;
                                break;
                            default:
                                step = 1;
                                break;
                        }
                        foreach (string oneArray in tempArrayTwo)
                        {
                            oneResult = new ArrayList();
                            tempArray = oneArray.ToString().Split(msrElementSeparate, StringSplitOptions.RemoveEmptyEntries);
                            if (tempArray != null)
                            {
                                for (int i = 0; i < tempArray.Length; i += step)
                                {
                                    oneResult.Add(Convert.ChangeType(OnGetValueFromXlsToEntity(string.Join(msrElementSeparate[0], tempArray, i, step), _SQLiteDataType), 
                                        _propertyInfo.PropertyType.GetElementType().GetElementType()));
                                }
                            }
                            twoResult.Add(oneResult.ToArray(_propertyInfo.PropertyType.GetElementType().GetElementType()));
                        }
                    }
                    _xlsValue = twoResult.ToArray(_propertyInfo.PropertyType.GetElementType());
                }                
                break;
            case enSQLiteDataTypeArrayDimension.OneDimensionArray:
                if (_xlsValue != null)
                {
                    tempArray = _xlsValue.ToString().Split(msrArraySeparate, StringSplitOptions.RemoveEmptyEntries);
                    if (tempArray != null)
                    {
                        for (int i = 0; i < tempArray.Length; i++)
                        {
                            oneResult.Add(Convert.ChangeType(OnGetValueFromXlsToEntity(tempArray[i], _SQLiteDataType), _propertyInfo.PropertyType.GetElementType()));
                        }
                    }
                    _xlsValue = oneResult.ToArray(_propertyInfo.PropertyType.GetElementType());
                }                
                break;
            default:
                if (_xlsValue != null)
                {
                    _xlsValue = OnGetValueFromXlsToEntity(_xlsValue, _SQLiteDataType);
                }                
                break;
        }
        return _xlsValue;
    }
    #endregion

    #region GetValueFromEntityPropertyToXlsColumn 获得实体属性值从实体属性值到XLS列值
    /// <summary>
    /// 获得实体属性值从实体属性值到XLS列值
    /// </summary>
    /// <param name="_entity">实体</param>
    /// <param name="_propertyInfo">属性信息</param>
    /// <param name="_fieldAttribute">字段属性</param>
    /// <returns>转换后的列值</returns>
    public static object GetValueFromEntityPropertyToXlsColumn(object _entity, PropertyInfo _propertyInfo, SQLiteFieldTypeAttribute _fieldAttribute)
    {        
        object srcValue = _propertyInfo.GetValue(_entity, null);
        ArrayList arrayListOne = null;
        ArrayList arrayListTwo = null;
        List<string> arrayValueOne = null;
        List<string> arrayValueTwo = null;
        switch (_fieldAttribute.arrayDimension)
        {
            case enSQLiteDataTypeArrayDimension.TwoDimensionArray:
                arrayListOne = new ArrayList((ICollection)srcValue);
                arrayValueOne = new List<string>();
                for (int i = 0; i < arrayListOne.Count; i++)
                {
                    arrayListTwo = new ArrayList((ICollection)arrayListOne[i]);
                    arrayValueTwo = new List<string>();
                    for (int k = 0; k < arrayListTwo.Count; k++)
                    {
                        arrayValueTwo.Add(OnGetValueFromEntityToXls(arrayListTwo[k], _fieldAttribute.dataType).ToString());
                    }
                    arrayValueOne.Add(string.Join(msrElementSeparate[0], arrayValueTwo.ToArray()));
                }
                srcValue = string.Join(msrArraySeparate[0], arrayValueOne.ToArray());
                break;
            case enSQLiteDataTypeArrayDimension.OneDimensionArray:
                arrayListOne = new ArrayList((ICollection)srcValue);
                arrayValueOne = new List<string>();
                for (int i = 0; i < arrayListOne.Count; i++)
                {
                    arrayValueOne.Add(OnGetValueFromEntityToXls(arrayListOne[i], _fieldAttribute.dataType).ToString());                    
                }
                srcValue = string.Join(msrArraySeparate[0], arrayValueOne.ToArray());
                break;            
            default:
                srcValue = OnGetValueFromEntityToXls(srcValue, _fieldAttribute.dataType);
                break;
        }
        return srcValue.ToString();
    }
    #endregion

    #region OnGetValueFromEntityToXls 获得指定的值从实体到XLS
    /// <summary>
    /// 获得指定的值从实体到XLS
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_SQLiteDataType">类型</param>
    /// <returns>值</returns>
    static object OnGetValueFromEntityToXls(object _value, enSQLiteDataType _SQLiteDataType)
    {
        switch (_SQLiteDataType)
        {
            case enSQLiteDataType.Boolean:
                _value = _value != null && (bool)_value ? 1 : 0;
                break;
            case enSQLiteDataType.Byte:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.Char:
                _value = _value == null ? char.MinValue : _value;
                break;
            case enSQLiteDataType.DateTime:
                _value = _value == null ? DateTime.Now : _value;
                _value = ((DateTime)_value).ToString(@"yyyy-MM-dd ss:hh:mm");
                break;
            case enSQLiteDataType.Decimal:
                _value = _value == null ? 0: _value;
                break;
            case enSQLiteDataType.Double:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.Guid:
                _value = _value == null ? Guid.NewGuid() : _value;
                break;
            case enSQLiteDataType.Int16:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.Int32:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.Int64:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.SByte:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.Single:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.String:
                _value = _value == null ? string.Empty : _value;
                break;
            case enSQLiteDataType.UInt16:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.UInt32:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.UInt64:
                _value = _value == null ? 0 : _value;
                break;
            case enSQLiteDataType.Vector2:
                Vector2 v2 = _value == null ? Vector2.zero : (Vector2)_value;
                _value = v2.x + msrElementSeparate[0] + v2.y;
                break;
            case enSQLiteDataType.Vector3:
                Vector3 v3 = _value == null ? Vector3.zero : (Vector3)_value;
                _value = v3.x + msrElementSeparate[0] + v3.y + msrElementSeparate[0] + v3.z;
                break;
            case enSQLiteDataType.Vector4:
                Vector4 v4 = _value == null ? Vector4.zero : (Vector4)_value;
                _value = v4.x + msrElementSeparate[0] + v4.y + msrElementSeparate[0] + v4.z + msrElementSeparate[0] + v4.w;
                break;
        }
        return _value;
    }
    #endregion

    #region OnGetValueFromXlsToEntity 获得指定的值从XLS到实体
    /// <summary>
    /// 获得指定的值从XLS到实体
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_SQLiteDataType">类型</param>
    /// <returns>值</returns>
    static object OnGetValueFromXlsToEntity(object _value, enSQLiteDataType _SQLiteDataType)
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
                    _value = Convert.ToBoolean( (_value.ToString() == "0" || _value.ToString().ToUpper() == "false".ToUpper() ) ? false : true);
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
                _value = ToVectorXFromXlsToEntity(_value, 2, msrElementSeparate);
                break;
            case enSQLiteDataType.Vector3:
                _value = ToVectorXFromXlsToEntity(_value, 3, msrElementSeparate);
                break;
            case enSQLiteDataType.Vector4:
                _value = ToVectorXFromXlsToEntity(_value, 4, msrElementSeparate);
                break;
        }
        return _value;
    }
    #endregion

    #region ToVectorXFromXlsToEntity 值转为VectorX从XLS到实体
    /// <summary>
    /// 值转为VectorX从XLS到实体
    /// </summary>
    /// <param name="_src">源值</param>
    /// <param name="_dimension">Vector向量维度</param>
    /// <param name="_separator">分隔符</param>
    /// <returns>转换后的值</returns>
    static object ToVectorXFromXlsToEntity(object _src, int _dimension, string[] _separator)
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