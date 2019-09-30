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
        isAsmdef = name.EndsWith(enFileExt.Asmdef.GetAttribute<FileExtAttribute>().ext);
        asmdefName = Path.GetFileNameWithoutExtension(nameWithoutExtension);
        asmdefId = asmdefName.UniqueHashCode();
    }

    /// <summary>
    /// 是否是Asmdef文件
    /// </summary>
    public bool isAsmdef { get; private set; }
    /// <summary>
    /// Asmdef文件名称
    /// </summary>
    public string asmdefName { get; private set; }
    /// <summary>
    /// Asmdef文件Id
    /// </summary>
    public int asmdefId { get; private set; }
}
#endif