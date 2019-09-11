using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace StrayFog.Timeline
{
    /// <summary>
    /// ArgumentTrackAsset
    /// </summary>
    [TrackColor(1, 1, 1), TrackClipType(typeof(ArgumentPlayableAsset), false)]
    public class ArgumentTrackAsset : PlayableTrack
    {
        public sealed override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            ScriptPlayable<ArgumentPlayableBehaviour> playable = (ScriptPlayable<ArgumentPlayableBehaviour>)OnCreateArgumentPlayable(graph, go, inputCount);
            ArgumentPlayableBehaviour behaviour = playable.GetBehaviour();
            behaviour.trackAsset = this;
            return base.CreateTrackMixer(graph, go, inputCount);
        }

        protected virtual Playable OnCreateArgumentPlayable(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<ArgumentPlayableBehaviour>.Create(graph, inputCount);
        }
    }
}

