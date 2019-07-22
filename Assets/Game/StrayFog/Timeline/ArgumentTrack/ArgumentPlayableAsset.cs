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
                PlayableDirector director = owner.GetComponent<PlayableDirector>();
                TimelineAsset timeline = (TimelineAsset)director.playableAsset;
                behaviour.director = director;
                behaviour.timeline = timeline;
                behaviour.trackAsset = templete.GetBehaviour().trackAsset;
                behaviour.playableAsset = this;
                behaviour.timelineClip = behaviour.trackAsset.FindTimelineClip(this);
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
    }
}

