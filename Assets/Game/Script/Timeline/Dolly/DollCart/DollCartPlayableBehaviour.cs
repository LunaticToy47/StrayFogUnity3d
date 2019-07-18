/*
using Cinemachine;
using System.Collections;
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
        /// 轨道
        /// </summary>
        public CinemachineDollyCart dollyCart { get; set; }
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
        public DollCartPlayableAsset playable { get; set; }
        /// <summary>
        /// PathLengthPercent(0-100%)
        /// </summary>
        public byte dollyPathLengthPercent { get; set; }
        /// <summary>
        /// TimelineClip
        /// </summary>
        TimelineClip mTemilineClip = null;
        public override void OnGraphStart(Playable playable)
        {
            dollyCart.m_Position = dollyCart.m_Speed = 0;
            OnFindTimelineClip();
            base.OnGraphStart(playable);
        }

        public override void OnGraphStop(Playable playable)
        {
            dollyCart.m_Position = dollyCart.m_Speed = 0;
            base.OnGraphStop(playable);
        }

        /// <summary>
        /// 查询行为所属的Clip
        /// </summary>
        void OnFindTimelineClip()
        {
            IEnumerator outClips = trackAsset.GetClips().GetEnumerator();
            while (outClips.MoveNext())
            {
                TimelineClip clip = (TimelineClip)outClips.Current;
                DollCartPlayableAsset doll = (DollCartPlayableAsset)clip.asset;
                if (doll == playable)
                {
                    mTemilineClip = clip;
                    break;
                }
            }
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            base.ProcessFrame(playable, info, playerData);
            double tempTime = director.time - mTemilineClip.start;
            double tempDeltaTime = tempTime / mTemilineClip.duration;
            float lerpTime = Mathf.Clamp01((float)tempDeltaTime);
            double pos = Mathf.Lerp(0, dollyCart.m_Path.PathLength, lerpTime * dollyPathLengthPercent * 0.01f);
            dollyCart.SendMessage("SetCartPosition", pos);
        }
    }
}
*/
