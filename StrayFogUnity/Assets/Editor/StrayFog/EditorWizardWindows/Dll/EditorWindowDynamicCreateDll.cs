#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// 动态生成Dll组件窗口
/// </summary>
public class EditorWindowDynamicCreateDll : AbsEditorWindow
{
    /// <summary>
    /// CS文件映射配置
    /// </summary>
    EditorCsFileConfigForDynamicCreateDll mCsFileConfigForDynamicCreateDll;
    /// <summary>
    /// Dll保存文件夹映射配置
    /// </summary>
    EditorDllSaveFolderConfigForDynamicCreateDll mDllSaveFolderConfigForDynamicCreateDll;         

    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mCsFileConfigForDynamicCreateDll = EditorStrayFogSavedAssetConfig.setCsFileConfigForDynamicCreateDll;
        mDllSaveFolderConfigForDynamicCreateDll = EditorStrayFogSavedAssetConfig.setDllSaveFolderConfigForDynamicCreateDll;
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
        EditorGUILayout.LabelField("Dll Save Folder:");
        mDllSaveFolderConfigForDynamicCreateDll.DrawGUI();
        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("CS Files:");
        mCsFileConfigForDynamicCreateDll.DrawGUI();        
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Build Dynamic Dll"))
        {
            if (EditorStrayFogExecute.ExecuteBuildDynamicDll())
            {
                EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed("Build Dynamic Dll");
            }            
            EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        }
        EditorGUILayout.EndHorizontal();
    }
    #endregion
}
#endif