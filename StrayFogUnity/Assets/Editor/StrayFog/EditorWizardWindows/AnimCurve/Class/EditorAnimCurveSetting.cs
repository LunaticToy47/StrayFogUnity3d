#if UNITY_EDITOR
using System;
#region Linear
/// <summary>
/// Linear曲线
/// </summary>
public class AnimCurve_Linear : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "Linear"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 2; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * _time / _curveDuration + _curveStartingValue;
    }
}
#endregion

#region SineEaseIn
/// <summary>
/// SineEaseIn曲线
/// </summary>
public class AnimCurve_SineEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "SineEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return -_curveFinalValue * Math.Cos(_time / _curveDuration * (Math.PI / 2)) + _curveFinalValue + _curveStartingValue;
    }
}
#endregion

#region QuadEaseIn
/// <summary>
/// QuadEaseIn曲线
/// </summary>
public class AnimCurve_QuadEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuadEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * (_time /= _curveDuration) * _time + _curveStartingValue;
    }
}
#endregion

#region CubicEaseIn
/// <summary>
/// CubicEaseIn曲线
/// </summary>
public class AnimCurve_CubicEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "CubicEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * (_time /= _curveDuration) * _time * _time + _curveStartingValue;
    }
}
#endregion

#region QuartEaseIn
/// <summary>
/// QuartEaseIn曲线
/// </summary>
public class AnimCurve_QuartEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuartEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * (_time /= _curveDuration) * _time * _time * _time + _curveStartingValue;
    }
}
#endregion

#region QuintEaseIn
/// <summary>
/// QuintEaseIn曲线
/// </summary>
public class AnimCurve_QuintEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuintEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * (_time /= _curveDuration) * _time * _time * _time * _time + _curveStartingValue;
    }
}
#endregion

#region ExpoEaseIn
/// <summary>
/// ExpoEaseIn曲线
/// </summary>
public class AnimCurve_ExpoEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "ExpoEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return (_time == 0) ? _curveStartingValue : _curveFinalValue * Math.Pow(2, 10 * (_time / _curveDuration - 1)) + _curveStartingValue;
    }
}
#endregion

#region CircEaseIn
/// <summary>
/// CircEaseIn曲线
/// </summary>
public class AnimCurve_CircEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "CircEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return -_curveFinalValue * (Math.Sqrt(1 - (_time /= _curveDuration) * _time) - 1) + _curveStartingValue;
    }
}
#endregion

#region BackEaseIn
/// <summary>
/// BackEaseIn曲线
/// </summary>
public class AnimCurve_BackEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "BackEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * (_time /= _curveDuration) * _time * ((1.70158 + 1) * _time - 1.70158) + _curveStartingValue;
    }
}
#endregion

#region ElasticEaseIn
/// <summary>
/// ElasticEaseIn曲线
/// </summary>
public class AnimCurve_ElasticEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "ElasticEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration) == 1)
            return _curveStartingValue + _curveFinalValue;

        double p = _curveDuration * .3;
        double s = p / 4;

        return -(_curveFinalValue * Math.Pow(2, 10 * (_time -= 1)) * Math.Sin((_time * _curveDuration - s) * (2 * Math.PI) / p)) + _curveStartingValue;
    }
}
#endregion

#region BounceEaseIn
/// <summary>
/// BounceEaseIn曲线
/// </summary>
public class AnimCurve_BounceEaseIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "BounceEaseIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue - EditorStrayFogUtility.Single<AnimCurve_BounceEaseOut>().KeyframeValue(_curveDuration - _time, 0, _curveFinalValue, _curveDuration) + _curveStartingValue;
    }
}
#endregion

#region SineEaseOut
/// <summary>
/// SineEaseOut曲线
/// </summary>
public class AnimCurve_SineEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "SineEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * Math.Sin(_time / _curveDuration * (Math.PI / 2)) + _curveStartingValue;
    }
}
#endregion

#region QuadEaseOut
/// <summary>
/// QuadEaseOut曲线
/// </summary>
public class AnimCurve_QuadEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuadEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return -_curveFinalValue * (_time /= _curveDuration) * (_time - 2) + _curveStartingValue;
    }

}
#endregion

