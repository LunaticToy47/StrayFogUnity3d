using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 场景管理
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogSceneManager")]
public partial class StrayFogSceneManager : AbsSingleMonoBehaviour
{
    /// <summary>
    /// 场景枚举
    /// </summary>
    List<int> mSceneEnums = new List<int>();
    /// <summary>
    /// 文件枚举映射
    /// </summary>
    static readonly Dictionary<int, string> m_enAssetDiskMapingFile_Maping =
        typeof(enAssetDiskMapingFile).ValueToNameForConstField();
    /// <summary>
    /// 场景文件后缀
    /// </summary>
    static readonly FileExtAttribute mSceneFileExtAttribute = typeof(enFileExt).ValueToAttributeForConstField<FileExtAttribute>()[(int)enFileExt.Scene];
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        mSceneEnums.Clear();
        foreach (KeyValuePair<int, string> key in m_enAssetDiskMapingFile_Maping)
        {
            if (key.Value.EndsWith(mSceneFileExtAttribute.noDotExt))
            {
                mSceneEnums.Add(key.Key);
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
    /// <param name="_file">场景文件enAssetDiskMapingFile</param>
    /// <param name="_folder">场景文件夹enAssetDiskMapingFolder</param>
    public void LoadScene(int _file, int _folder)
    {
        StrayFogGamePools.uiWindowManager.BeforeToggleScene();
        StrayFogGamePools.assetBundleManager.LoadAssetInMemory(_file, _folder,
                (result) =>
                {
                    mSceneAsync = SceneManager.LoadSceneAsync(result.input.assetName);
                    mSceneAsync.allowSceneActivation = false;
                    coroutine.StartCoroutine(OnActiveScene());
                });
    }

    IEnumerator OnActiveScene()
    {
        yield return new WaitForEndOfFrame();
        AllowSceneActivation();              
    }

    /// <summary>
    /// OnGUI绘制关卡选择按钮
    /// </summary>
    public void DrawLevelSelectButtonOnGUI()
    {
        GUILayout.Space(10);
        mScrollViewPosition = GUILayout.BeginScrollView(mScrollViewPosition);
        GUILayout.BeginHorizontal();
        foreach (int f in mSceneEnums)
        {
            if (GUILayout.Button(m_enAssetDiskMapingFile_Maping[f]))
            {
                LoadScene(f, enAssetDiskMapingFolder.Assets_Example_AssetBundles_Scene);
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();
    }
}