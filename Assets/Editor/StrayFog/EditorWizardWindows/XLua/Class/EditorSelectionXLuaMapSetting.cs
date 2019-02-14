#if UNITY_EDITOR
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
    }
}
#endif