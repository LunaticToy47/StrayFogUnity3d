//外部资源加载模式
#if (STREAMINGASSETS || ASSETBUNDLE)
#define ISLOADASSETBYEXTERNAL
#endif

using UnityEngine;
using System.Reflection;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
using System.Collections.Generic;
using static StrayFogMacroDefineScriptingDefineSymbols;
#endif
/// <summary>
/// StrayFogSetting
/// </summary>
public sealed class StrayFogSetting : AbsSingleScriptableObject
{
    #region isInternal 是否加载内部资源
    /// <summary>
    /// 是否加载内部资源
    /// </summary>
    [AliasTooltip("是否加载内部资源")]
    public bool isInternal
    {
        get
        {
#if UNITY_EDITOR && !ISLOADASSETBYEXTERNAL
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
    [AliasTooltip("是否使用数据库")]
    public bool isUseSQLite
    {
        get
        {
#if UNITY_EDITOR
#if SQLITE
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

    #region platform 运行平台
    //https://docs.unity3d.com/Manual/PlatformDependentCompilation.html
    /// <summary>
    /// 运行平台
    /// </summary>
    string mPlatform = string.Empty;
    /// <summary>
    /// 运行平台
    /// </summary>
    [AliasTooltip("运行平台")]
    public string platform
    {
        get
        {
            if (string.IsNullOrEmpty(mPlatform))
            {
                mPlatform = "ab_" +
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
            return mPlatform;
        }
    }
    #endregion

    #region assetBundleRoot 资源包路径根目录
    /// <summary>
    /// 资源包路径根目录
    /// </summary>
    string mAssetBundleRoot = string.Empty;
    /// <summary>
    /// 资源包根路径
    /// </summary>
    [AliasTooltip("资源包根路径")]
    public string assetBundleRoot
    {
        get
        {
            if (string.IsNullOrEmpty(mAssetBundleRoot))
            {
#if UNITY_WEBGL
                mAssetBundleRoot ="";
#else
                #region Others
#if UNITY_EDITOR
                #region UNITY_EDITOR
#if STREAMINGASSETS
                mAssetBundleRoot = Path.Combine(streamingAssetsRoot, platform).TransPathSeparatorCharToUnityChar();
#else
                mAssetBundleRoot = Path.Combine(Application.persistentDataPath, platform).TransPathSeparatorCharToUnityChar();
#endif
                #endregion
#else
                #region RunTime
#if STREAMINGASSETS
                mAssetBundleRoot = Path.Combine(streamingAssetsRoot, platform).TransPathSeparatorCharToUnityChar();
#elif UNITY_STANDALONE_WIN
                mAssetBundleRoot = Path.Combine(Path.GetDirectoryName(Application.dataPath), platform).TransPathSeparatorCharToUnityChar();
#else
                mAssetBundleRoot = Path.Combine(Application.persistentDataPath, platform).TransPathSeparatorCharToUnityChar();
#endif
                #endregion
#endif
                #endregion
#endif
            }
            return mAssetBundleRoot;
        }
    }
    #endregion

    #region streamingAssetsRoot streamingAssets根目录
    /// <summary>
    /// streamingAssets根目录
    /// </summary>
    string mStreamingAssetsRoot = string.Empty;
    /// <summary>
    /// streamingAssets根目录
    /// </summary>
    [AliasTooltip("streamingAssets根目录")]
    public string streamingAssetsRoot
    {
        get
        {
            if (string.IsNullOrEmpty(mStreamingAssetsRoot))
            {
#if UNITY_WEBGL
                mStreamingAssetsRoot = "/" + Path.GetFileName(Application.streamingAssetsPath);
#else
                mStreamingAssetsRoot = Application.streamingAssetsPath;
#endif
            }
            return mStreamingAssetsRoot;
        }
    }
    #endregion

    #region manifestPath Manifest文件路径
    /// <summary>
    /// Manifest文件路径
    /// </summary>
    [AliasTooltip("Manifest文件路径")]
    public string manifestPath { get { return Path.Combine(assetBundleRoot, platform).Replace(@"\", "/"); } }
    #endregion

    #region wwwPrefix WWW前缀
    /// <summary>
    /// WWW前缀
    /// </summary>
    [AliasTooltip("WWW前缀")]
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

    #region GetSQLiteConnectionString 获得SQLite数据库连接字符串
    /// <summary>
    /// SQLite数据库连接字符串
    /// </summary>
    Dictionary<int, string> mSQLiteConnectionStringMaping = new Dictionary<int, string>();
    /// <summary>
    /// 获得SQLite数据库连接字符串
    /// </summary>
    /// <param name="_dbPath">数据库路径</param>
    /// <returns>数据库连接字符串</returns>
    public string GetSQLiteConnectionString(string _dbPath)
    {
        int key = _dbPath.GetHashCode();
        if (!mSQLiteConnectionStringMaping.TryGetValue(key, out _dbPath))
        {
#if UNITY_EDITOR && !ISLOADASSETBYEXTERNAL
            _dbPath = string.Format("data source={0}", _dbPath);
#elif UNITY_ANDROID
        _dbPath = string.Format("URI=file:{0}", Path.Combine(assetBundleRoot, _dbPath));
#else
        _dbPath = string.Format("data source={0}", Path.Combine(assetBundleRoot, _dbPath));
#endif
            mSQLiteConnectionStringMaping.Add(key, _dbPath);
        }
        return _dbPath;
    }
    #endregion

    #region ToData 数据字符串
    /// <summary>
    /// 数据字符串
    /// </summary>
    StringBuilder mSbToData = new StringBuilder();
    /// <summary>
    /// 数据字符串
    /// </summary>
    /// <returns>数据字符串</returns>
    public string ToData()
    {
        if (mSbToData.Length == 0)
        {
            PropertyInfo[] properties = GetType().GetProperties();
            if (properties != null && properties.Length > 0)
            {
                AliasTooltipAttribute att = null;
                foreach (PropertyInfo p in properties)
                {
                    if (p.CanRead && !p.CanWrite)
                    {
                        att = p.GetFirstAttribute<AliasTooltipAttribute>();
                        mSbToData.AppendLine(string.Format("{0}【{1}】=>{2}", p.Name, att.alias, p.GetValue(this, null)));
                    }
                }
            }
        }
        return mSbToData.ToString();
    }
    #endregion

    #region UNITY_EDITOR
#if UNITY_EDITOR
    /// <summary>
    /// 资源加载模式映射
    /// </summary>
    Dictionary<int, string> menLoadAssetModeDefineMaping = typeof(enLoadAssetModeDefine).ValueToAttributeSpecifyValueForConstField<AliasTooltipAttribute, string>((a) => { return a.alias; });
    /// <summary>
    /// 资源加载模式
    /// </summary>
    [AliasTooltip("资源加载模式")]
    public string editorLoadAssetModeDefine
    {
        get
        {
#if STREAMINGASSETS
            return menLoadAssetModeDefineMaping[enLoadAssetModeDefine.STREAMINGASSETS];
#elif ASSETBUNDLE
            return menLoadAssetModeDefineMaping[enLoadAssetModeDefine.ASSETBUNDLE];
#else
            return "Editor";
#endif
        }
    }

    /// <summary>
    /// 加载配置表模式映射
    /// </summary>
    Dictionary<int, string> menLoadConfigDefineMaping = typeof(enLoadConfigDefine).ValueToAttributeSpecifyValueForConstField<AliasTooltipAttribute, string>((a) => { return a.alias; });
    /// <summary>
    /// 加载配置表模式
    /// </summary>
    [AliasTooltip("加载配置表模式")]
    public string editorLoadConfigDefine
    {
        get
        {
            string result = string.Empty;
            if (isUseSQLite)
            {
                result = menLoadConfigDefineMaping[enLoadConfigDefine.SQLITE];
            }
            else
            {
                result = menLoadConfigDefineMaping[enLoadConfigDefine.XLS];
            }
            return result;
        }
    }

    [InvokeMethod("EditorDisplayParameter")]
    [AliasTooltip("方法回调")]
    public string editorInvoke;
    /// <summary>
    /// OnDisplayPath
    /// </summary>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <returns>高度</returns>
    float EditorDisplayParameter(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        float y = _position.y;
        _position.height = 16;        
        PropertyInfo[] properties = GetType().GetProperties();
        if (properties != null && properties.Length > 0)
        {
            _position.height *= properties.Length;
        }
        EditorGUI.LabelField(_position, ToData());
        _position.y += _position.height;
        return _position.y - y;
    }
#endif
#endregion
        }