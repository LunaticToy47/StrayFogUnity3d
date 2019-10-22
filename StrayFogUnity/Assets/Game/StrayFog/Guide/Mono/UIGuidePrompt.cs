using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 引导提示【每个项目不同】
/// </summary>
[AddComponentMenu("StrayFog/Game/Guide/UIGuidePrompt")]
public class UIGuidePrompt : AbsMonoBehaviour
{
    /// <summary>
    /// 提示框
    /// </summary>
    Image mImgFramePrompt;
    /// <summary>
    /// 箭头
    /// </summary>
    Image mImgArrow;
    /// <summary>
    /// 说明背景
    /// </summary>
    Image mImgDescBg;
    /// <summary>
    /// 说明文字
    /// </summary>
    Text mTxtGuideContent;
    /// <summary>
    /// Awake
    /// </summary>
    protected override void Awake()
    {
        mImgFramePrompt = gameObject.GetComponent<Image>();
        mImgArrow = mImgFramePrompt.transform.GetChild(0).GetComponent<Image>();
        mImgDescBg = mImgArrow.transform.GetChild(0).GetComponent<Image>();
        mTxtGuideContent = mImgDescBg.transform.GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            SetArrowEdge(mImgArrow.rectTransform, TextAnchor.MiddleLeft);
            SetDescEdge(mImgDescBg.rectTransform, TextAnchor.MiddleLeft, 300);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            SetArrowEdge(mImgArrow.rectTransform, TextAnchor.MiddleRight);
            SetDescEdge(mImgDescBg.rectTransform, TextAnchor.MiddleRight, 300);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            SetArrowEdge(mImgArrow.rectTransform, TextAnchor.UpperCenter);
            SetDescEdge(mImgDescBg.rectTransform, TextAnchor.UpperCenter, 100);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            SetArrowEdge(mImgArrow.rectTransform, TextAnchor.LowerCenter);
            SetDescEdge(mImgDescBg.rectTransform, TextAnchor.LowerCenter, 100);
        }
    }

    /// <summary>
    /// 设置箭头显示位置
    /// </summary>
    /// <param name="_rectTransform">RectTransform</param>
    /// <param name="_anchor">锚点</param>
    void SetArrowEdge(RectTransform _rectTransform, TextAnchor _anchor)
    {
        _rectTransform.anchorMin = _rectTransform.anchorMax = _anchor.GetTextAnchorPivot();
        switch (_anchor)
        {
            case TextAnchor.MiddleLeft:                
                _rectTransform.localEulerAngles = Vector3.zero;
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.anchoredPosition = Vector2.zero;
                break;
            case TextAnchor.MiddleRight:
                _rectTransform.localEulerAngles = Vector3.forward * 180f;
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.anchoredPosition = Vector2.zero;
                break;
            case TextAnchor.UpperCenter:
                _rectTransform.localEulerAngles = Vector3.forward * -90f;
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.anchoredPosition = Vector2.zero;
                break;
            case TextAnchor.LowerCenter:
                _rectTransform.localEulerAngles = Vector3.forward * 90f;
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.anchoredPosition = Vector2.zero;
                break;
        }
    }

    /// <summary>
    /// 设置描述显示位置
    /// </summary>
    /// <param name="_rectTransform">RectTransform</param>
    /// <param name="_anchor">锚点</param>
    /// /// <param name="_width">宽度</param>
    void SetDescEdge(RectTransform _rectTransform, TextAnchor _anchor,int _width)
    {
        Vector2 size = _rectTransform.sizeDelta;
        size.x = _width;
        _rectTransform.sizeDelta = size;
        switch (_anchor)
        {
            case TextAnchor.MiddleLeft:
                _rectTransform.localEulerAngles = Vector3.zero;
                _rectTransform.anchorMin = _rectTransform.anchorMax = Text.GetTextAnchorPivot(_anchor);
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.anchoredPosition = Vector2.zero;
                break;
            case TextAnchor.MiddleRight:
                _rectTransform.localEulerAngles = Vector3.forward * 180f;
                _rectTransform.anchorMin = _rectTransform.anchorMax = Text.GetTextAnchorPivot(TextAnchor.MiddleLeft);
                _rectTransform.pivot = new Vector2(0f, 0.5f);
                _rectTransform.anchoredPosition = Vector2.zero;
                break;
            case TextAnchor.UpperCenter:
                _rectTransform.localEulerAngles = Vector3.forward * 90f;
                _rectTransform.anchorMin = _rectTransform.anchorMax = Text.GetTextAnchorPivot(TextAnchor.MiddleLeft);
                _rectTransform.pivot = new Vector2(0.5f, 0f);
                _rectTransform.anchoredPosition = Vector2.zero;
                break;
            case TextAnchor.LowerCenter:
                _rectTransform.localEulerAngles = Vector3.forward * -90f;
                _rectTransform.anchorMin = _rectTransform.anchorMax = Text.GetTextAnchorPivot(TextAnchor.MiddleLeft);
                _rectTransform.pivot = new Vector2(0.5f, 1f);
                _rectTransform.anchoredPosition = Vector2.zero;
                break;
        }
        _rectTransform.ForceRebuildLayoutImmediate();
    }
}