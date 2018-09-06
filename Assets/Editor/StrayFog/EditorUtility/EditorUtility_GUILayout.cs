﻿#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
/// <summary>
/// GUILayout工具
/// </summary>
public class EditorUtility_GUILayout : AbsSingle
{
    #region SerializedProperty 相关
    ///// <summary>
    ///// 属性名称正则
    ///// </summary>
    //static readonly string mPropertyNameRegex = @"[^\.]+?\.Array\.data\[\d+\]?|[^\.]+?";
    //MatchCollection match = Regex.Matches(_property.propertyPath, mPropertyNameRegex, RegexOptions.Compiled);

    /// <summary>
    /// 属性父节点路径正则
    /// </summary>
    static readonly string mPropertyParentPathRegex = @"(\s*)(\.?[^\.]+?\.Array\.data\[\d+\]?|[^\.]+?)$";

    /// <summary>
    /// ArrayData属性节点父路径正则
    /// </summary>
    static readonly string mArrayDataPropertyParentPathRegex = @"(\s*)(\.Array\.data\[\d+\]?)$";

    /// <summary>
    /// 属性索引正则
    /// </summary>
    static readonly string mPropertyIndexRegex = @"\.Array\.data\[(\d+)\]?$";

    /// <summary>
    /// 查找相对属性
    /// </summary>
    /// <param name="_property">属性</param>
    /// <param name="_relativePropertyPath">相对路径</param>
    /// <returns>相对属性</returns>
    public SerializedProperty FindPropertyRelative(SerializedProperty _property, string _relativePropertyPath)
    {
        string parentPath = Regex.Replace(_property.propertyPath, mPropertyParentPathRegex, "$1");
        parentPath += _relativePropertyPath;
        return _property.serializedObject.FindProperty(parentPath);
    }

    /// <summary>
    /// 查找父属性
    /// </summary>
    /// <param name="_property">属性</param>
    /// <param name="_fieldInfo">属性对应字段</param>
    /// <returns>父属性</returns>
    public SerializedProperty FindParentProperty(SerializedProperty _property, FieldInfo _fieldInfo)
    {
        SerializedProperty parent = null;
        if (_fieldInfo.FieldType.IsArray)
        {
            parent = FindArrayDataParentProperty(_property);
        }
        else
        {
            parent = FindParentProperty(_property);
        }
        return parent;
    }

    /// <summary>
    /// 查找父属性
    /// </summary>
    /// <param name="_property">属性</param>
    /// <returns>父属性</returns>
    SerializedProperty FindParentProperty(SerializedProperty _property)
    {
        string parentPath = Regex.Replace(_property.propertyPath, mPropertyParentPathRegex, "$1");
        if (parentPath.EndsWith("."))
        {
            parentPath = parentPath.Remove(parentPath.Length - 1);
        }
        return _property.serializedObject.FindProperty(parentPath);
    }

    /// <summary>
    /// 查找ArrayData节点父属性
    /// </summary>
    /// <param name="_property">属性</param>
    /// <returns>父属性</returns>
    SerializedProperty FindArrayDataParentProperty(SerializedProperty _property)
    {
        string parentPath = Regex.Replace(_property.propertyPath, mArrayDataPropertyParentPathRegex, "$1");
        if (parentPath.EndsWith("."))
        {
            parentPath = parentPath.Remove(parentPath.Length - 1);
        }
        return _property.serializedObject.FindProperty(parentPath);
    }

    /// <summary>
    /// 获得属性Key值
    /// </summary>
    /// <param name="_property">属性</param>
    /// <param name="_fieldInfo">字段信息</param>
    /// <returns>Key值</returns>
    public int GetPropertyKey(SerializedProperty _property, FieldInfo _fieldInfo)
    {
        return (_fieldInfo.DeclaringType.FullName + _property.propertyPath).UniqueHashCode();
    }

    /// <summary>
    /// 获得属性索引
    /// </summary>
    /// <param name="_property">获得属性索引</param>
    /// <returns>索引</returns>
    public int GetPropertyIndex(SerializedProperty _property)
    {
        Match match = Regex.Match(_property.propertyPath, mPropertyIndexRegex);
        int index = 0;
        if (match.Success)
        {
            index = int.Parse(match.Groups[1].Value);
        }
        return index;
    }
    #endregion

