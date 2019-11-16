using System;
using UnityEngine;
/// <summary>
/// 只读
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class SimulateMonoBehaviourAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_monoBehaviourMethod">MonoBehaviour方法</param>
    public SimulateMonoBehaviourAttribute(string _monoBehaviourMethod)
    {
        monoBehaviourMethod = _monoBehaviourMethod;
    }

    /// <summary>
    /// MonoBehaviour方法
    /// </summary>
    public string monoBehaviourMethod { get; private set; }
}

