#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 脚本编译宏指令
/// </summary>
public class EditorWindowMacroDefineScriptingDefineSymbols : EditorWindow
{
    /// <summary>
    /// 系统指令状态
    /// </summary>
    Dictionary<string, bool> mSystemDefineState = new Dictionary<string, bool>();
    /// <summary>
    /// 系统指令描述
    /// </summary>
    Dictionary<string, AliasTooltipAttribute> mSystemDefineAttribute = typeof(enSystemDefine).NameToAttribute<AliasTooltipAttribute>();
    /// <summary>
    /// 系统指令组
    /// </summary>
    List<string> mSystemDefine = new List<string>();


    /// <summary>
    /// 开发指令组状态
    /// </summary>
    Dictionary<string, bool> mDeveloperDefineState = new Dictionary<string, bool>();
    /// <summary>
    /// 开发指令描述
    /// </summary>
    Dictionary<string, AliasTooltipAttribute> mDeveloperDefineAttribute = typeof(enDeveloperDefine).NameToAttribute<AliasTooltipAttribute>();
    /// <summary>
    /// 开发指令组
    /// </summary>
    List<string> mDeveloperDefine = new List<string>();
    void OnFocus()
    {
        if (mSystemDefineState.Count <= 0)
        {
            mSystemDefine.AddRange(Enum.GetNames(typeof(enSystemDefine)));
            foreach (string sys in mSystemDefine)
            {
                mSystemDefineState.Add(sys, false);
            }
        }
        if (mDeveloperDefineState.Count <= 0)
        {
            mDeveloperDefine.AddRange(Enum.GetNames(typeof(enDeveloperDefine)));
            foreach (string dev in mDeveloperDefine)
            {
                mDeveloperDefineState.Add(dev, false);
            }
        }
        string[] symbol = EditorStrayFogApplication.GetScriptingDefineSymbolsForGroup();
        if (symbol != null)
        {
            foreach (string s in symbol)
            {
                if (mSystemDefineState.ContainsKey(s))
                {
                    mSystemDefineState[s] = mSystemDefineState.ContainsKey(s);
                }
                if (mDeveloperDefineState.ContainsKey(s))
                {
                    mDeveloperDefineState[s] = mDeveloperDefineState.ContainsKey(s);
                }
            }
        }
    }

    void OnLostFocus()
    {
        mSystemDefine.Clear();
        mSystemDefineState.Clear();
        mDeveloperDefine.Clear();
        mDeveloperDefineState.Clear();
    }

    void OnGUI()
    {
        EditorGUILayout.HelpBox("The System and Develop macro define is setting in StrayFogPlugins.Enums.EnumMacroDefineScriptingDefineSymbols.cs file.", MessageType.Info);
        EditorGUILayout.LabelField("1.System Defines");
        if (mSystemDefineState.Count > 0)
        {
            foreach (string define in mSystemDefine)
            {
                mSystemDefineState[define] = EditorGUILayout.ToggleLeft(
                    string.Format("{0}【{1}】", define, mSystemDefineAttribute[define].alias), mSystemDefineState[define]);
            }
        }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("2.Developer Defines");
        if (mDeveloperDefine.Count > 0)
        {
            foreach (string define in mDeveloperDefine)
            {
                mDeveloperDefineState[define] = EditorGUILayout.ToggleLeft(
                    string.Format("{0}【{1}】", define, mDeveloperDefineAttribute[define].alias), mDeveloperDefineState[define]);
            }
        }

        if (GUILayout.Button("Save Define"))
        {
            SaveDefine();
        }
    }

    void SaveDefine()
    {
        List<string> saveDefines = new List<string>();
        foreach (KeyValuePair<string, bool> k in mSystemDefineState)
        {
            if (k.Value)
            {
                saveDefines.Add(k.Key);
            }
        }

        foreach (KeyValuePair<string, bool> k in mDeveloperDefineState)
        {
            if (k.Value)
            {
                saveDefines.Add(k.Key);
            }
        }

        string defineChar = EditorStrayFogApplication.SetScriptingDefineSymbolsForGroup(saveDefines.ToArray());
        EditorUtility.DisplayDialog("Setting ScriptDefineSymbols", "Setting ScriptDefineSymbols【" + defineChar + "】 Success.", "OK");
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Close();
    }
}
#endif