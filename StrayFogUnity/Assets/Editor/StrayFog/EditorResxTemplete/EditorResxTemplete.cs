#if UNITY_EDITOR
using System.IO;
/// <summary>
/// EditorResxTemplete模板
/// </summary>
public class EditorResxTemplete
{   
    /// <summary>
    /// 根目录
    /// </summary>
    static readonly string msrRoot = enEditorApplicationFolder.Editor_ResxTemplete.GetAttribute<EditorApplicationFolderAttribute>().path;

    /// <summary>
    /// 获得文件字符串
    /// </summary>
    /// <param name="_relativePath">相对于enEditorApplicationFolder.Editor_ResxTemplete路径</param>
    /// <returns>文件字符串</returns>
    static string GetFileString(string _relativePath)
    {
        return File.ReadAllText(Path.Combine(msrRoot, _relativePath));
    }

    /// <summary>
    /// 获得文件流
    /// </summary>
    /// <param name="_relativePath">相对于enEditorApplicationFolder.Editor_ResxTemplete路径</param>
    /// <returns>文件字符串</returns>
    static byte[] GetFileBytes(string _relativePath)
    {
        return File.ReadAllBytes(Path.Combine(msrRoot, _relativePath));
    }

    /// <summary>
    /// AssetDiskMapingEnumTemplete
    /// </summary>
    public static string AssetDiskMapingEnumTemplete
    {
        get
        {
            return GetFileString("AssetDiskMaping/AssetDiskMapingEnumTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// Cmd_ClearSvnTemplete
    /// </summary>
    public static string Cmd_ClearSvnTemplete
    {
        get
        {
            return GetFileString("Cmd/Cmd_ClearSvnTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// Cmd_DebugProfilerTemplete
    /// </summary>
    public static string Cmd_DebugProfilerTemplete
    {
        get
        {
            return GetFileString("Cmd/Cmd_DebugProfilerTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// Cmd_PackageManifestTemplete
    /// </summary>
    public static string Cmd_PackageManifestTemplete
    {
        get
        {
            return GetFileString("Cmd/Cmd_PackageManifestTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// Cmd_ExecuteApplicationRestartMenu
    /// </summary>
    public static string Cmd_ExecuteApplicationRestartMenu
    {
        get
        {
            return GetFileString("Cmd/Cmd_ExecuteApplicationRestartMenu" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// Cmd_ExecuteEngineMenu
    /// </summary>
    public static string Cmd_ExecuteEngineMenu
    {
        get
        {
            return GetFileString("Cmd/Cmd_ExecuteEngineMenu" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// EditorFMSMachineMapingScriptTemplete
    /// </summary>
    public static string EditorFMSMachineMapingScriptTemplete
    {
        get
        {
            return GetFileString("Animator/EditorFMSMachineMapingScriptTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// EditorCustomAssetNewAssetScriptTemplete
    /// </summary>
    public static string EditorCustomAssetNewAssetScriptTemplete
    {
        get
        {
            return GetFileString("Develop/EditorCustomAssetNewAssetScriptTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// Editor_GeneralEnum_ScriptTemplete
    /// </summary>
    public static string Editor_GeneralEnum_ScriptTemplete
    {
        get
        {
            return GetFileString("General/Editor_GeneralEnum_ScriptTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// Editor_SimulateMonoBehaviour_MethodComponent_ScriptTemplete
    /// </summary>
    public static string Editor_SimulateMonoBehaviour_MethodComponent_ScriptTemplete
    {
        get
        {
            return GetFileString("SimulateMonoBehaviour/Editor_SimulateMonoBehaviour_MethodComponent_ScriptTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// Editor_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_ScriptTemplete
    /// </summary>
    public static string Editor_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_ScriptTemplete
    {
        get
        {
            return GetFileString("SimulateMonoBehaviour/Editor_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_ScriptTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// Editor_ISimulateMonoBehaviour_ScriptTemplete
    /// </summary>
    public static string Editor_ISimulateMonoBehaviour_ScriptTemplete
    {
        get
        {
            return GetFileString("SimulateMonoBehaviour/Editor_ISimulateMonoBehaviour_ScriptTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }
    

    /// <summary>
    /// Editor_AbsMonoBehaviour_ISimulateBehaviour_Method_ScriptTemplete
    /// </summary>
    public static string Editor_AbsMonoBehaviour_ISimulateBehaviour_Method_ScriptTemplete
    {
        get
        {
            return GetFileString("SimulateMonoBehaviour/Editor_AbsMonoBehaviour_ISimulateBehaviour_Method_ScriptTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }
    

    /// <summary>
    /// SQLiteCreateDeterminantViewTemplete
    /// </summary>
    public static string SQLiteCreateDeterminantViewTemplete
    {
        get
        {
            return GetFileString("SQLite/SQLiteCreateDeterminantViewTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// SQLiteDeterminantEntityScriptTemplete
    /// </summary>
    public static string SQLiteCreateTableTemplete
    {
        get
        {
            return GetFileString("SQLite/SQLiteCreateTableTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// SQLiteEntityScriptTemplete
    /// </summary>
    public static string SQLiteEntityScriptTemplete
    {
        get
        {
            return GetFileString("SQLite/SQLiteEntityScriptTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// UIWindowEnumMapingTemplete
    /// </summary>
    public static string UIWindowEnumMapingTemplete
    {
        get
        {
            return GetFileString("UIWindow/UIWindowEnumMapingTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }

    /// <summary>
    /// UIWindowViewTemplete
    /// </summary>
    public static string UIWindowViewTemplete
    {
        get
        {
            return GetFileString("UIWindow/UIWindowViewTemplete" +
                typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.TextAsset).ext);
        }
    }
}
#endif