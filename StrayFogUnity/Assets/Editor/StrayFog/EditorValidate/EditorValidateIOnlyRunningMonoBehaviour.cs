#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// IRunningMonoBehaviour编辑器验证
/// </summary>
[CustomEditor(typeof(MonoBehaviour), true, isFallback = true)]
public class EditorValidateIOnlyRunningMonoBehaviour : Editor
{
    /// <summary>
    /// OnEnable
    /// </summary>
    void OnEnable()
    {
        if ((target is IAttachMonoBehaviourOnlyRunning) && !EditorApplication.isPlaying)
        {
            DestroyImmediate(target, true);
        }
    }
}
#endif