using UnityEngine.Timeline;
using UnityEngine;
using UnityEngine.Playables;

namespace StrayFog.Timeline
{
    /// <summary>
    /// Trigger
    /// </summary>
    [TrackColor(0.8f, 0.8f, 0.8f)]
    [TrackClipType(typeof(TimeScalePlayableAsset))]
    public class TimeScaleTrackAsset : ArgumentTrackAsset
    {
        protected override Playable OnCreateArgumentPlayable(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<TimeScalePlayableBehaviour>.Create(graph, inputCount);
        }
    }
}

