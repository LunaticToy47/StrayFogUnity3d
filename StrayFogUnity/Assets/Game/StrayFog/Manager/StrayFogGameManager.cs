using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 运行时管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogGameManager")]
public sealed partial class StrayFogGameManager : AbsSingleMonoBehaviour
{
    #region Initialization 初始化
    /// <summary>
    /// 是否已初始化
    /// </summary>
    bool m_isInitialized = false;
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="_onCallback">结束回调</param>
    public void Initialization(Action _onCallback)
    {
        if (!m_isInitialized)
        {
            m_isInitialized = true;
            runningSetting = StrayFogSQLiteEntityHelper.Select<XLS_Config_Determinant_Table_GameSetting>()[0];
            StrayFogAssembly.LoadDynamicAssembly();
            StrayFogGamePools.uiWindowManager.OnOpenWindowEventHandler += UiWindowManager_OnOpenWindowEventHandler;
            StrayFogGamePools.uiWindowManager.OnCloseWindowEventHandler += UiWindowManager_OnCloseWindowEventHandler;

            StrayFogGamePools.guideManager.OnIsLevel += Current_OnIsLevel;
            StrayFogGamePools.guideManager.OnValidateFinished += Current_OnValidateFinished;
            OnPartialInitialization();
            Application.wantsToQuit += OnApplication_wantsToQuit;
            Application.lowMemory += Application_lowMemory;
#if UNITY_EDITOR || DEBUGLOG
            Application.logMessageReceivedThreaded += Application_logMessageReceivedThreaded;
#endif
        }

        if (_onCallback != null)
        {
            _onCallback.Invoke();
        }
    }
    #endregion

    #region runningSetting 游戏运行时设定
    /// <summary>
    /// 游戏运行时设定
    /// </summary>
    public XLS_Config_Determinant_Table_GameSetting runningSetting { get; private set; }
    #endregion

    #region UIWindow 相关
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    void UiWindowManager_OnOpenWindowEventHandler(AbsUIWindowView[] _windows, params object[] _parameters)
    {
        bool isOpenGuideWindow = false;
        foreach (AbsUIWindowView w in _windows)
        {
            isOpenGuideWindow |= w.config.id == StrayFogGamePools.guideManager.guideWindowId;
        }
        if (!isOpenGuideWindow)
        {
            if (StrayFogGamePools.uiWindowManager.IsOpenedWindow(StrayFogGamePools.guideManager.guideWindowId))
            {
                StrayFogGamePools.guideManager.OpenWindowCheckValidate(_windows, _parameters);
            }
            else
            {
                StrayFogGamePools.guideManager.OpenWindowCheckTrigger(_windows, _parameters);
            }
        }
    }

    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    void UiWindowManager_OnCloseWindowEventHandler(AbsUIWindowView[] _windows, params object[] _parameters)
    {

    }
    #endregion

    #region Guide 引导相关
    /// <summary>
    /// 是否是指定关卡
    /// </summary>
    /// <param name="_levelId">关卡id</param>
    /// <returns>true:是,false:否</returns>
    bool Current_OnIsLevel(int _levelId)
    {
        return true;
    }

    /// <summary>
    /// 验证完成
    /// </summary>
    /// <param name="_validate">验证器</param>
    void Current_OnValidateFinished(UIGuideValidate _validate)
    {

    }
    #endregion

    #region OnApplicationQuit
    /// <summary>
    /// 退出应用异步
    /// </summary>
    AsyncOperation mQuitAppAsyncOperation = null;

    /// <summary>
    /// Application_wantsToQuit
    /// </summary>
    /// <returns>true:quit,false:cancel quit</returns>
    bool OnApplication_wantsToQuit()
    {
        if (mQuitAppAsyncOperation == null)
        {
            OnApplication_quitting();
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// Application_quitting
    /// </summary>
    void OnApplication_quitting()
    {
        Time.timeScale = 0;
        StrayFogGamePools.assetBundleManager.Dispose();
        StrayFogSQLiteEntityHelper.CloseSQLite();
        StrayFogSQLiteEntityHelper.SaveExcelPackage();
        AssetBundle.UnloadAllAssetBundles(true);
        GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
        if (gos != null && gos.Length > 0)
        {
            foreach (GameObject g in gos)
            {
                if (g != null)
                {
                    Destroy(g);
                }
            }
        }
        mQuitAppAsyncOperation = Resources.UnloadUnusedAssets();
        Time.timeScale = 1;
        StartCoroutine(OnWaitQuitApp());
    }
    /// <summary>
    /// 等待退出应用
    /// </summary>
    /// <returns>异步</returns>
    IEnumerator OnWaitQuitApp()
    {
        yield return mQuitAppAsyncOperation;
        Application.Quit();
    }
    #endregion

    #region Application_lowMemory
    void Application_lowMemory()
    {
        StrayFogGamePools.assetBundleManager.LowMemoryFreeAsset();
    }
    #endregion

#if UNITY_EDITOR || DEBUGLOG
    void Application_logMessageReceivedThreaded(string condition, string stackTrace, LogType type)
    {
        
    }
#endif
}