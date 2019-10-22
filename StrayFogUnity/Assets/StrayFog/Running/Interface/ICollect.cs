using UnityEngine;
/// <summary>
/// 收集接口
/// </summary>
public interface ICollect
{
    /// <summary>
    /// 收集组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    void CollectCtrl<T>() where T : MonoBehaviour;
    /// <summary>
    /// 根据名称查询组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="_name">组件名称</param>
    /// <returns>组件</returns>
    T FindCtrlByName<T>(string _name) where T : MonoBehaviour;
}
