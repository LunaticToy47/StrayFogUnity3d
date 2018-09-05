﻿using System;
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
    public void OpenWindow<W>(Enum _window, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(_window, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow<W>(Enum[] _windows, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(_windows, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
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
    public void OpenWindow<W>(int _folderId, int _fileId, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(_folderId, _fileId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow<W>(int[] _folderIds, int[] _fileIds, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(_folderIds, _fileIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
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
    public void OpenWindow<W>(int _windowId, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(_windowId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow<W>(int[] _windowIds, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OpenWindow<W>(_windowIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
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
    public void OpenWindow<W>(int[] _windowIds, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OnOpenWindow<W>(OnGetWindowSetting(_windowIds), _onCallback, _parameters);
    }
    #endregion
}