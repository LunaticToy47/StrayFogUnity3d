using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace StrayFog.Timeline.DollCart
{
    /// <summary>
    /// DollCart跟踪
    /// </summary>
    public class DollCartPlayableBehaviour : PlayableBehaviour
    {
        /// <summary>
        /// PlayableDirector
        /// </summary>
        public PlayableDirector director { get; set; }
        /// <summary>
        /// TimelineAsset
        /// </summary>
        public TimelineAsset timeline { get; set; }
        /// <summary>
        /// DollCartTrackAsset
        /// </summary>
        public DollCartTrackAsset trackAsset { get; set; }
        /// <summary>
        /// DollCartPlayableAsset
        /// </summary>
        public DollCartPlayableAsset playableAsset { get; set; }

        /// <summary>
        /// 轨道
        /// </summary>
        public CinemachineDollyCart dollyCart { get; set; }
        /// <summary>
        /// 轨道起始百分比
        /// </summary>
        public byte dollyStartPercent { get; set; }
        /// <summary>
        /// 轨道结束百分比
        /// </summary>
        public byte dollyEndPercent { get; set; }
        /// <summary>
        /// TimelineClip
        /// </summary>
        TimelineClip mTimelineClip = null;
        public override void OnGraphStart(Playable playable)
        {
            dollyCart.m_Position = dollyCart.m_Speed = 0;
            mTimelineClip = trackAsset.FindTimelineClip(playableAsset);
            base.OnGraphStart(playable);
        }

        public override void OnGraphStop(Playable playable)
        {
            dollyCart.m_Position = dollyCart.m_Speed = 0;
            base.OnGraphStop(playable);
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            base.ProcessFrame(playable, info, playerData);
            double tempTime = director.time - mTimelineClip.start;
            double tempDeltaTime = tempTime / mTimelineClip.duration;
            float lerpTime = Mathf.Clamp01((float)tempDeltaTime);
            float sp = dollyCart.m_Path.PathLength * dollyStartPercent * 0.01f;
            float ep = dollyCart.m_Path.PathLength * dollyEndPercent * 0.01f;
            double pos = Mathf.Lerp(sp, ep, lerpTime);
            dollyCart.SendMessage("SetCartPosition", pos);
        }
    }
}
