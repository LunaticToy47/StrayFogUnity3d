using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
/// <summary>
/// ExampleSQLiteLevelForIOS
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleSQLiteLevelForIOS")]
public class ExampleSQLiteLevelForIOS : MonoBehaviour
{
    string mDbPath = string.Empty;
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    /// <summary>
    /// 表字段
    /// </summary>
    StringBuilder sbTableColumn = new StringBuilder();
    /// <summary>
    /// 表值
    /// </summary>
    StringBuilder sbTableValue = new StringBuilder();
    /// <summary>
    /// Awake
    /// </summary>
    private void Awake()
    {
        mDbPath = StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().GetSQLiteConnectionString(
            Path.Combine(Application.streamingAssetsPath, "XLS_Config.db").TransPathSeparatorCharToUnityChar());
    }

    private void OnGUI()
    {        
        if (GUILayout.Button("Read SQLite"))
        {
            StrayFogSQLiteHelper helper = new StrayFogSQLiteHelper(mDbPath);
            SqliteDataReader reader = helper.ReadFullTable("AsmdefMap");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    sbTableColumn.Append(reader.GetName(i) + ",");
                    sbTableValue.Append(reader.GetValue(i).ToString());
                }
                break;
            }
            reader.Close();
        }
        mScrollViewPosition = GUILayout.BeginScrollView(mScrollViewPosition);
        GUILayout.Label("Connect String=>"+ mDbPath);
        GUILayout.Label("Table Columns=>" + sbTableColumn.ToString());
        GUILayout.Label("Table Values=>" + sbTableValue.ToString());
        GUILayout.EndScrollView();
    }
}
