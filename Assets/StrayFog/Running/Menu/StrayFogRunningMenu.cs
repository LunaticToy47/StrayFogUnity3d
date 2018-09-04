using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// 菜单项
/// </summary>
public class StrayFogRunningMenu
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public StrayFogRunningMenu()
    {
        items = new List<StrayFogRunningMenuItem>();
    }
    /// <summary>
    /// 子菜单
    /// </summary>
    public List<StrayFogRunningMenuItem> items { get; private set; }
    /// <summary>
    /// 菜单项映射
    /// </summary>
    Dictionary<int, StrayFogRunningMenuItem> mDicMenuItemMaping = new Dictionary<int, StrayFogRunningMenuItem>();

    /// <summary>
    /// 添加菜单
    /// </summary>
    /// <param name="_itemName">菜单名称</param>
    /// <returns>返回菜单项</returns>
    public StrayFogRunningMenuItem AddMenuItem(string _itemName)
    {
        StrayFogRunningMenuItem item = null;
        string[] names = _itemName.Split(new string[2] { "/", @"\" }, StringSplitOptions.RemoveEmptyEntries);
        if (names != null && names.Length > 0)
        {
            string path = string.Empty;
            int guid = 0;
            int parentGuid = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (!string.IsNullOrEmpty(path))
                {
                    parentGuid = path.UniqueHashCode();
                }
                path = Path.Combine(path, names[i]);
                guid = path.UniqueHashCode();
                if (!mDicMenuItemMaping.ContainsKey(guid))
                {
                    item = new StrayFogRunningMenuItem(guid, path, names[i]);
                    mDicMenuItemMaping.Add(guid, item);
                    if (i == 0)
                    {//添加根菜单
                        items.Add(item);
                    }
                }
                item = mDicMenuItemMaping[guid];
                if (mDicMenuItemMaping.ContainsKey(parentGuid))
                {
                    mDicMenuItemMaping[parentGuid].AddItem(item);
                }
            }
        }
        return item;
    }
}
