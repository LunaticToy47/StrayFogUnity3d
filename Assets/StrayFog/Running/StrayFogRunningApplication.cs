using System;
using System.Reflection;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 注册引导事件句柄
/// </summary>
/// <param name="_guide">引导</param>
public delegate void RegisterGuideEventHandle(UIGuideRegister _guide);
/// <summary>
/// 注册引导事件句柄
/// </summary>
/// <param name="_xLuaFileId">xLua文件ID</param>
/// <param name="_xLuaFolderId">xLua文件夹ID</param>
/// <param name="_onComplete">完成事件</param>
public delegate void LoadXLuaEventHandle(int _xLuaFileId, int _xLuaFolderId, Action<bool,TextAsset> _onComplete);

/// <summary>
/// 引擎应用程序
/// </summary>
public class StrayFogRunningApplication : AbsSingleScriptableObject
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

    #region RegisterGuide 注册引导
    /// <summary>
    /// 注册引导事件
    /// </summary>
    public event RegisterGuideEventHandle OnRegisterGuide;
    /// <summary>
    /// 注册引导
    /// </summary>
    /// <param name="_guide">引导</param>
    public void RegisterGuide(UIGuideRegister _guide)
    {
        if (OnRegisterGuide != null)
        {
            OnRegisterGuide(_guide);
        }
    }
    #endregion

    #region LoadXLua 加载xLua文件
    /// <summary>
    /// 注册加载xLua文件事件
    /// </summary>
    public event LoadXLuaEventHandle OnLoadXLua;
    /// <summary>
    /// 加载xLua文件
    /// </summary>
    /// <param name="_xLuaFileId">xLua文件ID</param>
    /// <param name="_xLuaFolderId">xLua文件夹ID</param>
    /// <param name="_onComplete">完成回调</param>
    public void LoadXLua(int _xLuaFileId, int _xLuaFolderId, Action<bool,TextAsset> _onComplete)
    {
        if (OnLoadXLua != null)
        {
            OnLoadXLua(_xLuaFileId, _xLuaFolderId, _onComplete);
        }
        else
        {
            _onComplete(false,null);
        }
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
    protected virtual float EditorDisplayParameter(Rect _position, SerializedProperty _property, GUIContent _label)
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