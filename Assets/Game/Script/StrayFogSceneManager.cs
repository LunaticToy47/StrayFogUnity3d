using UnityEngine.SceneManagement;
/// <summary>
/// 场景管理
/// </summary>
public class StrayFogSceneManager : AbsSingleMonoBehaviour
{
    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="_sceneName">场景名称</param>
    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}