using UnityEngine;
/// <summary>
/// FMS状态机接口
/// </summary>
[AddComponentMenu("StrayFog/Game/FMS/FMSMachine")]
public class FMSMachine : AbsMonoBehaviour
{
    #region Animator 读写Animator
    /// <summary>
    /// 阿凡达
    /// </summary>
    public Animator animator { get { return mAnimator; } }
    /// <summary>
    /// 阿凡达
    /// </summary>
    Animator mAnimator = null;
    /// <summary>
    /// 设置阿凡达
    /// </summary>
    /// <param name="_animator">阿凡达</param>
    public void SetAnimator(Animator _animator)
    {
           //UnityEditor.Animations.AnimatorState
           mAnimator = _animator;
    }
    #endregion

    #region IsMachine 是否是指定状态机
    /// <summary>
    /// 是否是指定状态机
    /// </summary>
    /// <param name="_machineNameHash">状态机NameHash值</param>
    /// <returns>true:是,false:否</returns>
    public bool IsMachine(int _machineNameHash)
    {
        return mAnimator != null ? FMSMachineMaping.IsMachine(mAnimator, _machineNameHash) : false;
    }
    #endregion

    #region IsState 是否是指定状态
    /// <summary>
    /// 是否是指定状态
    /// </summary>
    /// <param name="_state">状态NameHash值</param>
    /// <returns>true:是,false:否</returns>
    public bool IsState(int _stateNameHash)
    {
        return mAnimator != null ? FMSMachineMaping.IsState(mAnimator, _stateNameHash) : false;
    }
    #endregion

    #region CrossFade 淡入淡出
    /// <summary>
    /// 淡入淡出
    /// </summary>
    /// <param name="_stateNameHash">状态值</param>
    public void CrossFade(int _stateNameHash)
    {
        CrossFade(_stateNameHash, 0);
    }
    /// <summary>
    /// 淡入淡出
    /// </summary>
    /// <param name="_stateName">状态名称</param>
    public void CrossFade(string _stateName)
    {        
        CrossFade(Animator.StringToHash(_stateName), 0);
    }
    /// <summary>
    /// 淡入淡出
    /// </summary>
    /// <param name="_stateNameHash">状态NameHash值</param>
    /// <param name="_normalizedTransitionDuration">归一化转换时间值</param>
    public void CrossFade(int _stateNameHash, float _normalizedTransitionDuration)
    {
        if (mAnimator != null)
        {
            mAnimator.CrossFade(_stateNameHash, Mathf.Clamp01(_normalizedTransitionDuration));
        }        
    }
    #endregion

    #region SetInteger
    /// <summary>
    /// SetInteger
    /// </summary>
    /// <param name="_parameter">参数</param>
    /// <param name="_value">值</param>
    public void SetInteger(int _parameter, int _value)
    {
        if (mAnimator != null)
        {
            mAnimator.SetInteger(_parameter, _value);
        }        
    }
    #endregion

    #region GetInteger
    /// <summary>
    /// GetInteger
    /// </summary>
    /// <param name="_parameter">参数</param>
    /// <returns>Value</returns>
    public int GetInteger(int _parameter)
    {
        return mAnimator != null ? mAnimator.GetInteger(_parameter) : 0;
    }
    #endregion

    #region SetFloat
    /// <summary>
    /// SetFloat
    /// </summary>
    /// <param name="_parameter">参数</param>
    /// <param name="_value">值</param>
    public void SetFloat(int _parameter, float _value)
    {
        if (mAnimator != null)
        {
            mAnimator.SetFloat(_parameter, _value);
        }        
    }
    #endregion

    #region GetFloat
    /// <summary>
    /// GetFloat
    /// </summary>
    /// <param name="_parameter">参数</param>
    /// <returns>Value</returns>
    public float GetFloat(int _parameter)
    {
        return mAnimator != null ? mAnimator.GetFloat(_parameter) : 0;
    }
    #endregion

    #region SetBool
    /// <summary>
    /// SetBool
    /// </summary>
    /// <param name="_parameter">参数</param>
    /// <param name="_value">值</param>
    public void SetBool(int _parameter, bool _value)
    {
        if (mAnimator != null)
        {
            mAnimator.SetBool(_parameter, _value);
        }        
    }
    #endregion

    #region GetBool
    /// <summary>
    /// GetBool
    /// </summary>
    /// <param name="_parameter">参数</param>
    /// <returns>Value</returns>
    public bool GetBool(int _parameter)
    {
        return mAnimator != null ? mAnimator.GetBool(_parameter) : false;
    }
    #endregion

    #region SetTrigger
    /// <summary>
    /// SetTrigger
    /// </summary>
    /// <param name="_parameter">参数enFMSParameter</param>
    /// <param name="_value">值</param>
    public void SetTrigger(int _parameter, bool _value)
    {
        if (mAnimator != null)
        {
            if (_value)
            {
                mAnimator.SetTrigger(_parameter);
            }
            else
            {
                mAnimator.ResetTrigger(_parameter);
            }
        }        
    }
    #endregion
}
