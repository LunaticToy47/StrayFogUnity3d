#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
/// <summary>
/// AnimatorControllerFMSMaping选择资源
/// </summary>
public class EditorSelectionAnimatorControllerFMSMapingAsset : EditorSelectionAsset
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pathOrGuid">路径或guid</param>
    public EditorSelectionAnimatorControllerFMSMapingAsset(string _pathOrGuid) : base(_pathOrGuid)
    {

    }

    /// <summary>
    /// 解析
    /// </summary>
    public void Resolver()
    {
        machineForStateMaping = new SortedDictionary<string, List<string>>();
        stateForMachineMaping = new SortedDictionary<string, List<string>>();

        stateForLayerMaping = new SortedDictionary<string, List<int>>();
        layerForStateMaping = new SortedDictionary<int, List<string>>();

        machineForLayerMaping = new SortedDictionary<string, List<int>>();
        layerForMachineMaping = new SortedDictionary<int, List<string>>();

        stateForNameHashMaping = new SortedDictionary<string, int>();
        parameterForNameHashMaping = new SortedDictionary<string, int>();
        AnimatorController ac = (AnimatorController)AssetDatabase.LoadMainAssetAtPath(path);
        OnResolverLayer(ac);
    }

    /// <summary>
    /// 状态与状态机映射
    /// Key:状态名称
    /// Value:Machine名称
    /// </summary>
    public SortedDictionary<string, List<string>> stateForMachineMaping { get; private set; }
    /// <summary>
    /// 状态机与状态映射
    /// Key:Machine名称
    /// Value:状态名称
    /// </summary>
    public SortedDictionary<string, List<string>> machineForStateMaping { get; private set; }

    /// <summary>
    /// 状态与layer索引映射
    /// Key:状态
    /// Value:layer索引
    /// </summary>
    public SortedDictionary<string, List<int>> stateForLayerMaping { get; private set; }
    /// <summary>
    /// layer与状态索引映射
    /// Key:layer索引
    /// Value:状态
    /// </summary>
    public SortedDictionary<int, List<string>> layerForStateMaping { get; private set; }

    /// <summary>
    /// 状态机与layer索引映射
    /// Key:状态机
    /// Value:layer索引
    /// </summary>
    public SortedDictionary<string, List<int>> machineForLayerMaping { get; private set; }
    /// <summary>
    /// layer与状态机索引映射
    /// Key:layer索引
    /// Value:状态机
    /// </summary>
    public SortedDictionary<int, List<string>> layerForMachineMaping { get; private set; }

    /// <summary>
    /// 状态与NameHash映射
    /// Key:状态
    /// Value:NameHash
    /// </summary>
    public SortedDictionary<string, int> stateForNameHashMaping { get; private set; }
    /// <summary>
    /// 参数与NameHash映射
    /// Key:参数名称
    /// Value:NameHash
    /// </summary>
    public SortedDictionary<string, int> parameterForNameHashMaping { get; private set; }
    /// <summary>
    /// 解析AnimatorController
    /// </summary>
    /// <param name="_ac">AnimatorController</param>
    void OnResolverLayer(AnimatorController _ac)
    {
        for (int i = 0; i < _ac.layers.Length; i++)
        {
            OnTraverseAnimatorStateMachine(i, _ac.layers[i].stateMachine);
        }
        foreach (AnimatorControllerParameter p in _ac.parameters)
        {
            if (!parameterForNameHashMaping.ContainsKey(p.name))
            {
                parameterForNameHashMaping.Add(p.name, p.nameHash);
            }
        }
    }

    /// <summary>
    /// 遍历状态机
    /// </summary>
    /// <param name="_layerIndex">layer索引</param>
    /// <param name="_machine">状态机</param>
    void OnTraverseAnimatorStateMachine(int _layerIndex, AnimatorStateMachine _machine)
    {
        if (_machine != null)
        {
            #region machineForStateMaping
            if (!machineForStateMaping.ContainsKey(_machine.name))
            {
                machineForStateMaping.Add(_machine.name, new List<string>());
            }
            #endregion

            #region machineForLayerMaping
            if (!machineForLayerMaping.ContainsKey(_machine.name))
            {
                machineForLayerMaping.Add(_machine.name, new List<int>());
            }
            if (!machineForLayerMaping[_machine.name].Contains(_layerIndex))
            {
                machineForLayerMaping[_machine.name].Add(_layerIndex);
            }
            #endregion

            #region layerForMachineMaping
            if (!layerForMachineMaping.ContainsKey(_layerIndex))
            {
                layerForMachineMaping.Add(_layerIndex, new List<string>());
            }
            if (!layerForMachineMaping[_layerIndex].Contains(_machine.name))
            {
                layerForMachineMaping[_layerIndex].Add(_machine.name);
            }
            #endregion

            if (_machine.states != null)
            {
                foreach (ChildAnimatorState s in _machine.states)
                {
                    #region stateForMachineMaping
                    if (!stateForMachineMaping.ContainsKey(s.state.name))
                    {
                        stateForMachineMaping.Add(s.state.name, new List<string>());
                    }
                    if (!stateForMachineMaping[s.state.name].Contains(_machine.name))
                    {
                        stateForMachineMaping[s.state.name].Add(_machine.name);
                    }
                    #endregion

                    #region machineForStateMaping
                    if (!machineForStateMaping[_machine.name].Contains(_machine.name))
                    {
                        machineForStateMaping[_machine.name].Add(s.state.name);
                    }
                    #endregion

                    #region stateForLayerMaping
                    if (!stateForLayerMaping.ContainsKey(s.state.name))
                    {
                        stateForLayerMaping.Add(s.state.name, new List<int>());
                    }
                    if (!stateForLayerMaping[s.state.name].Contains(_layerIndex))
                    {
                        stateForLayerMaping[s.state.name].Add(_layerIndex);
                    }
                    #endregion

                    #region layerForStateMaping
                    if (!layerForStateMaping.ContainsKey(_layerIndex))
                    {
                        layerForStateMaping.Add(_layerIndex, new List<string>());
                    }
                    if (!layerForStateMaping[_layerIndex].Contains(s.state.name))
                    {
                        layerForStateMaping[_layerIndex].Add(s.state.name);
                    }
                    #endregion

                    #region stateForNameHashMaping
                    if (!stateForNameHashMaping.ContainsKey(s.state.name))
                    {
                        stateForNameHashMaping.Add(s.state.name, s.state.nameHash);
                    }
                    #endregion
                }
            }

            if (_machine.stateMachines != null)
            {
                foreach (ChildAnimatorStateMachine cm in _machine.stateMachines)
                {
                    OnTraverseAnimatorStateMachine(_layerIndex, cm.stateMachine);
                }
            }
        }
    }
}
#endif