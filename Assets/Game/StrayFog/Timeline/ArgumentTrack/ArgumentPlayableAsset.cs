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
        public PlayableDirector director { get;private set; }
        /// <summary>
        /// TimelineAsset
        /// </summary>
        public TimelineAsset timeline { get; private set; }
        /// <summary>
        /// TrackAsset
        /// </summary>
        public ArgumentTrackAsset trackAsset { get; private set; }
        /// <summary>
        /// GenericBindingObject
        /// </summary>
        public UnityEngine.Object genericBindingObject { get; private set; }
        /// <summary>
        /// TimelineClip
        /// </summary>
        public TimelineClip timelineClip { get; private set; }        

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
                trackAsset = templete.GetBehaviour().trackAsset;
                timelineClip = trackAsset.FindTimelineClip(this);
                genericBindingObject = director.GetGenericBinding(trackAsset);
                behaviour.playableAsset = this;
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

