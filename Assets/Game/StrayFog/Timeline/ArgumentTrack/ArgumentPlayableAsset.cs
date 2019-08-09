using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace StrayFog.Timeline
{
    /// <summary>
    /// ArgumentPlayableAsset
    /// </summary>
    [Serializable]
    public class ArgumentPlayableAsset : PlayableAsset
    {
        /// <summary>
        /// PlayableDirector
        /// </summary>
        protected PlayableDirector director;
        /// <summary>
        /// TimelineAsset
        /// </summary>
        protected TimelineAsset timeline;
        /// <summary>
        /// TrackAsset
        /// </summary>
        protected ArgumentTrackAsset track;

        public sealed override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            ScriptPlayable<ArgumentPlayableBehaviour> playable = ScriptPlayable<ArgumentPlayableBehaviour>.Null;
            ScriptPlayable<ArgumentPlayableBehaviour> templete = ScriptPlayable<ArgumentPlayableBehaviour>.Null;
            for (int i = 0; i < graph.GetRootPlayableCount(); i++)
            {
                if (graph.GetRootPlayable(i).GetPlayableType().IsTypeOrSubTypeOf(typeof(ArgumentPlayableBehaviour)))
                {
                    templete = (ScriptPlayable<ArgumentPlayableBehaviour>)graph.GetRootPlayable(i);
                }
            }
            OnBeforeCreateArgumentPlayable(graph, owner);
            if (!templete.Equals(playable))
            {
                playable = (ScriptPlayable<ArgumentPlayableBehaviour>)OnCreateArgumentPlayable(graph,owner);
                ArgumentPlayableBehaviour behaviour = playable.GetBehaviour();
                director = owner.GetComponent<PlayableDirector>();
                timeline = (TimelineAsset)director.playableAsset;
                track = templete.GetBehaviour().trackAsset;
                behaviour.director = director;
                behaviour.timeline = timeline;
                behaviour.trackAsset = track;
                behaviour.playableAsset = this;
                behaviour.genericBindingObject = behaviour.director.GetGenericBinding(behaviour.trackAsset);
                behaviour.timelineClip = behaviour.trackAsset.FindTimelineClip(this);
                OnAfterCreateArgumentPlayable(graph, owner, playable);
            }
            return playable;
        }

        protected virtual void OnBeforeCreateArgumentPlayable(PlayableGraph graph, GameObject owner)
        {

        }

        protected virtual Playable OnCreateArgumentPlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<ArgumentPlayableBehaviour>.Create(graph);
        }

        protected virtual void OnAfterCreateArgumentPlayable(PlayableGraph graph, GameObject owner, Playable playable)
        {
            
        }
    }
}

