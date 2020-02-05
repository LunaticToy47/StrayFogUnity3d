#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
#region enEditorAssetFilterClassify 资源收集过滤分类
/// <summary>
/// 资源收集过滤分类
/// </summary>
[Serializable]
[Flags]
public enum enEditorAssetFilterClassify
{
    /// <summary>
    /// Texture2D
    /// </summary>
    [EditorAssetFilter("t:Texture2D")]
    Texture2D = 0x1,
    /// <summary>
    /// AudioClip
    /// </summary>
    [EditorAssetFilter("t:AudioClip")]
    AudioClip = 0x2,
    /// <summary>
    /// Prefab
    /// </summary>
    [EditorAssetFilter("t:Prefab")]
    Prefab = 0x4,
    /// <summary>
    /// Scene
    /// </summary>
    [EditorAssetFilter("t:Scene")]
    Scene = 0x8,
    /// <summary>
    /// Object
    /// </summary>
    [EditorAssetFilter("t:Object")]
    Object = 0x10,
    /// <summary>
    /// DefaultAsset
    /// </summary>
    [EditorAssetFilter("t:DefaultAsset")]
    DefaultAsset = 0x20,
    /// <summary>
    /// TextAsset
    /// </summary>
    [EditorAssetFilter("t:TextAsset")]
    TextAsset = 0x40
}
/// <summary>
/// 资源收集依赖分类
/// </summary>
[Serializable]
public enum enEditorDependencyClassify
{
    /// <summary>
    /// 不包含依赖项
    /// </summary>
    UnClude,
    /// <summary>
    /// 包含依赖项
    /// </summary>
    InClude,
}
#endregion
/// <summary>
/// 资源收集
/// </summary>
public class EditorUtility_CollectAsset : AbsEditorSingle
{
    #region CollectAsset 收集资源【T重载】
    #region  一参数
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, string.Empty, enEditorDependencyClassify.UnClude, null, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, string.Empty, enEditorDependencyClassify.UnClude, null, null, _displayProgressBar);
    }
    #endregion

    #region 二参数
    #region _searchInFolders,_filter
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, OnResolveAssetFilter(_filter), enEditorDependencyClassify.UnClude, null, null);
    }

    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, OnResolveAssetFilter(_filter), enEditorDependencyClassify.UnClude, null, null, _displayProgressBar);
    }

    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, enEditorDependencyClassify.UnClude, null, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, enEditorDependencyClassify.UnClude, null, null, _displayProgressBar);
    }
    #endregion

    #region _searchInFolders,_includeDependencies
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorDependencyClassify _dependencyClassify)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, string.Empty, _dependencyClassify, null, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorDependencyClassify _dependencyClassify, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, string.Empty, _dependencyClassify, null, null, _displayProgressBar);
    }
    #endregion

    #endregion

    #region 三参数
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, enEditorDependencyClassify _dependencyClassify)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, OnResolveAssetFilter(_filter), _dependencyClassify, null, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, enEditorDependencyClassify _dependencyClassify, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, OnResolveAssetFilter(_filter), _dependencyClassify, null, null, _displayProgressBar);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, enEditorDependencyClassify _dependencyClassify)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _dependencyClassify, null, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, enEditorDependencyClassify _dependencyClassify, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _dependencyClassify, null, null, _displayProgressBar);
    }
    #endregion

    #region 四参数
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, enEditorDependencyClassify _dependencyClassify,
        Func<T, bool> _funIslegal)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _dependencyClassify, _funIslegal, null);
    }

    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, enEditorDependencyClassify _dependencyClassify,
        Func<T, bool> _funIslegal, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _dependencyClassify, _funIslegal, null, _displayProgressBar);
    }

    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, enEditorDependencyClassify _dependencyClassify,
        Func<T, bool> _funIslegal)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _dependencyClassify, _funIslegal, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, enEditorDependencyClassify _dependencyClassify,
        Func<T, bool> _funIslegal, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _dependencyClassify, _funIslegal, null, _displayProgressBar);
    }
    #endregion

    #region 五参数
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_funIsForceExclude">是否强制排除</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, enEditorDependencyClassify _dependencyClassify,
        Func<T, bool> _funIslegal, Func<T, bool> _funIsForceExclude)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _dependencyClassify, _funIslegal, _funIsForceExclude, true);
    }

    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_funIsForceExclude">是否强制排除</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, enEditorDependencyClassify _dependencyClassify,
        Func<T, bool> _funIslegal, Func<T, bool> _funIsForceExclude)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _dependencyClassify, _funIslegal, _funIsForceExclude, true);
    }
    #endregion

    #region 六参数
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_funIsForceExclude">是否强制排除</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, enEditorDependencyClassify _dependencyClassify,
        Func<T, bool> _funIslegal, Func<T, bool> _funIsForceExclude, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, OnResolveAssetFilter(_filter), _dependencyClassify, _funIslegal, _funIsForceExclude, _displayProgressBar);
    }

    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_funIsForceExclude">是否强制排除</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, enEditorDependencyClassify _dependencyClassify,
        Func<T, bool> _funIslegal, Func<T, bool> _funIsForceExclude, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        return OnCollectAsset<T>(_searchInFolders, _filter, _dependencyClassify, _funIslegal, _funIsForceExclude, _displayProgressBar);
    }
    #endregion

    #endregion

    #region OnCollectAsset 收集资源
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_dependencyClassify">依赖项分类</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_funIsForceExclude">是否强制排除</param>
    /// <param name="_displayProgressBar">是否显示进度条</param>
    /// <returns>节点组</returns>
    List<T> OnCollectAsset<T>(
        string[] _searchInFolders, string _filter, enEditorDependencyClassify _dependencyClassify,
        Func<T, bool> _funIslegal, Func<T, bool> _funIsForceExclude, bool _displayProgressBar)
        where T : EditorSelectionAsset
    {
        List<T> results = new List<T>();
        string[] arrPath = AssetDatabase.FindAssets(_filter, _searchInFolders);
        if (arrPath != null && arrPath.Length > 0)
        {
            bool isForceExclude = false;
            bool islegal = false;
            List<string> lstNodePath = new List<string>();
            string[] arrDepPath = null;
            T node = null;
            float progress = 0;
            Type type = typeof(T);
            for (int i = 0; i < arrPath.Length; i++)
            {
                arrPath[i] = AssetDatabase.GUIDToAssetPath(arrPath[i]);
                progress = i + 1;
                if (_displayProgressBar)
                {
                    EditorUtility.DisplayProgressBar("CollectAsset=>" + type.Name, arrPath[i], progress / arrPath.Length);
                }

                if (_dependencyClassify == enEditorDependencyClassify.InClude)
                {
                    #region 收集依赖项
                    arrDepPath = AssetDatabase.GetDependencies(arrPath[i]);
                    if (arrDepPath != null && arrDepPath.Length > 0)
                    {
                        foreach (string p in arrDepPath)
                        {
                            if (!lstNodePath.Contains(p))
                            {
                                lstNodePath.Add(p);
                            }
                        }
                    }
                    #endregion
                }
                else if (!lstNodePath.Contains(arrPath[i]))
                {
                    lstNodePath.Add(arrPath[i]);
                }
            }

            progress = 0;
            for (int i = 0; i < lstNodePath.Count; i++)
            {
                progress = i + 1;
                if (_displayProgressBar)
                {
                    EditorUtility.DisplayProgressBar("Filter Asset=>" + type.Name, arrPath[i], progress / lstNodePath.Count);
                }
                if (File.Exists(lstNodePath[i]))
                {
                    node = (T)Activator.CreateInstance(typeof(T), lstNodePath[i]);
                    islegal = _funIslegal == null || (_funIslegal != null && _funIslegal(node));
                    isForceExclude = _funIsForceExclude != null && _funIsForceExclude(node);
                    if (islegal && !isForceExclude)
                    {
                        results.Add(node);
                    }
                }
            }
        }
        if (_displayProgressBar)
        {
            EditorUtility.ClearProgressBar();
        }
        return results;
    }
    #endregion

    #region OnResolveAssetFilter 获得资源过滤规则字符串
    /// <summary>
    /// enEditorAssetFilterClassify映射
    /// </summary>
    static readonly List<enEditorAssetFilterClassify> mEnEditorAssetFilterClassifyMaping = typeof(enEditorAssetFilterClassify).ToEnums<enEditorAssetFilterClassify>();
    /// <summary>
    /// 已解析的过滤字符映射
    /// </summary>
    static readonly Dictionary<int, string> mResolveAssetFilterMaping = new Dictionary<int, string>();
    /// <summary>
    /// 获得资源过滤规则字符串
    /// </summary>
    /// <param name="_filter">过滤</param>
    /// <returns>过滤字符串</returns>
    string OnResolveAssetFilter(enEditorAssetFilterClassify _filter)
    {
        string filter = string.Empty;
        int value = (int)_filter;
        if (mResolveAssetFilterMaping.ContainsKey(value))
        {
            filter = mResolveAssetFilterMaping[value];
        }
        else
        {
            for (int i = 0; i < mEnEditorAssetFilterClassifyMaping.Count; i++)
            {
                if ((mEnEditorAssetFilterClassifyMaping[i] & _filter) == mEnEditorAssetFilterClassifyMaping[i])
                {
                    filter += mEnEditorAssetFilterClassifyMaping[i].GetAttribute<EditorAssetFilterAttribute>().filter + " ";
                }
            }
            mResolveAssetFilterMaping.Add(value, filter);
        }
        return filter;
    }
    #endregion
}
#endif