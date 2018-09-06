#if UNITY_EDITOR 
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// ValueRangeAttribute绘制
/// </summary>
sealed class EditorValueRangeAttributeDrawer : AbsEditorAttributeDrawer
{
    /// <summary>
    /// ValueRangeAttribute映射
    /// </summary>
    static Dictionary<int, ValueRangeAttribute> mValueRangeMaping = new Dictionary<int, ValueRangeAttribute>();
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
        if (!mValueRangeMaping.ContainsKey(_propertyKey))
        {
            mValueRangeMaping.Add(_propertyKey, _fieldInfo.GetFirstAttributeAbsolute<ValueRangeAttribute>());
        }
        if (mValueRangeMaping[_propertyKey] != null)
        {
            switch (_property.propertyType)
            {
                case SerializedPropertyType.Integer:
                    _property.intValue = Mathf.Clamp(_property.intValue, mValueRangeMaping[_propertyKey].intMin, mValueRangeMaping[_propertyKey].intMax);
                    break;
                case SerializedPropertyType.Float:
                    _property.floatValue = Mathf.Clamp(_property.floatValue, mValueRangeMaping[_propertyKey].floatMin == 0 && mValueRangeMaping[_propertyKey].intMin != 0 ? mValueRangeMaping[_propertyKey].intMin : mValueRangeMaping[_propertyKey].floatMin, mValueRangeMaping[_propertyKey].floatMax == 0 && mValueRangeMaping[_propertyKey].intMax != 0 ? mValueRangeMaping[_propertyKey].intMax : mValueRangeMaping[_propertyKey].floatMax);
                    break;
            }
        }
        return _label;
    }
}
#endif