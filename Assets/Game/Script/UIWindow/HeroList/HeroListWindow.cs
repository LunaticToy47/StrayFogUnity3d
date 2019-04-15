using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// HeroListWindow
/// </summary>
[AddComponentMenu("Game/UIWindow/HeroListWindow")]
public class HeroListWindow : AbsUIWindowView
{
    /// <summary>
    /// Awake
    /// </summary>
    private void Awake()
    {
        Button btn = transform.Find(@"Table/c1_1").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            CloseWindow();
        });
    }
}