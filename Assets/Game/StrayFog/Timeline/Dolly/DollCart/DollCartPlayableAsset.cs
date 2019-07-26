using Cinemachine;
using System;
using UnityEngine;
using UnityEngine.Playables;

namespace StrayFog.Timeline.Dolly
{
    /// <summary>
    /// DollCart跟踪
    /// </summary>
    [Serializable]
    public class DollCartPlayableAsset : ArgumentPlayableAsset
    {
        /// <summary>
        /// 轨道对象
        /// </summary>
        public ExposedReference<CinemachineDollyCart> dollyCart;
        /// <summary>
        /// 轨道路径点数量
        /// </summary>        
        [ReadOnly()]
        public float dollCartMaxPathCount;
        /// <summary>
        /// 轨道起始百分比
        /// </summary>
        [ReadOnly]
        public float dollyStartPercent;
        /// <summary>
        /// 轨道结束百分比
        /// </summary>
        [ReadOnly]
        public float dollyEndPercent;

        /// <summary>
        /// 轨道起始点
        /// </summary>
        public float dollyStartPos = 0;
        /// <summary>
        /// 轨道结束点
        /// </summary>
        public float dollyEndPos = 0;

        protected override void OnBeforeCreateArgumentPlayable(PlayableGraph graph, GameObject owner)
        {
            CinemachineDollyCart dc = dollyCart.Resolve(graph.GetResolver());
            if (dc != null)
            {
                dollCartMaxPathCount = dc.m_Path.MaxUnit(CinemachinePathBase.PositionUnits.PathUnits);
                dollyStartPos = Mathf.Clamp(dollyStartPos, 0, dollCartMaxPathCount);
                dollyEndPos = Mathf.Clamp(dollyEndPos, 0, dollCartMaxPathCount);
                dollyStartPercent = dc.m_Path.FromPathNativeUnits(dollyStartPos, dc.m_PositionUnits) / dc.m_Path.MaxUnit(dc.m_PositionUnits);
                dollyEndPercent = dc.m_Path.FromPathNativeUnits(dollyEndPos, dc.m_PositionUnits) / dc.m_Path.MaxUnit(dc.m_PositionUnits);
                if (dollyEndPercent == 0)
                {
                    dollyEndPercent = 1;
                }
            }
            if (dollyStartPos > dollyEndPos)
            {
                dollyEndPos = dollyStartPos;
            }            
            base.OnBeforeCreateArgumentPlayable(graph, owner);
        }

        protected override Playable OnCreateArgumentPlayable(PlayableGraph graph, GameObject owner)
        {
            ScriptPlayable<DollCartPlayableBehaviour> playable = ScriptPlayable<DollCartPlayableBehaviour>.Create(graph);
            DollCartPlayableBehaviour behaviour = playable.GetBehaviour();
            behaviour.dollyCart = dollyCart.Resolve(graph.GetResolver());
            return playable;
        }
    }
}
