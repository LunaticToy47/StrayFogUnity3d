using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// UI窗口管理器【初始化】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region uiLayer ui层级
    /// <summary>
    /// ui层级
    /// </summary>
    public int uiLayer { get; private set; }
    #endregion

    #region OnAfterConstructor
    /// <summary>
    /// 窗口枚举类型
    /// </summary>
    readonly Type mWindowEnumType = typeof(enUIWindow);
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        uiLayer = LayerMask.NameToLayer("UI");
        OnInitialization();
        OnInitializSQLite();
        base.OnAfterConstructor();
    }
    #endregion

    #region OnInitialization 初始化
    /// <summary>
    /// 绘制模式组
    /// </summary>
    readonly List<RenderMode> mRenderModes = typeof(RenderMode).ToEnums<RenderMode>();
    /// <summary>
    /// 画面映射
    /// Key:RenderMode
    /// Value:画布
    /// </summary>
    Dictionary<int, UICanvas> mCanvasMaping = new Dictionary<int, UICanvas>();
    /// <summary>
    /// 事件系统
    /// </summary>
    EventSystem mEventSystem;
    /// <summary>
    /// StandaloneInputModule
    /// </summary>
    StandaloneInputModule mStandaloneInputModule;
    /// <summary>
    /// 初始化
    /// </summary>
    void OnInitialization()
    {
        foreach (RenderMode rm in mRenderModes)
        {
            if (!mCanvasMaping.ContainsKey((int)rm))
            {
                GameObject go = new GameObject(typeof(UICanvas).Name + "_" + rm.ToString());
                UICanvas cvs = go.AddComponent<UICanvas>();
                cvs.gameObject.layer = uiLayer;
                OnInitializationCanvas(cvs, rm);
                mCanvasMaping.Add((int)rm, cvs);
                DontDestroyOnLoad(go);
            }
        }

        if (EventSystem.current != null)
        {
            mEventSystem = EventSystem.current;
        }
        else
        {
            GameObject ego = new GameObject("EventSystem");
            mEventSystem = ego.AddComponent<EventSystem>();
        }
        if (mEventSystem.currentInputModule == null)
        {
            mStandaloneInputModule = mEventSystem.gameObject.AddComponent<StandaloneInputModule>();
        }
        DontDestroyOnLoad(mEventSystem);
    }
    #endregion

    #region InitializationCanvas 初始化画布
    /// <summary>
    /// farClipPlane
    /// </summary>
    readonly float mFarClipPlane = 5;
    /// <summary>
    /// nearClipPlane
    /// </summary>
    readonly float mNearClipPlane = 0.01f;
    /// <summary>
    /// ScreenSpaceCamera画布
    /// </summary>
    UICanvas mScreenSpaceCameraCanvas;
    /// <summary>
    /// 世界空间画布
    /// </summary>
    UICanvas mWorldSpaceCanvas;
    /// <summary>
    /// 初始化画布
    /// </summary>
    /// <param name="_uCanvas">画布</param>
    /// <param name="_renderMode">绘制模式</param>
    void OnInitializationCanvas(UICanvas _uCanvas, RenderMode _renderMode)
    {
        _uCanvas.canvas.renderMode = _renderMode;
        _uCanvas.canvas.sortingOrder = byte.MaxValue;
        _uCanvas.canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _uCanvas.canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
        _uCanvas.canvasScaler.referenceResolution = StrayFogRunningUtility.SingleMonoBehaviour<StrayFogGameManager>().runningSetting.resolution;
        _uCanvas.canvasScaler.referenceResolution = new Vector2(1920, 1080);
        switch (_renderMode)
        {
            case RenderMode.ScreenSpaceOverlay:
                _uCanvas.SetDirty();
                break;
            case RenderMode.ScreenSpaceCamera:
                mScreenSpaceCameraCanvas = _uCanvas;
                _uCanvas.canvas.planeDistance = mFarClipPlane;
                #region 创建摄像机
                GameObject go = new GameObject(_uCanvas.name + "_uiCamera");
                DontDestroyOnLoad(go);
                _uCanvas.canvas.worldCamera = go.AddComponent<Camera>();
                _uCanvas.canvas.worldCamera.depth = byte.MaxValue;
                _uCanvas.canvas.worldCamera.orthographic = false;
                //_uCanvas.canvas.worldCamera.orthographicSize = mOriginalOrthographicSize;
                _uCanvas.canvas.worldCamera.nearClipPlane = mNearClipPlane;
                _uCanvas.canvas.worldCamera.farClipPlane = mFarClipPlane + mNearClipPlane;
                _uCanvas.canvas.worldCamera.transform.position = Vector3.up * byte.MaxValue;
                _uCanvas.canvas.worldCamera.clearFlags = CameraClearFlags.Depth;
                _uCanvas.canvas.worldCamera.cullingMask = 1 << _uCanvas.gameObject.layer;
                _uCanvas.canvas.worldCamera.gameObject.layer = _uCanvas.canvas.gameObject.layer;
                _uCanvas.canvas.worldCamera.useOcclusionCulling = false;
                _uCanvas.canvas.worldCamera.allowHDR = false;
                _uCanvas.canvas.worldCamera.allowMSAA = false;
                _uCanvas.SetDirty();
                #endregion
                break;
            case RenderMode.WorldSpace:
                mWorldSpaceCanvas = _uCanvas;
                OnSetWorldSpaceCamera(null);
                break;
        }
    }
    #endregion

    #region OnSetWorldSpaceCamera 设置世界空间摄像机
    /// <summary>
    /// 设置世界空间摄像机
    /// </summary>
    /// <param name="_camera">世界空间摄像机</param>
    void OnSetWorldSpaceCamera(Camera _camera)
    {
        if (mWorldSpaceCanvas != null && mWorldSpaceCanvas.canvas.worldCamera == null)
        {
            if (_camera == null)
            {
                if (Camera.main == null)
                {
                    GameObject camera = new GameObject("CameraMain");
                    _camera = camera.AddComponent<Camera>();
                    _camera.tag = "MainCamera";
                }
                else
                {
                    _camera = Camera.main;
                }
            }
            mWorldSpaceCanvas.canvas.worldCamera = _camera;
            mWorldSpaceCanvas.SetDirty();
        }
    }
    #endregion

    #region OnGetCanvas 获得画布
    /// <summary>
    /// 获得画布
    /// </summary>
    /// <param name="_renderMode">绘制模式</param>
    /// <returns>画布</returns>
    UICanvas OnGetCanvas(RenderMode _renderMode)
    {
        return mCanvasMaping[(int)_renderMode];
    }
    #endregion
}