    #region EnumPopup 绘制枚举Popup
    /// <summary>
    /// Key:枚举类型HashCode
    /// Value:枚举值组
    /// </summary>
    static Dictionary<int, int[]> mEnumPopupValueMaping = new Dictionary<int, int[]>();
    /// <summary>
    /// Key:枚举类型HashCode
    /// Value:枚举别名组
    /// </summary>
    static Dictionary<int, GUIContent[]> mEnumPopupAliasMaping = new Dictionary<int, GUIContent[]>();
    /// <summary>
    /// 解析枚举
    /// </summary>
    /// <param name="_enumType">枚举类别</param>
    /// <returns>HashCode</returns>
    int OnResolveEnum(Type _enumType)
    {
        int hashCode = _enumType.GetHashCode();
        if (!mEnumPopupValueMaping.ContainsKey(hashCode))
        {
            Dictionary<int, string> vtn = _enumType.ValueToName();
            Dictionary<int, string> vta = _enumType.ValueToAttributeSpecifyValue<AliasTooltipAttribute, string>((a) => { if (a != null) { return a.alias; } else { return string.Empty; } });
            List<int> values = new List<int>(vtn.Keys);
            List<GUIContent> aliass = new List<GUIContent>();
            foreach (int v in values)
            {
                if (string.IsNullOrEmpty(vta[v]))
                {
                    aliass.Add(new GUIContent(vtn[v]));
                }
                else
                {
                    aliass.Add(new GUIContent(vta[v]));
                }
            }
            mEnumPopupValueMaping.Add(hashCode, values.ToArray());
            mEnumPopupAliasMaping.Add(hashCode, aliass.ToArray());
        }
        return hashCode;
    }
    /// <summary>
    /// 绘制枚举Popup
    /// </summary>
    /// <param name="_enumType">枚举类型</param>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    public void EnumPopup(Type _enumType, Rect _position, SerializedProperty _property, GUIContent _label)
    {
        int hashCode = OnResolveEnum(_enumType);
        EditorGUI.IntPopup(_position, _property, mEnumPopupAliasMaping[hashCode], mEnumPopupValueMaping[hashCode], _label);
    }

    /// <summary>
    /// 绘制枚举Popup
    /// </summary>
    /// <param name="_enum">枚举</param>
    /// <returns>枚举值</returns>
    public Enum EnumPopup(Enum _enum)
    {
        return EnumPopup(_enum, null, null);
    }
    /// <summary>
    /// 绘制枚举Popup
    /// </summary>
    /// <param name="_enum">枚举</param>
    /// <param name="_label">label</param>
    /// <returns>枚举值</returns>
    public Enum EnumPopup(Enum _enum, GUIContent _label)
    {
        return EnumPopup(_enum, _label, null);
    }
    /// <summary>
    /// 绘制枚举Popup
    /// </summary>
    /// <param name="_enum">枚举</param>
    /// <param name="_label">label</param>
    /// <returns>枚举值</returns>
    public Enum EnumPopup(Enum _enum, GUIContent _label, params GUILayoutOption[] _options)
    {
        Type t = _enum.GetType();
        int hashCode = OnResolveEnum(_enum.GetType());
        int selectedValue = (int)Convert.ToInt32(Enum.Parse(t, _enum.ToString()));
        if (_label != null)
        {
            selectedValue = EditorGUILayout.IntPopup(_label, selectedValue, mEnumPopupAliasMaping[hashCode], mEnumPopupValueMaping[hashCode], _options);
        }
        else
        {
            selectedValue = EditorGUILayout.IntPopup(selectedValue, mEnumPopupAliasMaping[hashCode], mEnumPopupValueMaping[hashCode], _options);
        }
        return (Enum)Enum.Parse(t, selectedValue.ToString());
    }
    #endregion

