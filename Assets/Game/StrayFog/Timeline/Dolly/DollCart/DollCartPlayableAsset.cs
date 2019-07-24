using Cinemachine;
using System;
using UnityEngine;
using UnityEngine.Playables;

namespace StrayFog.Timeline.Dolly
{
    /// <summary>
    /// DollCart跟踪
    /// </summary>
    [Serializable]
    public class DollCartPlayableAsset : ArgumentPlayableAsset
    {
        /// <summary>
        /// 轨道对象
        /// </summary>
        public ExposedReference<CinemachineDollyCart> dollyCart;
        /// <summary>
        /// 轨道起始百分比
        /// </summary>
        [Range(0,100)]
        public byte dollyStartPercent = 0;
        /// <summary>
        /// 轨道结束百分比
        /// </summary>
        [Range(0, 100)]
        public byte dollyEndPercent = 100;

        protected override void OnBeforeCreateArgumentPlayable(PlayableGraph graph, GameObject owner)
        {
            if (dollyStartPercent > dollyEndPercent)
            {
                dollyEndPercent = dollyStartPercent;
            }
            base.OnBeforeCreateArgumentPlayable(graph, owner);
        }

        protected override Playable OnCreateArgumentPlayable(PlayableGraph graph, GameObject owner)
        {
            ScriptPlayable<DollCartPlayableBehaviour> playable = ScriptPlayable<DollCartPlayableBehaviour>.Create(graph);
            DollCartPlayableBehaviour behaviour = playable.GetBehaviour();
            behaviour.dollyCart = dollyCart.Resolve(graph.GetResolver());
            behaviour.dollyStartPercent = dollyStartPercent;
            behaviour.dollyEndPercent = dollyEndPercent;
            return playable;
        }
    }
}
