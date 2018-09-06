using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// GuideWindow
/// </summary>
public class GuideWindow : AbsUIWindowView
{
    /// <summary>
    /// UI图形遮罩
    /// </summary>
    UIGraphicMaskShader mUIGraphicMask;
    /// <summary>
    /// 默认背景颜色
    /// </summary>
    readonly Color mDefaultColor = Color.black * 0.5f;
    /// <summary>
    /// 是否设置材质
    /// </summary>
    bool mIsSetMaterial = false;
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        mIsSetMaterial = false;
        mUIGraphicMask = gameObject.AddComponent<UIGraphicMaskShader>();
        mUIGraphicMask.color = mDefaultColor;
        LoadMaterial((args) => { });
    }

    /// <summary>
    /// 加载材质
    /// </summary>
    /// <param name="_onCallback">回调</param>
    /// <param name="_guideWidgets">引导控件组</param>
    void LoadMaterial(Action<UIGuideTrigger[]> _onCallback, params UIGuideTrigger[] _guideWidgets)
    {
        if (!mIsSetMaterial)
        {
            StrayFogRunningUtility.SingleMonoBehaviour<StrayFogAssetBundleManager>().LoadAssetInMemory(enAssetDiskMapingFile.f_GuideMaskShader_mat,
            enAssetDiskMapingFolder.Assets_Game_AssetBundles_Materials,
            (result) =>
            {
                mUIGraphicMask.material = result.Instantiate<Material>();
                mIsSetMaterial = true;
                Action<UIGuideTrigger[]> call = (Action<UIGuideTrigger[]>)result.extraParameter[0];
                UIGuideTrigger[] ws = (UIGuideTrigger[])result.extraParameter[1];
                if (call != null)
                {
                    call.Invoke(ws);
                }
            }, _onCallback, _guideWidgets);
        }
        else
        {
            if (_onCallback != null)
            {
                _onCallback.Invoke(_guideWidgets);
            }
        }
    }

    /// <summary>
    /// 切换背景显示
    /// </summary>
    /// <param name="_isDisplay">是否显示背景</param>
    public void ToggleBackgroundDisplay(bool _isDisplay)
    {
        mUIGraphicMask.color = _isDisplay ? mDefaultColor : Color.clear;
    }

    /// <summary>
    /// 添加引导项
    /// </summary>
    /// <param name="_guideWidgets">引导控件组</param>
    public void AddTrigger(params UIGuideTrigger[] _guideWidgets)
    {
        LoadMaterial((args) =>
        {
            if (args != null && args.Length > 0)
            {
                Graphic[] gs = new Graphic[args.Length];
                for (int i = 0; i < args.Length; i++)
                {
                    gs[i] = args[i].maskGraphic;
                }
                mUIGraphicMask.AddGraphicMask(gs);
            }
        }, _guideWidgets);
    }
    /// <summary>
    /// 移除引导项
    /// </summary>
    /// <param name="_guideWidget">引导控件组</param>
    public void RemoveTrigger(params UIGuideTrigger[] _guideWidgets)
    {
        if (_guideWidgets != null && _guideWidgets.Length > 0)
        {
            Graphic[] gs = new Graphic[_guideWidgets.Length];
            for (int i = 0; i < _guideWidgets.Length; i++)
            {
                gs[i] = _guideWidgets[i].maskGraphic;
            }
            mUIGraphicMask.RemoveGraphicMask(gs);
        }
    }
    /// <summary>
    /// 清除引导项
    /// </summary>
    public void ClearTrigger()
    {
        mUIGraphicMask.ClearGraphicMask();
    }
}