using System;
using System.Collections;
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
    /// 允许激活场景
    /// </summary>
    public void AllowSceneActivation()
    {
        if (mSceneAsync != null)
        {
            mSceneAsync.allowSceneActivation = true;
        }
    }

    /// <summary>
    /// 场景异步
    /// </summary>
    AsyncOperation mSceneAsync = null;
    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="_file">场景文件</param>
    public void LoadScene(enAssetDiskMapingFile _file, enAssetDiskMapingFolder _folder)
    {
        StrayFogGamePools.assetBundleManager.LoadAssetInMemory(_file, _folder,
                (result) =>
                {
                    mSceneAsync = SceneManager.LoadSceneAsync(result.assetName);
                    mSceneAsync.allowSceneActivation = false;
                    StartCoroutine(OnActiveScene());
                });
    }

    IEnumerator OnActiveScene()
    {
        yield return new WaitForSeconds(4);
        StrayFogGamePools.uiWindowManager.OpenWindow<LobbyWindow>(enUIWindow.LobbyWindow, (wins, wargs) =>
        {
            AllowSceneActivation();
        });
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
                LoadScene(f, enAssetDiskMapingFolder.Assets_Game_AssetBundles_Scene);
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();
    }
}