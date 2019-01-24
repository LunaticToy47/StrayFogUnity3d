#if UNITY_EDITOR
/// <summary>
/// 可保存资源DrawUI接口
/// </summary>
public interface IEditorSavedAssetDrawUI
{
    /// <summary>
    /// 获得保存资源路径组
    /// </summary>
    string[] paths { get; }
    /// <summary>
    /// 绘制GUI
    /// </summary>
    void DrawGUI();
}
#endif