using System.Collections;
using UnityEngine;
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
        /// 获得指定时间在TimelineClip中的0-1范围
        /// </summary>
        /// <param name="_timelineClip">TimelineClip</param>
        /// <param name="_time">时间</param>
        /// <returns>指定时间在TimelineClip中的0-1范围</returns>
        public static float GetTimeClamp01(this TimelineClip _timelineClip, double _time)
        {
            double tempTime = _time - _timelineClip.start;
            double tempDeltaTime = tempTime / _timelineClip.duration;
            return Mathf.Clamp01((float)tempDeltaTime);
        }

        /// <summary>
        /// 查找指定PlayableAsset的TimelineClip
        /// </summary>
        /// <param name="_trackAsset">TrackAsset</param>
        /// <param name="_playableAsset">PlayableAsset</param>
        /// <returns></returns>
        public static TimelineClip FindTimelineClip(this TrackAsset _trackAsset, PlayableAsset _playableAsset)
        {
            TimelineClip mTimelineClip = null;
            if (_playableAsset != null)
            {
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
            }
#if UNITY_EDITOR
            if (mTimelineClip == null)
            {
                Debug.LogErrorFormat("Can't find TimelineClip by【{0}】in the【{1}]】.", _trackAsset, _playableAsset);
            }
#endif
            return mTimelineClip;
        }

        /// <summary>
        /// 查找指定名称的TimelineClip
        /// </summary>
        /// <param name="_trackAsset">TrackAsset</param>
        /// <param name="_timelineClipDisplayName">TimelineClip名称</param>
        /// <returns>TimelineClip</returns>
        public static TimelineClip FindTimelineClip(this TrackAsset _trackAsset, string _timelineClipDisplayName)
        {
            TimelineClip timelineClip = null;
            if (_trackAsset != null)
            {
                IEnumerator outClips = _trackAsset.GetClips().GetEnumerator();
                while (outClips.MoveNext())
                {
                    TimelineClip tc = (TimelineClip)outClips.Current;
                    if (tc.displayName.Equals(_timelineClipDisplayName))
                    {
                        timelineClip = tc;
                        break;
                    }
                }
            }
#if UNITY_EDITOR
            if (timelineClip == null)
            {
                Debug.LogErrorFormat("Can't find TimelineClip  for【{0}】.", _timelineClipDisplayName);
            }
#endif
            return timelineClip;
        }

        /// <summary>
        /// 查找指定名称的TrackAsset
        /// </summary>
        /// <param name="_timeline">时间线</param>
        /// <param name="_trackAssetName">TrackAsset名称</param>
        /// <returns>TrackAsset</returns>
        public static TrackAsset FindTrackAsset(this TimelineAsset _timeline, string _trackAssetName)
        {
            TrackAsset trackAsset = null;
            if (_timeline != null)
            {
                IEnumerator outTracks = _timeline.GetOutputTracks().GetEnumerator();
                while (outTracks.MoveNext())
                {
                    TrackAsset ta = (TrackAsset)outTracks.Current;
                    if (ta.name.Equals(_trackAssetName))
                    {
                        trackAsset = ta;
                        break;
                    }
                }
            }
#if UNITY_EDITOR
            if (trackAsset == null)
            {
                Debug.LogErrorFormat("Can't find TrackAsset for【{0}】.", _trackAssetName);
            }
#endif
            return trackAsset;
        }

        /// <summary>
        /// 查找指定名称的TrackAsset
        /// </summary>
        /// <param name="_trackAsset">TrackAsset</param>
        /// <param name="_trackAssetName">TrackAsset名称</param>
        /// <returns>TrackAsset</returns>
        public static TrackAsset FindChildTrackAsset(this TrackAsset _trackAsset, string _trackAssetName)
        {
            TrackAsset trackAsset = null;
            if (_trackAsset != null)
            {
                IEnumerator childTracks = _trackAsset.GetChildTracks().GetEnumerator();
                while (childTracks.MoveNext())
                {
                    TrackAsset ta = (TrackAsset)childTracks.Current;
                    if (ta.name.Equals(_trackAssetName))
                    {
                        trackAsset = ta;
                        break;
                    }
                }
            }
#if UNITY_EDITOR
            if (trackAsset == null)
            {
                Debug.LogErrorFormat("Can't find ChildTrackAsset for【{0}】.", _trackAssetName);
            }
#endif
            return trackAsset;
        }
    }
}
