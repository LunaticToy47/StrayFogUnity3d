using System;
using System.Reflection;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 引擎应用程序
/// </summary>
public sealed class StrayFogRunningApplication : AbsSingleScriptableObject
{
    #region LoadAssetAtPath 从指定路径加载资源
    /// <summary>
    /// 从指定路径加载资源
    /// </summary>
    /// <param name="_assetPath">资源路径</param>
    /// <param name="_type">资源类别</param>
    /// <returns>资源</returns>
    public UnityEngine.Object LoadAssetAtPath(string _assetPath, Type _type)
    {
#if UNITY_EDITOR
        return AssetDatabase.LoadAssetAtPath(_assetPath, _type);
#else
        return null;
#endif
    }
    #endregion

    #region UNITY_EDITOR
#if UNITY_EDITOR
    [InvokeMethod("EditorDisplayParameter")]
    public string invoke;
    /// <summary>
    /// OnDisplayPath
    /// </summary>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <returns>高度</returns>
    float EditorDisplayParameter(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        float y = _position.y;
        _position.height = 16;
        PropertyInfo[] properties = GetType().GetProperties();
        if (properties != null && properties.Length > 0)
        {
            foreach (PropertyInfo p in properties)
            {
                if (p.CanRead && !p.CanWrite)
                {
                    EditorGUI.LabelField(_position, string.Format("{0}=>{1}", p.Name, p.GetValue(this, null)));
                    _position.y += _position.height;
                }
            }
        }
        return _position.y - y;
    }
#endif
    #endregion
}