#region CubicEaseOut
/// <summary>
/// CubicEaseOut曲线
/// </summary>
public class AnimCurve_CubicEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "CubicEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * ((_time = _time / _curveDuration - 1) * _time * _time + 1) + _curveStartingValue;
    }
}
#endregion

#region QuartEaseOut
/// <summary>
/// QuartEaseOut曲线
/// </summary>
public class AnimCurve_QuartEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuartEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return -_curveFinalValue * ((_time = _time / _curveDuration - 1) * _time * _time * _time - 1) + _curveStartingValue;
    }
}
#endregion

#region QuintEaseOut
/// <summary>
/// QuintEaseOut曲线
/// </summary>
public class AnimCurve_QuintEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuintEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * ((_time = _time / _curveDuration - 1) * _time * _time * _time * _time + 1) + _curveStartingValue;
    }
}
#endregion

#region ExpoEaseOut
/// <summary>
/// ExpoEaseOut曲线
/// </summary>
public class AnimCurve_ExpoEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "ExpoEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return (_time == _curveDuration) ? _curveStartingValue + _curveFinalValue : _curveFinalValue * (-Math.Pow(2, -10 * _time / _curveDuration) + 1) + _curveStartingValue;
    }
}
#endregion

#region CircEaseOut
/// <summary>
/// CircEaseOut曲线
/// </summary>
public class AnimCurve_CircEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "CircEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * Math.Sqrt(1 - (_time = _time / _curveDuration - 1) * _time) + _curveStartingValue;
    }
}
#endregion

#region BackEaseOut
/// <summary>
/// BackEaseOut曲线
/// </summary>
public class AnimCurve_BackEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "BackEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        return _curveFinalValue * ((_time = _time / _curveDuration - 1) * _time * ((1.70158 + 1) * _time + 1.70158) + 1) + _curveStartingValue;
    }
}
#endregion

#region ElasticEaseOut
/// <summary>
/// ElasticEaseOut曲线
/// </summary>
public class AnimCurve_ElasticEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "ElasticEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration) == 1)
            return _curveStartingValue + _curveFinalValue;

        double p = _curveDuration * .3;
        double s = p / 4;

        return (_curveFinalValue * Math.Pow(2, -10 * _time) * Math.Sin((_time * _curveDuration - s) * (2 * Math.PI) / p) + _curveFinalValue + _curveStartingValue);
    }
}
#endregion

#region BounceEaseOut
/// <summary>
/// BounceEaseOut曲线
/// </summary>
public class AnimCurve_BounceEaseOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "BounceEaseOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration) < (1 / 2.75))
            return _curveFinalValue * (7.5625 * _time * _time) + _curveStartingValue;
        else if (_time < (2 / 2.75))
            return _curveFinalValue * (7.5625 * (_time -= (1.5 / 2.75)) * _time + .75) + _curveStartingValue;
        else if (_time < (2.5 / 2.75))
            return _curveFinalValue * (7.5625 * (_time -= (2.25 / 2.75)) * _time + .9375) + _curveStartingValue;
        else
            return _curveFinalValue * (7.5625 * (_time -= (2.625 / 2.75)) * _time + .984375) + _curveStartingValue;
    }
}
#endregion

#region SineEaseInOut
/// <summary>
/// SineEaseInOut曲线
/// </summary>
public class AnimCurve_SineEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "SineEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration / 2) < 1)
            return _curveFinalValue / 2 * (Math.Sin(Math.PI * _time / 2)) + _curveStartingValue;

        return -_curveFinalValue / 2 * (Math.Cos(Math.PI * --_time / 2) - 2) + _curveStartingValue;
    }
}
#endregion

#region QuadEaseInOut
/// <summary>
/// QuadEaseInOut曲线
/// </summary>
public class AnimCurve_QuadEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuadEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration / 2) < 1)
            return _curveFinalValue / 2 * _time * _time + _curveStartingValue;

        return -_curveFinalValue / 2 * ((--_time) * (_time - 2) - 1) + _curveStartingValue;
    }
}
#endregion

