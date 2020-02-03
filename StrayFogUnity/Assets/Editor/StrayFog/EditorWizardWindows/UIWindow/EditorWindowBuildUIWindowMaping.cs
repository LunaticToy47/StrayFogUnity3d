#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 生成UI窗口映射
/// </summary>
public class EditorWindowBuildUIWindowMaping : AbsEditorWindow
{
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    /// <summary>
    /// 搜索窗口名称
    /// </summary>
    string mSearchWindowName = string.Empty;


    /// <summary>
    /// 搜索窗口绘制类别
    /// </summary>
    Dictionary<int, bool> mSearchWindowRenderMode = typeof(RenderMode).ValueToSpecialValue((m) => { return true; });
    /// <summary>
    /// 绘制类别
    /// </summary>
    List<RenderMode> mRenderModes = typeof(RenderMode).ToEnums<RenderMode>();


    /// <summary>
    /// 窗口最小Layer滚动视图位置
    /// </summary>
    Vector2 mWindowMinLayerScrollViewPosition = Vector2.zero;
    /// <summary>
    /// 窗口最小Layer映射
    /// </summary>
    static readonly Dictionary<int, string> msrWindowMinLayerMaping = 
        typeof(enEditorUIWindowLayer).ValueToAttributeSpecifyValue<AliasTooltipAttribute, string>((a) => { return a.alias; });
    /// <summary>
    /// 搜索窗口绘制类别
    /// </summary>
    Dictionary<int, bool> mSearchWindowMinLayer = 
        typeof(enEditorUIWindowLayer).ValueToSpecialValue((m) => { return true; });
    /// <summary>
    /// 窗口组
    /// </summary>
    List<EditorSelectionUIWindowSetting> mWindows;
    /// <summary>
    /// 要移除的窗口
    /// </summary>
    List<int> mRemoveWindows = new List<int>();
    /// <summary>
    /// 信息
    /// </summary>
    StringBuilder mSbInfo = new StringBuilder();

    /// <summary>
    /// 配置
    /// </summary>
    EditorXlsFileConfigForUIWindowSetting mConfig = null;

    /// <summary>
    /// OnFocus
    /// </summary>
    private void OnFocus()
    {
        mConfig = EditorStrayFogSavedAssetConfig.setXlsFileConfigForUIWindowSetting;
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        DrawBrower();
        DrawAssetNodes();
    }

    #region DrawBrower
    /// <summary>
    /// DrawBrower
    /// </summary>
    void DrawBrower()
    {
        mConfig.DrawGUI();
        EditorGUILayout.Separator();        
    }
    #endregion

