using UnityEngine;
/// <summary>
/// 引导样式
/// </summary>
public partial class XLS_Config_Table_UserGuideStyle
{
    /// <summary>
    /// 箭头锚点
    /// </summary>
    public TextAnchor enArrowAnchor { get; private set; }
    /// <summary>
    /// OnResolve
    /// </summary>
    protected override void OnResolve()
    {
        enArrowAnchor = (TextAnchor)arrowAnchor;
    }
}
