﻿#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 编辑器应用程序
/// </summary>
public sealed class EditorStrayFogApplication
{
    #region Assets路径
    /// <summary>
    /// Assets路径
    /// </summary>
    public readonly static string assetsPath = Path.GetFullPath("Assets");
    #endregion

    #region curvePresetLibrary 曲线预置库类型
    /// <summary>
    /// 曲线预置库类型
    /// </summary>
    public readonly static Type curvePresetLibrary = Type.GetType("UnityEditor.CurvePresetLibrary, UnityEditor");
    #endregion

    #region ScriptingDefineSymbolsForGroup 脚本宏定义
    #region OnSetScriptingDefineSymbolsForGroup 设置脚本宏定义
    /// <summary>
    /// 设置脚本宏定义
    /// </summary>
    /// <param name="_defines">宏定义</param>
    /// <returns>宏字符串</returns>
    public static string OnSetScriptingDefineSymbolsForGroup(string[] _defines)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(_defines.Join(enSplitSymbol.Colon));
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, sb.ToString());
        return sb.ToString();
    }
    #endregion

    #region GetScriptingDefineSymbolsForGroup 获得脚本宏定义
    /// <summary>
    /// 获得脚本宏定义
    /// </summary>
    /// <returns>宏定义</returns>
    public static string[] GetScriptingDefineSymbolsForGroup()
    {
        string[] symbol = null;
        string group = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        if (!string.IsNullOrEmpty(group))
        {
            symbol = group.Split(enSplitSymbol.Colon);
        }
        if (symbol == null)
        {
            symbol = new string[0];
        }
        return symbol;
    }
    #endregion

    #region AddScriptingDefineSymbol 添加脚本宏定义
    /// <summary>
    /// 添加脚本宏定义
    /// </summary>
    /// <param name="_defines">脚本宏定义</param>
    public static void AddScriptingDefineSymbol(params string[] _defines)
    {
        string[] exists = GetScriptingDefineSymbolsForGroup();
        List<string> saves = new List<string>();
        if (exists != null && exists.Length > 0)
        {
            foreach (string d in exists)
            {
                if (!saves.Contains(d))
                {
                    saves.Add(d);
                }
            }
        }
        if (_defines != null && _defines.Length > 0)
        {
            foreach (string d in _defines)
            {
                if (!saves.Contains(d))
                {
                    saves.Add(d);
                }
            }
        }
        OnSetScriptingDefineSymbolsForGroup(saves.ToArray());
    }
    #endregion

    #region RemoveScriptingDefineSymbol 移除脚本宏定义
    /// <summary>
    /// 移除脚本宏定义
    /// </summary>
    /// <param name="_defines">脚本宏定义</param>
    public static void RemoveScriptingDefineSymbol(params string[] _defines)
    {
        string[] exists = GetScriptingDefineSymbolsForGroup();
        List<string> saves = new List<string>();
        if (exists != null && exists.Length > 0)
        {
            foreach (string d in exists)
            {
                if (!saves.Contains(d))
                {
                    saves.Add(d);
                }
            }
        }
        if (_defines != null && _defines.Length > 0)
        {
            foreach (string d in _defines)
            {
                if (saves.Contains(d))
                {
                    saves.Remove(d);
                }
            }
        }
        OnSetScriptingDefineSymbolsForGroup(saves.ToArray());
    }
    #endregion
    #endregion

    #region  ExecuteMenu_AssetsRefresh 执行Assets/Refresh菜单
    /// <summary>
    /// 执行Assets/Refresh菜单
    /// </summary>
    public static void ExecuteMenu_AssetsRefresh()
    {
        AssetDatabase.SaveAssets();
        EditorApplication.ExecuteMenuItem("Assets/Refresh");
        AssetDatabase.Refresh();
    }
    #endregion

    #region PingObject
    /// <summary>
    /// PingObject
    /// </summary>
    /// <param name="_object">对象</param>
    public static void PingObject(UnityEngine.Object _object)
    {
        EditorGUIUtility.PingObject(_object);
        Selection.activeObject = _object;
    }

    /// <summary>
    /// PingObject
    /// </summary>
    /// <param name="_assetPath">资源路径</param>
    public static void PingObject(string _assetPath)
    {
        UnityEngine.Object obj = AssetDatabase.LoadMainAssetAtPath(_assetPath);
        PingObject(obj);
    }
    #endregion

    #region RevealInFinder
    /// <summary>
    /// RevealInFinder
    /// </summary>
    /// <param name="_object">对象</param>
    public static void RevealInFinder(UnityEngine.Object _object)
    {
        RevealInFinder(AssetDatabase.GetAssetPath(_object));
    }

    /// <summary>
    /// RevealInFinder
    /// </summary>
    /// <param name="_assetPath">资源路径</param>
    public static void RevealInFinder(string _assetPath)
    {
        EditorUtility.RevealInFinder(_assetPath);
    }
    #endregion

    #region OpenFile 打开文件
    /// <summary>
    /// 打开文件
    /// </summary>
    /// <param name="_object">对象</param>
    public static void OpenFile(UnityEngine.Object _object)
    {
        OpenFile(Path.GetFullPath(AssetDatabase.GetAssetPath(_object)));
    }

    /// <summary>
    /// OpenFile
    /// </summary>
    /// <param name="_assetPath">资源路径</param>
    public static void OpenFile(string _assetPath)
    {
        EditorStrayFogUtility.cmd.OpenFile(_assetPath);
    }
    #endregion    

    #region CopyToClipboard 文本复制到剪帖板
    /// <summary>
    /// 文本复制到剪帖板
    /// </summary>
    /// <param name="_text">文本</param>
    public static void CopyToClipboard(string _text)
    {
        TextEditor te = new TextEditor();//很强大的文本工具
        te.text = _text;
        te.OnFocus();
        te.Copy();
    }
    #endregion

    #region IsSubToProject Path是否从属于工程路径
    /// <summary>
    /// Path是否从属于工程路径
    /// </summary>
    /// <param name="_path">路径</param>
    /// <returns>True:是,False:否</returns>
    public static bool IsSubToProject(string _path)
    {
        return IsSubTo(_path, Path.GetDirectoryName(assetsPath));
    }
    #endregion

    #region IsSubToAssets Path是否从属于Assets路径
    /// <summary>
    /// Path是否从属于Assets路径
    /// </summary>
    /// <param name="_path">路径</param>
    /// <returns>True:是,False:否</returns>
    public static bool IsSubToAssets(string _path)
    {
        return IsSubTo(_path, assetsPath);
    }
    #endregion

    #region IsSubTo Path是否从属于Root路径
    /// <summary>
    /// Path是否从属于Root路径
    /// </summary>   
    /// <param name="_path">路径</param>
    /// <param name="_root">根路径</param>
    /// <returns>True:是,False:否</returns>
    public static bool IsSubTo(string _path, string _root)
    {
        return !string.IsNullOrEmpty(_path) && Path.GetFullPath(_path).TransPathSeparatorCharToUnityChar().StartsWith(Path.GetFullPath(_root).TransPathSeparatorCharToUnityChar(), true, System.Globalization.CultureInfo.CurrentCulture);
    }
    #endregion

    #region GetRelativeToAssets 获得Path相对于Assets的路径
    /// <summary>
    /// 获得Path相对于Assets的路径
    /// </summary>
    /// <param name="_path">路径</param>
    /// <returns>相对于Assets路径</returns>
    public static string GetRelativeToAssets(string _path)
    {
        return GetRelativeTo(_path, Path.GetDirectoryName(assetsPath));
    }
    #endregion

    #region GetRelativeTo 获得Path相对于Root的路径
    /// <summary>
    /// 获得Path相对于Root的路径
    /// </summary>
    /// <param name="_path">路径</param>
    /// <param name="_root">根目录</param>
    /// <returns>相对于Root的路径</returns>
    public static string GetRelativeTo(string _path, string _root)
    {
        _path = Path.GetFullPath(_path).TransPathSeparatorCharToUnityChar().Replace(Path.GetFullPath(_root).TransPathSeparatorCharToUnityChar(), "");
        return Regex.Replace(_path, "^(/+)", "", RegexOptions.IgnoreCase);
    }
    #endregion

    #region TryRelativeToAssets 尝试获得Path相对于Assets的路径
    /// <summary>
    /// 尝试获得Path相对于Assets的路径
    /// </summary>
    /// <returns>相对于Assets路径</returns>
    public static string TryRelativeToAssets()
    {
        return TryRelativeToAssets(string.Empty);
    }
    /// <summary>
    /// 尝试获得Path相对于Assets的路径
    /// </summary>
    /// <param name="_path">尝试的路径</param>
    /// <returns>相对于Assets路径</returns>
    public static string TryRelativeToAssets(string _path)
    {
        if (string.IsNullOrEmpty(_path))
        {//如果为空，则直接转到Assets路径下
            _path = Path.GetFileName(assetsPath);
        }
        else if (IsSubToProject(_path))
        {//如果是工程子目录
            _path = GetRelativeToAssets(_path);
        }
        return _path;
    }
    #endregion

    #region StrayFog命令行参数
    /// <summary>
    /// 命令行参数名称
    /// </summary>
    const string mCmdArgName = "-StrayFogArgs=";
    /// <summary>
    /// 追加StrayFog命令行参数
    /// </summary>
    /// <param name="_arguments">参数</param>
    /// <returns>命令行参数</returns>
    public static string CombineStrayFogArguments(params string[] _arguments)
    {
        string args = string.Empty;
        if (_arguments != null && _arguments.Length > 0)
        {
            args = " " + mCmdArgName + _arguments.JsonSerialize();
        }
        return args;
    }
    /// <summary>
    /// 获得StrayFog命令行参数
    /// </summary>
    /// <returns>参数</returns>
    public string[] GetStrayFogArguments()
    {
        string[] args = new string[0];
        string[] clas = Environment.GetCommandLineArgs();
        if (clas != null && clas.Length > 0)
        {
            foreach (string s in clas)
            {
                if (s.StartsWith(mCmdArgName))
                {
                    args = s.Remove(0, mCmdArgName.Length).JsonDeserialize<string[]>();
                    break;
                }
            }
        }
        return args;
    }
    #endregion

    #region IsExecuteMethodInCmd 是否在Cmd中执行方法
    //https://docs.unity3d.com/Manual/CommandLineArguments.html
    /// <summary>
    /// 是否在Cmd中执行方法
    /// </summary>
    /// <returns>true:是,false:否</returns>
    public static bool IsExecuteMethodInCmd()
    {
        string[] clas = Environment.GetCommandLineArgs();
        List<string> args = new List<string>() { "-quit", "-batchmode", "-executeMethod" };
        if (clas != null && clas.Length > 0)
        {
            foreach (string s in clas)
            {
                if (args.Contains(s))
                {
                    args.Remove(s);
                }
            }
        }
        return args.Count <= 0;
    }
    #endregion

    #region MenuItemQuickDisplayDialogSucceed  MenuItem成功快速提示
    /// <summary>
    /// MenuItem成功快速提示
    /// </summary>
    /// <param name="_title">标题</param>
    public static void MenuItemQuickDisplayDialogSucceed(string _title)
    {
        EditorUtility.DisplayDialog(_title, _title + " Succeed!", "OK");
    }
    #endregion

    #region MenuItemQuickDisplayDialog_OKCancel  MenuItem确认提示
    /// <summary>
    /// MenuItem确认提示
    /// </summary>
    /// <param name="_title">标题</param>
    public static bool MenuItemQuickDisplayDialog_OKCancel(string _title)
    {
        return EditorUtility.DisplayDialog(_title, _title,"OK","Cancel");
    }
    #endregion

}
#endif