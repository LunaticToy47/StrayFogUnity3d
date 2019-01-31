using UnityEngine;
using System.Reflection;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// StrayFogSetting
/// </summary>
public class StrayFogSetting : AbsSingleScriptableObject
{
    #region platform 运行平台
    //https://docs.unity3d.com/Manual/PlatformDependentCompilation.html
    /// <summary>
    /// 运行平台
    /// </summary>
    public string platform
    {
        get
        {
            return "ab_" +
            #region Platform Define
#if UNITY_STANDALONE_OSX
        //#define directive for compiling/executing code specifically for Mac OS X (including Universal, PPC and Intel architectures).
        "osx";
#elif UNITY_STANDALONE_WIN
        //#define directive for compiling/executing code specifically for Windows standalone applications.
        "win";
#elif UNITY_STANDALONE_LINUX
        //#define directive for compiling/executing code specifically for Linux standalone applications.
        "linux";
#elif UNITY_STANDALONE
        //#define directive for compiling/executing code for any standalone platform (Mac OS X, Windows or Linux).
        "standalone";
#elif UNITY_WII
        //#define directive for compiling/executing code for the Wii console.
        "wii";
#elif UNITY_IOS
        //#define directive for compiling/executing code for the iOS platform.
        "ios";
#elif UNITY_IPHONE
        //Deprecated. Use UNITY_IOS instead.
        "iphone";
#elif UNITY_ANDROID
//#define directive for the Android platform.
"android";
#elif UNITY_PS4
        //#define directive for running PlayStation 4 code.
        "ps4";
#elif UNITY_SAMSUNGTV
        //#define directive for executing Samsung TV code.
        "samsungtv";
#elif UNITY_XBOXONE
        //#define directive for executing Xbox One code.
        "xboxone";
#elif UNITY_TIZEN
        //#define directive for the Tizen platform.
        "tizen";
#elif UNITY_TVOS
        //#define directive for the Apple TV platform.
        "tvos";
#elif UNITY_WP_8_1
        //#define directive for Windows Phone 8.1.
        "wp_8_1";
#elif UNITY_WSA
        //#define directive for Windows Store Apps. Additionally, NETFX_CORE is defined when compiling C# files against .NET Core.
        "wsa";
#elif UNITY_WSA_8_1
        //#define directive for Windows Store Apps when targeting SDK 8.1.
        "wsa_8_1";
#elif UNITY_WSA_10_0
        //#define directive for Windows Store Apps when targeting Universal Windows 10 Apps. Additionally WINDOWS_UWP and NETFX_CORE are defined when compiling C# files against .NET Core.
        "wsa_10_0";
#elif UNITY_WINRT
        //Same as UNITY_WSA.
        "winrt";
#elif UNITY_WINRT_8_1
        //Equivalent to UNITY_WP_8_1 | UNITY_WSA_8_1. This is also defined when compiling against Universal SDK 8.1.
        "winrt_8_1";
#elif UNITY_WINRT_10_0
        //Equivalent to UNITY_WSA_10_0
        "winrt_10_0";
#elif UNITY_WEBGL
        //#define directive for WebGL.
        "webgl";
#elif UNITY_ADS
        //#define directive for calling Unity Ads methods from your game code. Version 5.2 and above.
        "ads";
#elif UNITY_ANALYTICS
        //#define directive for calling Unity Analytics methods from your game code. Version 5.2 and above.
        "analytics";
#elif UNITY_ASSERTIONS
        //#define directive for assertions control process.
        "assertions";
#endif
            #endregion
        }
    }
    #endregion

    #region assetBundleRoot 资源包路径根目录
    /// <summary>
    /// 资源包根路径
    /// </summary>
    public string assetBundleRoot
    {
        get
        {
            return
#if UNITY_WEBGL
"";
#elif (UNITY_STANDALONE_WIN)&& !UNITY_EDITOR
            Path.GetDirectoryName(Application.dataPath) + "/" + platform;
#else
            Application.persistentDataPath + "/" + platform;
#endif
        }
    }
    #endregion

