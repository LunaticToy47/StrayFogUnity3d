﻿#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
/// <summary>
/// AssetBundleName选择资源
/// </summary>
public class EditorSelectionAssetBundleNameAsset : EditorSelectionAsset
{
    /// <summary>
    /// 场景后缀
    /// </summary>
    readonly static string msrSceneExt = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Scene).ext;
    /// <summary>
    /// Dll后缀
    /// </summary>
    readonly static string msrDllExt = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Dll).ext;
    /// <summary>
    /// xLua后缀
    /// </summary>
    readonly static string msrXLuaTxtExt = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.XLuaTxt).ext;
    /// <summary>
    /// Asmdef后缀
    /// </summary>
    readonly static string msrAsmdefExt = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Asmdef).ext;
    /// <summary>
    /// Asset后缀
    /// </summary>
    readonly static string msrAssetExt = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Asset).ext;
    /// <summary>
    /// 名称前缀
    /// </summary>
    static readonly Dictionary<string, string> msrNamePrefix = new Dictionary<string, string>()
        {
            {msrSceneExt,"s_" },
            {msrAssetExt,"a_" },
            {msrXLuaTxtExt,"x_" },
            {msrDllExt,"d_" },
            {msrAsmdefExt,"m_" }
        };

    /// <summary>
    /// 要锁定资源名称的后缀
    /// </summary>
    static readonly List<string> msrLockNameExt = new List<string>() {
        msrDllExt,msrAsmdefExt,msrAssetExt
    };
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pathOrGuid">路径或guid</param>
    public EditorSelectionAssetBundleNameAsset(string _pathOrGuid) : base(_pathOrGuid)
    {
        isRoot = false;
    }
    /// <summary>
    /// 引用项
    /// </summary>
    Dictionary<int, EditorSelectionAssetBundleNameAsset> mRefrenceMaping = new Dictionary<int, EditorSelectionAssetBundleNameAsset>();
    /// <summary>
    /// 依赖项
    /// </summary>
    Dictionary<int, EditorSelectionAssetBundleNameAsset> mDependencyMaping = new Dictionary<int, EditorSelectionAssetBundleNameAsset>();
    /// <summary>
    /// 构建节点依赖链
    /// </summary>
    /// <param name="_nodeMaping">节点映射</param>
    public void BuildDependencyLink(Dictionary<int, EditorSelectionAssetBundleNameAsset> _nodeMaping)
    {
        string[] dps = AssetDatabase.GetDependencies(path, false);
        if (dps != null && dps.Length > 0)
        {
            EditorSelectionAssetBundleNameAsset temp = null;
            foreach (string d in dps)
            {
                if (!d.Equals(guid))
                {
                    temp = new EditorSelectionAssetBundleNameAsset(d);
                    if (EditorStrayFogUtility.assetBundleName.IsAllowSetBundleName(temp))
                    {
                        if (!_nodeMaping.ContainsKey(temp.guidHashCode))
                        {
                            _nodeMaping.Add(temp.guidHashCode, temp);
                        }
                        if (!_nodeMaping[temp.guidHashCode].mRefrenceMaping.ContainsKey(guidHashCode))
                        {
                            _nodeMaping[temp.guidHashCode].mRefrenceMaping.Add(guidHashCode, _nodeMaping[guidHashCode]);
                        }
                        if (!_nodeMaping[guidHashCode].mDependencyMaping.ContainsKey(temp.guidHashCode))
                        {
                            _nodeMaping[guidHashCode].mDependencyMaping.Add(temp.guidHashCode, _nodeMaping[temp.guidHashCode]);
                        }
                        _nodeMaping[temp.guidHashCode].BuildDependencyLink(_nodeMaping);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 日志
    /// </summary>
    /// <returns>日志</returns>
    public string ToLog()
    {
        StringBuilder sbLog = new StringBuilder();
        sbLog.AppendLine(string.Format("【{0}】【{1}】", path, mAssetBundleName));
        sbLog.AppendLine("dependencyies=>");
        foreach (EditorSelectionAssetBundleNameAsset d in mDependencyMaping.Values)
        {
            sbLog.AppendLine(d.path);
        }
        sbLog.AppendLine("refrences=>");
        foreach (EditorSelectionAssetBundleNameAsset r in mRefrenceMaping.Values)
        {
            sbLog.AppendLine(r.path);
        }
        sbLog.AppendLine("syncShrinkMerges=>");
        foreach (EditorSelectionAssetBundleNameAsset y in mSyncShrinkMergeMaping.Values)
        {
            sbLog.AppendLine(string.Format("{0}【{1}】", y.path, y.mAssetBundleName));
        }
        return sbLog.ToString();
    }
    /// <summary>
    /// 同步收缩合并点
    /// </summary>
    public Dictionary<int, EditorSelectionAssetBundleNameAsset> mSyncShrinkMergeMaping = new Dictionary<int, EditorSelectionAssetBundleNameAsset>();
    /// <summary>
    /// 收缩合并
    /// </summary>
    /// <returns>是否合并</returns>
    public bool ShrinkMerge()
    {
        #region 收缩合并说明
        /*
         * 收缩合并
         * 1.收缩合并目的是为了保证任何一个资源X都是被多个或零个资源引用，
         *    将所有只有一个资源引用的资源收缩到引用的资源内，
         *    以达到在使用任何资源时只进行最小的物理文件读取次数，加快载入内存的时间消耗。
         * 
         * 收缩合并图解:
         * 递归对所有只有唯一引用资源的资源都归入到引用资源中
         *            A       G
         *          /   \      |
         *         B    C    H                  【收缩合并】D合并到B
         *       /   \/   \  /
         *     D    E     F                   
         *===================================
         *            A        G             
         *          /    \      |            
         *     [BD]    C    H                【收缩合并】BD、C合并到A，H合并到G
         *          \   /  \  /
         *            E     F 
         *===================================
         *           A[BDC]   G[H]       【收缩合并】E合并到A
         *            |     \     /
         *           E        F
         *===================================
         *[BDCE] A    G[H]              【收缩合并】没有需要收缩合并的项，收缩合并结束
         *             \  /
         *               F                     
         *===================================
         * 结果=> 【ABDCE】=资源A,【GH】=资源G,【F】= 资源F
         * =====================
         */
        #endregion

        //仅被一个资源引用并且不是根节点的节点将被收缩
        bool isShrinkMerge = (mRefrenceMaping.Count == 1) && !isRoot;
        if (isShrinkMerge)
        {
            List<EditorSelectionAssetBundleNameAsset> lstRefs = new List<EditorSelectionAssetBundleNameAsset>(mRefrenceMaping.Values);
            EditorSelectionAssetBundleNameAsset refObj = lstRefs[0];
            #region 依赖项处理
            foreach (EditorSelectionAssetBundleNameAsset d in mDependencyMaping.Values)
            {
                //所有依赖项的引用项去掉当前项，添加当前项的引用项
                //去掉当前项
                d.mRefrenceMaping.Remove(guidHashCode);
                //添加当前项的引用项
                if (!d.mRefrenceMaping.ContainsKey(refObj.guidHashCode))
                {
                    d.mRefrenceMaping.Add(refObj.guidHashCode, refObj);
                }
                //当前依赖项添加到引用项的依赖项中
                if (!refObj.mDependencyMaping.ContainsKey(d.guidHashCode))
                {
                    refObj.mDependencyMaping.Add(d.guidHashCode, d);
                }
            }
            #endregion

            #region 同步项处理
            if (!refObj.mSyncShrinkMergeMaping.ContainsKey(guidHashCode))
            {
                refObj.mSyncShrinkMergeMaping.Add(guidHashCode, this);
            }
            foreach (EditorSelectionAssetBundleNameAsset y in mSyncShrinkMergeMaping.Values)
            {
                if (!refObj.mSyncShrinkMergeMaping.ContainsKey(y.guidHashCode))
                {
                    refObj.mSyncShrinkMergeMaping.Add(y.guidHashCode, y);
                }
            }
            #endregion

            mRefrenceMaping = new Dictionary<int, EditorSelectionAssetBundleNameAsset>();
            mDependencyMaping = new Dictionary<int, EditorSelectionAssetBundleNameAsset>();
            mSyncShrinkMergeMaping = new Dictionary<int, EditorSelectionAssetBundleNameAsset>();
        }
        return isShrinkMerge;
    }
    /// <summary>
    /// AssetBundleName
    /// </summary>
    string mAssetBundleName = string.Empty;
    /// <summary>
    /// 保存AssetBundleName
    /// </summary>
    /// <param name="_sync">同步节点</param>
    public void SaveAssetBundleName(EditorSelectionAssetBundleNameAsset _sync)
    {
        mAssetBundleName = "o_";
        int hashCode = path.UniqueHashCode();
        if (msrNamePrefix.ContainsKey(ext))
        {
            mAssetBundleName = msrNamePrefix[ext];
        }
        else if (name.EndsWith(msrXLuaTxtExt))
        {//同一目录下的lua文件打为一个资源
            mAssetBundleName = msrNamePrefix[msrXLuaTxtExt];
            hashCode = directory.UniqueHashCode();
        }
        mAssetBundleName += hashCode;
        bool isLockName = false;        
        AssetImporter importer = AssetImporter.GetAtPath(path);
        if (importer is TextureImporter)
        {
            TextureImporter ti = (TextureImporter)importer;
            if (!string.IsNullOrEmpty(ti.spritePackingTag))
            {
                //如果是精灵图集，一个图集一个资源，同一个图集的Sprite的Tag与目录一致
                mAssetBundleName = "sp_" + ti.spritePackingTag.UniqueHashCode();
                isLockName = true;
            }
        }
        else if (msrLockNameExt.Contains(ext))
        {
            isLockName = true;
        }
        mAssetBundleName = Path.Combine(directory, mAssetBundleName).OnlyCNUSAndOtherReplaceU().TransPathSeparatorCharToUnityChar();

        if (_sync != null && !isLockName)
        {
            if (EditorStrayFogUtility.assetBundleName.IsSceneRelateAsset(this))
            {
                mAssetBundleName = _sync.mAssetBundleName + "_necDep";
            }
            else if (_sync.ext == msrSceneExt && ext != msrSceneExt)
            {
                mAssetBundleName = _sync.mAssetBundleName + "_refDep";
            }
            else
            {
                mAssetBundleName = _sync.mAssetBundleName;
            }
        }

        importer.SetAssetBundleNameAndVariant(mAssetBundleName, string.Empty);
        EditorUtility.SetDirty(importer);
        OnSyncAssetBundleName(_sync == null ? this : _sync);
    }
    /// <summary>
    /// 同步AssetBundleName
    /// </summary>
    /// <param name="_sync">同步节点</param>
    void OnSyncAssetBundleName(EditorSelectionAssetBundleNameAsset _sync)
    {
        foreach (EditorSelectionAssetBundleNameAsset y in mSyncShrinkMergeMaping.Values)
        {
            y.SaveAssetBundleName(_sync);
        }
    }
    /// <summary>
    /// 获得AssetBundleName
    /// </summary>
    /// <returns>AssetBundleName</returns>
    public string GetAssetBundleName()
    {
        string abName = string.Empty;
        AssetImporter mImporter = AssetImporter.GetAtPath(path);
        if (mImporter != null && isFile)
        {
            abName = mImporter.assetBundleName;
        }
        return abName;
    }
    /// <summary>
    /// 清除资源包名称
    /// </summary>
    public void ClearAssetBundleName()
    {
        AssetImporter mImporter = AssetImporter.GetAtPath(path);
        if (mImporter != null && isFile)
        {
            mImporter.SetAssetBundleNameAndVariant(string.Empty, string.Empty);
            EditorUtility.SetDirty(mImporter);
        }
    }

    /// <summary>
    /// 是否是根节点
    /// </summary>
    public bool isRoot { get; private set; }
    /// <summary>
    /// 设置根节点
    /// </summary>
    /// <param name="_isRoot">是否是根节点</param>
    public void SetRoot(bool _isRoot)
    {
        isRoot = _isRoot;
    }
}
#endif