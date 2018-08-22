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
    DefaultAsset = 0x20
}
#endregion


/// <summary>
/// 资源收集
/// </summary>
public class EditorUtility_CollectAsset : AbsSingle<EditorUtility_CollectAsset>
{
    #region CollectAsset 收集资源【EditorSelectionAsset重载】
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders, OnResolveAssetFilter(_filter));
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders, string _filter)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders, _filter);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders, bool _includeDependencies)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders, _includeDependencies);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, bool _includeDependencies)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders, OnResolveAssetFilter(_filter), _includeDependencies);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders, string _filter, bool _includeDependencies)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders, _filter, _includeDependencies);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, bool _includeDependencies,
        Func<EditorSelectionAsset, bool> _funIslegal)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders, OnResolveAssetFilter(_filter), _includeDependencies, _funIslegal);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders, string _filter, bool _includeDependencies,
        Func<EditorSelectionAsset, bool> _funIslegal)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders, _filter, _includeDependencies, _funIslegal);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_funIsForceExclude">是否强制排除</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, bool _includeDependencies,
        Func<EditorSelectionAsset, bool> _funIslegal,
        Func<EditorSelectionAsset, bool> _funIsForceExclude)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders, OnResolveAssetFilter(_filter), _includeDependencies, _funIslegal, _funIsForceExclude);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_funIsForceExclude">是否强制排除</param>
    /// <returns>节点组</returns>
    public List<EditorSelectionAsset> CollectAsset(
        string[] _searchInFolders, string _filter, bool _includeDependencies,
        Func<EditorSelectionAsset, bool> _funIslegal,
        Func<EditorSelectionAsset, bool> _funIsForceExclude)
    {
        return CollectAsset<EditorSelectionAsset>(_searchInFolders, _filter, _includeDependencies, _funIslegal, _funIsForceExclude);
    }
    #endregion

    #region CollectAsset 收集资源【T重载】
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
        return CollectAsset<T>(_searchInFolders, string.Empty, false, null, null);
    }
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
        return CollectAsset<T>(_searchInFolders, OnResolveAssetFilter(_filter), false, null, null);
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
        return CollectAsset<T>(_searchInFolders, _filter, false, null, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, bool _includeDependencies)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, string.Empty, _includeDependencies, null, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, bool _includeDependencies)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, OnResolveAssetFilter(_filter), _includeDependencies, null, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, bool _includeDependencies)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _includeDependencies, null, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, bool _includeDependencies,
        Func<T, bool> _funIslegal)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, OnResolveAssetFilter(_filter), _includeDependencies, _funIslegal, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, bool _includeDependencies,
        Func<T, bool> _funIslegal)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, _filter, _includeDependencies, _funIslegal, null);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_funIsForceExclude">是否强制排除</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, enEditorAssetFilterClassify _filter, bool _includeDependencies,
        Func<T, bool> _funIslegal, Func<T, bool> _funIsForceExclude)
        where T : EditorSelectionAsset
    {
        return CollectAsset<T>(_searchInFolders, OnResolveAssetFilter(_filter), _includeDependencies, _funIslegal, _funIsForceExclude);
    }
    /// <summary>
    /// 收集资源
    /// </summary>
    /// <typeparam name="T">资源节点</typeparam>
    /// <param name="_searchInFolders">搜索目录</param>
    /// <param name="_filter">过滤</param>
    /// <param name="_includeDependencies">是否包含依赖项</param>
    /// <param name="_funIslegal">是否合法</param>
    /// <param name="_funIsForceExclude">是否强制排除</param>
    /// <returns>节点组</returns>
    public List<T> CollectAsset<T>(
        string[] _searchInFolders, string _filter, bool _includeDependencies,
        Func<T, bool> _funIslegal, Func<T, bool> _funIsForceExclude)
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
            for (int i = 0; i < arrPath.Length; i++)
            {
                arrPath[i] = AssetDatabase.GUIDToAssetPath(arrPath[i]);
                if (_includeDependencies)
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

            foreach (string p in lstNodePath)
            {
                if (File.Exists(p))
                {
                    node = (T)Activator.CreateInstance(typeof(T), p);
                    islegal = _funIslegal == null || (_funIslegal != null && _funIslegal(node));
                    isForceExclude = _funIsForceExclude != null && _funIsForceExclude(node);
                    if (islegal && !isForceExclude)
                    {
                        results.Add(node);
                    }
                }
            }
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
