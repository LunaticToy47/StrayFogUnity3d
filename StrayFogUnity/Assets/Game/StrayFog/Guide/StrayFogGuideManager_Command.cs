using System;
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
    Dictionary<int, Queue<IGuideCommand>> mCacheGuideTriggerCommandMaping = new Dictionary<int, Queue<IGuideCommand>>();

    #region OnCreateGuideCommand 创建引导命令
    /// <summary>
    /// 创建引导命令
    /// </summary>
    /// <param name="_config">配置</param>
    /// <returns>命令</returns>
    IGuideCommand OnCreateGuideCommand(XLS_Config_Table_UserGuideConfig _config)
    {
        IGuideCommand result = null;
        if (!mCacheGuideTriggerCommandMaping.ContainsKey(_config.guideType))
        {
            mCacheGuideTriggerCommandMaping.Add(_config.guideType, new Queue<IGuideCommand>());
        }
        if (mCacheGuideTriggerCommandMaping[_config.guideType].Count > 0)
        {
            result = mCacheGuideTriggerCommandMaping[_config.guideType].Dequeue();
        }
        else
        {
            switch (_config.enGuideType)
            {
                case enUserGuideConfig_GuideType.Strong:
                    result = new UserGuideConfig_GuideType_Strong_Command();
                    result.OnAfterRecycle += Result_OnAfterRecycle;
                    break;
                case enUserGuideConfig_GuideType.Weakness:
                    result = new UserGuideConfig_GuideType_Weakness_Command();
                    result.OnAfterRecycle += Result_OnAfterRecycle;
                    break;
            }            
        }
        result.ResolveConfig(_config, (id) => { return mGuideReferObjectMaping.ContainsKey(id) ? mGuideReferObjectMaping[id] : default; });
        return result;
    }

    /// <summary>
    /// 回收命令
    /// </summary>
    /// <param name="_recycle">命令</param>
    void Result_OnAfterRecycle(IRecycle _recycle)
    {
        IGuideCommand cmd = (IGuideCommand)_recycle;
        mCacheGuideTriggerCommandMaping[cmd.guideType].Enqueue(cmd);
    }
    #endregion
}
