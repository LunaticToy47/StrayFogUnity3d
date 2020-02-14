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
        layerNameForIndexMaping = new SortedDictionary<string, int>();

        machineForStateMaping = new SortedDictionary<string, List<string>>();
        stateForMachineMaping = new SortedDictionary<string, List<string>>();

        stateForLayerMaping = new SortedDictionary<string, List<string>>();
        layerForStateMaping = new SortedDictionary<string, List<string>>();

        machineForLayerMaping = new SortedDictionary<string, List<string>>();
        layerForMachineMaping = new SortedDictionary<string, List<string>>();

        stateForNameHashMaping = new SortedDictionary<string, int>();
        parameterForNameHashMaping = new SortedDictionary<string, int>();        

        AnimatorController ac = (AnimatorController)AssetDatabase.LoadMainAssetAtPath(path);
        OnResolverLayer(ac);
    }

    /// <summary>
    /// Layer层名称与索引 
    /// Key:Layer名称
    /// Value:Layer索引 
    /// </summary>
    public SortedDictionary<string,int> layerNameForIndexMaping { get; private set; }

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
    /// Value:layer名称
    /// </summary>
    public SortedDictionary<string, List<string>> stateForLayerMaping { get; private set; }
    /// <summary>
    /// layer与状态索引映射
    /// Key:layer名称
    /// Value:状态
    /// </summary>
    public SortedDictionary<string, List<string>> layerForStateMaping { get; private set; }

    /// <summary>
    /// 状态机与layer索引映射
    /// Key:状态机
    /// Value:layer名称
    /// </summary>
    public SortedDictionary<string, List<string>> machineForLayerMaping { get; private set; }
    /// <summary>
    /// layer与状态机索引映射
    /// Key:layer名称
    /// Value:状态机
    /// </summary>
    public SortedDictionary<string, List<string>> layerForMachineMaping { get; private set; }

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
        string layerName = string.Empty;
        for (int i = 0; i < _ac.layers.Length; i++)
        {
            layerName = _ac.layers[i].name + "_index" + i;
            if (!layerNameForIndexMaping.ContainsKey(layerName))
            {
                layerNameForIndexMaping.Add(layerName, i);
            }
            OnTraverseAnimatorStateMachine(i, layerName, _ac.layers[i].stateMachine, string.Empty);
        }

        string parameterName = string.Empty;
        foreach (AnimatorControllerParameter p in _ac.parameters)
        {
            parameterName = p.name + "_" + p.type;
            if (!parameterForNameHashMaping.ContainsKey(parameterName))
            {
                parameterForNameHashMaping.Add(parameterName, p.nameHash);
            }
        }
    }

    /// <summary>
    /// 遍历状态机
    /// </summary>
    /// <param name="_layerIndex">layer索引</param>
    /// <param name="_layerName">Layer名称</param>
    /// <param name="_machine">状态机</param>
    /// <param name="_pathName">路径名称</param>
    void OnTraverseAnimatorStateMachine(int _layerIndex, string _layerName, AnimatorStateMachine _machine,string _pathName)
    {
        if (_machine != null)
        {
            string machineName = string.IsNullOrEmpty(_pathName) ? _machine.name : (_pathName + "." + _machine.name);            
            #region machineForStateMaping
            if (!machineForStateMaping.ContainsKey(machineName))
            {
                machineForStateMaping.Add(machineName, new List<string>());
            }
            #endregion

            #region machineForLayerMaping
            if (!machineForLayerMaping.ContainsKey(machineName))
            {
                machineForLayerMaping.Add(machineName, new List<string>());
            }
            if (!machineForLayerMaping[machineName].Contains(_layerName))
            {
                machineForLayerMaping[machineName].Add(_layerName);
            }
            #endregion

            #region layerForMachineMaping
            if (!layerForMachineMaping.ContainsKey(_layerName))
            {
                layerForMachineMaping.Add(_layerName, new List<string>());
            }
            if (!layerForMachineMaping[_layerName].Contains(machineName))
            {
                layerForMachineMaping[_layerName].Add(machineName);
            }
            #endregion

            if (_machine.states != null)
            {
                string stateName = string.Empty;
                foreach (ChildAnimatorState s in _machine.states)
                {
                    stateName = machineName + "." + s.state.name;
                    #region stateForMachineMaping
                    if (!stateForMachineMaping.ContainsKey(stateName))
                    {
                        stateForMachineMaping.Add(stateName, new List<string>());
                    }
                    if (!stateForMachineMaping[stateName].Contains(machineName))
                    {
                        stateForMachineMaping[stateName].Add(machineName);
                    }
                    #endregion

                    #region machineForStateMaping
                    if (!machineForStateMaping[machineName].Contains(machineName))
                    {
                        machineForStateMaping[machineName].Add(stateName);
                    }
                    #endregion

                    #region stateForLayerMaping
                    if (!stateForLayerMaping.ContainsKey(stateName))
                    {
                        stateForLayerMaping.Add(stateName, new List<string>());
                    }
                    if (!stateForLayerMaping[stateName].Contains(_layerName))
                    {
                        stateForLayerMaping[stateName].Add(_layerName);
                    }
                    #endregion

                    #region layerForStateMaping
                    if (!layerForStateMaping.ContainsKey(_layerName))
                    {
                        layerForStateMaping.Add(_layerName, new List<string>());
                    }
                    if (!layerForStateMaping[_layerName].Contains(stateName))
                    {
                        layerForStateMaping[_layerName].Add(stateName);
                    }
                    #endregion

                    #region stateForNameHashMaping
                    if (!stateForNameHashMaping.ContainsKey(stateName))
                    {
                        stateForNameHashMaping.Add(stateName, Animator.StringToHash(stateName));
                    }
                    #endregion
                }
            }

            if (_machine.stateMachines != null)
            {
                foreach (ChildAnimatorStateMachine cm in _machine.stateMachines)
                {
                    OnTraverseAnimatorStateMachine(_layerIndex, _layerName, cm.stateMachine, machineName);
                }
            }
        }
    }
}
#endif