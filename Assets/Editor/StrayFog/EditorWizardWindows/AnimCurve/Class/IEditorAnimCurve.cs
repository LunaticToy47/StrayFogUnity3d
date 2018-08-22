/// <summary>
/// 编辑器动画曲线
/// </summary>
public interface IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    string curveName { get; }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    int keyframeCount { get; }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration);
}
