using UnityEngine;
/// <summary>
/// 是否是指定关卡事件代理
/// </summary>
/// <param name="_levelId">关卡id</param>
/// <returns>true:是指定关卡,false:不是指定关卡</returns>
public delegate bool IsLevelEventHandler(int _levelId);
/// <summary>
/// 引导验证完成事件代理
/// </summary>
/// <param name="_validate">验证器</param>
public delegate void GuideValidateFinishedEventHandler(UIGuideValidate _validate);
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
    public event IsLevelEventHandler OnIsLevel;
    #endregion

    #region OnValidateFinished 验证器完成事件
    /// <summary>
    /// 验证器完成事件
    /// </summary>
    public event GuideValidateFinishedEventHandler OnValidateFinished;
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
    }
    #endregion
}
