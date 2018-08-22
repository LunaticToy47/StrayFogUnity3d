using System;
using UnityEngine;
/// <summary>
/// 范围
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class ValueRangeAttribute : PropertyAttribute
{
    /// <summary>
    /// 最小值
    /// </summary>
    public float floatMin { get; private set; }
    /// <summary>
    /// 最大值
    /// </summary>
    public float floatMax { get; private set; }

    /// <summary>
    /// 最小值
    /// </summary>
    public int intMin { get; private set; }
    /// <summary>
    /// 最大值
    /// </summary>
    public int intMax { get; private set; }
    /// <summary>
    /// 构造函数
    /// </summary>
    public ValueRangeAttribute(float min, float max)
    {
        floatMin = min;
        floatMax = max;
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    public ValueRangeAttribute(int min, int max)
    {
        intMin = min;
        intMax = max;
    }
}

