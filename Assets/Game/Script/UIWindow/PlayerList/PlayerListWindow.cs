using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// PlayerListWindow
/// </summary>
[AddComponentMenu("Game/UIWindow/PlayerListWindow")]
public class PlayerListWindow : AbsUIWindowView
{
    /// <summary>
    /// Awake
    /// </summary>
    private void Awake()
    {
        Button btn = transform.Find(@"Table/c1_1").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            CloseWindow();
        });
    }
}