using UnityEngine.EventSystems;
/// <summary>
/// 收集接口
/// </summary>
public interface ICollect
{
    /// <summary>
    /// 收集组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    void CollectCtrl<T>() where T : UIBehaviour;
    /// <summary>
    /// 查询指定名称组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="_name">组件名称</param>
    /// <returns>组件</returns>
    T FindCtrlByName<T>(string _name) where T : UIBehaviour;
    /// <summary>
    /// 查询指定名称组件【组件类型是指定类型或父类型】
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="_name">组件名称</param>
    /// <returns>组件</returns>
    T FindCtrlByNameIsSelfOrParent<T>(string _name) where T : UIBehaviour;
}
