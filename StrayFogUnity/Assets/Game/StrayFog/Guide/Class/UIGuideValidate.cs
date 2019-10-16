using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 引导触发
/// </summary>
[AddComponentMenu("StrayFog/Game/Guide/UIGuideValidate")]
public class UIGuideValidate : AbsMonoBehaviour
{
    #region config
    /// <summary>
    /// config
    /// </summary>
    public XLS_Config_Table_UserGuideConfig config { get; private set; }
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
    public void SetConfig(XLS_Config_Table_UserGuideConfig _config)
    {
        config = _config;
        maskGraphic = gameObject.GetComponent<Graphic>();
    }
    #endregion
}
