using System;
using UnityEngine;
using UnityEngine.Playables;

namespace StrayFog.Timeline
{
    /// <summary>
    /// TimeScalePlayableAsset
    /// </summary>
    [Serializable]
    public class TimeScalePlayableAsset : ArgumentPlayableAsset
    {
        /// <summary>
        /// TimeScale参数
        /// </summary>
        [Serializable]
        public struct TimeScaleArgument
        {
            /// <summary>
            /// 时间缩放曲线
            /// </summary>
            [Tooltip("时间缩放曲线")]
            public AnimationCurve timeScaleCurve;
        }
        /// <summary>
        /// TimeScale参数
        /// </summary>
        public TimeScaleArgument timeScaleArgument;

        protected override Playable OnCreateArgumentPlayable(PlayableGraph graph, GameObject owner)
        {
            ScriptPlayable<TimeScalePlayableBehaviour> playable = ScriptPlayable<TimeScalePlayableBehaviour>.Create(graph);
            return playable;
        }
    }
}

