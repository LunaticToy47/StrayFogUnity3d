using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 引导提示【每个项目不同】
/// </summary>
[AddComponentMenu("StrayFog/Game/Guide/UIGuidePrompt")]
public class UIGuidePrompt : AbsUIBehaviour
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
        mImgArrow = transform.GetChild(0).GetComponent<Image>();
        mImgDescBg = transform.GetChild(1).GetComponent<Image>();
        mTxtGuideContent = mImgDescBg.transform.GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            SetArrowEdge(mImgArrow.rectTransform, TextAnchor.MiddleLeft, mImgFramePrompt.rectTransform.rect);
            SetDescEdge(mImgDescBg.rectTransform, TextAnchor.MiddleLeft, Vector2.right * 300, mImgFramePrompt.rectTransform.rect);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            SetArrowEdge(mImgArrow.rectTransform, TextAnchor.MiddleRight, mImgFramePrompt.rectTransform.rect);
            SetDescEdge(mImgDescBg.rectTransform, TextAnchor.MiddleRight, Vector2.up * 100, mImgFramePrompt.rectTransform.rect);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            SetArrowEdge(mImgArrow.rectTransform, TextAnchor.UpperCenter, mImgFramePrompt.rectTransform.rect);
            SetDescEdge(mImgDescBg.rectTransform, TextAnchor.UpperCenter, Vector2.right * 300, mImgFramePrompt.rectTransform.rect);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            SetArrowEdge(mImgArrow.rectTransform, TextAnchor.LowerCenter, mImgFramePrompt.rectTransform.rect);
            SetDescEdge(mImgDescBg.rectTransform, TextAnchor.LowerCenter, Vector2.up * 100, mImgFramePrompt.rectTransform.rect);
        }
    }

    /// <summary>
    /// 设置箭头显示位置
    /// </summary>
    /// <param name="_rectTransform">RectTransform</param>
    /// <param name="_anchor">锚点</param>
    /// <param name="_parentRect">父矩形</param>
    void SetArrowEdge(RectTransform _rectTransform, TextAnchor _anchor,Rect _parentRect)
    {
        switch (_anchor)
        {
            case TextAnchor.MiddleLeft:
                _rectTransform.localEulerAngles = Vector3.zero;
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, _rectTransform.rect.width);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, _rectTransform.rect.height);
                _rectTransform.anchoredPosition = Vector2.down * _parentRect.height * 0.5f;
                break;
            case TextAnchor.MiddleRight:
                _rectTransform.localEulerAngles = Vector3.forward * 180f;
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, _rectTransform.rect.width);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, _rectTransform.rect.height);
                _rectTransform.anchoredPosition = Vector2.up * _parentRect.height * 0.5f;
                break;
            case TextAnchor.UpperCenter:
                _rectTransform.localEulerAngles = Vector3.forward * -90f;
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, _rectTransform.rect.width);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, _rectTransform.rect.height);
                _rectTransform.anchoredPosition = Vector2.right * _parentRect.width * 0.5f;
                break;
            case TextAnchor.LowerCenter:
                _rectTransform.localEulerAngles = Vector3.forward * 90f;
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, _rectTransform.rect.width);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, _rectTransform.rect.height);
                _rectTransform.anchoredPosition = Vector2.left * _parentRect.width * 0.5f;
                break;
        }
    }

    /// <summary>
    /// 设置描述显示位置
    /// </summary>
    /// <param name="_rectTransform">RectTransform</param>
    /// <param name="_anchor">锚点</param>
    /// <param name="_offset">偏移</param>
    /// <param name="_parentRect">父节点矩形</param>
    void SetDescEdge(RectTransform _rectTransform, TextAnchor _anchor, Vector2 _offset , Rect _parentRect)
    {       
        switch (_anchor)
        {
            case TextAnchor.MiddleLeft:
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, _rectTransform.rect.width);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, _rectTransform.rect.height);
                _rectTransform.anchoredPosition = Vector2.up * _parentRect.height * 0.5f;
                break;
            case TextAnchor.MiddleRight:
                _rectTransform.pivot = new Vector2(0, 0.5f);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, _rectTransform.rect.width);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, _rectTransform.rect.height);
                _rectTransform.anchoredPosition = Vector2.up * _parentRect.height;
                break;
            case TextAnchor.UpperCenter:
                _rectTransform.pivot = new Vector2(1f, 0.5f);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, _rectTransform.rect.width);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, _rectTransform.rect.height);
                _rectTransform.anchoredPosition = Vector2.right * _parentRect.width;
                break;
            case TextAnchor.LowerCenter:
                _rectTransform.pivot = new Vector2(0f, 0.5f);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, _rectTransform.rect.width);
                _rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, _rectTransform.rect.height);
                _rectTransform.anchoredPosition = Vector2.left * _parentRect.width;
                break;
        }
    }
}
