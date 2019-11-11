using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// UI拖拽组件
/// </summary>
[AddComponentMenu("StrayFog/Game/UI/Drag/UIDragMono")]
[RequireComponent(typeof(MaskableGraphic))]
public class UIDragMono : UIBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    /// <summary>
    /// 开始拖拽事件
    /// </summary>
    public event Action<UIDragMono, PointerEventData> OnBeginDragEvent;
    /// <summary>
    /// 拖拽事件
    /// </summary>
    public event Action<UIDragMono, PointerEventData> OnDragEvent;
    /// <summary>
    /// 结束拖拽事件
    /// </summary>
    public event Action<UIDragMono, PointerEventData> OnEndDragEvent;
    /// <summary>
    /// MaskableGraphic
    /// </summary>
    MaskableGraphic mMaskableGraphic = null;
    /// <summary>
    /// 差值
    /// </summary>
    Vector2 mOffset = Vector2.zero;
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="_eventData">参数</param>
    public void OnBeginDrag(PointerEventData _eventData)
    {
        if (mMaskableGraphic == null)
        {
            mMaskableGraphic = GetComponent<MaskableGraphic>();
        }
        RectTransform canvas = (RectTransform)mMaskableGraphic.canvas.transform;
        Vector2 mouseUguiPos = Vector2.zero;
        RectTransform dragTransform = (RectTransform)_eventData.pointerDrag.transform;
        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas, _eventData.position, _eventData.pressEventCamera, out mouseUguiPos);
        if (isRect)//如果在
        {
            //计算图片中心和鼠标点的差值
            mOffset = dragTransform.anchoredPosition - mouseUguiPos;
        }
        OnBeginDragEvent?.Invoke(this, _eventData);
    }

    /// <summary>
    /// 拖拽
    /// </summary>
    /// <param name="_eventData">参数</param>
    public void OnDrag(PointerEventData _eventData)
    {
        if (_eventData.dragging)
        {
            RectTransform canvas = (RectTransform)mMaskableGraphic.canvas.transform;
            Vector2 mouseUguiPos = Vector2.zero;
            RectTransform dragTransform = (RectTransform)_eventData.pointerDrag.transform;
            if (RectTransformUtility.RectangleContainsScreenPoint(canvas, _eventData.position, _eventData.pressEventCamera))
            {//如果鼠标在屏幕内
                bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvas, _eventData.position, _eventData.pressEventCamera, out mouseUguiPos);
                if (isRect)//如果在
                {
                    //设置图片的ugui坐标与鼠标的ugui坐标保持不变
                    dragTransform.anchoredPosition = mOffset + mouseUguiPos;
                    dragTransform.FixedPositionInCanvas(canvas);
                }
            }
            OnDragEvent?.Invoke(this, _eventData);
        }
    }

    /// <summary>
    /// 结束拖拽
    /// </summary>
    /// <param name="_eventData">参数</param>
    public void OnEndDrag(PointerEventData _eventData)
    {
        OnEndDragEvent?.Invoke(this, _eventData);
    }
}