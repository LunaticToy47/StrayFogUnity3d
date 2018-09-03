using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 启动关卡
/// </summary>
[AddComponentMenu("Game/Level/StartUp")]
public class StartUpLevel : MonoBehaviour, IAttachMonoBehaviourAnyWhere
{
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogAssembly.LoadDynamicAssembly();
        List<Type> levels = StrayFogAssembly.GetExportedTypes(typeof(IRunningStartUpLevel));
        Type startupLevel = null;
        if (levels != null && levels.Count > 0)
        {
            foreach (Type t in levels)
            {
                if (t.IsClass && !t.IsAbstract)
                {
                    startupLevel = t;
                    break;
                }
            }
        }

        if (startupLevel != null)
        {
            gameObject.AddComponent(startupLevel);
        }
        else
        {
            throw new UnityException("Can't find level inherit IRunningStartUpLevel.");
        }
    }
}
