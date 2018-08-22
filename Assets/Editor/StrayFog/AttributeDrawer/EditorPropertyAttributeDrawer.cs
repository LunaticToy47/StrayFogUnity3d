using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/*
 1.EditorUnityGUIContentAttributeDrawer必须直接继承PropertyDrawer才可以起作用
 2.当CustomPropertyDrawer的useForChildren=true，则其子类才会起作用
*/

[CustomPropertyDrawer(typeof(PropertyAttribute), true)]
public class EditorPropertyAttributeDrawer : PropertyDrawer
{
    /// <summary>
    /// 属性绘制组
    /// </summary>
    static List<AbsEditorAttributeDrawer> mAttributeDrawers = null;
    /// <summary>
    /// 属性高
    /// </summary>
    Dictionary<int, float> mPropertyHeightMaping = new Dictionary<int, float>();
    /// <summary>
    /// 属性是否显示
    /// </summary>
    Dictionary<int, bool> mPropertyDrawMaping = new Dictionary<int, bool>();
    /// <summary>
    /// 是否绘制
    /// </summary>
    bool mIsDraw = false;
    /// <summary>
    /// OnGUI
    /// </summary>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        if (mAttributeDrawers == null)
        {
            mAttributeDrawers = new List<AbsEditorAttributeDrawer>();
            #region 搜索属性绘制类
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            Type drawerType = typeof(AbsEditorAttributeDrawer);
            if (types != null && types.Length > 0)
            {
                foreach (Type t in types)
                {
                    if (t.IsSubTypeOf(drawerType))
                    {
                        mAttributeDrawers.Add((AbsEditorAttributeDrawer)assembly.CreateInstance(t.FullName));
                    }
                }
            }
            #endregion
        }
        mIsDraw = true;
        int propertyKey = EditorStrayFogUtility.guiLayout.GetPropertyKey(_property, fieldInfo);
        if (!mPropertyHeightMaping.ContainsKey(propertyKey))
        {
            mPropertyHeightMaping.Add(propertyKey, 0);
        }
        float propertyHeight = 0;
        foreach (AbsEditorAttributeDrawer drawer in mAttributeDrawers)
        {
            _label = drawer.Execute(propertyKey, _position, _property, _label, fieldInfo);
            propertyHeight += drawer.GetPropertyHeight(propertyKey);
            mIsDraw &= drawer.IsDrawer(propertyKey);
        }
        mPropertyHeightMaping[propertyKey] = propertyHeight;
        if (!mPropertyDrawMaping.ContainsKey(propertyKey))
        {
            mPropertyDrawMaping.Add(propertyKey, mIsDraw);
        }
        else
        {
            mPropertyDrawMaping[propertyKey] = mIsDraw;
        }
        if (mIsDraw)
        {
            switch (_property.propertyType)
            {
                case SerializedPropertyType.Enum:
                    #region 绘制枚举
                    Type type = fieldInfo.FieldType;
                    if (type.IsArray)
                    {
                        type = fieldInfo.FieldType.GetElementType();
                    }
                    EditorStrayFogUtility.guiLayout.EnumPopup(type, _position, _property, _label);
                    #endregion
                    break;
                default:
                    #region 绘制普通
                    EditorGUI.PropertyField(_position, _property, _label, _property.hasVisibleChildren && _property.isExpanded);
                    #endregion
                    break;
            }
        }
    }
    /// <summary>
    /// GetPropertyHeight
    /// </summary>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <returns>Height</returns>
    public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label)
    {
        int propertyKey = EditorStrayFogUtility.guiLayout.GetPropertyKey(_property, fieldInfo);
        bool isDraw = mPropertyDrawMaping.ContainsKey(propertyKey) ? mPropertyDrawMaping[propertyKey] : false;
        return (isDraw ? EditorGUI.GetPropertyHeight(_property, _label) : 0) + (mPropertyHeightMaping.ContainsKey(propertyKey) ? mPropertyHeightMaping[propertyKey] : 0);
    }
}
