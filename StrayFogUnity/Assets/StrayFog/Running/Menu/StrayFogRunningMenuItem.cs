using System.Collections.Generic;
/// <summary>
/// 菜单子项
/// </summary>
public class StrayFogRunningMenuItem
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_guid">标识ID</param>
    /// <param name="_itemName">菜单路径</param>
    /// <param name="_displayName">显示名称</param>
    internal StrayFogRunningMenuItem(int _guid, string _itemName, string _displayName)
    {
        itemName = _itemName;
        guid = _guid;
        displayName = _displayName;
        arguments = new object[0];
        items = new List<StrayFogRunningMenuItem>();
    }
    /// <summary>
    /// 标识Guid
    /// </summary>
    public int guid { get; private set; }
    /// <summary>
    /// 菜单名称
    /// </summary>
    public string itemName { get; private set; }
    /// <summary>
    /// 显示名称
    /// </summary>
    public string displayName { get; private set; }
    /// <summary>
    /// 参数
    /// </summary>
    public object[] arguments { get; private set; }
    /// <summary>
    /// 子菜单
    /// </summary>
    public List<StrayFogRunningMenuItem> items { get; private set; }
    /// <summary>
    /// 添加子菜单
    /// </summary>
    /// <param name="_item">子菜单</param>
    public void AddItem(StrayFogRunningMenuItem _item)
    {
        if (!items.Contains(_item))
        {
            items.Add(_item);
        }
    }
    /// <summary>
    /// 清除参数
    /// </summary>
    public void ClearArguments()
    {
        arguments = new object[0];
    }
    /// <summary>
    /// 追加参数
    /// </summary>
    /// <param name="_arguments">参数</param>
    public void AppendArguments(params object[] _arguments)
    {
        List<object> args = new List<object>();
        if (arguments != null)
        {
            args.AddRange(arguments);
        }
        if (_arguments != null)
        {
            args.AddRange(_arguments);
        }
        arguments = args.ToArray();
    }
}
