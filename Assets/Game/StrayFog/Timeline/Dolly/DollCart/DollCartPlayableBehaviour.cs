using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

namespace StrayFog.Timeline.Dolly
{
    /// <summary>
    /// DollCart跟踪
    /// </summary>
    public class DollCartPlayableBehaviour : ArgumentPlayableBehaviour
    {
        /// <summary>
        /// 轨道
        /// </summary>
        public CinemachineDollyCart dollyCart { get; set; }

        /// <summary>
        /// DollCartPlayableAsset
        /// </summary>
        DollCartPlayableAsset mDollCartPlayableAsset;

        public override void OnGraphStart(Playable playable)
        {
            dollyCart.m_Position = dollyCart.m_Speed = 0;
            mDollCartPlayableAsset = (DollCartPlayableAsset)playableAsset;
            base.OnGraphStart(playable);
        }

        public override void OnGraphStop(Playable playable)
        {
            dollyCart.m_Position = dollyCart.m_Speed = 0;
            base.OnGraphStop(playable);
        }

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            OnSetCartPosition(playable, info);
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            base.OnBehaviourPause(playable, info);
            OnSetCartPosition(playable, info);
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            base.ProcessFrame(playable, info, playerData);
            OnSetCartPosition(playable, info);
        }

        /// <summary>
        /// SetCartPosition
        /// </summary>
        /// <param name="playable">Playable</param>
        /// <param name="info">FrameData</param>
        void OnSetCartPosition(Playable playable, FrameData info)
        {
            if (director != null && dollyCart != null)
            {
                double tempTime = director.time - timelineClip.start;
                double tempDeltaTime = tempTime / timelineClip.duration;
                float lerpTime = Mathf.Clamp01((float)tempDeltaTime);
                float sp = dollyCart.m_Path.MaxUnit(dollyCart.m_PositionUnits) * mDollCartPlayableAsset.dollyStartPercent;
                float ep = dollyCart.m_Path.MaxUnit(dollyCart.m_PositionUnits) * mDollCartPlayableAsset.dollyEndPercent;
                double pos = Mathf.Lerp(sp, ep, lerpTime);
                dollyCart.SendMessage("SetCartPosition", pos);
            }
        }
    }
}
