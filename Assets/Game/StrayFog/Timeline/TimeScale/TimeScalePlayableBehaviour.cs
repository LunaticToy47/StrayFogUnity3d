using System;
using UnityEngine;
using UnityEngine.Playables;

namespace StrayFog.Timeline
{
    /// <summary>
    /// TimeScalePlayableBehaviour
    /// </summary>
    public class TimeScalePlayableBehaviour : ArgumentPlayableBehaviour
    {
        /// <summary>
        /// TimeScalePlayableAsset
        /// </summary>
        TimeScalePlayableAsset mTimeScalePlayableAsset;
        /// <summary>
        /// 是否禁止修改TimeScale
        /// </summary>
        bool mIsForbidModifyTimeScale = false;
        public override void OnGraphStart(Playable playable)
        {
            mTimeScalePlayableAsset = (TimeScalePlayableAsset)playableAsset;
            if (Application.isPlaying)
            {
                StrayFogGamePools.eventHandlerManager.AddListener((int)enStrayFogEvent.IsForbidModifyTimeScale, OnIsForbidModifyTimeScale);
            }
            base.OnGraphStart(playable);
        }

        /// <summary>
        /// 是否禁止修改TimeScale
        /// </summary>
        /// <param name="_args">参数</param>
        void OnIsForbidModifyTimeScale(StrayFogEventHandlerArgs _args)
        {
            mIsForbidModifyTimeScale = _args.GetValue<bool>();
        }

        public override void OnGraphStop(Playable playable)
        {
            OnRestoreTimeScale();
            base.OnGraphStop(playable);
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            OnRestoreTimeScale();
            base.OnBehaviourPause(playable, info);
        }


        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            OnSetTimeScale(playable, info, playerData);
            base.ProcessFrame(playable, info, playerData);
        }

        /// <summary>
        /// 设置TimeScale
        /// </summary>
        /// <param name="playable">Playable</param>
        /// <param name="info">FrameData</param>
        /// <param name="playerData">playerData</param>
        void OnSetTimeScale(Playable playable, FrameData info, object playerData)
        {
            if (!mIsForbidModifyTimeScale)
            {
                float lerpTime = playableAsset.timelineClip.GetTimeClamp01(playableAsset.director.time);
                Time.timeScale = mTimeScalePlayableAsset.timeScaleArgument.timeScaleCurve.Evaluate(lerpTime);
            }
        }

        /// <summary>
        /// 恢复TimeScale
        /// </summary>
        void OnRestoreTimeScale()
        {
            Time.timeScale = 1;
        }
    }
}
