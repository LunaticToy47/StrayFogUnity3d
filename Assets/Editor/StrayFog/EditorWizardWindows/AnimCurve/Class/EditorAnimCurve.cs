#if UNITY_EDITOR
using UnityEngine;
/// <summary>
/// 曲线
/// </summary>
class EditorAnimCurve
{
    /// <summary>
    /// 名称
    /// </summary>
    public string name { get; private set; }
    /// <summary>
    /// 帧数
    /// </summary>
    public int keyframeCount { get; private set; }
    /// <summary>
    /// 曲线
    /// </summary>
    public AnimationCurve curve { get; private set; }
    /// <summary>
    /// 开始时间
    /// </summary>
    float mStartingTime = 0;
    /// <summary>
    /// 结束时间
    /// </summary>
    float mFinalTime = 1;
    /// <summary>
    /// 持续时间
    /// </summary>
    float mDurationTime = 1;
    /// <summary>
    /// 开始值
    /// </summary>
    float mStartingValue = 0;
    /// <summary>
    /// 结束值
    /// </summary>
    float mFinalValue = 1;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_animCurve">曲线</param>
    public EditorAnimCurve(IEditorAnimCurve _animCurve)
    {
        name = _animCurve.curveName;
        keyframeCount = _animCurve.keyframeCount;
        curve = new AnimationCurve();
        for (int i = 0; i < _animCurve.keyframeCount; ++i)
        {
            //当前帧时间
            float time = i / (_animCurve.keyframeCount - 1f);
            //当前帧时间所对应的值
            float value = (float)_animCurve.KeyframeValue(time, mStartingValue, mFinalValue, mDurationTime);
            Keyframe key = new Keyframe(time, value);
            curve.AddKey(key);
        }
        for (var i = 0; i < _animCurve.keyframeCount; ++i)
        {
            curve.SmoothTangents(i, 0f);
        }
    }
    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>字符串</returns>
    public override string ToString()
    {
        return string.Format("【{0}】【Keyframe=>{1}】【Time=>start:{2}-final:{3},duration:{4}】【Value=>start:{5}-final:{6}】",
            name, keyframeCount, mStartingTime, mFinalTime, mDurationTime, mStartingValue, mFinalValue);
    }
}
#endif