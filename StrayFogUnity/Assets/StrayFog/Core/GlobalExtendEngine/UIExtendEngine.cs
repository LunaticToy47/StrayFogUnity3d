﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// UGUI扩展
/// </summary>
public static class UIExtendEngine
{
    #region 固定位置在指定画布区域
    /// <summary>
    /// 固定位置在指定画布区域
    /// </summary>
    /// <param name="_source">源位置</param>
    /// <param name="_canvas">画布</param>
    public static void FixedPositionInCanvas(this RectTransform _source, RectTransform _canvas)
    {
        Rect mRect = new Rect(0, 0, _canvas.rect.width, _canvas.rect.height);
        _source.FixedPositionInCanvas(_canvas, mRect);
    }

    /// <summary>
    /// 固定位置在指定画布区域内
    /// </summary>
    /// <param name="_source">源位置</param>
    /// <param name="_canvas">画布</param>
    /// <param name="_rect">限制区域(画布左下角为坐标原点(0,0))</param>
    public static void FixedPositionInCanvas(this RectTransform _source, RectTransform _canvas, Rect _rect)
    {
        Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(_canvas, _source);
        Vector2 delta = Vector2.zero;
        Vector3 tempCenter = bounds.center;
        tempCenter.x += _canvas.rect.width * 0.5f;
        tempCenter.y += _canvas.rect.height * 0.5f;
        bounds.center = tempCenter;
        if (bounds.center.x - bounds.extents.x < _rect.x)//target超出area的左边框
        {
            delta.x += Mathf.Abs(bounds.center.x - bounds.extents.x - _rect.x);
        }
        else if (bounds.center.x + bounds.extents.x > _rect.width)//target超出area的右边框
        {
            delta.x -= Mathf.Abs(bounds.center.x + bounds.extents.x - _rect.width);
        }

        if (bounds.center.y - bounds.extents.y < _rect.y)//target超出area上边框
        {
            delta.y += Mathf.Abs(bounds.center.y - bounds.extents.y - _rect.y);
        }
        else if (bounds.center.y + bounds.extents.y > _rect.height)//target超出area的下边框
        {
            delta.y -= Mathf.Abs(bounds.center.y + bounds.extents.y - _rect.height);
        }
        //加上偏移位置算出在屏幕内的坐标
        _source.anchoredPosition += delta;
    }
    #endregion

    #region UI坐标转换
    /// <summary>
    /// 世界物体转换为UI坐标
    /// </summary>
    /// <param name="_worldGo">世界物体</param>
    /// <param name="_worldCamera">世界摄像机</param>
    /// <param name="_uiCanvas">UI画布</param>
    /// <param name="_uiCamera">UI摄像机</param>
    /// <returns>UI坐标</returns>
    public static Vector2 WorldToLocalPointInRectangle(this Transform _worldGo, Camera _worldCamera, Canvas _uiCanvas, Camera _uiCamera)
    {
        return WorldToLocalPointInRectangle(_worldGo.position, _worldCamera, _uiCanvas, _uiCamera);
    }

