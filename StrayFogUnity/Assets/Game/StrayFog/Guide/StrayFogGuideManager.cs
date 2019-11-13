using System;
using UnityEngine;
/// <summary>
/// 引导管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogGuideManager")]
public partial class StrayFogGuideManager : AbsSingleMonoBehaviour
{
    #region OnIsLevel 是否是指定关卡
    /// <summary>
    /// 是否是指定关卡
    /// </summary>
    public event Func<int, bool> OnIsLevel;
    #endregion

    #region OnValidateFinished 验证器完成事件
    /// <summary>
    /// 验证器完成事件
    /// </summary>
    public event Action<UIGuideValidate> OnValidateFinished;
    #endregion

    #region OnAfterConstructor
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        OnInitGuideWindowData();
        OnInitGuideConfigData();
        OnInitGuideReferObjectData();
        OnInitGuideStyleData();
        OnInitGuideResolveCommand();
    }
    #endregion
}