    #region EqualsSerializedPropertyValue 给定值是否与属性值相等
    /// <summary>
    /// 给定值是否与属性值相等
    /// </summary>
    /// <param name="_property">属性</param>
    /// <returns>true:相等,false:不相等</returns>
    public bool EqualsSerializedPropertyValue(object _value, SerializedProperty _property)
    {
        bool isEquals = false;
        switch (_property.propertyType)
        {
            case SerializedPropertyType.AnimationCurve:
                isEquals = _property.animationCurveValue.Equals((AnimationCurve)_value);
                break;
            case SerializedPropertyType.ArraySize:
                isEquals = _property.arraySize.Equals((int)_value);
                break;
            case SerializedPropertyType.Boolean:
                isEquals = _property.boolValue.Equals((bool)_value);
                break;
            case SerializedPropertyType.Bounds:
                isEquals = _property.boundsValue.Equals((Bounds)_value);
                break;
            case SerializedPropertyType.Character:
                isEquals = _property.stringValue.Equals((string)_value);
                break;
            case SerializedPropertyType.Color:
                isEquals = _property.colorValue.Equals((Color)_value);
                break;
            case SerializedPropertyType.Enum:
                isEquals = _property.intValue.Equals((int)_value);
                break;
            case SerializedPropertyType.ExposedReference:
                isEquals = _property.exposedReferenceValue.Equals(_value);
                break;
            case SerializedPropertyType.Float:
                isEquals = _property.floatValue.Equals((float)_value);
                break;
            case SerializedPropertyType.Generic:
                isEquals = true;
                break;
            case SerializedPropertyType.Gradient:
                isEquals = true;
                break;
            case SerializedPropertyType.Integer:
                isEquals = _property.intValue.Equals((int)_value);
                break;
            case SerializedPropertyType.LayerMask:
                isEquals = _property.intValue.Equals((int)_value);
                break;
            case SerializedPropertyType.ObjectReference:
                isEquals = _property.objectReferenceValue.Equals(_value);
                break;
            case SerializedPropertyType.Quaternion:
                isEquals = _property.quaternionValue.Equals((Quaternion)_value);
                break;
            case SerializedPropertyType.Rect:
                isEquals = _property.rectValue.Equals((Rect)_value);
                break;
            case SerializedPropertyType.String:
                isEquals = _property.stringValue.Equals((string)_value);
                break;
            case SerializedPropertyType.Vector2:
                isEquals = _property.vector2Value.Equals((Vector2)_value);
                break;
            case SerializedPropertyType.Vector3:
                isEquals = _property.vector3Value.Equals((Vector3)_value);
                break;
            case SerializedPropertyType.Vector4:
                isEquals = _property.vector4Value.Equals((Vector4)_value);
                break;
        }
        return isEquals;
    }
    #endregion

    #region IsNonZeroPositive 属性值是否是非零正整数
    /// <summary>
    /// 属性值是否是非零正整数
    /// </summary>
    /// <param name="_property">属性</param>
    /// <returns>true:相等,false:不相等</returns>
    public bool IsNonZeroPositive(SerializedProperty _property)
    {
        bool isNonZeroPositive = false;
        switch (_property.propertyType)
        {
            case SerializedPropertyType.AnimationCurve:
                isNonZeroPositive = _property.animationCurveValue.length > 0;
                break;
            case SerializedPropertyType.ArraySize:
                isNonZeroPositive = _property.arraySize > 0;
                break;
            case SerializedPropertyType.Boolean:
                isNonZeroPositive = _property.boolValue;
                break;
            case SerializedPropertyType.Bounds:
                isNonZeroPositive = !_property.boundsValue.Equals(new Bounds());
                break;
            case SerializedPropertyType.Character:
                isNonZeroPositive = !string.IsNullOrEmpty(_property.stringValue);
                break;
            case SerializedPropertyType.Color:
                isNonZeroPositive = !_property.colorValue.Equals(Color.clear);
                break;
            case SerializedPropertyType.Enum:
                isNonZeroPositive = _property.intValue > 0;
                break;
            case SerializedPropertyType.ExposedReference:
                isNonZeroPositive = _property.exposedReferenceValue != null;
                break;
            case SerializedPropertyType.Float:
                isNonZeroPositive = _property.floatValue > 0;
                break;
            case SerializedPropertyType.Generic:
                isNonZeroPositive = true;
                break;
            case SerializedPropertyType.Gradient:
                isNonZeroPositive = true;
                break;
            case SerializedPropertyType.Integer:
                isNonZeroPositive = _property.intValue > 0;
                break;
            case SerializedPropertyType.LayerMask:
                isNonZeroPositive = _property.intValue > 0;
                break;
            case SerializedPropertyType.ObjectReference:
                isNonZeroPositive = _property.objectReferenceValue != null;
                break;
            case SerializedPropertyType.Quaternion:
                isNonZeroPositive = !_property.quaternionValue.Equals(Quaternion.identity);
                break;
            case SerializedPropertyType.Rect:
                isNonZeroPositive = !_property.rectValue.Equals(Rect.zero);
                break;
            case SerializedPropertyType.String:
                isNonZeroPositive = !string.IsNullOrEmpty(_property.stringValue);
                break;
            case SerializedPropertyType.Vector2:
                isNonZeroPositive = !_property.vector2Value.Equals(Vector2.zero);
                break;
            case SerializedPropertyType.Vector3:
                isNonZeroPositive = !_property.vector3Value.Equals(Vector3.zero);
                break;
            case SerializedPropertyType.Vector4:
                isNonZeroPositive = !_property.vector4Value.Equals(Vector4.zero);
                break;
        }
        return isNonZeroPositive;
    }
    #endregion
}
#endif