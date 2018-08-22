using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// CMD工具
/// </summary>
public sealed class EditorUtility_CMD : AbsSingle<EditorUtility_CMD>
{
    #region ExcuteFile 执行文件
    /// <summary>
    /// 执行文件
    /// </summary>
    /// <param name="_fileName">文件名称</param>
    /// <returns>错误信息</returns>
    public Exception ExcuteFile(string _fileName)
    {
        return ExcuteFile(_fileName, string.Empty);
    }
    /// <summary>
    /// 执行文件
    /// </summary>
    /// <param name="_fileName">文件名称</param>
    /// <param name="_arguments">参数</param>
    /// <returns>错误信息</returns>
    public Exception ExcuteFile(string _fileName, string _arguments)
    {
        Exception error = default(Exception);
        try
        {
            using (Process process = new Process())
            {
                ProcessStartInfo psi = new ProcessStartInfo(_fileName, _arguments);
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();
            }
        }
        catch (Exception ep)
        {
            error = ep;
        }
        return error;
    }
    #endregion

    #region ExcuteCmd 执行Cmd命令
    /// <summary>
    /// 执行Cmd命令
    /// </summary>
    /// <param name="_commands">命令行</param>
    /// <returns>错误信息</returns>
    public Exception ExcuteCmd(params string[] _commands)
    {
        string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".bat");
        File.WriteAllLines(path, _commands);
        Exception ep = ExcuteFile(path);
        File.Delete(path);
        return ep;
    }
    #endregion

    #region OpenUrl 打开Url页面
    /// <summary>
    /// 打开Url页面
    /// </summary>
    /// <param name="_url">Url地址</param>
    public void OpenUrl(string _url)
    {
        OpenFile(_url);
    }
    #endregion

    #region OpenFile 打开文件
    /// <summary>
    /// 打开文件
    /// </summary>
    /// <param name="_filePath">文件路径</param>
    public void OpenFile(string _filePath)
    {
        Process.Start(_filePath);
    }
    #endregion

    #region DeleteFolder 删除文件夹
    /// <summary>
    /// 删除文件夹
    /// </summary>
    /// <param name="_folder">文件夹</param>
    public void DeleteFolder(string _folder)
    {
        if (Directory.Exists(_folder))
        {
            ExcuteCmd(string.Format("rd /s /q \"{0}\" & ping 127.0.0.1 -n 5>nul &exit", _folder));
        }
        else
        {
            UnityEngine.Debug.LogErrorFormat("CMD can not found folder=>{0}", _folder);
        }
    }
    #endregion

    #region Restart 自动重启
    /// <summary>
    /// 自动重启
    /// </summary>
    public void Restart()
    {
        Process p = Process.GetCurrentProcess();
        string path = Path.Combine(EditorApplication.applicationPath, p.MainModule.FileName);
        string bat = EditorResxTemplete.EditorResxTemplete.Cmd_ExecuteApplicationRestartMenu;
        MethodInfo method = typeof(EditorStrayFogExecute).GetMethod("ExecuteBuildPackage");
        bat = bat.Replace("#Pid#", p.Id.ToString())
            .Replace("#EngineExe#", path)
            .Replace("#ProjectPath#", Path.GetDirectoryName(Application.dataPath))
            .Replace("#LogFile#", Path.Combine(Application.persistentDataPath, "Restart.log"))
            .Replace("#ExecuteMethod#", method.DeclaringType.FullName + "." + method.Name);
        UnityEngine.Debug.Log(bat);
        ExcuteCmd(bat);
    }
    #endregion
}
