/*
 * https://docs.unity3d.com/ScriptReference/AssetModificationProcessor.html
 */
using UnityEditor;
/// <summary>
/// Unity编辑器资源修改监听
/// </summary>
public sealed class EditorUnityAssetModificationProcessor : UnityEditor.AssetModificationProcessor
{
    ///// <summary>
    ///// 指定资源是否应该禁用编辑器
    ///// </summary>
    ///// <param name="_assetPath">资源路径</param>
    ///// <param name="_message">提示信息</param>
    ///// <returns>是否禁用编辑器</returns>
    //public static bool IsOpenForEdit(string _assetPath, out string _message)
    //{
    //    _message = "File is locked for editing.";
    //    return true;
    //}

    /// <summary>
    /// 准备创建资源
    /// </summary>
    /// <param name="_path">资源路径</param>
    public static void OnWillCreateAsset(string _path)
    {
        
    }

    /// <summary>
    /// 准备保存资源
    /// </summary>
    /// <param name="_paths">资源路径</param>
    /// <returns>资源路径</returns>
    public static string[] OnWillSaveAssets(string[] _paths)
    {
        return _paths;
    }

    /// <summary>
    /// 准备移动资源
    /// </summary>
    /// <param name="_oldPath">旧路径</param>
    /// <param name="_newPath">新路径</param>
    /// <returns>资源移动结果</returns>
    public static AssetMoveResult OnWillMoveAsset(string _oldPath, string _newPath)
    {
        return AssetMoveResult.DidNotMove;
    }

    /// <summary>
    /// 准备删除资源
    /// </summary>
    /// <param name="_assetPath">资源路径</param>
    /// <param name="_option">移除选项</param>
    /// <returns>删除资源结果</returns>
    public static AssetDeleteResult OnWillDeleteAsset(string _assetPath, RemoveAssetOptions _option)
    {
        return AssetDeleteResult.DidNotDelete;
    }
}