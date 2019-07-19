using System;
using UnityEditor;
/// <summary>
/// EditorMenuCommand
/// </summary>
public class EditorMenuCommand
{
    [MenuItem("CONTEXT/MonoBehaviour/Auto GUID")]
    static void AutoGUID(MenuCommand menuCommand)
    {
        EditorStrayFogApplication.CopyToClipboard(Guid.NewGuid().ToString().UniqueHashCode().ToString());
        EditorUtility.DisplayDialog("Auto GUID", "New GUID CopyToClipboard.", "OK");
    }
}
