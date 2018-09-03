﻿using System.IO;
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
            return GetFileString("AssetDiskMaping/AssetDiskMapingEnumTemplete");
        }
    }

    /// <summary>
    /// Cmd_ClearSvnTemplete
    /// </summary>
    public static string Cmd_ClearSvnTemplete
    {
        get
        {
            return GetFileString("Cmd/Cmd_ClearSvnTemplete");
        }
    }

    /// <summary>
    /// Cmd_DebugProfilerTemplete
    /// </summary>
    public static string Cmd_DebugProfilerTemplete
    {
        get
        {
            return GetFileString("Cmd/Cmd_DebugProfilerTemplete");
        }
    }

    /// <summary>
    /// Cmd_DeleteManifestTemplete
    /// </summary>
    public static string Cmd_DeleteManifestTemplete
    {
        get
        {
            return GetFileString("Cmd/Cmd_DeleteManifestTemplete");
        }
    }

    /// <summary>
    /// Cmd_ExecuteApplicationRestartMenu
    /// </summary>
    public static string Cmd_ExecuteApplicationRestartMenu
    {
        get
        {
            return GetFileString("Cmd/Cmd_ExecuteApplicationRestartMenu");
        }
    }

    /// <summary>
    /// Cmd_ExecuteEngineMenu
    /// </summary>
    public static string Cmd_ExecuteEngineMenu
    {
        get
        {
            return GetFileString("Cmd/Cmd_ExecuteEngineMenu");
        }
    }

    /// <summary>
    /// EditorFMSMachineMapingScriptTemplete
    /// </summary>
    public static string EditorFMSMachineMapingScriptTemplete
    {
        get
        {
            return GetFileString("Animator/EditorFMSMachineMapingScriptTemplete");
        }
    }

    /// <summary>
    /// EdtiorCustomAssetNewAssetScriptTemplete
    /// </summary>
    public static string EdtiorCustomAssetNewAssetScriptTemplete
    {
        get
        {
            return GetFileString("Develop/EdtiorCustomAssetNewAssetScriptTemplete");
        }
    }

    /// <summary>
    /// GrassDestabilizeShader
    /// </summary>
    public static byte[] GrassDestabilizeShader
    {
        get
        {
            return GetFileBytes("UIShader/Grass/GrassDestabilizeShader");
        }
    }

    /// <summary>
    /// GreyShader
    /// </summary>
    public static byte[] GreyShader
    {
        get
        {
            return GetFileBytes("UIShader/Grey/GreyShader");
        }
    }

    /// <summary>
    /// RippleWaterShader
    /// </summary>
    public static byte[] RippleWaterShader
    {
        get
        {
            return GetFileBytes("UIShader/Water/RippleWaterShader");
        }
    }

    /// <summary>
    /// SQLiteDeterminantEntityScriptTemplete
    /// </summary>
    public static string SQLiteDeterminantEntityScriptTemplete
    {
        get
        {
            return GetFileString("SQLite/SQLiteDeterminantEntityScriptTemplete");
        }
    }

    /// <summary>
    /// SQLiteEntityHelperExtendTemplete
    /// </summary>
    public static string SQLiteEntityHelperExtendTemplete
    {
        get
        {
            return GetFileString("SQLite/SQLiteEntityHelperExtendTemplete");
        }
    }

    /// <summary>
    /// SQLiteEntityScriptTemplete
    /// </summary>
    public static string SQLiteEntityScriptTemplete
    {
        get
        {
            return GetFileString("SQLite/SQLiteEntityScriptTemplete");
        }
    }

    /// <summary>
    /// UIGraphicMaskFragmentShader
    /// </summary>
    public static byte[] UIGraphicMaskFragmentShader
    {
        get
        {
            return GetFileBytes("UIShader/GraphicMask/UIGraphicMaskFragmentShader");
        }
    }

    /// <summary>
    /// UIGraphicMaskVertexShader
    /// </summary>
    public static byte[] UIGraphicMaskVertexShader
    {
        get
        {
            return GetFileBytes("UIShader/GraphicMask/UIGraphicMaskVertexShader");
        }
    }

    /// <summary>
    /// UIWindowEnumMapingTemplete
    /// </summary>
    public static string UIWindowEnumMapingTemplete
    {
        get
        {
            return GetFileString("UIWindow/UIWindowEnumMapingTemplete");
        }
    }

    /// <summary>
    /// UIWindowViewTemplete
    /// </summary>
    public static string UIWindowViewTemplete
    {
        get
        {
            return GetFileString("UIWindow/UIWindowViewTemplete");
        }
    }
}
