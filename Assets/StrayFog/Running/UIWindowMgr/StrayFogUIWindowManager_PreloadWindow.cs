using System;
/// <summary>
/// UI窗口管理器【预加载窗口】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region Enum
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(Enum _window, params object[] _parameters)
    {
        PreloadWindow(_window, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(Enum[] _windows, params object[] _parameters)
    {
        PreloadWindow(_windows, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(Enum _window, UIWindowSettingEventHandler _onCallback, params object[] _parameters)
    {
        PreloadWindow(new Enum[1] { _window }, _onCallback, _parameters);
    }
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(Enum[] _windows, UIWindowSettingEventHandler _onCallback, params object[] _parameters)
    {
        PreloadWindow(OnGetWindowSetting(_windows), _onCallback, _parameters);
    }
    #endregion

    #region FolderId FileId
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(int _folderId, int _fileId, params object[] _parameters)
    {
        PreloadWindow(_folderId, _fileId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(int[] _folderIds, int[] _fileIds, params object[] _parameters)
    {
        PreloadWindow(_folderIds, _fileIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(int _folderId, int _fileId, UIWindowSettingEventHandler _onCallback, params object[] _parameters)
    {
        PreloadWindow(OnGetWindowSetting(_folderId, _fileId), _onCallback, _parameters);
    }
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(int[] _folderIds, int[] _fileIds, UIWindowSettingEventHandler _onCallback, params object[] _parameters)
    {
        PreloadWindow(OnGetWindowSetting(_folderIds, _fileIds), _onCallback, _parameters);
    }
    #endregion

    #region WindowId
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(int _windowId, params object[] _parameters)
    {
        PreloadWindow(_windowId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(int[] _windowIds, params object[] _parameters)
    {
        PreloadWindow(_windowIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(int _windowId, UIWindowSettingEventHandler _onCallback, params object[] _parameters)
    {
        PreloadWindow(new int[1] { _windowId }, _onCallback, _parameters);
    }
    /// <summary>
    /// 预加载窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void PreloadWindow(int[] _windowIds, UIWindowSettingEventHandler _onCallback, params object[] _parameters)
    {
        OnPreloadWindow<AbsUIWindowView>(OnGetWindowSetting(_windowIds), _onCallback, null, null, _parameters);
    }
    #endregion
}
