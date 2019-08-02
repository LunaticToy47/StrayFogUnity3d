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
            StrayFogGamePools.runningApplication.OnRegisterGuide += Current_OnRegisterGuide;
            StrayFogGamePools.guideManager.OnIsLevel += Current_OnIsLevel;
            StrayFogGamePools.guideManager.OnWindowIsOpened += Current_OnWindowIsOpened;
            StrayFogGamePools.guideManager.OnTriggerFinished += Current_OnTriggerFinished;
            StrayFogGamePools.guideManager.TriggerCheck();
            OnPartialInitialization();
            Application.wantsToQuit += OnApplication_wantsToQuit;
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

    #region Guide 引导相关
    /// <summary>
    /// 指定窗口是否打开
    /// </summary>
    /// <param name="_windowId">窗口id</param>
    /// <returns>true:打开,false:未打开</returns>
    bool Current_OnWindowIsOpened(int _windowId)
    {
        return StrayFogGamePools.uiWindowManager.IsOpenedWindow(_windowId);
    }

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
    /// 注册引导
    /// </summary>
    /// <param name="_guide">引导</param>
    void Current_OnRegisterGuide(UIGuideRegister _guide)
    {
        StrayFogGamePools.guideManager.RegisterGuide(_guide);
    }

    /// <summary>
    /// 触发器完成
    /// </summary>
    /// <param name="_trigger">触发器</param>
    void Current_OnTriggerFinished(UIGuideTrigger _trigger)
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

#if UNITY_EDITOR || DEBUGLOG
    void Application_logMessageReceivedThreaded(string condition, string stackTrace, LogType type)
    {
        
    }
#endif
}