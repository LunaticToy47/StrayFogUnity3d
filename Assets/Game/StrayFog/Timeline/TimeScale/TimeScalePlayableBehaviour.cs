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

        public override void OnGraphStart(Playable playable)
        {
            mTimeScalePlayableAsset = (TimeScalePlayableAsset)playableAsset;
            base.OnGraphStart(playable);
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
            float lerpTime = timelineClip.GetTimeClamp01(director.time);
            Time.timeScale = mTimeScalePlayableAsset.timeScaleArgument.timeScaleCurve.Evaluate(lerpTime);
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
