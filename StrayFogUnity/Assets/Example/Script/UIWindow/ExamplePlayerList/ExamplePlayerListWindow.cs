using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ExamplePlayerListWindow
/// </summary>
[AddComponentMenu("StrayFog/Example/UIWindow/ExamplePlayerListWindow")]
public class ExamplePlayerListWindow : AbsUIWindowView
{
    /// <summary>
    /// OnRunAwake
    /// </summary>
    protected override void OnRunAwake()
    {
        Button btn = gameObject.transform.Find(@"Table/c1_1").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            CloseWindow();
        });
    }
}