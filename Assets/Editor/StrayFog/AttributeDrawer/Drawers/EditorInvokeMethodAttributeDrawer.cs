using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// InvokeMethodAttribute绘制
/// </summary>
sealed class EditorInvokeMethodAttributeDrawer : AbsEditorAttributeDrawer
{
    /// <summary>
    /// 调用方法特性映射
    /// </summary>
    static Dictionary<int, MethodInfo> mInvokeMethodMaping = new Dictionary<int, MethodInfo>();
    /// <summary>
    /// 调用方法对应值对象映射
    /// </summary>
    static Dictionary<int, object> mInvokeMethodObjectMaping = new Dictionary<int, object>();
    /// <summary>
    /// 属性映射
    /// </summary>
    static Dictionary<int, InvokeMethodAttribute> mInvokeMethodAttributeMaping = new Dictionary<int, InvokeMethodAttribute>();
    /// <summary>
    /// 属性高度映射
    /// </summary>
    static Dictionary<int, float> mPropertyHeightMaping = new Dictionary<int, float>();
    /// <summary>
    /// Execute
    /// </summary>
    /// <param name="_propertyKey">属性Key</param>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <param name="_fieldInfo">字段信息</param>
    public override GUIContent Execute(int _propertyKey, Rect _position, SerializedProperty _property, GUIContent _label, FieldInfo _fieldInfo)
    {
        if (!mPropertyHeightMaping.ContainsKey(_propertyKey))
        {
            mPropertyHeightMaping.Add(_propertyKey, 0);
        }
        if (!mInvokeMethodAttributeMaping.ContainsKey(_propertyKey))
        {
            mInvokeMethodAttributeMaping.Add(_propertyKey, _fieldInfo.GetFirstAttributeAbsolute<InvokeMethodAttribute>());
        }
        if (mInvokeMethodAttributeMaping[_propertyKey] != null)
        {
            MethodInfo execMethod = null;
            object execMethodObject = null;
            SerializedProperty parentProperty = null;
            int key = 0;
            object[] parameters = new object[3] { _position, _property, _label };
            if (!mInvokeMethodMaping.ContainsKey(_propertyKey))
            {
                #region 查找可执行的方法
                MethodInfo[] waitMethods = _fieldInfo.DeclaringType.GetMethods(mInvokeMethodAttributeMaping[_propertyKey].bindingFlags);
                if (waitMethods != null && waitMethods.Length > 0)
                {
                    ParameterInfo[] mtParams = null;
                    ParameterInfo mtReturn = null;
                    bool isValidMethod = false;
                    foreach (MethodInfo mi in waitMethods)
                    {
                        isValidMethod = false;
                        mtParams = mi.GetParameters();
                        mtReturn = mi.ReturnParameter;
                        isValidMethod = mi.Name.Equals(mInvokeMethodAttributeMaping[_propertyKey].methodName) && mtParams != null && mtParams.Length == parameters.Length && mtReturn != null;
                        if (isValidMethod)
                        {
                            for (int i = 0; i < mtParams.Length; i++)
                            {
                                isValidMethod &= mtParams[i].ParameterType.IsTypeOrSubTypeOf(parameters[i].GetType().BaseType);
                            }
                            isValidMethod &= mtReturn.ParameterType.IsTypeOrSubTypeOf(typeof(float));
                        }
                        if (isValidMethod)
                        {
                            execMethod = mi;
                            break;
                        }
                    }
                }
                mInvokeMethodMaping.Add(_propertyKey, execMethod);
                #endregion
            }

            if (!mInvokeMethodObjectMaping.ContainsKey(_propertyKey) || mInvokeMethodObjectMaping[_propertyKey] == null)
            {
                #region 查找当前fieldInfo的值对象                    
                if (_property.depth == 0)
                {
                    //根属性
                    if (!mInvokeMethodObjectMaping.ContainsKey(_propertyKey))
                    {
                        mInvokeMethodObjectMaping.Add(_propertyKey, _fieldInfo.GetValue(_property.serializedObject.targetObject));
                    }
                    else
                    {
                        mInvokeMethodObjectMaping[_propertyKey] = _fieldInfo.GetValue(_property.serializedObject.targetObject);
                    }
                }
                else
                {
                    parentProperty = EditorStrayFogUtility.guiLayout.FindParentProperty(_property, _fieldInfo);
                    key = 0;
                    if (parentProperty != null)
                    {
                        key = EditorStrayFogUtility.guiLayout.GetPropertyKey(parentProperty, _fieldInfo);
                        if (mInvokeMethodObjectMaping.ContainsKey(key))
                        {
                            if (_fieldInfo.DeclaringType.IsTypeOf(mInvokeMethodObjectMaping[key].GetType()))
                            {
                                if (!mInvokeMethodObjectMaping.ContainsKey(_propertyKey))
                                {
                                    mInvokeMethodObjectMaping.Add(_propertyKey, _fieldInfo.GetValue(mInvokeMethodObjectMaping[key]));
                                }
                                else
                                {
                                    mInvokeMethodObjectMaping[_propertyKey] = _fieldInfo.GetValue(mInvokeMethodObjectMaping[key]);
                                }
                            }
                        }
                    }
                    else if (_fieldInfo.FieldType.IsArray)
                    {
                        Array arrayValue = (Array)_fieldInfo.GetValue(_property.serializedObject.targetObject);
                        int index = EditorStrayFogUtility.guiLayout.GetPropertyIndex(_property);
                        if (arrayValue != null && arrayValue.Length > index)
                        {
                            if (!mInvokeMethodObjectMaping.ContainsKey(_propertyKey))
                            {
                                mInvokeMethodObjectMaping.Add(_propertyKey, arrayValue.GetValue(index));
                            }
                            else
                            {
                                mInvokeMethodObjectMaping[_propertyKey] = arrayValue.GetValue(index);
                            }
                        }
                    }
                }
                #endregion
            }

            #region 执行函数
            execMethod = mInvokeMethodMaping[_propertyKey];
            if (execMethod != null)
            {
                #region 调用对象
                if (_property.depth == 0)
                {
                    execMethodObject = _property.serializedObject.targetObject;
                }
                else
                {
                    parentProperty = EditorStrayFogUtility.guiLayout.FindParentProperty(_property, _fieldInfo);
                    if (parentProperty == null)
                    {
                        execMethodObject = _property.serializedObject.targetObject;
                    }
                    else
                    {
                        key = EditorStrayFogUtility.guiLayout.GetPropertyKey(parentProperty, _fieldInfo);
                        if (mInvokeMethodObjectMaping.ContainsKey(key))
                        {
                            execMethodObject = mInvokeMethodObjectMaping[key];
                        }
                    }
                }
                #endregion

                if (execMethodObject != null)
                {
                    mPropertyHeightMaping[_propertyKey] = Convert.ToSingle(execMethod.Invoke(execMethodObject, parameters));
                }
            }
            else
            {
                Debug.LogErrorFormat("InvokeMethodAttribute call method 【float {0}(Rect _position, SerializedProperty _property, GUIContent _label)】", mInvokeMethodAttributeMaping[_propertyKey].methodName);
            }
            #endregion
        }
        return _label;
    }

    /// <summary>
    /// 是否绘制属性
    /// </summary>
    /// <param name="_propertyKey">属性Key</param>
    /// <returns>true:绘制,false:不绘制</returns>
    public override bool IsDrawer(int _propertyKey)
    {
        return mInvokeMethodAttributeMaping.ContainsKey(_propertyKey) && mInvokeMethodAttributeMaping[_propertyKey] != null ? mInvokeMethodAttributeMaping[_propertyKey].isDrawProperty : base.IsDrawer(_propertyKey);
    }

    /// <summary>
    /// GetPropertyHeight
    /// </summary>
    /// <param name="_propertyKey">属性Key</param>
    /// <returns>属性高度</returns>
    public override float GetPropertyHeight(int _propertyKey)
    {
        return mPropertyHeightMaping[_propertyKey];
    }
}
