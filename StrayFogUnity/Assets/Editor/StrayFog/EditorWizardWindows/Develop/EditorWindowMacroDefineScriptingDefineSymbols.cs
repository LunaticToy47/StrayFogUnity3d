#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 脚本编译宏指令
/// </summary>
public class EditorWindowMacroDefineScriptingDefineSymbols : AbsEditorWindow
{
    /// <summary>
    /// 宏状态
    /// Key:宏枚举
    /// Value:枚举状态【Key:检举名称HashCode,Value:是否选择】
    /// </summary>
    static Dictionary<int, Dictionary<string, bool>> mDefineStates = new Dictionary<int, Dictionary<string, bool>>();

    /// <summary>
    /// 宏状态
    /// Key:宏枚举
    /// Value:枚举属性【Key:检举名称HashCode,Value:属性】
    /// </summary>
    static Dictionary<int, Dictionary<string, AliasTooltipAttribute>> mDefineAttributes = new Dictionary<int, Dictionary<string, AliasTooltipAttribute>>();

    /// <summary>
    /// 宏枚举类型
    /// </summary>
    static List<Type> mDefineTypes = new List<Type>() { typeof(enSystemDefine),typeof(enDeveloperDefine),typeof(enXLuaDefine) };

    /// <summary>
    /// 宏枚举类型属性
    /// </summary>
    static Dictionary<int, AliasTooltipAttribute> mDefineTypeAttributes = new Dictionary<int, AliasTooltipAttribute>();

    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        int tKey = 0;
        List<string> symbols = new List<string>(EditorStrayFogApplication.GetScriptingDefineSymbolsForGroup());

        foreach (Type t in mDefineTypes)
        {
            tKey = t.GetHashCode();
            if (!mDefineStates.ContainsKey(tKey))
            {
                mDefineStates.Add(tKey, new Dictionary<string, bool>());
            }
            if (!mDefineAttributes.ContainsKey(tKey))
            {
                mDefineAttributes.Add(tKey, t.NameToAttributeForConstField<AliasTooltipAttribute>());
            }
            if (!mDefineTypeAttributes.ContainsKey(tKey))
            {
                mDefineTypeAttributes.Add(tKey, t.GetFirstAttribute<AliasTooltipAttribute>());
            }
            foreach (KeyValuePair<string, AliasTooltipAttribute> key in mDefineAttributes[tKey])
            {
                if (!mDefineStates[tKey].ContainsKey(key.Key))
                {
                    mDefineStates[tKey].Add(key.Key, false);
                }
                mDefineStates[tKey][key.Key] = symbols.Contains(key.Key);
            }
        }
    }

    void OnGUI()
    {
        EditorGUILayout.HelpBox("The System and Develop macro define is setting in EnumMacroDefineScriptingDefineSymbols.cs file.", MessageType.Info);
        foreach (KeyValuePair<int, AliasTooltipAttribute> define in mDefineTypeAttributes)
        {
            EditorGUILayout.LabelField(string.Format("【{0}】",define.Value.alias));
            foreach (KeyValuePair<string, AliasTooltipAttribute> attribute in mDefineAttributes[define.Key])
            {
                EditorGUILayout.BeginHorizontal();
                mDefineStates[define.Key][attribute.Key] = EditorGUILayout.ToggleLeft(
                    string.Format("{0}【{1}】", attribute.Key, attribute.Value.alias), mDefineStates[define.Key][attribute.Key]);
                if (GUILayout.Button(string.Format("Copy 【{0}】Define", attribute.Value.alias)))
                {
                    EditorStrayFogApplication.CopyToClipboard(attribute.Key);
                }
                EditorGUILayout.EndHorizontal();
            }
            GUILayout.HorizontalSlider(0, 0, 0, GUILayout.Height(1));
            EditorGUILayout.Separator();
            EditorGUILayout.Separator();
        }

        if (GUILayout.Button("Save Define"))
        {
            SaveDefine();
        }
    }

    void SaveDefine()
    {
        List<string> saveDefines = new List<string>();
        foreach (Dictionary<string, bool> key in mDefineStates.Values)
        {
            foreach (KeyValuePair<string, bool> k in key)
            {
                if (k.Value)
                {
                    saveDefines.Add(k.Key);
                }
            }            
        }
        string defineChar = EditorStrayFogApplication.SetScriptingDefineSymbolsForGroup(saveDefines.ToArray());
        EditorUtility.DisplayDialog("Setting ScriptDefineSymbols", "Setting ScriptDefineSymbols【" + defineChar + "】 Success.", "OK");
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Close();
    }
}
#endif