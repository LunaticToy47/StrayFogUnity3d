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
    public class DollCartTrackAsset : ArgumentTrackAsset
    {
        protected override Playable OnCreateArgumentPlayable(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<DollCartPlayableBehaviour>.Create(graph, inputCount);
        }
    }
}
