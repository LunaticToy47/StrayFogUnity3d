using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UGUI画布
/// </summary>
[RequireComponent(typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster))]
[AddComponentMenu("StrayFog/Game/UI/UICanvas")]
public sealed class UICanvas : AbsMonoBehaviour
{
    /// <summary>
    /// 画布
    /// </summary>
    public Canvas canvas { get; private set; }
    /// <summary>
    /// 画布缩放
    /// </summary>
    public CanvasScaler canvasScaler { get; private set; }
    /// <summary>
    /// 绘制检测
    /// </summary>
    public GraphicRaycaster graphicRaycaster { get; private set; }
    /// <summary>
    /// RectTransfrom
    /// </summary>
    public RectTransform rectTransfrom { get; private set; }

    /// <summary>
    /// 像素转世界单位
    /// </summary>
    public float pixelsToWorld { get; private set; }

    /// <summary>
    /// 世界转像素单位
    /// </summary>
    public float worldToPixels { get; private set; }

    /// <summary>
    /// OnAwake
    /// </summary>
    protected override void OnAwake()
    {
        canvas = gameObject.GetComponent<Canvas>();
        canvasScaler = gameObject.GetComponent<CanvasScaler>();
        graphicRaycaster = gameObject.GetComponent<GraphicRaycaster>();
        rectTransfrom = gameObject.GetComponent<RectTransform>();
    }
    /// <summary>
    /// SetDirty
    /// </summary>
    public void SetDirty()
    {
        pixelsToWorld = 1 / canvasScaler.referencePixelsPerUnit;
        worldToPixels = canvasScaler.referencePixelsPerUnit;
    }

    /// <summary>
    /// 层级根节点
    /// Key:层级
    /// Value:根节点
    /// </summary>
    Dictionary<int, RectTransform> mLayerMaping = new Dictionary<int, RectTransform>();
    /// <summary>
    /// 附加窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    public void AttachWindow(AbsUIWindowView _window)
    {
        int layer = _window.config.layer;
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
            GameObject go = new GameObject(((enUIWindowLayer)_window.config.layer).ToString());
            go.layer = gameObject.layer;
            RectTransform rt = go.AddComponent<RectTransform>();
            rt.SetParent(canvas.transform,false);
            rt.SetSiblingIndex(siblingIndex);
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.anchoredPosition = Vector2.zero;
            rt.sizeDelta = Vector2.zero;
            mLayerMaping.Add(layer, rt);
        }
        _window.rectTransform.SetParent(mLayerMaping[layer],false);
    }

    /// <summary>
    /// 获得每单位距离的缩放值(每1个单位距离的缩放值变化值)
    /// </summary>
    /// <returns>单位距离的缩放值</returns>
    public Vector3 GetScalePerUnit()
    {
        return gameObject.transform.localScale / canvas.planeDistance;
    }

    /// <summary>
    /// 获得从世界坐标到锚点坐标的偏移量
    /// </summary>
    /// <param name="_worldPoisition">世界坐标</param>
    /// <returns>UI位置偏移值</returns>
    public Vector3 GetWorldToAnchoredPosition3DOffset(Vector3 _worldPoisition)
    {
        Vector3 offset = _worldPoisition;
        offset.x /= rectTransfrom.localScale.x;
        offset.y /= rectTransfrom.localScale.y;
        offset.z /= rectTransfrom.localScale.z;
        return offset;
    }

    /// <summary>
    /// 获得从锚点坐标到世界坐标到偏移量
    /// </summary>
    /// <param name="_anchoredPosition3D">锚点坐标</param>
    /// <returns>UI位置偏移值</returns>
    public Vector3 GetAnchoredPosition3DToWorldOffset(Vector3 _anchoredPosition3D)
    {
        Vector3 offset = _anchoredPosition3D;
        offset.x *= rectTransfrom.localScale.x;
        offset.y *= rectTransfrom.localScale.y;
        offset.z *= rectTransfrom.localScale.z;
        return offset;
    }
}
