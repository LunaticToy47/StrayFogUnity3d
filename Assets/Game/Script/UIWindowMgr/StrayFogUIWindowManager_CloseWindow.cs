using System;
/// <summary>
/// UI窗口管理器【关闭窗口】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region Enum
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow<W>(Enum _window, params object[] _parameters)
    {
        CloseWindow(_window, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(Enum[] _windows, params object[] _parameters)
    {
        CloseWindow(_windows, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(Enum _window, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        CloseWindow(new Enum[1] { _window }, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(Enum[] _windows, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        CloseWindow(OnGetWindowSetting(_windows), _onCallback, _parameters);
    }
    #endregion

    #region FolderId FileId
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int _folderId, int _fileId, params object[] _parameters)
    {
        CloseWindow(_folderId, _fileId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int[] _folderIds, int[] _fileIds, params object[] _parameters)
    {
        CloseWindow(_folderIds, _fileIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int _folderId, int _fileId, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        CloseWindow(OnGetWindowSetting(_folderId, _fileId), _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int[] _folderIds, int[] _fileIds, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        CloseWindow(OnGetWindowSetting(_folderIds, _fileIds), _onCallback, _parameters);
    }
    #endregion

    #region WindowId
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int _windowId, params object[] _parameters)
    {
        CloseWindow(_windowId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int[] _windowIds, params object[] _parameters)
    {
        CloseWindow(_windowIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int _windowId, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        CloseWindow(new int[1] { _windowId }, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int[] _windowIds, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        OnCloseWindow(OnGetWindowSetting(_windowIds), _onCallback, _parameters);
    }
    #endregion
}
