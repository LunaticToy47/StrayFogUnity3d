using UnityEngine;
/// <summary>
/// 模拟MonoBehaviour协程
/// </summary>
public class SimulateMonoBehaviour_Coroutine : MonoBehaviour
{
    /// <summary>
    /// OnDestroy
    /// </summary>
    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
