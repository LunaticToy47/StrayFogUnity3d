using Cinemachine;
using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace StrayFog.Timeline.DollCart
{
    /// <summary>
    /// DollCart跟踪
    /// </summary>
    [Serializable]
    public class DollCartPlayableAsset : PlayableAsset
    {
        /// <summary>
        /// 轨道对象
        /// </summary>
        public ExposedReference<CinemachineDollyCart> dollyCart;
        /// <summary>
        /// 轨道起始百分比
        /// </summary>
        [Range(0, 100)]
        public byte dollyStartPercent = 0;
        /// <summary>
        /// 轨道结束百分比
        /// </summary>
        [Range(0, 100)]
        public byte dollyEndPercent = 100;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            if (dollyStartPercent > dollyEndPercent)
            {
                dollyEndPercent = dollyStartPercent;
            }
            ScriptPlayable<DollCartPlayableBehaviour> playable = ScriptPlayable<DollCartPlayableBehaviour>.Null;
            ScriptPlayable<DollCartPlayableBehaviour> templete = ScriptPlayable<DollCartPlayableBehaviour>.Null;
            for (int i = 0; i < graph.GetRootPlayableCount(); i++)
            {
                if (graph.GetRootPlayable(i).GetPlayableType().Equals(typeof(DollCartPlayableBehaviour)))
                {
                    templete = (ScriptPlayable<DollCartPlayableBehaviour>)graph.GetRootPlayable(i);
                }
            }
            if (!templete.Equals(playable))
            {
                playable = ScriptPlayable<DollCartPlayableBehaviour>.Create(graph, templete.GetBehaviour());
                DollCartPlayableBehaviour behaviour = playable.GetBehaviour();
                PlayableDirector director = owner.GetComponent<PlayableDirector>();
                TimelineAsset timeline = (TimelineAsset)director.playableAsset;
                behaviour.dollyCart = dollyCart.Resolve(graph.GetResolver());
                behaviour.director = director;
                behaviour.timeline = timeline;
                behaviour.playableAsset = this;
                behaviour.dollyStartPercent = dollyStartPercent;
                behaviour.dollyEndPercent = dollyEndPercent;
            }
            return playable;
        }
    }
}