using System;
/// <summary>
/// UI窗口管理器【窗口是否打开】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region Enum
    /// <summary>
    /// 窗口是否打开
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <returns>true:打开,false:关闭</returns>
    public bool IsOpenedWindow(Enum _window)
    {
        return IsOpenedWindow(OnGetWindowSetting(_window));
    }
    /// <summary>
    /// 窗口是否打开
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <returns>true:打开,false:关闭</returns>
    public bool IsOpenedWindow(Enum[] _windows)
    {
        return IsOpenedWindow(OnGetWindowSetting(_windows));
    }
    #endregion

    #region FolderId FileId
    /// <summary>
    /// 窗口是否打开
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <returns>true:打开,false:关闭</returns>
    public bool IsOpenedWindow(int _folderId, int _fileId)
    {
        return IsOpenedWindow(OnGetWindowSetting(_folderId, _fileId));
    }
    /// <summary>
    /// 窗口是否打开
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <returns>true:打开,false:关闭</returns>
    public bool IsOpenedWindow(int[] _folderIds, int[] _fileIds)
    {
        return IsOpenedWindow(OnGetWindowSetting(_folderIds, _fileIds));
    }
    #endregion

    #region WindowId
    /// <summary>
    /// 窗口是否打开
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <returns>true:打开,false:关闭</returns>
    public bool IsOpenedWindow(int _windowId)
    {
        return IsOpenedWindow(new int[1] { _windowId });
    }
    /// <summary>
    /// 窗口是否打开
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <returns>true:打开,false:关闭</returns>
    public bool IsOpenedWindow(int[] _windowIds)
    {
        return OnIsOpenedWindow(OnGetWindowSetting(_windowIds));
    }
    #endregion
}