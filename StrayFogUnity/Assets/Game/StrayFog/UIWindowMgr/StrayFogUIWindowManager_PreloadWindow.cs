using System;
/// <summary>
/// UI窗口管理器【预加载窗口】
/// </summary>
public partial class StrayFogUIWindowManager
{
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
        OnLoadWindowInMemory(OnGetWindowSetting(_windowIds), false,_onCallback, _parameters);
    }
    #endregion
}
