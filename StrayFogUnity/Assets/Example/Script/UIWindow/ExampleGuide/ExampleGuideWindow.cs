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
    /// �����ļ�
    /// </summary>
    protected override enAssetDiskMapingFile materialFile { get { return enAssetDiskMapingFile.f_GuideMaskShader_mat; } }

    /// <summary>
    /// �����ļ���
    /// </summary>
    protected override enAssetDiskMapingFolder materialFolder { get { return enAssetDiskMapingFolder.Assets_Game_AssetBundles_Materials; } }

    /// <summary>
    /// ������ʾ����
    /// </summary>
    Queue<UIGuidePrompt> mUIGuidePromptQueue = new Queue<UIGuidePrompt>();
    /// <summary>
    /// �����е���ʾ
    /// </summary>
    List<UIGuidePrompt> mRunningPrompt = new List<UIGuidePrompt>();

    /// <summary>
    /// ������ʾUI
    /// </summary>
    UIGuidePrompt mUIGuidePrompt;
    /// <summary>
    /// OnAfterAwake
    /// </summary>
    protected override void OnAfterAwake()
    {
        GameObject go = gameObject.transform.Find("ImgFramePrompt").gameObject;        
        mUIGuidePrompt = go.GetComponent<UIGuidePrompt>();
        if (mUIGuidePrompt == null)
        {
            mUIGuidePrompt = go.AddDynamicComponent<UIGuidePrompt>();
        }        
        mUIGuidePrompt.gameObject.SetActive(false);
        base.OnAfterAwake();
    }

    /// <summary>
    /// ���GraphicMask����
    /// </summary>
    /// <param name="_graphicMask">����</param>
    protected override void OnAddGraphicMask(AbsUIGuideGraphic _graphicMask)
    {
        UIGuidePrompt prompt = null;
        if (mUIGuidePromptQueue.Count > 0)
        {
            prompt = mUIGuidePromptQueue.Dequeue();
        }
        else
        {
            GameObject go = GameObject.Instantiate(mUIGuidePrompt.gameObject);
            go.AddDynamicComponent<UIGuidePrompt>();
            prompt.gameObject.transform.SetParent(mUIGuidePrompt.gameObject.transform.parent, false);
        }
        prompt.gameObject.SetActive(true);
        prompt.ApplyGraphic(_graphicMask);
        mRunningPrompt.Add(prompt);
        base.OnAddGraphicMask(_graphicMask);
    }

    /// <summary>
    /// �Ƴ�GraphicMask����
    /// </summary>
    /// <param name="_graphicMask">����</param>
    protected override void OnRemoveGraphicMask(AbsUIGuideGraphic _graphicMask)
    {
        UIGuidePrompt run = null;
        foreach (UIGuidePrompt p in mRunningPrompt)
        {
            if (p.IsGraphic(_graphicMask))
            {
                run = p;  
                break;
            }
        }
        run.gameObject.SetActive(false);
        mRunningPrompt.Remove(run);
        mUIGuidePromptQueue.Enqueue(run);
        base.OnRemoveGraphicMask(_graphicMask);
    }
}