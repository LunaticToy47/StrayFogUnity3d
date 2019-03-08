using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI窗口SiblingIndex
/// </summary>
[AddComponentMenu("Game/UI/UIWindowSiblingIndex")]
public sealed class UIWindowSiblingIndex : AbsMonoBehaviour
{
    /// <summary>
    /// 层级根节点
    /// Key:层级
    /// Value:根节点
    /// </summary>
    Dictionary<int, RectTransform> mLayerMaping = new Dictionary<int, RectTransform>();
    /// <summary>
    /// 附加窗口SiblingIndex占位符
    /// </summary>
    /// <param name="_winCfg">窗口配置</param>
    /// <returns>占位符</returns>
    public RectTransform GetWindowSiblingIndex(XLS_Config_Table_UIWindowSetting _winCfg)
    {
        int layer = _winCfg.layer;
        if (!mLayerMaping.ContainsKey(layer))
        {
            int siblingIndex = 0;
            foreach (KeyValuePair<int, RectTransform> key in mLayerMaping)
            {
                if (key.Key < layer)
                {
                    siblingIndex = Mathf.Max(siblingIndex, key.Value.GetSiblingIndex() + 1);
                }
            }
            GameObject go = new GameObject(((enUIWindowLayer)_winCfg.layer).ToString());
            go.layer = gameObject.layer;
            RectTransform rt = go.AddComponent<RectTransform>();
            rt.SetParent(transform, false);
            rt.SetSiblingIndex(siblingIndex);
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.anchoredPosition = Vector2.zero;
            rt.sizeDelta = Vector2.zero;
            mLayerMaping.Add(layer, rt);
        }
        return mLayerMaping[layer];
    }
}