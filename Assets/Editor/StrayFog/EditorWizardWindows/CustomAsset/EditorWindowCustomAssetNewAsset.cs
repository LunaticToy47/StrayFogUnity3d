using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 自定义资源窗口
/// </summary>
public class EditorWindowCustomAssetNewAsset : EditorWindow
{
    /// <summary>
    /// Txt脚本模板
    /// </summary>
    string mTxtScriptTemplete = EditorResxTemplete.EditorResxTemplete.EdtiorCustomAssetNewAssetScriptTemplete;
    /// <summary>
    /// 脚本内容
    /// </summary>
    string mScriptContent = string.Empty;
    /// <summary>
    /// 脚本配置
    /// </summary>
    EditorTextAssetConfig mScriptConfig = new EditorTextAssetConfig("", "", enFileExt.CS, "");
    /// <summary>
    /// 资源配置
    /// </summary>
    EditorEngineAssetConfig mAssetConfig = new EditorEngineAssetConfig("", "", enFileExt.Asset, "");
    /// <summary>
    /// 新资源名称
    /// </summary>
    string mNewAssetName = string.Empty;
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {

    }
    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        mNewAssetName = EditorGUILayout.TextField("资源名称", mNewAssetName);
        if (!string.IsNullOrEmpty(mNewAssetName.Trim()))
        {
            mScriptConfig.SetName(mNewAssetName);
            mAssetConfig.SetName(mNewAssetName);
            mAssetConfig.SetType(mNewAssetName);
            EditorGUILayout.LabelField("1." + mScriptConfig.fileName);
            EditorGUILayout.LabelField("2." + mAssetConfig.fileName);
            mScriptContent = mTxtScriptTemplete.Replace("#ClassName#", mNewAssetName);
            mScriptConfig.SetText(mScriptContent);
            EditorGUILayout.HelpBox(mScriptContent, MessageType.Info);

            if (File.Exists(mAssetConfig.fileName))
            {
                if (GUILayout.Button("Brower"))
                {
                    EditorStrayFogApplication.PingObject(mAssetConfig.fileName);
                }
            }
            else if (EditorStrayFogAssembly.IsExistsTypeInApplication(mNewAssetName))
            {
                if (GUILayout.Button("Create Asset"))
                {
                    mAssetConfig.CreateAsset();
                    EditorUtility.DisplayDialog("Custom Asset ", string.Format("Create Asset【{0}】success , path is '{1}'.", mAssetConfig.name, mAssetConfig.fileName), "OK");
                    EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
                }
            }
            else if (GUILayout.Button("Create Script"))
            {
                mScriptConfig.CreateAsset();
                EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
            }
        }
    }
}
