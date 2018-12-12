#if UNITY_EDITOR 
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// ReadOnlyAttribute绘制
/// </summary>
sealed class EditorReadOnlyAttributeDrawer : AbsEditorAttributeDrawer
{
    /// <summary>
    /// 只读映射
    /// </summary>
    static Dictionary<int, bool> mReadOnlyMaping = new Dictionary<int, bool>();
    /// <summary>
    /// 是否只读
    /// </summary>
    /// <param name="_propertyKey">属性Key</param>
    /// <returns>true:只读,false:非只读</returns>
    public override bool IsReadOnly(int _propertyKey)
    {
        return mReadOnlyMaping[_propertyKey];
    }
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
        if (!mReadOnlyMaping.ContainsKey(_propertyKey))
        {            
            ReadOnlyAttribute attr = _fieldInfo.GetFirstAttributeAbsolute<ReadOnlyAttribute>();
            mReadOnlyMaping.Add(_propertyKey, attr != null);
        }
        return _label;
    }
}
#endif