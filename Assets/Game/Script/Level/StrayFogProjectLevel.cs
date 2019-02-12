using System.IO;
using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[AddComponentMenu("Game/ExampleLevel/StrayFogProjectLevel")]
public class StrayFogProjectLevel : AbsMonoBehaviour
{
    [AliasTooltip("属性数量")]
    public int attCount = 2;
    [AliasTooltip("曲线")]
    public AnimationCurve animCurve;
    [AliasTooltip("枚举例子")]
    public enPropertyAttributeExample en;
    #region Templete
    [AliasTooltip("AT0")]
    public int at0;
    #endregion Templete
    #region Element
    #endregion Element

    public enum enPropertyAttributeExample
    {
        [AliasTooltip("大写A")]
        A,
        [AliasTooltip("大写B")]
        B,
    }
#if UNITY_EDITOR
    [InvokeMethod("EditorDisplayParameter")]
    [AliasTooltip("调用函数")]
    public int invokeMethod;
    /// <summary>
    /// OnDisplayPath
    /// </summary>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <returns>高度</returns>
    protected float EditorDisplayParameter(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        float y = _position.y;
        _position.height = 16;
        EditorGUI.LabelField(_position, "method example for InvokeMethodAttribute.");
        _position.y += _position.height;
        return _position.y - y;
    }

    [ContextMenu("RecoverAttribute")]
    public void RecoverAttribute()
    {
        string path = @"Assets\Game\Script\PropertyAttributeExample.cs";
        string text = File.ReadAllText(path);

        string regionTemplete = "#region Templete";
        string endregionTemplete = "#endregion Templete";
        string regionElement = "#region Element";
        string endregionElement = "#endregion Element";
        int regionTempleteIndex = text.IndexOf(regionTemplete) + regionTemplete.Length;
        int endregionTempleteIndex = text.IndexOf(endregionTemplete);
        int regionElementIndex = text.IndexOf(regionElement) + regionElement.Length;
        int endregionElementIndex = text.IndexOf(endregionElement);

        string templete = text.Substring(regionTempleteIndex, endregionTempleteIndex - regionTempleteIndex);
        StringBuilder sb = new StringBuilder();
        attCount = Mathf.Clamp(attCount, 0, int.MaxValue);
        sb.AppendLine();
        sb.Append("\t");
        for (int i = 1; i <= attCount; i++)
        {
            sb.Append(templete.Replace("0", i.ToString()));
        }
        text = text.Remove(regionElementIndex, endregionElementIndex - regionElementIndex);
        text = text.Insert(regionElementIndex, sb.ToString());
        File.WriteAllText(path, text, Encoding.UTF8);
    }
#endif

    /// <summary>
    /// OnGUI
    /// </summary>
    private void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
    }
}
