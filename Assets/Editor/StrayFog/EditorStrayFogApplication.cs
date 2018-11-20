#if UNITY_EDITOR
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

    #region SaveScriptingDefineSymbols 保存脚本宏定义
    /// <summary>
    /// 脚本宏定义分隔符
    /// </summary>
    static readonly string msrScriptingDefineSymbolSpeatorChar = ";";
    /// <summary>
    /// 保存脚本宏定义
    /// </summary>
    /// <param name="_defines">宏定义</param>
    /// <returns>宏字符串</returns>
    public static string SetScriptingDefineSymbolsForGroup(string[] _defines)
    {
        StringBuilder sb = new StringBuilder();
        if (_defines.Length > 0)
        {
            foreach (string s in _defines)
            {
                sb.AppendFormat("{0}{1}", s, msrScriptingDefineSymbolSpeatorChar);
            }
            sb.Remove(sb.Length - 1, 1);
        }
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, sb.ToString());
        return sb.ToString();
    }
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
            symbol = group.Split(new string[1] { msrScriptingDefineSymbolSpeatorChar }, StringSplitOptions.RemoveEmptyEntries);
        }
        if (symbol == null)
        {
            symbol = new string[0];
        }
        return symbol;
    }
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

    #region GetRelativeToProject 获得Path相对于工程的路径
    /// <summary>
    /// 获得Path相对于工程的路径
    /// </summary>
    /// <param name="_path">路径</param>
    /// <returns>相对路径</returns>
    public static string GetRelativeToProject(string _path)
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
    /// <returns>相对路径</returns>
    public static string GetRelativeTo(string _path, string _root)
    {
        _path = Path.GetFullPath(_path).TransPathSeparatorCharToUnityChar().Replace(Path.GetFullPath(_root).TransPathSeparatorCharToUnityChar(), "");
        return Regex.Replace(_path, "^(/+)", "", RegexOptions.IgnoreCase);
    }
    #endregion

    #region TryRelativeToProject 尝试获得Path相对于工程的路径
    /// <summary>
    /// 尝试获得Path相对于工程的路径
    /// </summary>
    /// <param name="_path">尝试的路径</param>
    /// <returns>相对路径</returns>
    public static string TryRelativeToProject(string _path)
    {
        if (string.IsNullOrEmpty(_path))
        {//如果为空，则直接转到Assets路径下
            _path = Path.GetFileName(assetsPath);
        }
        else if (IsSubToProject(_path))
        {//如果是工程子目录
            _path = GetRelativeToProject(_path);
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

    #region IsExecuteMethodInCmd
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

    #region Db库
    /// <summary>
    /// SQLiteHelper
    /// </summary>
    static SQLiteHelper mSqlHelper = null;
    /// <summary>
    /// SQL帮助类
    /// </summary>
    public static SQLiteHelper sqlHelper { get { if (mSqlHelper == null) { mSqlHelper = new SQLiteHelper(string.Format("data source={0}", StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().dbSource)); } return mSqlHelper; } }
    /// <summary>
    /// 关闭数据库
    /// </summary>
    public static void CloseDb()
    {
        if (mSqlHelper != null)
        {
            mSqlHelper.Close();
            mSqlHelper = null;
        }
    }
    #endregion
}
#endif