#region CubicEaseInOut
/// <summary>
/// CubicEaseInOut曲线
/// </summary>
public class AnimCurve_CubicEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "CubicEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration / 2) < 1)
            return _curveFinalValue / 2 * _time * _time * _time + _curveStartingValue;

        return _curveFinalValue / 2 * ((_time -= 2) * _time * _time + 2) + _curveStartingValue;
    }
}
#endregion

#region QuartEaseInOut
/// <summary>
/// QuartEaseInOut曲线
/// </summary>
public class AnimCurve_QuartEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuartEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration / 2) < 1)
            return _curveFinalValue / 2 * _time * _time * _time * _time + _curveStartingValue;

        return -_curveFinalValue / 2 * ((_time -= 2) * _time * _time * _time - 2) + _curveStartingValue;
    }
}
#endregion

#region QuintEaseInOut
/// <summary>
/// QuintEaseInOut曲线
/// </summary>
public class AnimCurve_QuintEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuintEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration / 2) < 1)
            return _curveFinalValue / 2 * _time * _time * _time * _time * _time + _curveStartingValue;
        return _curveFinalValue / 2 * ((_time -= 2) * _time * _time * _time * _time + 2) + _curveStartingValue;
    }
}
#endregion

#region ExpoEaseInOut
/// <summary>
/// ExpoEaseInOut曲线
/// </summary>
public class AnimCurve_ExpoEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "ExpoEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time == 0)
            return _curveStartingValue;

        if (_time == _curveDuration)
            return _curveStartingValue + _curveFinalValue;

        if ((_time /= _curveDuration / 2) < 1)
            return _curveFinalValue / 2 * Math.Pow(2, 10 * (_time - 1)) + _curveStartingValue;

        return _curveFinalValue / 2 * (-Math.Pow(2, -10 * --_time) + 2) + _curveStartingValue;
    }
}
#endregion

#region CircEaseInOut
/// <summary>
/// CircEaseInOut曲线
/// </summary>
public class AnimCurve_CircEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "CircEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration / 2) < 1)
            return -_curveFinalValue / 2 * (Math.Sqrt(1 - _time * _time) - 1) + _curveStartingValue;

        return _curveFinalValue / 2 * (Math.Sqrt(1 - (_time -= 2) * _time) + 1) + _curveStartingValue;
    }
}
#endregion

#region BackEaseInOut
/// <summary>
/// BackEaseInOut曲线
/// </summary>
public class AnimCurve_BackEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "BackEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        double s = 1.70158;
        if ((_time /= _curveDuration / 2) < 1)
            return _curveFinalValue / 2 * (_time * _time * (((s *= (1.525)) + 1) * _time - s)) + _curveStartingValue;
        return _curveFinalValue / 2 * ((_time -= 2) * _time * (((s *= (1.525)) + 1) * _time + s) + 2) + _curveStartingValue;
    }
}
#endregion

#region ElasticEaseInOut
/// <summary>
/// ElasticEaseInOut曲线
/// </summary>
public class AnimCurve_ElasticEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "ElasticEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if ((_time /= _curveDuration / 2) == 2)
            return _curveStartingValue + _curveFinalValue;

        double p = _curveDuration * (.3 * 1.5);
        double s = p / 4;

        if (_time < 1)
            return -.5 * (_curveFinalValue * Math.Pow(2, 10 * (_time -= 1)) * Math.Sin((_time * _curveDuration - s) * (2 * Math.PI) / p)) + _curveStartingValue;
        return _curveFinalValue * Math.Pow(2, -10 * (_time -= 1)) * Math.Sin((_time * _curveDuration - s) * (2 * Math.PI) / p) * .5 + _curveFinalValue + _curveStartingValue;
    }
}
#endregion

