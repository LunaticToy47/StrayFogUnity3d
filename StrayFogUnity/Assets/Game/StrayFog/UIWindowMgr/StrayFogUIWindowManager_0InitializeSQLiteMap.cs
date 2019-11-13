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
        List<XLS_Config_Table_UIWindowSetting> tables = StrayFogConfigHelper.Select<XLS_Config_Table_UIWindowSetting>();
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
    /// 枚举键值映射
    /// </summary>
    Dictionary<int, int> mEnumKeyValueMaping = new Dictionary<int, int>();
    /// <summary>
    /// 获得窗口设定
    /// </summary>
    /// <param name="_wins">窗口组</param>
    /// <returns>窗口设定</returns>
    int[] OnGetWindowSetting(params Enum[] _wins)
    {
        int[] ids = null;
        int key = 0;
        if (_wins != null && _wins.Length > 0)
        {
            ids = new int[_wins.Length];            
            for (int i = 0; i < _wins.Length; i++)
            {
                key = _wins[i].GetHashCode();
                if (!mEnumKeyValueMaping.ContainsKey(key))
                {
                    mEnumKeyValueMaping.Add(key, Convert.ToInt32(_wins[i]));
                }
                ids[i] = mEnumKeyValueMaping[key];
            }
        }
        return ids;
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
        int[] ids = null;
        if (_folderIds != null && _fileIds != null && _folderIds.Length == _fileIds.Length)
        {
            ids = new int[_folderIds.Length];
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
                    ids[i] = mFolderIdFileIdForWinIdMaping[_folderIds[i]][_fileIds[i]];
                }
            }
        }
        else
        {
            Debug.LogError("FolderId length is not equals FileIds length.");
        }
        return ids;
    }

    /// <summary>
    /// 获得窗口设定
    /// </summary>
    /// <param name="_winIds">窗口Id组</param>
    /// <returns>窗口设定</returns>
    XLS_Config_Table_UIWindowSetting[] OnGetWindowSetting(params int[] _winIds)
    {
        XLS_Config_Table_UIWindowSetting[] result = null;
        if (_winIds != null && _winIds.Length > 0)
        {
            result = new XLS_Config_Table_UIWindowSetting[_winIds.Length];
            for (int i = 0; i < _winIds.Length; i++)
            {
                if (mWindowSettingMaping.ContainsKey(_winIds[i]))
                {
                    result[i] = mWindowSettingMaping[_winIds[i]];
                }
                else
                {
                    Debug.LogErrorFormat("Can't found WindowId【{0}】", _winIds[i]);
                }
            }            
        }
        if (result == null)
        {
            result = new XLS_Config_Table_UIWindowSetting[0];
        }
        return result;
    }
    #endregion
}
