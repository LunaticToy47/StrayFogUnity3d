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
    /// GUIContent映射
    /// </summary>
    static Dictionary<int, GUIContent> mGUIContentMaping = new Dictionary<int, GUIContent>();
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
        if (!mGUIContentMaping.ContainsKey(_propertyKey))
        {
            mGUIContentMaping.Add(_propertyKey, new GUIContent(_label.text, _label.image, _label.tooltip));
            AliasTooltipAttribute attr = _fieldInfo.GetFirstAttributeAbsolute<AliasTooltipAttribute>();
            if (attr != null)
            {
                mGUIContentMaping[_propertyKey].text = attr.alias;
                mGUIContentMaping[_propertyKey].tooltip = attr.tooltip;
            }
        }
        return mGUIContentMaping[_propertyKey];
    }
}
#endif