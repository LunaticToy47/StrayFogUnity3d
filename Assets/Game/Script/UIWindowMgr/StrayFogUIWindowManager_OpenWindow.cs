using System;
using System.Collections.Generic;
/// <summary>
/// UI窗口管理器【打开窗口】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region Enum
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(Enum _window, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_window, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(Enum[] _windows, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_windows, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(Enum _window, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_window, _onCallback, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_window">窗口</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow<W>(Enum _window, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(new Enum[1] { _window }, _onCallback, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(Enum[] _windows, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_windows, _onCallback, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windows">窗口组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow<W>(Enum[] _windows, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(OnGetWindowSetting(_windows), _onCallback, _parameters);
    }
    #endregion

    #region FolderId FileId
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(int _folderId, int _fileId, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_folderId, _fileId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(int[] _folderIds, int[] _fileIds, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_folderIds, _fileIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(int _folderId, int _fileId, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_folderId, _fileId, _onCallback, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow<W>(int _folderId, int _fileId, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(OnGetWindowSetting(_folderId, _fileId), _onCallback, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(int[] _folderIds, int[] _fileIds, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_folderIds, _fileIds, _onCallback, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow<W>(int[] _folderIds, int[] _fileIds, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(OnGetWindowSetting(_folderIds, _fileIds), _onCallback, _parameters);
    }
    #endregion

    #region WindowId
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(int _windowId, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_windowId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(int[] _windowIds, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_windowIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(int _windowId, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_windowId, _onCallback, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow<W>(int _windowId, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(new int[1] { _windowId }, _onCallback, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(int[] _windowIds, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        OpenWindow<AbsUIWindowView>(_windowIds, _onCallback, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow<W>(int[] _windowIds, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OnOpenWindow<W>(OnGetWindowSetting(_windowIds), _onCallback, _parameters);
    }
    #endregion

    #region BeforeToggleScene 切换场景前
    /// <summary>
    /// 切换场景前
    /// </summary>
    public void BeforeToggleScene()
    {
        OnGetWindowSerialize().SaveToggleSceneWindowSequence();
        //将当前所有可以关闭的窗口都关闭
        foreach (UIWindowHolder holder in mWindowHolderMaping.Values)
        {
            if (!holder.winCfg.isManualCloseWhenGotoScene)
            {
                holder.SetTargetActive(false);
                holder.ToggleActive();
#if DEBUGLOG
                UnityEngine.Debug.Log(holder.winCfg.name);
#endif
            }
        }        
    }
    #endregion

    #region AfterToggleScene 切换场景后
    /// <summary>
    /// 切换场景后
    /// </summary>
    /// <param name="_callback">回调</param>
    public void AfterToggleScene(Action _callback)
    {
        List<int> winIds = OnGetWindowSerialize().RestoreToggleSceneWindowSequence();
        if (winIds.Count > 0)
        {
            OpenWindow(winIds.ToArray(),
            (wins, args) =>
            {
                Action callback = (Action)args[0];
                callback();
            }, _callback);
        }
        else
        {
            _callback();
        }
    }
    #endregion
}