#if UNITY_EDITOR 
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// AliasTooltipAttribute绘制
/// </summary>
sealed class EditorAliasTooltipAttributeDrawer : AbsEditorAttributeDrawer
{
    /// <summary>
    /// AliasTooltipAttribute映射
    /// </summary>
    static Dictionary<int, AliasTooltipAttribute> mAliasTooltipMaping = new Dictionary<int, AliasTooltipAttribute>();
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
        if (!mAliasTooltipMaping.ContainsKey(_propertyKey))
        {           
            AliasTooltipAttribute attr = _fieldInfo.GetFirstAttributeAbsolute<AliasTooltipAttribute>();
            mAliasTooltipMaping.Add(_propertyKey, attr);
        }
        if (mAliasTooltipMaping[_propertyKey] != null)
        {
            _label.text = mAliasTooltipMaping[_propertyKey].alias;
            _label.tooltip = mAliasTooltipMaping[_propertyKey].tooltip;
        }
        return _label;
    }
}
#endif