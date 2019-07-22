using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

namespace StrayFog.Timeline.DollCart
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
        /// 轨道起始百分比
        /// </summary>
        public byte dollyStartPercent { get; set; }
        /// <summary>
        /// 轨道结束百分比
        /// </summary>
        public byte dollyEndPercent { get; set; }
        public override void OnGraphStart(Playable playable)
        {
            dollyCart.m_Position = dollyCart.m_Speed = 0;
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
            double tempTime = director.time - timelineClip.start;
            double tempDeltaTime = tempTime / timelineClip.duration;
            float lerpTime = Mathf.Clamp01((float)tempDeltaTime);
            float sp = dollyCart.m_Path.PathLength * dollyStartPercent * 0.01f;
            float ep = dollyCart.m_Path.PathLength * dollyEndPercent * 0.01f;
            double pos = Mathf.Lerp(sp, ep, lerpTime);
            dollyCart.SendMessage("SetCartPosition", pos);
        }
    }
}
