#if UNITY_EDITOR
/// <summary>
/// 可保存资源DrawUI接口
/// </summary>
public interface IEditorSavedAssetDrawUI
{
    /// <summary>
    /// 绘制GUI
    /// </summary>
    void DrawGUI();
}
#endif