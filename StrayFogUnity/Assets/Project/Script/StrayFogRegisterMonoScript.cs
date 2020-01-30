using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 注册组件
/// </summary>
[AddComponentMenu("StrayFog/Game/ProjectAPK/StrayFogRegisterMonoScript")]
public sealed class StrayFogRegisterMonoScript : MonoBehaviour
{
#if UNITY_EDITOR
    /// <summary>
    /// 脚本
    /// </summary>
    public MonoScript monoScript;
#endif

    /// <summary>
    /// Asmdef文件Id
    /// </summary>
    [ReadOnly()]
    [AliasTooltip("Asmdef文件Id", "AsmdefMap.xlsx映射数据")]
    public int asmdefId;

    /// <summary>
    /// 组件脚本名称
    /// </summary>
    [ReadOnly()]
    [AliasTooltip("组件脚本名称")]
    public string monoBehaviourScriptName;

    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        Type type = typeof(enSQLiteDataType);
        var nv = type.NameToValueForConstField<long>();
        var nsv = type.NameToSpecialValueForConstField<string>((f) => { return f.Name + "=>" + f.FieldType.FullName; });
        var na = type.NameToAttributeForConstField<CodeAttribute>();
        var nsa = type.NameToAttributeSpecifyValueForConstField<CodeAttribute,string>((a)=> { return a.csTypeName; });

        var vn = type.ValueToNameForConstField<int>();
        var vsv = type.ValueToSpecialValueForConstField<string>((f) => { return f.Name + "=>" + f.FieldType.FullName; });
        var va = type.ValueToAttributeForConstField<int, CodeAttribute>();
        var vsa = type.ValueToAttributeSpecifyValueForConstField<CodeAttribute, string>((a)=> { return a.csTypeName; });

        var names = type.ToNamesForConstField();
        var values = type.ToValuesForConstField();

        var attrs = type.ToAttributesForConstField<CodeAttribute>();
        var attSpValues = type.ToAttributeSpecifyValueForConstField<CodeAttribute, string>((a)=> { return a.csTypeName; });

        Debug.LogError("SSSS");

        //object ins = StrayFogAssembly.CreateInstance(monoBehaviourScriptName);
        //if (ins is ISimulateMonoBehaviour)
        //{
        //    ISimulateMonoBehaviour mono = (ISimulateMonoBehaviour)ins;
        //    mono.BindGameObject(gameObject);
        //}
        //else
        //{
        //    Debug.LogErrorFormat("【{0}】is not IMonoBehaviourLifeCycle", monoBehaviourScriptName);
        //}

    }
}
