#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// StrayFogRegisterMonoScript
/// </summary>
[CustomEditor(typeof(StrayFogRegisterMonoScript), true)]
public class EditorStrayFogRegisterMonoScriptInspector : Editor
{
    /// <summary>
    /// StrayFogRegisterMonoScript
    /// </summary>
    StrayFogRegisterMonoScript mStrayFogRegisterMonoScript;
    /// <summary>
    /// OnEnable
    /// </summary>
    void OnEnable()
    {
        mStrayFogRegisterMonoScript = (StrayFogRegisterMonoScript)target;
    }

    /// <summary>
    /// OnInspectorGUI
    /// </summary>
    public override void OnInspectorGUI()
    {
        if (mStrayFogRegisterMonoScript != null && 
            mStrayFogRegisterMonoScript.monoScript != null)
        {
            mStrayFogRegisterMonoScript.asmdefId = EditorStrayFogExecute.FindAssemblyForAsmdef(mStrayFogRegisterMonoScript.monoScript.GetClass().Assembly);
            mStrayFogRegisterMonoScript.monoBehaviourScriptName = mStrayFogRegisterMonoScript.monoScript.name;
        }
        base.OnInspectorGUI();
    }
}
#endif
