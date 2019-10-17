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
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            SetArrowEdge(RectTransform.Edge.Left);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            SetArrowEdge(RectTransform.Edge.Right);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            SetArrowEdge(RectTransform.Edge.Top);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SetArrowEdge(RectTransform.Edge.Bottom);
        }
    }

    /// <summary>
    /// 设置箭头显示位置
    /// </summary>
    /// <param name="_edge">位置</param>
    void SetArrowEdge(RectTransform.Edge _edge)
    {
        switch (_edge)
        {
            case RectTransform.Edge.Left:
                mImgArrow.rectTransform.SetInsetAndSizeFromParentEdge(_edge, 0, mImgArrow.rectTransform.rect.width);                
                break;
            case RectTransform.Edge.Right:
                //mImgArrow.rectTransform.SetInsetAndSizeFromParentEdge(_edge, -mImgArrow.rectTransform.rect.width, mImgArrow.rectTransform.rect.width);
                break;
            case RectTransform.Edge.Top:
                //mImgArrow.rectTransform.SetInsetAndSizeFromParentEdge(_edge, -mImgArrow.rectTransform.rect.width, mImgArrow.rectTransform.rect.width);
                break;
            case RectTransform.Edge.Bottom:
                //mImgArrow.rectTransform.SetInsetAndSizeFromParentEdge(_edge, -mImgArrow.rectTransform.rect.width, mImgArrow.rectTransform.rect.width);
                break;
        }        
        //mImgDescBg.rectTransform.SetInsetAndSizeFromParentEdge(_edge, -mImgArrow.rectTransform.rect.width, mImgDescBg.rectTransform.rect.width);
    }
}
