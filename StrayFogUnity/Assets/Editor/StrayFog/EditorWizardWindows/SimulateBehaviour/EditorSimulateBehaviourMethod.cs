#if UNITY_EDITOR
using System.Collections.Generic;
using System.Reflection;
/// <summary>
/// 模拟Behaviour分类
/// </summary>
public enum enEditorSimulateBehaviourClassify
{
    /// <summary>
    /// MonoBehaviour
    /// </summary>
    MonoBehaviour,
    /// <summary>
    /// UIBehaviour
    /// </summary>
    UIBehaviour,
}
/// <summary>
/// 模拟Behaviour方法
/// </summary>
public class EditorSimulateBehaviourMethod
{
    /// <summary>
    /// 模拟Key值
    /// </summary>
    public int simulateKey { get; private set; }
    /// <summary>
    /// 方法重写前缀
    /// </summary>
    public string methodOverridePrefix { get; private set; }
    /// <summary>
    /// 模拟Behaviour分类
    /// </summary>
    public enEditorSimulateBehaviourClassify simulateBehaviourClassify { get; private set; }
    /// <summary>
    /// 是否生成模拟
    /// </summary>
    public bool isBuildSimulate { get; private set; }
    /// <summary>
    /// 方法信息
    /// </summary>
    public MethodInfo methodInfo { get; private set; }
    /// <summary>
    /// 方法枚举名称
    /// </summary>
    public string methodEnumName { get; private set; }
    /// <summary>
    /// 方法枚举值
    /// </summary>
    public int methodEnumValue { get; private set; }
    /// <summary>
    /// 虚方法名称
    /// </summary>
    public string vrtualMethodName { get; private set; }
    /// <summary>
    /// 方法形参参数组
    /// </summary>
    public List<string> methodFormalParameters { get; private set; }
    /// <summary>
    /// 方法输入参数组
    /// </summary>
    public List<string> methodInputParameters { get; private set; }
    /// <summary>
    /// 类名
    /// </summary>
    public string className { get; private set; }
    /// <summary>
    /// 模拟Behaviour方法
    /// </summary>
    /// <param name="_method">方法</param>
    /// <param name="_classify">分类</param>
    public EditorSimulateBehaviourMethod(MethodInfo _method, enEditorSimulateBehaviourClassify _classify)
    {
        methodInfo = _method;
        className = "Simulate"+_classify + "_" + _method.Name;
        methodEnumName = _classify + "_" + _method.Name;
        methodEnumValue = methodEnumName.UniqueHashCode();
        simulateBehaviourClassify = _classify;
        vrtualMethodName = _method.Name.ToUpper().StartsWith("ON") ? _method.Name.Remove(0, 2) : _method.Name;
        bool hasObs = _method.HasObsoleteAttribute();
        ParameterInfo[] pams = _method.GetParameters();
        methodFormalParameters = new List<string>();
        methodInputParameters = new List<string>();
        string tempSimulateValue = _method.Name;
        if (pams != null && pams.Length > 0)
        {
            foreach (ParameterInfo p in pams)
            {
                hasObs |= p.HasObsoleteAttribute();
                methodFormalParameters.Add(string.Format("{0} _{1}", p.ParameterType, p.Name));
                methodInputParameters.Add(string.Format("_{0}", p.Name));
                tempSimulateValue += p.ParameterType.Name + p.Name;
            }
        }

        methodOverridePrefix = string.Empty;
        if (_method.IsVirtual)
        {
            if (_method.IsPrivate)
            {
                methodOverridePrefix = "override ";
            }
            else if (_method.IsPublic)
            {
                methodOverridePrefix = "public override ";
            }
            else
            {
                methodOverridePrefix = "protected override ";
            }
        }

        if (_method.ReturnParameter != null)
        {
            if (string.IsNullOrEmpty(_method.ReturnParameter.Name))
            {
                methodOverridePrefix += _method.ReturnParameter.ParameterType.Name.ToLower();
            }
            else
            {
                methodOverridePrefix += _method.ReturnParameter.ParameterType.ToString();
            }
        }
        simulateKey = tempSimulateValue.UniqueHashCode();
        isBuildSimulate = !hasObs;
    }    
}
#endif