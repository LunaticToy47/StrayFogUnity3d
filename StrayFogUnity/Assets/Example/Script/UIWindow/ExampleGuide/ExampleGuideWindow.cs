using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ExampleGuideWindow
/// </summary>
[AddComponentMenu("StrayFog/Example/UIWindow/ExampleGuideWindow")]
public class ExampleGuideWindow : AbsUIGuideWindowView
{
    /// <summary>
    /// 材质文件
    /// </summary>
    protected override enAssetDiskMapingFile materialFile { get { return enAssetDiskMapingFile.f_GuideMaskShader_mat; } }

    /// <summary>
    /// 材质文件夹
    /// </summary>
    protected override enAssetDiskMapingFolder materialFolder { get { return enAssetDiskMapingFolder.Assets_Game_AssetBundles_Materials; } }

    /// <summary>
    /// 引导提示队列
    /// </summary>
    Queue<UIGuidePrompt> mUIGuidePromptQueue = new Queue<UIGuidePrompt>();
    /// <summary>
    /// 运行中的提示
    /// </summary>
    List<UIGuidePrompt> mRunningPrompt = new List<UIGuidePrompt>();

    /// <summary>
    /// 引导提示UI
    /// </summary>
    UIGuidePrompt mUIGuidePrompt;
    /// <summary>
    /// OnAfterAwake
    /// </summary>
    protected override void OnAfterAwake()
    {
        //mUIGuidePrompt = transform.Find("ImgFramePrompt").gameObject.AddComponent<UIGuidePrompt>();
        mUIGuidePrompt = transform.Find("Panel/ImgFramePrompt").gameObject.AddComponent<UIGuidePrompt>();
        mUIGuidePrompt.gameObject.SetActive(false);
        base.OnAfterAwake();
    }

    /// <summary>
    /// 添加GraphicMask遮罩
    /// </summary>
    /// <param name="_graphicMask">遮罩</param>
    protected override void OnAddGraphicMask(AbsUIGuideGraphic _graphicMask)
    {
        UIGuidePrompt prompt = null;
        if (mUIGuidePromptQueue.Count > 0)
        {
            prompt = mUIGuidePromptQueue.Dequeue();
        }
        else
        {
            prompt = Instantiate(mUIGuidePrompt);
            prompt.transform.SetParent(mUIGuidePrompt.transform.parent, false);
        }
        prompt.gameObject.SetActive(true);
        prompt.ApplyGraphic(_graphicMask);
        mRunningPrompt.Add(prompt);
        base.OnAddGraphicMask(_graphicMask);
    }

    /// <summary>
    /// 移除GraphicMask遮罩
    /// </summary>
    /// <param name="_graphicMask">遮罩</param>
    protected override void OnRemoveGraphicMask(AbsUIGuideGraphic _graphicMask)
    {
        foreach (UIGuidePrompt p in mRunningPrompt)
        {
            p.IsGraphic(_graphicMask);
        }
        base.OnRemoveGraphicMask(_graphicMask);
    }
}