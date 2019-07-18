/*
using UnityEngine.Timeline;
using UnityEngine;
using UnityEngine.Playables;

namespace StrayFog.Timeline.DollCart
{
    /// <summary>
    /// DollCart跟踪
    /// </summary>
    [TrackColor(0.8f, 0.8f, 0.8f)]
    [TrackClipType(typeof(DollCartPlayableAsset))]
    public class DollCartTrackAsset : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            ScriptPlayable<DollCartPlayableBehaviour> playable = ScriptPlayable<DollCartPlayableBehaviour>.Create(graph, inputCount);
            playable.GetBehaviour().trackAsset = this;
            return base.CreateTrackMixer(graph, go, inputCount);
        }
    }
}
*/