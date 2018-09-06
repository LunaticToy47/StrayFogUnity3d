using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 引导注册组件
/// </summary>
[AddComponentMenu("Game/Guide/UIGuideRegister")]
public class UIGuideRegister : MonoBehaviour, IAttachMonoBehaviourAnyWhere
{
    /// <summary>
    /// 引导绘制图节点索引
    /// </summary>
    [AliasTooltip("引导绘制图节点索引", "引导绘制图节点索引\r\n空值：触发控件本身\r\n非空值：触发控件子节点,index为子节点索引,例如：【0,1,0】,表示在触发控件根节点下的第一个子节点的第二个子节点的第一个子节点")]
    [ValueRange(0, int.MaxValue)]
    public int[] graphicsNodeIndexs;
    /// <summary>
    /// 触发id
    /// </summary>
    [AliasTooltip("触发id")]
    [ValueRange(0, int.MaxValue)]
    [ReferPropertyDisplayInspector("isValidate", false)]
    public int triggerId;
    /// <summary>
    /// 验证是否完成事件
    /// </summary>
    [AliasTooltip("验证是否完成事件")]
    [ReferPropertyDisplayInspector("isValidate", false)]
    public EventTriggerType validateIsFinishEventTriggerType = EventTriggerType.PointerClick;
    /// <summary>
    /// 验证id
    /// </summary>
    [AliasTooltip("验证id")]
    [ValueRange(0, int.MaxValue)]
    [ReferPropertyDisplayInspector("isValidate", true)]
    public int validateId;
    /// <summary>
    /// 是否是验证节点
    /// </summary>
    [AliasTooltip("是否是验证节点")]
    public bool isValidate;
    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        StrayFogRunningUtility.SingleScriptableObject<StrayFogRunningApplication>().RegisterGuide(this);
    }
}
