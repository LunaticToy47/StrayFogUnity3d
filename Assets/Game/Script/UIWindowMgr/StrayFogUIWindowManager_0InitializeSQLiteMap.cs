using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI窗口管理器【SQLite映射】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region OnInitializeSQLite 初始化SQLite映射
    /// <summary>
    /// 窗口设置映射
    /// </summary>
    Dictionary<int, XLS_Config_Table_UIWindowSetting> mWindowSettingMaping = new Dictionary<int, XLS_Config_Table_UIWindowSetting>();
    /// <summary>
    /// 资源磁盘与窗口ID映射
    /// Key:FolderId
    /// Value:[Key:FileId,Value:WinId]
    /// </summary>
    Dictionary<int, Dictionary<int, int>> mFolderIdFileIdForWinIdMaping = new Dictionary<int, Dictionary<int, int>>();
    /// <summary>
    /// 初始化SQLite数据
    /// </summary>
    void OnInitializeSQLite()
    {
        List<XLS_Config_Table_UIWindowSetting> tables = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_UIWindowSetting>();
        foreach (XLS_Config_Table_UIWindowSetting t in tables)
        {
            mWindowSettingMaping.Add(t.id, t);
            if (!mFolderIdFileIdForWinIdMaping.ContainsKey(t.folderId))
            {
                mFolderIdFileIdForWinIdMaping.Add(t.folderId, new Dictionary<int, int>());
            }
            if (!mFolderIdFileIdForWinIdMaping[t.folderId].ContainsKey(t.fileId))
            {
                mFolderIdFileIdForWinIdMaping[t.folderId].Add(t.fileId, t.id);
            }
            else
            {
                Debug.LogErrorFormat("UIWindowManager SQLite has the same fileId 【{0}】", t.fileId);
            }
        }
    }
    #endregion

    #region OnGetWindowSetting 获得窗口设定
    /// <summary>
    /// 获得窗口设定
    /// </summary>
    /// <param name="_wins">窗口组</param>
    /// <returns>窗口设定</returns>
    int[] OnGetWindowSetting(params Enum[] _wins)
    {
        List<int> ids = new List<int>();
        if (_wins != null && _wins.Length > 0)
        {
            int id = 0;
            Type type = _wins[0].GetType();
            foreach (Enum w in _wins)
            {
                if (Enum.IsDefined(type, w.ToString()))
                {
                    id = (int)Enum.Parse(type, w.ToString());
                    if (!ids.Contains(id))
                    {
                        ids.Add(id);
                    }
                }
                else
                {
                    Debug.LogErrorFormat("There is undefined【{0}】", w);
                }
            }
        }
        return ids.ToArray();
    }

    /// <summary>
    /// 获得窗口设定
    /// </summary>
    /// <param name="_folderId">文件夹id</param>
    /// <param name="_fileId">文件id</param>
    /// <returns>窗口设定</returns>
    int[] OnGetWindowSetting(int _folderId, int _fileId)
    {
        return OnGetWindowSetting(new int[1] { _folderId }, new int[1] { _fileId });
    }

    /// <summary>
    /// 获得窗口设定
    /// </summary>
    /// <param name="_folderIds">文件夹id组</param>
    /// <param name="_fileIds">文件id组</param>
    /// <returns>窗口设定</returns>
    int[] OnGetWindowSetting(int[] _folderIds, int[] _fileIds)
    {
        List<int> ids = new List<int>();
        if (_folderIds != null && _fileIds != null && _folderIds.Length == _fileIds.Length)
        {
            int id = 0;
            for (int i = 0; i < _folderIds.Length; i++)
            {
                if (!mFolderIdFileIdForWinIdMaping.ContainsKey(_folderIds[i]))
                {
                    Debug.LogErrorFormat("Can't found FolderId【{0}】", _folderIds[i]);
                }
                else if (!mFolderIdFileIdForWinIdMaping[_folderIds[i]].ContainsKey(_fileIds[i]))
                {
                    Debug.LogErrorFormat("Can't found FileId【{0}】", _fileIds[i]);
                }
                else
                {
                    id = mFolderIdFileIdForWinIdMaping[_folderIds[i]][_fileIds[i]];
                    if (!ids.Contains(id))
                    {
                        ids.Add(id);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("FolderId length is not equals FileIds length.");
        }
        return ids.ToArray();
    }

    /// <summary>
    /// 获得窗口设定
    /// </summary>
    /// <param name="_winIds">窗口Id组</param>
    /// <returns>窗口设定</returns>
    XLS_Config_Table_UIWindowSetting[] OnGetWindowSetting(params int[] _winIds)
    {
        List<XLS_Config_Table_UIWindowSetting> result = new List<XLS_Config_Table_UIWindowSetting>();
        if (_winIds != null && _winIds.Length > 0)
        {
            foreach (int id in _winIds)
            {
                if (mWindowSettingMaping.ContainsKey(id))
                {
                    result.Add(mWindowSettingMaping[id]);
                }
                else
                {
                    Debug.LogErrorFormat("Can't found WindowId【{0}】", id);
                }
            }
        }
        return result.ToArray();
    }
    #endregion
}
