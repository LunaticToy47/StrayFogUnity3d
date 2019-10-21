#if UNITY_EDITOR 
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// ReferPropertyDisplayInspector绘制
/// </summary>
sealed class EditorReferPropertyDisplayMultipleInspectorDrawer : AbsEditorAttributeDrawer
{
    /// <summary>
    /// ReferPropertyDisplayMultipleInspectorAttribute映射
    /// </summary>
    static Dictionary<int, List<ReferPropertyDisplayMultipleInspectorAttribute>> mReferPropertyDisplayMultipleInspectorMaping = new Dictionary<int, List<ReferPropertyDisplayMultipleInspectorAttribute>>();
    /// <summary>
    /// 是否绘制
    /// </summary>
    static Dictionary<int, bool> mIsDarwerMaping = new Dictionary<int, bool>();
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
        if (!mReferPropertyDisplayMultipleInspectorMaping.ContainsKey(_propertyKey))
        {
            mReferPropertyDisplayMultipleInspectorMaping.Add(_propertyKey, _fieldInfo.GetAttributes<ReferPropertyDisplayMultipleInspectorAttribute>());
        }
        if (!mIsDarwerMaping.ContainsKey(_propertyKey))
        {
            mIsDarwerMaping.Add(_propertyKey, true);
        }
        if (mReferPropertyDisplayMultipleInspectorMaping[_propertyKey] != null && mReferPropertyDisplayMultipleInspectorMaping[_propertyKey].Count > 0)
        {
            bool isShow = true;
            switch (mReferPropertyDisplayMultipleInspectorMaping[_propertyKey][0].referPropertyOperator)
            {
                case enSerializedPropertyOperatorInspectorAttribute.And:
                    isShow = true;
                    break;
                case enSerializedPropertyOperatorInspectorAttribute.Or:
                    isShow = false;
                    break;
            }
            foreach (ReferPropertyDisplayMultipleInspectorAttribute attr in mReferPropertyDisplayMultipleInspectorMaping[_propertyKey])
            {
                switch (mReferPropertyDisplayMultipleInspectorMaping[_propertyKey][0].referPropertyOperator)
                {
                    case enSerializedPropertyOperatorInspectorAttribute.And:
                        isShow &= OnSingleShow(_property, attr);
                        break;
                    case enSerializedPropertyOperatorInspectorAttribute.Or:
                        isShow |= OnSingleShow(_property, attr);
                        break;
                }
            }
            mIsDarwerMaping[_propertyKey] = isShow;
        }
        return _label;
    }

    /// <summary>
    /// 单个属性显示
    /// </summary>
    /// <param name="_property">属性</param>
    /// <param name="_multipleAttribute">多属性</param>
    /// <returns>true:显示,false:不显示</returns>
    bool OnSingleShow(SerializedProperty _property, ReferPropertyDisplayMultipleInspectorAttribute _multipleAttribute)
    {
        bool isShow = true;
        switch (_multipleAttribute.operatorType)
        {
            case enSerializedPropertyOperatorInspectorAttribute.And:
                isShow = true;
                break;
            case enSerializedPropertyOperatorInspectorAttribute.Or:
                isShow = false;
                break;
        }
        SerializedProperty referSp = EditorStrayFogUtility.guiLayout.FindPropertyRelative(_property, _multipleAttribute.referPropertyName);
        if (referSp != null)
        {
            if (_multipleAttribute.referPropertyValue.Length > 0)
            {
                foreach (object v in _multipleAttribute.referPropertyValue)
                {
                    switch (_multipleAttribute.displayType)
                    {
                        case enSerializedPropertyDisplayInspectorAttribute.GivenValue:
                            switch (_multipleAttribute.operatorType)
                            {
                                case enSerializedPropertyOperatorInspectorAttribute.And:
                                    isShow &= EditorStrayFogUtility.guiLayout.EqualsSerializedPropertyValue(v, referSp);
                                    break;
                                case enSerializedPropertyOperatorInspectorAttribute.Or:
                                    isShow |= EditorStrayFogUtility.guiLayout.EqualsSerializedPropertyValue(v, referSp);
                                    break;
                            }
                            break;
                        case enSerializedPropertyDisplayInspectorAttribute.NOT:
                            switch (_multipleAttribute.operatorType)
                            {
                                case enSerializedPropertyOperatorInspectorAttribute.And:
                                    isShow &= !EditorStrayFogUtility.guiLayout.EqualsSerializedPropertyValue(v, referSp);
                                    break;
                                case enSerializedPropertyOperatorInspectorAttribute.Or:
                                    isShow |= !EditorStrayFogUtility.guiLayout.EqualsSerializedPropertyValue(v, referSp);
                                    break;
                            }
                            break;
                        case enSerializedPropertyDisplayInspectorAttribute.NonZeroPositive:
                            switch (_multipleAttribute.operatorType)
                            {
                                case enSerializedPropertyOperatorInspectorAttribute.And:
                                    isShow &= EditorStrayFogUtility.guiLayout.IsNonZeroPositive(referSp);
                                    break;
                                case enSerializedPropertyOperatorInspectorAttribute.Or:
                                    isShow |= EditorStrayFogUtility.guiLayout.IsNonZeroPositive(referSp);
                                    break;
                            }
                            break;
                    }
                }
            }
            else
            {
                switch (_multipleAttribute.displayType)
                {
                    case enSerializedPropertyDisplayInspectorAttribute.GivenValue:
                        isShow &= referSp.objectReferenceValue == null;
                        break;
                    case enSerializedPropertyDisplayInspectorAttribute.NonZeroPositive:
                        isShow &= referSp.objectReferenceValue != null;
                        break;
                    case enSerializedPropertyDisplayInspectorAttribute.NOT:
                        isShow &= referSp.objectReferenceValue != null;
                        break;
                }
            }
        }
        return isShow;
    }

    /// <summary>
    /// 是否绘制
    /// </summary>
    /// <param name="_propertyKey">属性key</param>
    /// <returns>true:绘制,false:不绘制</returns>
    public override bool IsDrawer(int _propertyKey)
    {
        return mIsDarwerMaping[_propertyKey];
    }
}
#endif