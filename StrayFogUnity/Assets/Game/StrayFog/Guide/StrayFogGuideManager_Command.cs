using System.Collections.Generic;
/// <summary>
/// 引导管理器_命令集
/// </summary>
public partial class StrayFogGuideManager
{
    /// <summary>
    /// 触发命令缓存
    /// Key:触发类别
    /// Value:命令集
    /// </summary>
    Dictionary<int, Queue<AbsGuideCommand>> mCacheGuideTriggerCommandMaping = new Dictionary<int, Queue<AbsGuideCommand>>();

    #region OnCreateGuideCommand 创建引导命令
    /// <summary>
    /// 创建引导命令
    /// </summary>
    /// <param name="_config">配置</param>
    /// <returns>命令</returns>
    AbsGuideCommand OnCreateGuideCommand(XLS_Config_Table_UserGuideConfig _config)
    {
        AbsGuideCommand result = null;
        if (!mCacheGuideTriggerCommandMaping.ContainsKey(_config.guideType))
        {
            mCacheGuideTriggerCommandMaping.Add(_config.guideType, new Queue<AbsGuideCommand>());
        }
        if (mCacheGuideTriggerCommandMaping[_config.guideType].Count > 0)
        {
            result = mCacheGuideTriggerCommandMaping[_config.guideType].Dequeue();
        }
        else
        {
            result = Cmd_UserGuideConfig_GuideTypeMaping[_config.guideType]();
            result.OnAfterRecycle += Result_OnAfterRecycle;
            result.OnFinishGuide += Result_OnFinishGuide;
        }
        result.ResolveConfig(_config, 
            (id) => { return mGuideReferObjectMaping.ContainsKey(id) ? mGuideReferObjectMaping[id] : default; },
            (id) => { return mGuideStyleMaping.ContainsKey(id) ? mGuideStyleMaping[id] : default; }       
            );
        return result;
    }

    /// <summary>
    /// 完成引导
    /// </summary>
    /// <param name="_cmd">指令</param>
    void Result_OnFinishGuide(IGuideCommand _cmd)
    {        
        AbsGuideCommand cmd = (AbsGuideCommand)_cmd;
        mWaitGuideCommandMaping.Remove(cmd.guideConfig.id);
        mTriggerGuideCommand = null;
        OnCheckGuideForWindow();
        cmd.Recycle();
        if (mTriggerGuideCommand != null)
        {//如果有下一个引导，则对引导窗口的显示进行调整

        }
        else
        {
            _cmd.guideWindow.CloseWindow();
        }
    }

    /// <summary>
    /// 回收命令
    /// </summary>
    /// <param name="_recycle">命令</param>
    void Result_OnAfterRecycle(IRecycle _recycle)
    {
        AbsGuideCommand cmd = (AbsGuideCommand)_recycle;
        mCacheGuideTriggerCommandMaping[cmd.guideConfig.guideType].Enqueue(cmd);
    }
    #endregion
}
