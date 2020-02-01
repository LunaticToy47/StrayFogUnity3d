#if UNITY_EDITOR 
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// ReadOnlyAttribute绘制
/// </summary>
sealed class EditorStaticClassConstFieldMapForEnumAttributeDrawer : AbsEditorAttributeDrawer
{
    /// <summary>
    /// StaticClassConstFieldMapForEnumAttribute映射
    /// </summary>
    static Dictionary<int, StaticClassConstFieldMapForEnumAttribute> mStaticClassConstFieldMapForEnumAttributeMaping = new Dictionary<int, StaticClassConstFieldMapForEnumAttribute>();
    /// <summary>
    /// GetLabel
    /// </summary>
    /// <param name="_propertyKey">属性Key</param>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <param name="_fieldInfo">字段信息</param>
    public override GUIContent Execute(int _propertyKey, Rect _position, SerializedProperty _property, GUIContent _label, FieldInfo _fieldInfo)
    {
        if (!mStaticClassConstFieldMapForEnumAttributeMaping.ContainsKey(_propertyKey))
        {
            StaticClassConstFieldMapForEnumAttribute attr =
                _fieldInfo.GetFirstAttributeAbsolute<StaticClassConstFieldMapForEnumAttribute>();
            mStaticClassConstFieldMapForEnumAttributeMaping.Add(_propertyKey, attr);
        }
        return _label;
    }

    /// <summary>
    /// 是否是静态类常量映射枚举
    /// </summary>
    /// <param name="_propertyKey">属性Key</param>
    /// <returns>true:是,false:否</returns>
    public override bool isStaticClassConstFieldMapForEnum(int _propertyKey)
    {
        return mStaticClassConstFieldMapForEnumAttributeMaping[_propertyKey] != null;
    }
}
#endif
