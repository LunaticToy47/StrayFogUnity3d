using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 绘制遮罩
/// </summary>
public abstract partial class AbsUIGraphicMask : MaskableGraphic, ICanvasRaycastFilter
{
    /// <summary>
    /// 遮罩事件触发分类
    /// </summary>
    [AliasTooltip("遮罩事件触发分类")]
    public enTriggerEventClassiy triggerEventClassify = enTriggerEventClassiy.MaskEnable;
    /// <summary>
    /// 遮罩绘制分类
    /// </summary>
    [AliasTooltip("遮罩绘制分类")]
    public enGraphicMaskClassify graphicClassify = enGraphicMaskClassify.ExceptMask;
    /// <summary>
    /// 绘制精灵填充分类
    /// </summary>
    [AliasTooltip("绘制精灵填充分类")]
    public enGraphicSpriteFillClassify graphicSpriteFillClassify = enGraphicSpriteFillClassify.SceneRatioFill;
    /// <summary>
    /// 精灵图
    /// </summary>
    [AliasTooltip("精灵图")]
    public Sprite sprite;

    #region 这个属性必须重写返回当前的Sprite
    /// <summary>
    /// Image's texture comes from the UnityEngine.Image.
    /// </summary>
    public override Texture mainTexture
    {
        get
        {
            return sprite == null ? s_WhiteTexture : sprite.texture;
        }
    }
    #endregion

    #region enTriggerEventClassiy 事件触发分类
    /// <summary>
    /// 事件触发分类
    /// </summary>
    public enum enTriggerEventClassiy
    {
        /// <summary>
        /// 禁用事件
        /// </summary>
        [AliasTooltip("禁用事件")]
        DisableAll,
        /// <summary>
        /// 仅禁用遮罩事件
        /// </summary>
        [AliasTooltip("仅禁用遮罩事件")]
        MaskDisable,
        /// <summary>
        /// 仅开启遮罩事件
        /// </summary>
        [AliasTooltip("仅开启遮罩事件")]
        MaskEnable,
        /// <summary>
        /// 开启事件
        /// </summary>
        [AliasTooltip("开启事件")]
        OpenAll,
    }
    #endregion

    #region enGraphicMaskClassify 绘制遮罩分类
    /// <summary>
    /// 绘制遮罩分类
    /// </summary>
    public enum enGraphicMaskClassify
    {
        /// <summary>
        /// 全屏填充
        /// </summary>
        [AliasTooltip("全屏填充")]
        Scene,
        /// <summary>
        /// 仅填充遮罩
        /// </summary>
        [AliasTooltip("仅填充遮罩")]
        Mask,
        /// <summary>
        /// 除遮罩之外都填充
        /// </summary>
        [AliasTooltip("除遮罩之外都填充")]
        ExceptMask,
    }
    #endregion

    #region enGraphicSpriteFillClassify 绘制精灵填充分类
    /// <summary>
    /// 绘制精灵填充分类
    /// </summary>
    public enum enGraphicSpriteFillClassify
    {
        /// <summary>
        /// 按所占屏幕比例填充
        /// </summary>
        [AliasTooltip("按所占屏幕比例填充")]
        SceneRatioFill,
        /// <summary>
        /// 遮罩单独填充
        /// </summary>
        [AliasTooltip("遮罩单独填充")]
        MaskAloneFill,
    }
    #endregion

    #region IsRaycastLocationValid 是否通过Raycast验证
    /// <summary>
    /// 是否通过Raycast验证
    /// </summary>
    /// <param name="_screenPoint">屏幕坐标</param>
    /// <param name="_eventCamera">检测相机</param>
    /// <returns>True:检测到有效目标【事件停止传递】,False:未检测到有效目标【事件继续传递】</returns>
    public bool IsRaycastLocationValid(Vector2 _screenPoint, Camera _eventCamera)
    {
        bool isStopEvent = false;
        switch (triggerEventClassify)
        {
            case enTriggerEventClassiy.DisableAll:
                isStopEvent = true;
                break;
            case enTriggerEventClassiy.MaskDisable:
                isStopEvent = OnIsPointInAnyMask(_screenPoint, _eventCamera);
                break;
            case enTriggerEventClassiy.MaskEnable:
                isStopEvent = !OnIsPointInAnyMask(_screenPoint, _eventCamera);
                break;
            case enTriggerEventClassiy.OpenAll:
                isStopEvent = false;
                break;
        }
        return isStopEvent;
    }
    #endregion

