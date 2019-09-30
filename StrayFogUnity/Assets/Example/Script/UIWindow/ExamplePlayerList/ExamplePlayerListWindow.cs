using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ExamplePlayerListWindow
/// </summary>
[AddComponentMenu("StrayFog/Example/UIWindow/ExamplePlayerListWindow")]
public class ExamplePlayerListWindow : AbsUIWindowView
{
    /// <summary>
    /// Awake
    /// </summary>
    protected override void Awake()
    {
        Button btn = transform.Find(@"Table/c1_1").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            CloseWindow();
        });
    }
}