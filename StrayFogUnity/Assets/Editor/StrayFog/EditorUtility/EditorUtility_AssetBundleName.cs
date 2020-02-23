#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
/// <summary>
/// AssetBundleName工具
/// </summary>
public class EditorUtility_AssetBundleName : AbsEditorSingle
{
    /// <summary>
    /// 非法Unity资源名称
    /// </summary>
    const string illegalUnityAssetName = @"[^\w\d_\.]";
    /// <summary>
    /// 非法的目录
    /// </summary>
    const string mIllegalUnityDirectory = @"[^\w|/|\\]";

    #region IsIgnoreSetAssetBundleName 是否忽略设置AssetBundleName名称
    /// <summary>
    /// 忽略设置资源包名称的扩展名列表
    /// </summary>
    static readonly List<int> msrIgnoreAssetBundleNames =
        new List<int>() {
            enFileExt.CS, enFileExt.LightMapExr,enFileExt.Javascript,enFileExt.Dll_MDB,enFileExt.Dll_PDB,enFileExt.Cginc,enFileExt.Asmdef };
    /// <summary>
    /// 是否是忽略后缀名映射
    /// </summary>
    static Dictionary<int, bool> mIgnoreExtMaping = new Dictionary<int, bool>();
    /// <summary>
    /// 指定扩展名称是否忽略设置AssetBundleName
    /// </summary>
    /// <param name="_ext">扩展名</param>
    /// <returns>True:忽略,False:不忽略</returns>
    public bool IsIgnoreSetAssetBundleName(string _ext)
    {
        int key = _ext.UniqueHashCode();
        if (!mIgnoreExtMaping.ContainsKey(key))
        {
            FileExtAttribute attr = null;
            bool isIgnore = false;
            for (int i = 0; i < msrIgnoreAssetBundleNames.Count; i++)
            {
                attr = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(msrIgnoreAssetBundleNames[i]);
                isIgnore |= attr.IsExt(_ext);
                if (isIgnore)
                {
                    break;
                }
            }
            mIgnoreExtMaping.Add(key, isIgnore);
        }
        return mIgnoreExtMaping[key];
    }
    #endregion

