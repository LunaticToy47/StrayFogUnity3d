﻿using System;
/// <summary>
/// UI窗口管理器【获得窗口】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region FolderId FileId
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow(int _folderId, int _fileId, params object[] _parameters)
    {
        GetWindow<AbsUIWindowView>(_folderId, _fileId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow(int[] _folderIds, int[] _fileIds, params object[] _parameters)
    {
        GetWindow<AbsUIWindowView>(_folderIds, _fileIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow(int _folderId, int _fileId, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        GetWindow<AbsUIWindowView>(_folderId, _fileId, _onCallback, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow<W>(int _folderId, int _fileId, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        GetWindow<W>(OnGetWindowSetting(_folderId, _fileId), _onCallback, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow(int[] _folderIds, int[] _fileIds, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        GetWindow<AbsUIWindowView>(_folderIds, _fileIds, _onCallback, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow<W>(int[] _folderIds, int[] _fileIds, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        GetWindow<W>(OnGetWindowSetting(_folderIds, _fileIds), _onCallback, _parameters);
    }
    #endregion

    #region WindowId
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow(int _windowId, params object[] _parameters)
    {
        GetWindow<AbsUIWindowView>(_windowId, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow(int[] _windowIds, params object[] _parameters)
    {
        GetWindow<AbsUIWindowView>(_windowIds, (wins, paras) => { }, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow(int _windowId, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        GetWindow<AbsUIWindowView>(_windowId, _onCallback, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowId">窗口Id</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow<W>(int _windowId, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        GetWindow<W>(new int[1] { _windowId }, _onCallback, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow(int[] _windowIds, UIWindowEntityEventHandler<AbsUIWindowView> _onCallback, params object[] _parameters)
    {
        GetWindow<AbsUIWindowView>(_windowIds, _onCallback, _parameters);
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_onCallback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void GetWindow<W>(int[] _windowIds, UIWindowEntityEventHandler<W> _onCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OnGetWindow<W>(OnGetWindowSetting(_windowIds), _onCallback, _parameters);
    }
    #endregion
}
