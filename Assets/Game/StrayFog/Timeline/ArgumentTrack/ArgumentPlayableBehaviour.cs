using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace StrayFog.Timeline
{
    /// <summary>
    /// ArgumentPlayableBehaviour
    /// </summary>
    public class ArgumentPlayableBehaviour : PlayableBehaviour
    {
        /// <summary>
        /// PlayableDirector
        /// </summary>
        public PlayableDirector director { get; set; }
        /// <summary>
        /// TimelineAsset
        /// </summary>
        public TimelineAsset timeline { get; set; }
        /// <summary>
        /// ArgumentTrackAsset
        /// </summary>
        public ArgumentTrackAsset trackAsset { get; set; }
        /// <summary>
        /// AbsArgumentPlayableAsset
        /// </summary>
        public ArgumentPlayableAsset playableAsset { get; set; }
        /// <summary>
        /// TimelineClip
        /// </summary>
        public TimelineClip timelineClip { get; set; }
    }
}
