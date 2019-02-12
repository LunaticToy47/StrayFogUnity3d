using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 场景管理
/// </summary>
public class StrayFogSceneManager : AbsSingleMonoBehaviour
{
    /// <summary>
    /// 场景枚举
    /// </summary>
    List<enAssetDiskMapingFile> mSceneEnums = new List<enAssetDiskMapingFile>();
    /// <summary>
    /// 文件枚举映射
    /// </summary>
    static readonly Dictionary<string, enAssetDiskMapingFile> m_enAssetDiskMapingFile_Maping = typeof(enAssetDiskMapingFile).NameToEnum<enAssetDiskMapingFile>();
    /// <summary>
    /// 场景文件后缀
    /// </summary>
    static readonly FileExtAttribute mSceneFileExtAttribute = enFileExt.Scene.GetAttribute<FileExtAttribute>();
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        foreach (KeyValuePair<string, enAssetDiskMapingFile> key in m_enAssetDiskMapingFile_Maping)
        {
            if (key.Key.EndsWith(mSceneFileExtAttribute.noDotExt))
            {
                mSceneEnums.Add(key.Value);
            }
        }
        base.OnAfterConstructor();
    }

    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="_sceneName">场景名称</param>
    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    /// <summary>
    /// OnGUI绘制关卡选择按钮
    /// </summary>
    public void DrawLevelSelectButtonOnGUI()
    {
        GUILayout.Space(10);
        mScrollViewPosition = GUILayout.BeginScrollView(mScrollViewPosition);
        GUILayout.BeginHorizontal();
        foreach (enAssetDiskMapingFile f in mSceneEnums)
        {
            if (GUILayout.Button(f.ToString()))
            {
                StrayFogGamePools.assetBundleManager.LoadAssetInMemory(
                    f, enAssetDiskMapingFolder.Assets_Game_AssetBundles_Scene,
                (result) =>
                {
                    SceneManager.LoadScene(result.assetName);
                });
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();
    }
}