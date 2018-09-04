using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 引导触发
/// </summary>
[AddComponentMenu("Game/Guide/UIGuideValidate")]
public class UIGuideValidate : AbsMonoBehaviour
{
    #region config
    /// <summary>
    /// config
    /// </summary>
    public View_UserGuideValidate config { get; private set; }
    #endregion

    #region maskGraphic
    /// <summary>
    /// maskGraphic
    /// </summary>
    public Graphic maskGraphic { get; private set; }
    #endregion

    #region SetConfig  设置配置
    /// <summary>
    /// 设置配置
    /// </summary>
    /// <param name="_config">配置</param>
    public void SetConfig(View_UserGuideValidate _config)
    {
        config = _config;
        maskGraphic = gameObject.GetComponent<Graphic>();
    }
    #endregion
}
