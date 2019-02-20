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
            return GetFileString("AssetDiskMaping/AssetDiskMapingEnumTemplete"+enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// Cmd_ClearSvnTemplete
    /// </summary>
    public static string Cmd_ClearSvnTemplete
    {
        get
        {
            return GetFileString("Cmd/Cmd_ClearSvnTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// Cmd_DebugProfilerTemplete
    /// </summary>
    public static string Cmd_DebugProfilerTemplete
    {
        get
        {
            return GetFileString("Cmd/Cmd_DebugProfilerTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// Cmd_PackageManifestTemplete
    /// </summary>
    public static string Cmd_PackageManifestTemplete
    {
        get
        {
            return GetFileString("Cmd/Cmd_PackageManifestTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// Cmd_ExecuteApplicationRestartMenu
    /// </summary>
    public static string Cmd_ExecuteApplicationRestartMenu
    {
        get
        {
            return GetFileString("Cmd/Cmd_ExecuteApplicationRestartMenu" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// Cmd_ExecuteEngineMenu
    /// </summary>
    public static string Cmd_ExecuteEngineMenu
    {
        get
        {
            return GetFileString("Cmd/Cmd_ExecuteEngineMenu" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// EditorFMSMachineMapingScriptTemplete
    /// </summary>
    public static string EditorFMSMachineMapingScriptTemplete
    {
        get
        {
            return GetFileString("Animator/EditorFMSMachineMapingScriptTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// EdtiorCustomAssetNewAssetScriptTemplete
    /// </summary>
    public static string EdtiorCustomAssetNewAssetScriptTemplete
    {
        get
        {
            return GetFileString("Develop/EdtiorCustomAssetNewAssetScriptTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// GrassDestabilizeShader
    /// </summary>
    public static byte[] GrassDestabilizeShader
    {
        get
        {
            return GetFileBytes("UIShader/Grass/GrassDestabilizeShader" + enFileExt.Shader.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// GreyShader
    /// </summary>
    public static byte[] GreyShader
    {
        get
        {
            return GetFileBytes("UIShader/Grey/GreyShader" + enFileExt.Shader.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// RippleWaterShader
    /// </summary>
    public static byte[] RippleWaterShader
    {
        get
        {
            return GetFileBytes("UIShader/Water/RippleWaterShader" + enFileExt.Shader.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// SQLiteCreateDeterminantViewTemplete
    /// </summary>
    public static string SQLiteCreateDeterminantViewTemplete
    {
        get
        {
            return GetFileString("SQLite/SQLiteCreateDeterminantViewTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// SQLiteDeterminantEntityScriptTemplete
    /// </summary>
    public static string SQLiteCreateTableTemplete
    {
        get
        {
            return GetFileString("SQLite/SQLiteCreateTableTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// SQLiteEntityScriptTemplete
    /// </summary>
    public static string SQLiteEntityScriptTemplete
    {
        get
        {
            return GetFileString("SQLite/SQLiteEntityScriptTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// UIGraphicMaskFragmentShader
    /// </summary>
    public static byte[] UIGraphicMaskFragmentShader
    {
        get
        {
            return GetFileBytes("UIShader/GraphicMask/UIGraphicMaskFragmentShader" + enFileExt.Shader.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// UIGraphicMaskVertexShader
    /// </summary>
    public static byte[] UIGraphicMaskVertexShader
    {
        get
        {
            return GetFileBytes("UIShader/GraphicMask/UIGraphicMaskVertexShader" + enFileExt.Shader.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// UIWindowEnumMapingTemplete
    /// </summary>
    public static string UIWindowEnumMapingTemplete
    {
        get
        {
            return GetFileString("UIWindow/UIWindowEnumMapingTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }

    /// <summary>
    /// UIWindowViewTemplete
    /// </summary>
    public static string UIWindowViewTemplete
    {
        get
        {
            return GetFileString("UIWindow/UIWindowViewTemplete" + enFileExt.TextAsset.GetAttribute<FileExtAttribute>().ext);
        }
    }
}
#endif