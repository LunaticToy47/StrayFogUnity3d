#if UNITY_EDITOR 
using System;
using UnityEngine;
/// <summary>
/// 编辑器单选属性
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public class EditorRadioAttribute : PropertyAttribute
{

}
#endif
