using System;
/// <summary>
/// UI窗口管理器【关闭窗口】
/// </summary>
public partial class StrayFogUIWindowManager
{
    /// <summary>
    /// 关闭窗口事件
    /// </summary>
    public event UIWindowEntityEventHandler<AbsUIWindowView> OnCloseWindowEventHandler;

    #region Enum
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(Enum _window, params object[] _parameters)
    {
        CloseWindow<AbsUIWindowView>(_window, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(Enum[] _windows, params object[] _parameters)
    {
        CloseWindow<AbsUIWindowView>(_windows, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(Enum _window, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        CloseWindow<AbsUIWindowView>(_window, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_window">窗口</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow<W>(Enum _window, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        CloseWindow<W>(new Enum[1] { _window }, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(Enum[] _windows, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        CloseWindow<AbsUIWindowView>(_windows, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windows">窗口组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow<W>(Enum[] _windows, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        CloseWindow<W>(OnGetWindowSetting(_windows), _onCallback, _parameters);
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
        CloseWindow<AbsUIWindowView>(_folderId, _fileId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int[] _folderIds, int[] _fileIds, params object[] _parameters)
    {
        CloseWindow<AbsUIWindowView>(_folderIds, _fileIds, (wins, paras) => { }, _parameters);
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
        CloseWindow<AbsUIWindowView>(_folderId, _fileId, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow<W>(int _folderId, int _fileId, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        CloseWindow<W>(OnGetWindowSetting(_folderId, _fileId), _onCallback, _parameters);
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
        CloseWindow<AbsUIWindowView>(_folderIds, _fileIds, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow<W>(int[] _folderIds, int[] _fileIds, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        CloseWindow<W>(OnGetWindowSetting(_folderIds, _fileIds), _onCallback, _parameters);
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
        CloseWindow<AbsUIWindowView>(_windowId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int[] _windowIds, params object[] _parameters)
    {
        CloseWindow<AbsUIWindowView>(_windowIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int _windowId, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        CloseWindow<AbsUIWindowView>(_windowId, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow<W>(int _windowId, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        CloseWindow<W>(new int[1] { _windowId }, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(int[] _windowIds, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        CloseWindow<AbsUIWindowView>(_windowIds, _onCallback, _parameters);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow<W>(int[] _windowIds, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OnCloseWindow<W>(OnGetWindowSetting(_windowIds), _onCallback, _parameters);
    }
    #endregion
}
