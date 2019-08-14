using UnityEngine;
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
        /// ArgumentTrackAsset
        /// </summary>
        public ArgumentTrackAsset trackAsset { get; set; }
        /// <summary>
        /// AbsArgumentPlayableAsset
        /// </summary>
        public ArgumentPlayableAsset playableAsset { get; set; }
    }
}
