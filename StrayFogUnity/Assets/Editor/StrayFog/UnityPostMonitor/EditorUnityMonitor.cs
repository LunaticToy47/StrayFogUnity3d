#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

/// <summary>
/// Unity监听
/// </summary>
[InitializeOnLoad]
public static class EditorUnityMonitor
{
    /// <summary>
    /// Unity监听[InitializeOnLoad]在Unity启动时调用
    /// </summary>
    static EditorUnityMonitor()
    {
#if UNITY_EDITOR
        EP.Log("OnHowToUse_InitializeOnLoad");
#endif
    }
}
#endif