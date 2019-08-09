using UnityEngine;
/// <summary>
/// 角色抽象组件
/// </summary>
[RequireComponent(typeof(FMSMachine))]
public abstract class AbsRole : AbsMonoBehaviour
{
    /// <summary>
    /// 动画阿凡达
    /// </summary>
    [AliasTooltip("角色阿凡达")]
    public Animator animator;
}