#region BounceEaseInOut
/// <summary>
/// BounceEaseInOut曲线
/// </summary>
public class AnimCurve_BounceEaseInOut : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "BounceEaseInOut"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_BounceEaseIn>().KeyframeValue(_time * 2, 0, _curveFinalValue, _curveDuration) * .5 + _curveStartingValue;
        else
            return EditorStrayFogUtility.Single<AnimCurve_BounceEaseOut>().KeyframeValue(_time * 2 - _curveDuration, 0, _curveFinalValue, _curveDuration) * .5 + _curveFinalValue * .5 + _curveStartingValue;
    }
}
#endregion

#region SineEaseOutIn
/// <summary>
/// SineEaseOutIn曲线
/// </summary>
public class AnimCurve_SineEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "SineEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_SineEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);

        return EditorStrayFogUtility.Single<AnimCurve_SineEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion

#region QuadEaseOutIn
/// <summary>
/// QuadEaseOutIn曲线
/// </summary>
public class AnimCurve_QuadEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuadEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_QuadEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);

        return EditorStrayFogUtility.Single<AnimCurve_QuadEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion

#region CubicEaseOutIn
/// <summary>
/// CubicEaseOutIn曲线
/// </summary>
public class AnimCurve_CubicEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "CubicEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_CubicEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);

        return EditorStrayFogUtility.Single<AnimCurve_CubicEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion

#region QuartEaseOutIn
/// <summary>
/// QuartEaseOutIn曲线
/// </summary>
public class AnimCurve_QuartEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuartEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_QuartEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);

        return EditorStrayFogUtility.Single<AnimCurve_QuartEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion

#region QuintEaseOutIn
/// <summary>
/// QuintEaseOutIn曲线
/// </summary>
public class AnimCurve_QuintEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "QuintEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_QuintEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);
        return EditorStrayFogUtility.Single<AnimCurve_QuintEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion

#region ExpoEaseOutIn
/// <summary>
/// ExpoEaseOutIn曲线
/// </summary>
public class AnimCurve_ExpoEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "ExpoEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_ExpoEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);

        return EditorStrayFogUtility.Single<AnimCurve_ExpoEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion

#region CircEaseOutIn
/// <summary>
/// CircEaseOutIn曲线
/// </summary>
public class AnimCurve_CircEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "CircEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 15; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_CircEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);

        return EditorStrayFogUtility.Single<AnimCurve_CircEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion

#region BackEaseOutIn
/// <summary>
/// BackEaseOutIn曲线
/// </summary>
public class AnimCurve_BackEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "BackEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_BackEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);
        return EditorStrayFogUtility.Single<AnimCurve_BackEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion

#region ElasticEaseOutIn
/// <summary>
/// ElasticEaseOutIn曲线
/// </summary>
public class AnimCurve_ElasticEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "ElasticEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_ElasticEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);
        return EditorStrayFogUtility.Single<AnimCurve_ElasticEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion

#region BounceEaseOutIn
/// <summary>
/// BounceEaseOutIn曲线
/// </summary>
public class AnimCurve_BounceEaseOutIn : AbsEditorSingle, IEditorAnimCurve
{
    /// <summary>
    /// 曲线名称
    /// </summary>
    public string curveName { get { return "BounceEaseOutIn"; } }
    /// <summary>
    /// 关键帧数量
    /// </summary>
    public int keyframeCount { get { return 30; } }
    /// <summary>
    /// 每帧计算函数
    /// </summary>
    /// <param name="_time">当前帧时间</param>
    /// <param name="_curveStartingValue">曲线开始值</param>
    /// <param name="_curveFinalValue">曲线结束值</param>
    /// <param name="_curveDuration">曲线持续时间</param>
    public double KeyframeValue(double _time, double _curveStartingValue, double _curveFinalValue, double _curveDuration)
    {
        if (_time < _curveDuration / 2)
            return EditorStrayFogUtility.Single<AnimCurve_BounceEaseOut>().KeyframeValue(_time * 2, _curveStartingValue, _curveFinalValue / 2, _curveDuration);
        return EditorStrayFogUtility.Single<AnimCurve_BounceEaseIn>().KeyframeValue((_time * 2) - _curveDuration, _curveStartingValue + _curveFinalValue / 2, _curveFinalValue / 2, _curveDuration);
    }
}
#endregion
#endif