﻿#if UNITY_EDITOR 
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// ReferPropertyDisplayInspector绘制
/// </summary>
sealed class EditorReferPropertyDisplayInspectorDrawer : AbsEditorAttributeDrawer
{
    /// <summary>
    /// ReferPropertyDisplayInspector映射
    /// </summary>
    static Dictionary<int, ReferPropertyDisplayInspectorAttribute> mReferPropertyDisplayInspectorMaping = new Dictionary<int, ReferPropertyDisplayInspectorAttribute>();
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
        if (!mReferPropertyDisplayInspectorMaping.ContainsKey(_propertyKey))
        {
            mReferPropertyDisplayInspectorMaping.Add(_propertyKey, _fieldInfo.GetFirstAttributeAbsolute<ReferPropertyDisplayInspectorAttribute>());
        }
        if (!mIsDarwerMaping.ContainsKey(_propertyKey))
        {
            mIsDarwerMaping.Add(_propertyKey, true);
        }
        if (mReferPropertyDisplayInspectorMaping[_propertyKey] != null)
        {
            bool isShow = true;
            switch (mReferPropertyDisplayInspectorMaping[_propertyKey].operatorType)
            {
                case enSerializedPropertyOperatorInspectorAttribute.And:
                    isShow = true;
                    break;
                case enSerializedPropertyOperatorInspectorAttribute.Or:
                    isShow = false;
                    break;
            }
            SerializedProperty referSp = EditorStrayFogUtility.guiLayout.FindPropertyRelative(_property, mReferPropertyDisplayInspectorMaping[_propertyKey].referPropertyName);
            if (referSp != null)
            {
                if (mReferPropertyDisplayInspectorMaping[_propertyKey].referPropertyValue.Length > 0)
                {
                    foreach (object v in mReferPropertyDisplayInspectorMaping[_propertyKey].referPropertyValue)
                    {
                        switch (mReferPropertyDisplayInspectorMaping[_propertyKey].displayType)
                        {
                            case enSerializedPropertyDisplayInspectorAttribute.GivenValue:
                                switch (mReferPropertyDisplayInspectorMaping[_propertyKey].operatorType)
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
                                switch (mReferPropertyDisplayInspectorMaping[_propertyKey].operatorType)
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
                                switch (mReferPropertyDisplayInspectorMaping[_propertyKey].operatorType)
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
                    switch (mReferPropertyDisplayInspectorMaping[_propertyKey].displayType)
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
            mIsDarwerMaping[_propertyKey] = isShow;
        }
        return _label;
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