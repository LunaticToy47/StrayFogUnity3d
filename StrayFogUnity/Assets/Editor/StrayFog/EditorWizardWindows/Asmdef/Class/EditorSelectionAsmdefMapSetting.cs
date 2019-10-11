#if UNITY_EDITOR
using System.IO;
/// <summary>
/// AsmdefMap设定选择资源
/// </summary>
public class EditorSelectionAsmdefMapSetting : EditorSelectionAssetDiskMaping
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pathOrGuid">路径或guid</param>
    public EditorSelectionAsmdefMapSetting(string _pathOrGuid) : base(_pathOrGuid)
    {
        
    }

    /// <summary>
    /// 解析
    /// </summary>
    protected override void OnResolve()
    {
        isAsmdef = name.EndsWith(enFileExt.Asmdef.GetAttribute<FileExtAttribute>().ext);
        SaveAssetBundleName(null);        
        asmdefDllName = Path.GetFileNameWithoutExtension(name);
        asmdefId = asmdefDllName.UniqueHashCode();

        asmdefDllPath = Path.Combine(EditorStrayFogAssembly.scriptAssembliesPath, asmdefDllName + enFileExt.Dll.GetAttribute<FileExtAttribute>().ext).TransPathSeparatorCharToUnityChar();        
        asmdefDllAssetbundleName = GetAssetBundleName();

        asmdefPdbPath = Path.Combine(EditorStrayFogAssembly.scriptAssembliesPath, asmdefDllName + enFileExt.Dll_PDB.GetAttribute<FileExtAttribute>().ext).TransPathSeparatorCharToUnityChar();
        asmdefPdbAssetbundleName = GetAssetBundleName()+"_p";
        ClearAssetBundleName();
    }

    /// <summary>
    /// 是否是Asmdef文件
    /// </summary>
    public bool isAsmdef { get; private set; }
    /// <summary>
    /// Asmdef文件Id
    /// </summary>
    public int asmdefId { get; private set; }
    /// <summary>
    /// Asmdef文件名称
    /// </summary>
    public string asmdefDllName { get; private set; }
    /// <summary>
    /// Asmdef映射dll文件
    /// </summary>
    public string asmdefDllPath { get; private set; }
    /// <summary>
    /// Asmdef资源Dll名称
    /// </summary>
    public string asmdefDllAssetbundleName { get; private set; }
    /// <summary>
    /// Asmdef映射Pdb文件
    /// </summary>
    public string asmdefPdbPath { get; private set; }
    /// <summary>
    /// Asmdef资源Pdb名称
    /// </summary>
    public string asmdefPdbAssetbundleName { get; private set; }
}
#endif