    #region DrawAssetNodes 绘制节点
    /// <summary>
    /// 绘制节点
    /// </summary>
    void DrawAssetNodes()
    {
        #region  mSearchWindowName 搜索
        mSearchWindowName = EditorGUILayout.TextField("Search Window Name", mSearchWindowName);
        #endregion
        EditorGUILayout.Separator();

        #region RenderMode 窗口绘制类别

        #region 批量选择
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Selected All RenderMode"))
        {
            AdjustRenderModeSelected(1);
        }
        if (GUILayout.Button("UnSelected All RenderMode"))
        {
            AdjustRenderModeSelected(-1);
        }
        if (GUILayout.Button("Reverse All RenderMode"))
        {
            AdjustRenderModeSelected(0);
        }
        EditorGUILayout.EndHorizontal();
        #endregion
        EditorGUILayout.Separator();

        #region 显示操作
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Window Render Mode", GUILayout.ExpandWidth(false));
        foreach (RenderMode rm in mRenderModes)
        {
            mSearchWindowRenderMode[(int)rm] = EditorGUILayout.ToggleLeft(rm.ToString(), mSearchWindowRenderMode[(int)rm], GUILayout.ExpandWidth(false));
        }
        EditorGUILayout.EndHorizontal();
        #endregion
        #endregion
        EditorGUILayout.Separator();

        #region enUIWindowLayer 窗口层级

        #region 批量选择
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Selected All Layer"))
        {
            AdjustWindowMinLayerSelected(1);
        }
        if (GUILayout.Button("UnSelected All Layer"))
        {
            AdjustWindowMinLayerSelected(-1);
        }
        if (GUILayout.Button("Reverse All Layer"))
        {
            AdjustWindowMinLayerSelected(0);
        }
        EditorGUILayout.EndHorizontal();
        #endregion
        EditorGUILayout.Separator();

        #region 显示操作
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Window Layer", GUILayout.ExpandWidth(false));
        mWindowMinLayerScrollViewPosition = EditorGUILayout.BeginScrollView(mWindowMinLayerScrollViewPosition, GUILayout.ExpandHeight(false));
        EditorGUILayout.BeginHorizontal();
        foreach (KeyValuePair<int, string> key in msrWindowMinLayerMaping)
        {
            mSearchWindowMinLayer[key.Key] = EditorGUILayout.ToggleLeft(key.Value, mSearchWindowMinLayer[key.Key], GUILayout.ExpandWidth(false));
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndHorizontal();
        #endregion

        #endregion
        EditorGUILayout.Separator();

        #region isDraw 计算是否绘制
        if (mWindows != null && mWindows.Count > 0)
        {
            for (int i = 0; i < mWindows.Count; i++)
            {
                mWindows[i].isDraw =
                    //名称过滤
                    (string.IsNullOrEmpty(mSearchWindowName) || Regex.IsMatch(mWindows[i].nameWithoutExtension,
                    string.Format(@"({0})+?\w*", mSearchWindowName.Replace(",", "|")), RegexOptions.IgnoreCase)) &&
                    //绘制类别过滤
                    mSearchWindowRenderMode[(int)mWindows[i].assetNode.renderMode] &&
                    //窗口最小Layer
                    mSearchWindowMinLayer[(int)mWindows[i].assetNode.layer];
            }
        }        
        #endregion

        #region 绘制窗口属性列表
        mRemoveWindows.Clear();
        if (mWindows != null && mWindows.Count > 0)
        {
            mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
            EditorGUILayout.BeginVertical();
            for (int i = 0; i < mWindows.Count; i++)
            {
                if (mWindows[i].isDraw)
                {
                    EditorGUILayout.BeginHorizontal();
                    #region 显示属性
                    EditorGUILayout.LabelField(
                        string.Format("{0}=>【{1}】{2}",
                            string.Format("{0}.{1}", (i + 1).PadLeft(mWindows.Count), mWindows[i].nameWithoutExtension),
                            mWindows[i].assetNode.renderMode.ToString(),
                            msrWindowMinLayerMaping[(int)mWindows[i].assetNode.layer]
                        )
                     );
                    #endregion
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    #region Setting 按钮
                    if (GUILayout.Button("Setting"))
                    {
                        EditorStrayFogApplication.PingObject(mWindows[i].assetNode);
                    }
                    #endregion

                    #region Brower 按钮
                    if (GUILayout.Button("Brower"))
                    {
                        EditorStrayFogApplication.PingObject(mWindows[i].path);
                    }
                    #endregion

                    #region Select 按钮
                    if (GUILayout.Button("Select"))
                    {
                        mSearchWindowName = mWindows[i].nameWithoutExtension;
                    }
                    #endregion

                    #region Delete 按钮
                    if (GUILayout.Button("Delete"))
                    {
                        int delScriptIndex = -1;
                        if (EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths != null && EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths.Length > 0)
                        {
                            string path = Path.GetDirectoryName(mWindows[i].directory).TransPathSeparatorCharToUnityChar();
                            for (int p = 0; p < EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths.Length; p++)
                            {
                                if (path.Equals(EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths[i]))
                                {
                                    delScriptIndex = p;
                                    break;
                                }
                            }
                        }
                        if (delScriptIndex >= 0)
                        {                            
                            string delPrefabDirectory = mWindows[i].directory;
                            string delScriptDirectory = Path.Combine(EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowScript.paths[delScriptIndex], Path.GetFileName(mWindows[i].directory));
                            string delAssetPath = AssetDatabase.GetAssetPath(mWindows[i].assetNode);
                            mSbInfo.Length = 0;
                            mSbInfo.AppendLine("Do you want to delete window ?");
                            mSbInfo.AppendLine(string.Format("Window =>{0}", mWindows[i].path));
                            mSbInfo.AppendLine("It will delete follow asset:");
                            mSbInfo.AppendLine(string.Format("1. Del Prefab Folder => {0}", delPrefabDirectory));
                            mSbInfo.AppendLine(string.Format("2. Del Script Folder => {0}", delScriptDirectory));
                            mSbInfo.AppendLine(string.Format("3. Del Asset => {0}", delAssetPath));
                            mSbInfo.AppendLine(string.Format("4. Del SQLite UIWindowSetting Where id={0}", mWindows[i].winId));
                            if (EditorUtility.DisplayDialog("Delete", mSbInfo.ToString(), "Yes", "No"))
                            {
                                mRemoveWindows.Add(i);
                                EditorStrayFogUtility.cmd.DeleteFolder(delPrefabDirectory);
                                EditorStrayFogUtility.cmd.DeleteFolder(delScriptDirectory);
                                File.Delete(delAssetPath);
                                EditorStrayFogXLS.DeleteUIWindowSetting(mWindows[i].winId);
                                break;
                            }

                        }
                    }
                    #endregion
                    EditorGUILayout.EndHorizontal();
                }
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();

            if (mRemoveWindows.Count > 0)
            {
                foreach (int index in mRemoveWindows)
                {
                    mWindows.RemoveAt(index);
                }
                BuilderWindowEnum();
            }
        }
        #endregion

        #region 显示窗口
        if (GUILayout.Button("Display UIWindow"))
        {
            mWindows = EditorStrayFogGlobalVariable.CollectUIWindowSettingAssets<EditorSelectionUIWindowSetting>();
        }
        #endregion

        #region 保存设置
        if (GUILayout.Button("Save Window Setting"))
        {
            BuilderWindowEnum();
        }
        #endregion
    }

    /// <summary>
    /// 调整RenderMode选中
    /// </summary>
    /// <param name="_state">状态【-1:全False,0:取反,1:全True】</param>
    void AdjustRenderModeSelected(int _state)
    {
        foreach (RenderMode rm in mRenderModes)
        {
            if (_state < 0)
            {
                mSearchWindowRenderMode[(int)rm] = false;
            }
            else if (_state > 0)
            {
                mSearchWindowRenderMode[(int)rm] = true;
            }
            else
            {
                mSearchWindowRenderMode[(int)rm] = !mSearchWindowRenderMode[(int)rm];
            }
        }
    }

    /// <summary>
    /// 调整MinLayer选中
    /// </summary>
    /// <param name="_state">状态【-1:全False,0:取反,1:全True】</param>
    void AdjustWindowMinLayerSelected(int _state)
    {
        foreach (int md in msrWindowMinLayerMaping.Keys)
        {
            if (_state < 0)
            {
                mSearchWindowMinLayer[md] = false;
            }
            else if (_state > 0)
            {
                mSearchWindowMinLayer[md] = true;
            }
            else
            {
                mSearchWindowMinLayer[md] = !mSearchWindowMinLayer[md];
            }
        }
    }

    /// <summary>
    /// 创建窗口枚举
    /// </summary>
    void BuilderWindowEnum()
    {
        EditorStrayFogExecute.ExecuteBuildUIWindowSetting();
        EditorStrayFogExecute.ExecuteBuildAllAssetDiskMaping();
        EditorUtility.DisplayDialog("Builder Window Enum", "Builder Window Enum Success", "OK");
    }
    #endregion
}
#endif