    #region streamingAssetsRoot streamingAssets根目录
    /// <summary>
    /// streamingAssets根目录
    /// </summary>
    public string streamingAssetsRoot
    {
        get
        {
            return
#if UNITY_WEBGL
"/" + Path.GetFileName(Application.streamingAssetsPath);
#else
 Application.streamingAssetsPath;
#endif
        }
    }
    #endregion

    #region manifestPath Manifest文件路径
    /// <summary>
    /// Manifest文件路径
    /// </summary>
    public string manifestPath { get { return Path.Combine(assetBundleRoot, platform).Replace(@"\", "/"); } }
    #endregion

    #region wwwPrefix WWW前缀
    /// <summary>
    /// WWW前缀
    /// </summary>
    public string wwwPrefix
    {
        get
        {
            return
#if UNITY_WEBGL
string.Empty;
#else
 @"file:///";
#endif
        }
    }
    #endregion    

    #region isInternal 是否是内部资源加载
    /// <summary>
    /// 是否是内部资源加载
    /// </summary>
    public bool isInternal
    {
        get
        {
#if UNITY_EDITOR && !FORCEEXTERNALLOADASSET
            return true;
#else
            return false;
#endif
        }
    }
    #endregion
    
    #region isUseSQLite 是否使用数据库
    /// <summary>
    /// 是否使用数据库
    /// </summary>
    public bool isUseSQLite
    {
        get
        {
#if UNITY_EDITOR
#if FORCEUSESQLITE
            return true;
#else
            return !isInternal;
#endif
#else
            return true;
#endif
        }
    }
    #endregion

    #region ToData 数据字符串
    /// <summary>
    /// 数据字符串
    /// </summary>
    /// <returns>数据字符串</returns>
    public string ToData()
    {
        StringBuilder sb = new StringBuilder();
        PropertyInfo[] properties = GetType().GetProperties();
        if (properties != null && properties.Length > 0)
        {
            foreach (PropertyInfo p in properties)
            {
                if (p.CanRead && !p.CanWrite)
                {
                    sb.AppendLine(string.Format("{0}=>{1}", p.Name, p.GetValue(this, null)));
                }
            }
        }
        return sb.ToString();
    }
    #endregion

    #region UNITY_EDITOR
#if UNITY_EDITOR
    [InvokeMethod("EditorDisplayParameter")]
    [AliasTooltip("方法回调")]
    public string invoke;
    /// <summary>
    /// OnDisplayPath
    /// </summary>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <returns>高度</returns>
    protected virtual float EditorDisplayParameter(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        float y = _position.y;
        _position.height = 16;
        PropertyInfo[] properties = GetType().GetProperties();
        if (properties != null && properties.Length > 0)
        {
            foreach (PropertyInfo p in properties)
            {
                if (p.CanRead && !p.CanWrite)
                {
                    EditorGUI.LabelField(_position, string.Format("{0}=>{1}", p.Name, p.GetValue(this, null)));
                    _position.y += _position.height;
                }
            }
        }
        return _position.y - y;
    }
#endif
    #endregion

    #region GetSQLiteConnectionString 获得SQLite数据库连接字符串
    /// <summary>
    /// 获得SQLite数据库连接字符串
    /// </summary>
    /// <param name="_dbPath">数据库路径</param>
    /// <returns>数据库连接字符串</returns>
    public string GetSQLiteConnectionString(string _dbPath)
    {
#if UNITY_EDITOR && !FORCEEXTERNALLOADASSET
        _dbPath = string.Format("data source={0}", _dbPath);
#elif UNITY_ANDROID
        _dbPath = string.Format("URI=file:{0}", Path.Combine(assetBundleRoot, _dbPath));
#else
        _dbPath = string.Format("data source={0}", Path.Combine(assetBundleRoot, _dbPath));
#endif

#if UNITY_EDITOR
        Debug.LogFormat("GetSQLiteConnectionString=>【{0}】", _dbPath);
#endif
        return _dbPath;
    }
    #endregion
}
