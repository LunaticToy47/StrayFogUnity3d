using Unity.Entities;
using UnityEngine;
/// <summary>
/// ExampleECSSystem【ScriptBehaviourManager】
/// </summary>
public class ExampleECSSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Debug.Log("ECSSystem");
    }
}
