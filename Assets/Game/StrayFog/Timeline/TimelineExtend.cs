using System.Collections;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace StrayFog.Timeline
{
    /// <summary>
    /// Timeline扩展
    /// </summary>
    public static class TimelineExtend
    {
        /// <summary>
        /// 查找指定PlayableAsset的TimelineClip
        /// </summary>
        /// <param name="_trackAsset">TrackAsset</param>
        /// <param name="_playableAsset">PlayableAsset</param>
        /// <returns></returns>
        public static TimelineClip FindTimelineClip(this TrackAsset _trackAsset, PlayableAsset _playableAsset)
        {
            TimelineClip mTimelineClip = null;
            IEnumerator outClips = _trackAsset.GetClips().GetEnumerator();
            while (outClips.MoveNext())
            {
                TimelineClip clip = (TimelineClip)outClips.Current;
                if (clip.asset.Equals(_playableAsset))
                {
                    mTimelineClip = clip;
                    break;
                }
            }
            return mTimelineClip;
        }
    }
}
