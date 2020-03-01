using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// 插入条数
    /// </summary>
    int mInsertNum = 1000000;
    /// <summary>
    /// 时间
    /// </summary>
    Stopwatch watch = new Stopwatch();
    /// <summary>
    /// Awake
    /// </summary>
    private void Awake()
    {
        mDbPath = StrayFogRunningPool.runningSetting.GetSQLiteConnectionString(
            Path.Combine(Application.streamingAssetsPath, "XLS_Config.db").TransPathSeparatorCharToUnityChar());
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Insert 10W"))
        {
            StrayFogSQLiteHelper helper = new StrayFogSQLiteHelper(mDbPath);           
            while (mInsertNum > 0)
            {
                helper.ExecuteQuery("INSERT INTO AsmdefMap VALUES (1,'AAAAAAAA','BBBBBBBB','CCCCCCC','DDDDDD','EEEEEE',0)");
                mInsertNum--;
            }            
        }
        GUILayout.Label("Insert Num =>" + mInsertNum);
        if (GUILayout.Button("Read SQLite"))
        {
            watch.Reset();
            watch.Start();
            StrayFogSQLiteHelper helper = new StrayFogSQLiteHelper(mDbPath);
            SqliteDataReader reader = helper.ReadFullTable("AsmdefMap");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    sbTableColumn.Append(reader.GetName(i) + ",");
                    sbTableValue.Append(reader.GetValue(i).ToString());
                }
            }
            reader.Close();
            watch.Stop();
        }
        GUILayout.Label("Time=>" + watch.ElapsedMilliseconds);
        mScrollViewPosition = GUILayout.BeginScrollView(mScrollViewPosition);
        GUILayout.Label("Connect String=>"+ mDbPath);
        GUILayout.Label("Table Columns=>" + sbTableColumn.ToString());
        GUILayout.Label("Table Values=>" + sbTableValue.ToString());
        GUILayout.EndScrollView();
    }
}
