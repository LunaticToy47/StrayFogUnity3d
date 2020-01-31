#if UNITY_EDITOR
using System.IO;
/// <summary>
/// XLuaMap设定选择资源
/// </summary>
public class EditorSelectionXLuaMapSetting : EditorSelectionAssetDiskMaping
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pathOrGuid">路径或guid</param>
    public EditorSelectionXLuaMapSetting(string _pathOrGuid) : base(_pathOrGuid)
    {
        isXLua = name.EndsWith(typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.XLuaTxt).ext);
        xLuaName = Path.GetFileNameWithoutExtension(nameWithoutExtension);
        xLuaId = xLuaName.UniqueHashCode();
    }

    /// <summary>
    /// 是否是xLua文件
    /// </summary>
    public bool isXLua { get; private set; }
    /// <summary>
    /// xLua文件名称
    /// </summary>
    public string xLuaName { get; private set; }
    /// <summary>
    /// xLua文件Id
    /// </summary>
    public int xLuaId { get; private set; }
}
#endif