    #region OnIsPointInAnyMask Point是否在任意Mask上
    /// <summary>
    /// Point是否在任意Mask上
    /// </summary>
    /// <param name="_screenPoint">屏幕坐标</param>
    /// <param name="_eventCamera">检测相机</param>
    /// <returns>True:是,False:否</returns>
    bool OnIsPointInAnyMask(Vector2 _screenPoint, Camera _eventCamera)
    {
        bool isPointInAnyMask = false;
        if (mGraphicMasks != null && mGraphicMasks.Count > 0)
        {
            foreach (Graphic g in mGraphicMasks)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(g.rectTransform, _screenPoint, _eventCamera))
                {
                    isPointInAnyMask = true;
                    break;
                }
            }
        }
        return isPointInAnyMask;
    }
    #endregion

    #region graphicMasks 当前GraphicMask组
    /// <summary>
    /// 当前GraphicMask组
    /// </summary>
    protected List<Graphic> graphicMasks { get { return mGraphicMasks; } }
    #endregion

    #region AddGraphicMask 添加遮罩Graphic
    /// <summary>
    /// Graphic组
    /// </summary>
    List<Graphic> mGraphicMasks = new List<Graphic>();
    /// <summary>
    /// 添加Graphic遮罩
    /// </summary>
    /// <param name="_masks">遮罩组</param>
    public void AddGraphicMask(params Graphic[] _masks)
    {
        if (_masks != null && _masks.Length > 0)
        {
            bool isChange = false;
            foreach (Graphic g in _masks)
            {
                if (!mGraphicMasks.Contains(g))
                {
                    isChange |= true;
                    mGraphicMasks.Add(g);
                    OnRegisterDirty(g);
                }
            }
            if (isChange)
            {
                OnDirtyAction();
            }
        }
    }
    #endregion

    #region RemoveGraphicMask 移除Graphic遮罩
    /// <summary>
    /// 移除Graphic遮罩
    /// </summary>
    /// <param name="_mask">遮罩组</param>
    public void RemoveGraphicMask(params Graphic[] _masks)
    {
        if (_masks != null && _masks.Length > 0)
        {
            bool isChange = false;
            foreach (Graphic g in _masks)
            {
                isChange = mGraphicMasks.Contains(g);
                mGraphicMasks.Remove(g);
                OnUnRegisterDirty(g);
            }
            if (isChange)
            {
                OnDirtyAction();
            }
        }
    }
    #endregion

    #region ClearGraphicMask 清除Graphic遮罩
    /// <summary>
    /// 清除Graphic遮罩
    /// </summary>
    public void ClearGraphicMask()
    {
        if (mGraphicMasks != null && mGraphicMasks.Count > 0)
        {
            foreach (Graphic g in mGraphicMasks)
            {
                OnUnRegisterDirty(g);
            }
            mGraphicMasks.Clear();
            OnDirtyAction();
        }
    }
    #endregion

    #region OnRegisterDirty 注册Dirty事件
    /// <summary>
    /// 注册Dirty事件
    /// </summary>
    /// <param name="_graphic">绘制</param>
    void OnRegisterDirty(Graphic _graphic)
    {
        _graphic.RegisterDirtyLayoutCallback(OnDirtyAction);
        _graphic.RegisterDirtyMaterialCallback(OnDirtyAction);
        _graphic.RegisterDirtyVerticesCallback(OnDirtyAction);
    }
    #endregion

    #region OnUnRegisterDirty 注销Dirty事件
    /// <summary>
    /// 注销Dirty事件
    /// </summary>
    /// <param name="_graphic">绘制</param>
    void OnUnRegisterDirty(Graphic _graphic)
    {
        _graphic.UnregisterDirtyLayoutCallback(OnDirtyAction);
        _graphic.UnregisterDirtyMaterialCallback(OnDirtyAction);
        _graphic.UnregisterDirtyVerticesCallback(OnDirtyAction);
    }
    #endregion

    #region Dirty动作
    /// <summary>
    /// Dirty动作
    /// </summary>
    void OnDirtyAction()
    {
        SetAllDirty();
    }
    #endregion

    #region OnIsChangeGraphicMaskVariable 绘制遮罩变量是否有变更
    /// <summary>
    /// 最后绘制的graphic遮罩
    /// </summary>
    Dictionary<int, GraphicVariable> mLastDrawGraphicMaskMaping = new Dictionary<int, GraphicVariable>();
    /// <summary>
    /// 绘制遮罩变量是否有变更
    /// </summary>
    /// <param name="_masks">绘制遮罩</param>
    /// <returns>True:有变更,False:无变更</returns>
    bool OnIsChangeGraphicMaskVariable(List<Graphic> _masks)
    {
        bool isAnyMaskChange = mLastDrawGraphicMaskMaping.Count != _masks.Count;
        int gid = 0;
        if (!isAnyMaskChange)
        {
            //如果个数相同，则看是不是与最后保存的是同样的Graphic
            foreach (Graphic g in _masks)
            {
                gid = g.gameObject.GetInstanceID();
                isAnyMaskChange |= !mLastDrawGraphicMaskMaping.ContainsKey(gid);
                if (isAnyMaskChange)
                {
                    break;
                }
            }
        }

        if (!isAnyMaskChange)
        {
            //如果与保存的是同样的Graphic,则看每个Graphic的参数是否有不同
            foreach (Graphic g in _masks)
            {
                isAnyMaskChange |= mLastDrawGraphicMaskMaping[g.gameObject.GetInstanceID()].isDifferent(g);
                if (isAnyMaskChange)
                {
                    break;
                }
            }
        }
        else
        {
            mLastDrawGraphicMaskMaping.Clear();
            foreach (Graphic g in _masks)
            {
                mLastDrawGraphicMaskMaping.Add(g.gameObject.GetInstanceID(), new GraphicVariable(g));
            }
        }
        return isAnyMaskChange;
    }

    /// <summary>
    /// Graphic变量
    /// </summary>
    class GraphicVariable
    {
        /// <summary>
        /// anchoredPosition
        /// </summary>
        Vector2 mAnchoredPosition = Vector2.zero;
        /// <summary>
        /// anchoredPosition3D
        /// </summary>
        Vector3 mAnchoredPosition3D = Vector3.zero;
        /// <summary>
        /// anchorMin
        /// </summary>
        Vector2 mAnchorMin = Vector2.zero;
        /// <summary>
        /// anchorMax
        /// </summary>
        Vector2 mAnchorMax = Vector2.zero;
        /// <summary>
        /// offsetMin
        /// </summary>
        Vector2 mOffsetMin = Vector2.zero;
        /// <summary>
        /// offsetMax
        /// </summary>
        Vector2 mOffsetMax = Vector2.zero;
        /// <summary>
        /// pivot
        /// </summary>
        Vector2 mPivot = Vector2.zero;
        /// <summary>
        /// sizeDelta
        /// </summary>
        Vector2 mSizeDelta = Vector2.zero;

        /// <summary>
        /// localEulerAngles
        /// </summary>
        Vector3 mLocalEulerAngles = Vector3.zero;
        /// <summary>
        /// localScale
        /// </summary>
        Vector3 mLocalScale = Vector3.zero;

        /// <summary>
        /// Graphic变量
        /// </summary>
        /// <param name="_g">Graphic</param>
        public GraphicVariable(Graphic _g)
        {
            SetVariable(_g);
        }

        /// <summary>
        /// 设置变量
        /// </summary>
        /// <param name="_g">Graphic</param>
        void SetVariable(Graphic _g)
        {
            RectTransform rt = (RectTransform)_g.gameObject.transform;
            mAnchoredPosition = rt.anchoredPosition;
            mAnchoredPosition3D = rt.anchoredPosition3D;
            mAnchorMin = rt.anchorMin;
            mAnchorMax = rt.anchorMax;
            mOffsetMin = rt.offsetMin;
            mOffsetMax = rt.offsetMax;
            mPivot = rt.pivot;
            mSizeDelta = rt.sizeDelta;
            mLocalScale = rt.localScale;
            mLocalEulerAngles = rt.localEulerAngles;
        }

        /// <summary>
        /// 是否与指定Graphic不同
        /// </summary>
        /// <param name="_g">Graphic</param>
        /// <returns></returns>
        public bool isDifferent(Graphic _g)
        {
            RectTransform rt = (RectTransform)_g.gameObject.transform;
            bool isNot = mAnchoredPosition != rt.anchoredPosition ||
            mAnchoredPosition3D != rt.anchoredPosition3D ||
            mAnchorMin != rt.anchorMin ||
            mAnchorMax != rt.anchorMax ||
            mOffsetMin != rt.offsetMin ||
            mOffsetMax != rt.offsetMax ||
            mPivot != rt.pivot ||
            mSizeDelta != rt.sizeDelta ||
            mLocalScale != rt.localScale ||
            mLocalEulerAngles != rt.localEulerAngles;
            if (isNot)
            {
                SetVariable(_g);
            }
            return isNot;
        }
    }
    #endregion

    #region LateUpdate
    /// <summary>
    /// LateUpdate
    /// </summary>
    private void LateUpdate()
    {
        if (OnIsChangeGraphicMaskVariable(mGraphicMasks))
        {
            OnDirtyAction();
        }
    }
    #endregion
}