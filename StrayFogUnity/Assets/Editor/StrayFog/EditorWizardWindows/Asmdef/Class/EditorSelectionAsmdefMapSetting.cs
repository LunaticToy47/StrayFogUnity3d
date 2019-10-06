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
        asmdefName = Path.GetFileNameWithoutExtension(name);
        asmdefDll = Path.Combine(EditorStrayFogAssembly.scriptAssembliesPath, asmdefName + enFileExt.Dll.GetAttribute<FileExtAttribute>().ext).TransPathSeparatorCharToUnityChar();
        asmdefId = asmdefName.UniqueHashCode();
        asmdefAssetbundleName = GetAssetBundleName();
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
    /// Asmdef资源文件名称
    /// </summary>
    public string asmdefAssetbundleName { get; private set; }
    /// <summary>
    /// Asmdef文件名称
    /// </summary>
    public string asmdefName { get; private set; }
    /// <summary>
    /// Asmdef映射dll文件
    /// </summary>
    public string asmdefDll { get; private set; }
}
#endif