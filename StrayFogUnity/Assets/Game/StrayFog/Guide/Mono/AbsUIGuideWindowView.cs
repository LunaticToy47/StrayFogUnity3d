using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 引导窗口视图
/// </summary>
public abstract class AbsUIGuideWindowView : AbsUIWindowView
{
    /// <summary>
    /// 材质文件
    /// </summary>
    protected abstract enAssetDiskMapingFile materialFile { get; }
    /// <summary>
    /// 材质文件夹
    /// </summary>
    protected abstract enAssetDiskMapingFolder materialFolder { get; }
    
    /// <summary>
    /// Graphic遮罩映射
    /// </summary>
    Dictionary<int, Dictionary<int, AbsUIGuideGraphic>> mUIGuideGraphicMaping = new Dictionary<int, Dictionary<int, AbsUIGuideGraphic>>();

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
    /// OnRunAwake
    /// </summary>
    protected sealed override void OnRunAwake()
    {
        mIsSetMaterial = false;
        mUIGraphicMask = gameObject.AddComponent<UIGraphicMaskShader>();
        mUIGraphicMask.color = mDefaultColor;
        LoadMaterial((args) => { });
        OnAfterRunAwake();
    }
    /// <summary>
    /// OnAfterRunAwake
    /// </summary>
    protected virtual void OnAfterRunAwake() { }

    /// <summary>
    /// 加载材质
    /// </summary>
    /// <param name="_onCallback">回调</param>
    /// <param name="_guideWidgets">引导控件组</param>
    void LoadMaterial(Action<AbsUIGuideGraphic[]> _onCallback, params AbsUIGuideGraphic[] _guideWidgets)
    {
        if (!mIsSetMaterial)
        {
            StrayFogGamePools.assetBundleManager.LoadAssetInMemory(materialFile, materialFolder,
            (output) =>
            {
                output.Instantiate<Material>((result) =>
                {
                    mUIGraphicMask.material = (Material)result.asset;
                    mIsSetMaterial = true;
                    Action<AbsUIGuideGraphic[]> call = (Action<AbsUIGuideGraphic[]>)result.input.extraParameter[0];
                    AbsUIGuideGraphic[] ws = (AbsUIGuideGraphic[])result.input.extraParameter[1];
                    if (call != null)
                    {
                        call.Invoke(ws);
                    }
                });
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
    /// 添加Graphic遮罩
    /// </summary>
    /// <param name="_masks">遮罩Graphic组</param>
    public void AddGraphicMask(params AbsUIGuideGraphic[] _masks)
    {
        LoadMaterial((args) =>
        {
            if (_masks != null)
            {
                foreach (AbsUIGuideGraphic g in _masks)
                {
                    if (!mUIGuideGraphicMaping.ContainsKey(g.type))
                    {
                        mUIGuideGraphicMaping.Add(g.type, new Dictionary<int, AbsUIGuideGraphic>());
                    }
                    if (!mUIGuideGraphicMaping[g.type].ContainsKey(g.index))
                    {
                        mUIGuideGraphicMaping[g.type].Add(g.index, null);
                    }
                    mUIGuideGraphicMaping[g.type][g.index] = g;
                    mUIGraphicMask.AddGraphicMask(g);
                    OnAddGraphicMask(g);
                }
            }            
        }, _masks);
    }

    /// <summary>
    /// 添加GraphicMask遮罩
    /// </summary>
    /// <param name="_graphicMask">遮罩</param>
    protected virtual void OnAddGraphicMask(AbsUIGuideGraphic _graphicMask) { }

    /// <summary>
    /// 移除Graphic遮罩
    /// </summary>
    /// <param name="_masks">遮罩Graphic组</param>
    public void RemoveGraphicMask(params AbsUIGuideGraphic[] _masks)
    {
        if (_masks != null)
        {
            foreach (AbsUIGuideGraphic g in _masks)
            {
                if (mUIGuideGraphicMaping.ContainsKey(g.type) && mUIGuideGraphicMaping[g.type].ContainsKey(g.index))
                {
                    mUIGuideGraphicMaping[g.type].Remove(g.index);
                    OnRemoveGraphicMask(g);
                }                
            }
        }        
        mUIGraphicMask.RemoveGraphicMask(_masks);
    }

    /// <summary>
    /// 移除GraphicMask遮罩
    /// </summary>
    /// <param name="_graphicMask">遮罩</param>
    protected virtual void OnRemoveGraphicMask(AbsUIGuideGraphic _graphicMask) { }

    /// <summary>
    /// 获得引导Graphic遮罩
    /// </summary>
    /// <param name="_type">类别</param>
    /// <param name="_index">索引</param>
    /// <returns>引导Graphic遮罩</returns>
    public AbsUIGuideGraphic GetGraphicMask(int _type,int _index)
    {
        AbsUIGuideGraphic result = default;
        if (mUIGuideGraphicMaping.ContainsKey(_type) && mUIGuideGraphicMaping[_type].ContainsKey(_index))
        {
            result = mUIGuideGraphicMaping[_type][_index];
        }
        return result;
    }

    /// <summary>
    /// 清除引导项
    /// </summary>
    public void ClearTrigger()
    {
        mUIGuideGraphicMaping.Clear();
        if (mUIGraphicMask != null)
        {
            mUIGraphicMask.ClearGraphicMask();
        }
    }
}