using Unity.Entities;
using UnityEngine;
/// <summary>
/// ECSSystem【ScriptBehaviourManager】
/// </summary>
public class ECSSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Debug.Log("ECSSystem");
    }
}
