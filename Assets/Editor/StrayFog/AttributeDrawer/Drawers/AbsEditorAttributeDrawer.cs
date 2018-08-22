using System.Reflection;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 编辑器属性绘制抽象类
/// </summary>
abstract class AbsEditorAttributeDrawer
{
    /// <summary>
    /// Execute
    /// </summary>
    /// <param name="_propertyKey">属性Key</param>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <param name="_fieldInfo">字段信息</param>
    public virtual GUIContent Execute(int _propertyKey, Rect _position, SerializedProperty _property, GUIContent _label, FieldInfo _fieldInfo)
    {
        return _label;
    }
    /// <summary>
    /// 是否绘制属性
    /// </summary>
    /// <param name="_propertyKey">属性Key</param>
    /// <returns>true:绘制,false:不绘制</returns>
    public virtual bool IsDrawer(int _propertyKey)
    {
        return true;
    }
    /// <summary>
    /// GetPropertyHeight
    /// </summary>
    /// <param name="_propertyKey">属性Key</param>
    /// <returns>属性高度</returns>
    public virtual float GetPropertyHeight(int _propertyKey)
    {
        return 0;
    }
}
