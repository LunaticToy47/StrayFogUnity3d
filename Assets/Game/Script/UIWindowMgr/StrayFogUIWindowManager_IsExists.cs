using System;
/// <summary>
/// UI窗口管理器【窗口是否存在】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region Enum
    /// <summary>
    /// 窗口是否存在
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <returns>true:存在,false:不存在</returns>
    public bool IsExistsWindow(Enum _window)
    {
        return IsExistsWindow(OnGetWindowSetting(_window));
    }
    /// <summary>
    /// 窗口是否存在
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <returns>true:存在,false:不存在</returns>
    public bool IsExistsWindow(Enum[] _windows)
    {
        return IsExistsWindow(OnGetWindowSetting(_windows));
    }
    #endregion

    #region FolderId FileId
    /// <summary>
    /// 窗口是否存在
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <returns>true:存在,false:不存在</returns>
    public bool IsExistsWindow(int _folderId, int _fileId)
    {
        return IsExistsWindow(OnGetWindowSetting(_folderId, _fileId));
    }
    /// <summary>
    /// 窗口是否存在
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <returns>true:存在,false:不存在</returns>
    public bool IsExistsWindow(int[] _folderIds, int[] _fileIds)
    {
        return IsExistsWindow(OnGetWindowSetting(_folderIds, _fileIds));
    }
    #endregion

    #region WindowId
    /// <summary>
    /// 窗口是否存在
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <returns>true:存在,false:不存在</returns>
    public bool IsExistsWindow(int _windowId)
    {
        return IsExistsWindow(new int[1] { _windowId });
    }
    /// <summary>
    /// 窗口是否存在
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <returns>true:存在,false:不存在</returns>
    public bool IsExistsWindow(int[] _windowIds)
    {
        return OnIsExistsWindow(_windowIds);
    }
    #endregion
}
