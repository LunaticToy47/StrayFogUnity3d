using UnityEngine;
/// <summary>
/// StrayFog协程
/// </summary>
public class StrayFogCoroutine : MonoBehaviour
{
    /// <summary>
    /// OnDestroy
    /// </summary>
    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