    /// <summary>
    /// 世界物体转换为UI坐标
    /// </summary>
    /// <param name="_worldPosition">世界坐标</param>
    /// <param name="_worldCamera">世界摄像机</param>
    /// <param name="_uiCanvas">UI画布</param>
    /// <param name="_uiCamera">UI摄像机</param>
    /// <returns>UI坐标</returns>
    public static Vector2 WorldToLocalPointInRectangle(this Vector3 _worldPosition, Camera _worldCamera, Canvas _uiCanvas, Camera _uiCamera)
    {
        Vector2 mUIPoint = RectTransformUtility.WorldToScreenPoint(_worldCamera, _worldPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)_uiCanvas.transform, mUIPoint, _uiCamera, out mUIPoint);
        return mUIPoint;
    }

    /// <summary>
    /// 将指定Graphic定位到参考Graphic位置
    /// </summary>
    /// <param name="_self">指定Graphic</param>
    /// <param name="_refer">参考Graphic</param>
    /// <returns>UI坐标</returns>
    public static Vector2 LocalPointToRefer(this Graphic _self, Graphic _refer)
    {
        Vector2 mUIPoint = RectTransformUtility.WorldToScreenPoint(_refer.canvas.worldCamera, _refer.transform.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _self.transform.parent as RectTransform, mUIPoint, _self.canvas.worldCamera, out mUIPoint);
        return mUIPoint;
    }
    #endregion

    #region UI在屏幕的坐标位置
    /// <summary>
    /// UI在屏幕的坐标
    /// </summary>
    /// <param name="_graphic">Graphic</param>
    /// <returns>坐标</returns>
    public static Vector3 WorldToScreenPoint(this Graphic _graphic)
    {
        return _graphic.canvas.worldCamera != null ?
            _graphic.canvas.worldCamera.WorldToScreenPoint(_graphic.rectTransform.position) : Vector3.zero;
    }
    #endregion

    #region UI在画布的Normalized值
    /// <summary>
    /// UI在画布的Normalized值
    /// </summary>
    /// <param name="_graphic">Graphic</param>
    /// <returns>Normalized值</returns>
    public static Vector2 PointToNormalized(this Graphic _graphic)
    {
        RectTransform rect = (RectTransform)_graphic.canvas.transform;
        return Rect.PointToNormalized(rect.rect, _graphic.rectTransform.anchoredPosition);
    }
    #endregion

    #region Normalized值在指定UI的画布的坐标
    /// <summary>
    /// Normalized值在指定UI的画布的坐标
    /// </summary>
    /// <param name="_graphic">Graphic</param>
    /// <param name="_normalizedRectCoordinates">Normalized坐标</param>
    /// <returns>Normalized值</returns>
    public static Vector2 NormalizedToPoint(this Graphic _graphic, Vector2 _normalizedRectCoordinates)
    {
        RectTransform rect = (RectTransform)_graphic.canvas.transform;
        return Rect.NormalizedToPoint(rect.rect, _normalizedRectCoordinates);
    }
    #endregion

    #region Graphic在VertexHelper的本地四角坐标
    /// <summary>
    /// Graphic在VertexHelper的本地四角坐标
    /// </summary>
    /// <param name="_graphic">Graphic</param>
    /// <param name="_corners">四角坐标</param>
    public static void GraphicLocalCornersForVertexHelper(this Graphic _graphic, out Vector3[] _corners)
    {
        _corners = new Vector3[4];
        _graphic.rectTransform.GetWorldCorners(_corners);
        for (int i = 0; i < _corners.Length; i++)
        {
            Vector2 mUIPoint = RectTransformUtility.WorldToScreenPoint(_graphic.canvas.worldCamera, _corners[i]);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)_graphic.canvas.transform, mUIPoint, _graphic.canvas.worldCamera, out mUIPoint);
            _corners[i] = mUIPoint;
        }
    }
    #endregion

    #region Graphic在VertexHelper的本地矩形
    /// <summary>
    /// Graphic在VertexHelper的本地矩形
    /// </summary>
    /// <param name="_graphic">Graphic</param>
    /// <returns>矩形</returns>
    public static Rect GraphicLocalRectForVertexHelper(this Graphic _graphic)
    {
        Vector3[] fourCorners = null;
        return GraphicLocalRectForVertexHelper(_graphic, ref fourCorners);
    }
    #endregion

    #region Graphic在VertexHelper的本地矩形
    /// <summary>
    /// Graphic在VertexHelper的本地矩形
    /// </summary>
    /// <param name="_graphic">Graphic</param>
    /// <param name="_corners">矩形四角</param>
    /// <returns>矩形</returns>
    public static Rect GraphicLocalRectForVertexHelper(this Graphic _graphic, ref Vector3[] _corners)
    {
        GraphicLocalCornersForVertexHelper(_graphic, out _corners);
        Rect rect = new Rect();
        rect.xMin = rect.yMin = float.MaxValue;
        rect.xMax = rect.yMax = float.MinValue;
        foreach (Vector3 n in _corners)
        {
            rect.xMin = Mathf.Min(rect.xMin, n.x);
            rect.yMin = Mathf.Min(rect.yMin, n.y);
            rect.xMax = Mathf.Max(rect.xMax, n.x);
            rect.yMax = Mathf.Max(rect.yMax, n.y);
        }
        return rect;
    }
    #endregion

    #region GraphicDrawingDimensionsForVertexHelper Graphic在VertexHelper的实际轮廓
    /// <summary>
    /// Graphic在VertexHelper的实际轮廓
    /// </summary>
    /// <param name="_graphic">Graphic</param>
    /// <param name="_graphicSprite">Graphic绘制的精灵图</param>
    /// <param name="_shouldPreserveAspect">是否保持纵横比</param>
    /// <returns>x,y左下角,z,w右上角</returns>
    public static Vector4 GraphicDrawingDimensionsForVertexHelper(this Graphic _graphic, Sprite _graphicSprite, bool _shouldPreserveAspect)
    {
        Vector4 padding = _graphicSprite == null ? Vector4.zero : UnityEngine.Sprites.DataUtility.GetPadding(_graphicSprite);
        Vector2 size = _graphicSprite == null ? Vector2.zero : new Vector2(_graphicSprite.rect.width, _graphicSprite.rect.height);

        Rect r = _graphic.GetPixelAdjustedRect();
        // Debug.Log(string.Format("r:{2}, size:{0}, padding:{1}", size, padding, r));

        int spriteW = Mathf.RoundToInt(size.x);
        int spriteH = Mathf.RoundToInt(size.y);

        Vector4 v = new Vector4(
                padding.x / spriteW,
                padding.y / spriteH,
                (spriteW - padding.z) / spriteW,
                (spriteH - padding.w) / spriteH);

        if (_shouldPreserveAspect && size.sqrMagnitude > 0.0f)
        {
            float spriteRatio = size.x / size.y;
            float rectRatio = r.width / r.height;

            if (spriteRatio > rectRatio)
            {
                float oldHeight = r.height;
                r.height = r.width * (1.0f / spriteRatio);
                r.y += (oldHeight - r.height) * _graphic.rectTransform.pivot.y;
            }
            else
            {
                float oldWidth = r.width;
                r.width = r.height * spriteRatio;
                r.x += (oldWidth - r.width) * _graphic.rectTransform.pivot.x;
            }
        }

        v = new Vector4(
                r.x + r.width * v.x,
                r.y + r.height * v.y,
                r.x + r.width * v.z,
                r.y + r.height * v.w
                );

        return v;
    }
    #endregion

    #region TransRectToBounds 转换矩形为Bounds
    /// <summary>
    /// 转换矩形为Bounds
    /// </summary>
    /// <param name="_rect">矩形</param>
    /// <returns>矩形</returns>
    public static Bounds TransRectToBounds(this Rect _rect)
    {
        Bounds b = new Bounds();
        b.center = _rect.center;
        b.max = _rect.max;
        b.min = _rect.min;
        return b;
    }
    #endregion

    #region RectTransform 设置为全伸展
    /// <summary>
    /// RectTransform设置为全伸展
    /// </summary>
    /// <param name="_trans">转换</param>
    public static void IdentityStreech(this RectTransform _trans)
    {
        _trans.anchorMax = Vector2.one;
        _trans.anchorMin = Vector2.zero;
        _trans.pivot = Vector2.one * 0.5f;
        _trans.localRotation = Quaternion.identity;
        _trans.localScale = Vector3.one;
        _trans.anchoredPosition3D = Vector3.zero;
        _trans.anchoredPosition = Vector2.zero;
        _trans.sizeDelta = Vector2.zero;
    }
    #endregion

    #region AddListener 添加监听事件
    /// <summary>
    /// 添加监听事件
    /// </summary>
    /// <param name="_trigger">触发器</param>
    /// <param name="_eventTriggerType">事件类型</param>
    /// <param name="_callback">回调</param>
    public static void AddListener<T>(this EventTrigger _trigger,
        EventTriggerType _eventTriggerType,
        UnityAction<T> _callback)
        where T : BaseEventData
    {
        UnityAction<BaseEventData> call = new UnityAction<BaseEventData>((data) => { _callback((T)data); });
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = _eventTriggerType;
        entry.callback.AddListener(call);
        _trigger.triggers.Add(entry);
    }
    #endregion

    #region IsCenterPointInRectanle Graphic A中心点是否在Graphic B的矩形中
    /// <summary>
    /// Graphic A中心点是否在Graphic B的矩形中
    /// </summary>
    /// <param name="_a">Graphic A</param>
    /// <param name="_b">Graphic B</param>
    /// <param name="_point">A中心点在B中的坐标</param>
    /// <returns>true:在,false:不在</returns>
    public static bool IsCenterPointInRectanle(this Graphic _a, Graphic _b, out Vector2 _point)
    {
        Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(_a.rectTransform);
        Vector3 offset = bounds.center * _a.canvas.transform.localScale.x;
        Vector2 point = RectTransformUtility.WorldToScreenPoint(_a.canvas.worldCamera, _a.rectTransform.position + offset);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_b.rectTransform, point, _b.canvas.worldCamera, out _point);
        return _b.GetPixelAdjustedRect().Contains(_point);
    }
    #endregion

    #region ForceRebuildLayoutImmediate 立即强制刷新Layout布局
    /// <summary>
    /// 立即强制刷新Layout布局 
    /// </summary>
    /// <param name="_rectTransform">RectTransform</param>
    public static void ForceRebuildLayoutImmediate(this RectTransform _rectTransform)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
    }
    #endregion

    #region MarkLayoutForRebuild 在当前帧末尾刷新Layout布局
    /// <summary>
    /// 在当前帧末尾刷新Layout布局 
    /// </summary>
    /// <param name="_rectTransform">RectTransform</param>
    public static void MarkLayoutForRebuild(this RectTransform _rectTransform)
    {
        LayoutRebuilder.MarkLayoutForRebuild(_rectTransform);
    }
    #endregion

    #region GetTextAnchorPivot 获得指定TextAnchor锚点的Pivot
    /// <summary>
    /// 获得指定TextAnchor锚点的Pivot
    /// </summary>
    /// <param name="_anchor">锚点</param>
    /// <returns>Pivot</returns>
    public static Vector2 GetTextAnchorPivot(this TextAnchor _anchor)
    {
        return Text.GetTextAnchorPivot(_anchor);
    }
    #endregion

    #region CopyFrom 从指定的RectTransform复制值
    /// <summary>
    /// 从指定的RectTransform复制值
    /// </summary>
    /// <param name="_self">要复制值的RectTransform</param>
    /// <param name="_from">复制源RectTransform</param>
    public static void CopyRectTransformFrom(this Graphic _self, Graphic _from)
    {
        _self.rectTransform.sizeDelta = _from.rectTransform.sizeDelta;
        _self.rectTransform.localEulerAngles = _from.rectTransform.localEulerAngles;
        _self.rectTransform.localScale = _from.rectTransform.localScale;        
        _self.rectTransform.anchoredPosition = _self.LocalPointToRefer(_from);
    }
    #endregion

    #region AlignFrom 从指定的RectTransform对齐位置
    /// <summary>
    /// 从指定的RectTransform对齐位置
    /// </summary>
    /// <param name="_self">要复制值的RectTransform</param>
    /// <param name="_from">复制源RectTransform</param>
    public static void AlignRectTransformFrom(this Graphic _self, Graphic _from)
    {
        _self.rectTransform.anchoredPosition = _self.LocalPointToRefer(_from);
    }
    #endregion

    #region AlignFrom 从指定的RectTransform对齐位置
    /// <summary>
    /// 从指定的RectTransform对齐位置
    /// </summary>
    /// <param name="_self">要復制值的RectTransform</param>
    /// <param name="_selfAnchor">自身锚点</param>
    /// <param name="_selfOffsetPos">自身位置偏移</param>
    /// <param name="_from">復制源RectTransform</param>
    /// <param name="_fromAnchor">复制源锚点</param>
    /// <param name="_fromOffsetPos">复制源锚点偏移</param>
    public static void AlignRectTransformFrom(this Graphic _self, TextAnchor _selfAnchor, Vector2 _selfOffsetPos, Graphic _from, TextAnchor _fromAnchor, Vector2 _fromOffsetPos)
    {
        Vector2 pos = _self.LocalPointToRefer(_from);
        Vector2 pivot = _selfAnchor.GetTextAnchorPivot();
        pivot = _self.rectTransform.pivot - pivot;
        _selfOffsetPos = pivot * _self.rectTransform.sizeDelta + _selfOffsetPos;

        pivot = _fromAnchor.GetTextAnchorPivot();
        pivot = pivot - _from.rectTransform.pivot;
        _fromOffsetPos = pivot * _from.rectTransform.sizeDelta + _fromOffsetPos;

        _self.rectTransform.anchoredPosition = pos + _selfOffsetPos + _fromOffsetPos;
    }
    #endregion

    #region WorldReferToUI 世界物体相对于指定UI控件位置坐标
    /// <summary>
    /// 世界物体相对于指定UI控件位置坐标
    /// </summary>
    /// <param name="_worldGo">世界物体</param>
    /// <param name="_worldCamera">世界摄像机</param>
    /// <param name="_graphic">UI控件</param>
    /// <returns>UI坐标</returns>
    public static Vector2 WorldReferToUI(this Transform _worldGo, Camera _worldCamera, Graphic _graphic)
    {
        return _worldGo.WorldReferToUI(_worldCamera, _graphic.rectTransform, _graphic.canvas, _graphic.canvas.worldCamera);
    }

    /// <summary>
    /// 世界物体相对于指定UI控件位置坐标
    /// </summary>
    /// <param name="_worldGo">世界物体</param>
    /// <param name="_worldCamera">世界摄像机</param>
    /// <param name="_uiRectTransform">UI控件</param>
    /// <param name="_uiCanvas">UI画布</param>
    /// <returns>UI坐标</returns>
    public static Vector2 WorldReferToUI(this Transform _worldGo, Camera _worldCamera, RectTransform _uiRectTransform, Canvas _uiCanvas)
    {
        return _worldGo.WorldReferToUI(_worldCamera,_uiRectTransform,_uiCanvas,_uiCanvas.worldCamera);
    }

    /// <summary>
    /// 世界物体相对于指定UI控件位置坐标
    /// </summary>
    /// <param name="_worldGo">世界物体</param>
    /// <param name="_worldCamera">世界摄像机</param>
    /// <param name="_uiRectTransform">UI控件</param>
    /// <param name="_uiCanvas">UI画布</param>
    /// <param name="_uiCamera">UI摄像机</param>
    /// <returns>UI坐标</returns>
    public static Vector2 WorldReferToUI(this Transform _worldGo, Camera _worldCamera, RectTransform _uiRectTransform, Canvas _uiCanvas,Camera _uiCamera)
    {
        return _worldGo.position.WorldReferToUI(_worldCamera, _uiRectTransform, _uiCanvas, _uiCamera);
    }

    /// <summary>
    /// 世界物体相对于指定UI控件位置坐标
    /// </summary>
    /// <param name="_worldPosition">世界物体</param>
    /// <param name="_worldCamera">世界摄像机</param>
    /// <param name="_graphic">UI控件</param>
    /// <returns>UI坐標</returns>
    public static Vector2 WorldReferToUI(this Vector3 _worldPosition, Camera _worldCamera, Graphic _graphic)
    {
        return _worldPosition.WorldReferToUI(_worldCamera, _graphic.rectTransform, _graphic.canvas, _graphic.canvas.worldCamera);
    }

    /// <summary>
    /// 世界物體相對于指定UI控件位置坐標
    /// </summary>
    /// <param name="_worldPosition">世界物體坐标</param>
    /// <param name="_worldCamera">世界攝像機</param>
    /// <param name="_uiRectTransform">UI控件</param>
    /// <param name="_uiCanvas">UI畫布</param>
    /// <param name="_uiCamera">UI攝像機</param>
    /// <returns>UI坐標</returns>
    public static Vector2 WorldReferToUI(this Vector3 _worldPosition, Camera _worldCamera, RectTransform _uiRectTransform, Canvas _uiCanvas, Camera _uiCamera)
    {
        Vector2 point = RectTransformUtility.WorldToScreenPoint(_worldCamera, _worldPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _uiRectTransform.transform.parent as RectTransform, point, _uiCamera, out point);
        return point;
    }
    #endregion
}