    #region IsSceneRelateAsset 是否是场景关联资源
    /// <summary>
    /// 场景后缀属性
    /// </summary>
    static readonly FileExtAttribute mSceneAttribute =
        typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Scene);
    /// <summary>
    /// 是否是场景关联资源
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    /// <param name="_node">节点</param>
    /// <returns>True:是,False:否</returns>
    public bool IsSceneRelateAsset<T>(T _node)
        where T : EditorSelectionAsset
    {
        return File.Exists(_node.directory + mSceneAttribute.ext);
    }
    #endregion

    #region IsBelongEditorDirectory 是否属于Editor目录
    /// <summary>
    /// 是否属于Editor目录映射
    /// </summary>
    static Dictionary<int, bool> msIsBelongEditorDirectoryMaping = new Dictionary<int, bool>();
    /// <summary>
    /// 是否属于Editor文件夹
    /// </summary>
    /// <param name="_directory">目录</param>
    /// <returns>True:是,False:否</returns>
    public bool IsBelongEditorDirectory(string _directory)
    {
        bool isBelongEditor = false;
        int key = _directory.UniqueHashCode();
        if (!msIsBelongEditorDirectoryMaping.ContainsKey(key))
        {
            string[] dds = _directory.Split(new string[] { @"\", @"/" }, System.StringSplitOptions.RemoveEmptyEntries);
            if (dds != null)
            {
                for (int i = 0; i < dds.Length; i++)
                {
                    isBelongEditor |= dds[i].ToUpper().Equals("EDITOR");
                    if (isBelongEditor)
                    {
                        break;
                    }
                }
            }
            msIsBelongEditorDirectoryMaping.Add(key, isBelongEditor);
        }
        return msIsBelongEditorDirectoryMaping[key];
    }
    #endregion

    #region IsDllPlugins 是否是dll插件
    /// <summary>
    /// 是否是dll插件
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    /// <param name="_node">节点</param>
    /// <returns>True:是,False:否</returns>
    public bool IsDllPlugins<T>(T _node)
        where T : EditorSelectionAsset
    {
        return _node.isFile && !IsBelongEditorDirectory(_node.directory) && _node.ext == typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Dll).ext;
    }
    #endregion

    #region IsAsmdef 是否是Asmdef文件
    /// <summary>
    /// 是否是Asmdef文件
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    /// <param name="_node">节点</param>
    /// <returns>True:是,False:否</returns>
    public bool IsAsmdef<T>(T _node)
        where T : EditorSelectionAsset
    {
        return _node.isFile && !IsBelongEditorDirectory(_node.directory) && _node.ext == typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Asmdef).ext;
    }
    #endregion    

    #region IsAllowSetBundleName 是否允许设定AssetBundleName
    /// <summary>
    /// 节点是否允许设定AssetBundleName
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    /// <param name="_node">节点</param>
    /// <returns>True:是,False:否</returns>
    public bool IsAllowSetBundleName<T>(T _node)
        where T : EditorSelectionAsset
    {
        return _node.isFile && !IsBelongEditorDirectory(_node.directory) && !IsIgnoreSetAssetBundleName(_node.ext);
    }
    #endregion

    #region IsIllegalDirectory 是否是不合法的目录
    /// <summary>
    /// 是否是不合法的目录
    /// </summary>
    /// <param name="_directory">目录</param>
    /// <returns>true:非法目录,false:合法目录</returns>
    public bool IsIllegalDirectory(string _directory)
    {
        return Regex.IsMatch(_directory, mIllegalUnityDirectory);
    }
    #endregion

    #region IsIllegalFile 是否是不合法的文件
    /// <summary>
    /// 是否是不合法的文件
    /// </summary>
    /// <param name="_name">文件名称</param>
    /// <returns>true:非法文件,false:合法文件</returns>
    public bool IsIllegalFile(string _name)
    {
        return Regex.IsMatch(_name, illegalUnityAssetName);
    }
    #endregion

    #region Collect 收集指定目录下可设置AssetBundeName的资源
    /// <summary>
    /// 收集指定目录下可设置AssetBundeName的资源
    /// </summary>
    /// <param name="_folders">目录组</param>
    /// <param name="_error">错误信息</param>
    /// <returns>资源组</returns>
    public List<T> Collect<T>(string[] _folders, out string _error)
        where T : EditorSelectionAsset
    {
        List<T> nodes = new List<T>();
        _error = string.Empty;
        if (_folders != null && _folders.Length > 0)
        {
            StringBuilder sbErrorFile = new StringBuilder();
            sbErrorFile.AppendLine("Illegal file name");
            StringBuilder sbErrorDirectory = new StringBuilder();
            sbErrorDirectory.AppendLine("Illegal directory name");
            bool isAnyIllegal = false;
            nodes = EditorStrayFogUtility.collectAsset.CollectAsset<T>(
                _folders, enEditorAssetFilterClassify.Object,enEditorDependencyClassify.UnClude,
                (node) =>
                {
                    bool isLegal = IsLegalAssetBundleNamePackageNode(node);
                    if (!isLegal)
                    {
                        if (node.isFile)
                        {
                            sbErrorFile.AppendLine(node.path);
                        }
                        if (node.isDirectory)
                        {
                            sbErrorDirectory.AppendLine(node.path);
                        }
                    }
                    return isLegal;
                });
            if (isAnyIllegal)
            {
                _error = sbErrorFile.ToString() + sbErrorDirectory.ToString();
                nodes.Clear();
            }
        }
        return nodes;
    }
    #endregion

    #region IsLegalAssetBundleNamePackageNode 是否是合法的可打包的资源
    /// <summary>
    /// 是否是合法的可打包的资源
    /// </summary>
    /// <param name="_node">节点</param>
    /// <returns>true:合法,false:不合法</returns>
    public bool IsLegalAssetBundleNamePackageNode<T>(T _node)
        where T : EditorSelectionAsset
    {
        bool isAllowSetBundleName = IsAllowSetBundleName(_node);
        bool isSceneRelateAsset = IsSceneRelateAsset(_node);
        bool isIllegalFile = IsIllegalFile(_node.nameWithoutExtension);
        bool isIllegalDirectory = IsIllegalDirectory(_node.directory);
        return isAllowSetBundleName && !isSceneRelateAsset && !isIllegalFile && !isIllegalDirectory;
    }
    #endregion
}
#endif