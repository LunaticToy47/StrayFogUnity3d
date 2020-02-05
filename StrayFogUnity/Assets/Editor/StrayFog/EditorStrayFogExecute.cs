#if UNITY_EDITOR
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 执行工具
/// </summary>
public sealed class EditorStrayFogExecute
{
    #region UIWindow菜单

    #region ExecuteBuildUIWindowSetting 生成窗口设定
    /// <summary>
    /// 生成窗口设定
    /// </summary>
    public static void ExecuteBuildUIWindowSetting()
    {
        List<EditorSelectionUIWindowSetting> mWindows = EditorStrayFogGlobalVariable.CollectUIWindowSettingAssets<EditorSelectionUIWindowSetting>();
        float progress = 0;
        string scriptTemplete = EditorResxTemplete.UIWindowEnumMapingTemplete;
        string result = scriptTemplete;

        #region Windows
        string replaceWindowsTemplete = string.Empty;
        string formatWindowsTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(scriptTemplete, @"#Windows#", out replaceWindowsTemplete);
        Dictionary<int, StringBuilder> dicSbWindowsTemplete = new Dictionary<int, StringBuilder>();
        #endregion

        StringBuilder sbLog = new StringBuilder();        
        Dictionary<int, string> dicAssemblyName = new Dictionary<int, string>();
        int pathKey = 0;

        #region 收集窗口枚举常量
        if (mWindows != null && mWindows.Count > 0)
        {            
            foreach (EditorSelectionUIWindowSetting w in mWindows)
            {
                pathKey = Path.GetDirectoryName(w.directory).TransPathSeparatorCharToUnityChar().UniqueHashCode();
                if (!dicSbWindowsTemplete.ContainsKey(pathKey))
                {
                    dicSbWindowsTemplete.Add(pathKey, new StringBuilder());
                }
                if (!dicAssemblyName.ContainsKey(pathKey))
                {
                    dicAssemblyName.Add(pathKey, w.ownerAssembly.GetName().Name);
                }
                dicSbWindowsTemplete[pathKey].AppendLine(
                    formatWindowsTemplete                    
                    .Replace("#Name#", w.nameWithoutExtension)
                    .Replace("#Id#", w.winId.ToString())
                    );                          
                progress++;
                EditorUtility.DisplayProgressBar("Builder Window Enum", w.path, progress / mWindows.Count);
            }
            EditorStrayFogXLS.InsertUIWindowSetting(mWindows, (n, p) =>
            {
                EditorUtility.DisplayProgressBar("Insert Window Setting To Xls", n, p);
            });
        }
        #endregion

        #region 生成窗口枚举静态类
        if (EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths != null && EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths.Length > 0)
        {
            for (int i = 0; i < EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths.Length; i++)
            {
                pathKey = EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths[i].UniqueHashCode();
                if (dicSbWindowsTemplete.ContainsKey(pathKey))
                {

                    result = scriptTemplete
                        .Replace(replaceWindowsTemplete, dicSbWindowsTemplete[pathKey].ToString())                  
                        .Replace("#Directory#", EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths[i].TransPathSeparatorCharToUnityChar())                     
                        .Replace("#AssemblyName#", dicAssemblyName[pathKey])
                     ;
                    
                    result = EditorStrayFogUtility.regex.ClearRepeatCRLF(result);
                    EditorTextAssetConfig cfg = new EditorTextAssetConfig("EnumUIWindow",
                        EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowScript.paths[i], enFileExt.CS, result);
                    cfg.CreateAsset();
                    sbLog.AppendLine(string.Format("ExecuteBuildUIWindowSetting 【{0}】Succeed!", cfg.fileName));
                }                
            }
        }
        #endregion

        #region 生成窗口属性枚举静态类
        string txt_StaticConstField_ScriptTemplete = EditorResxTemplete.Editor_GeneralStaticConstField_ScriptTemplete;
        string buildStaticConstFieldScriptFolder = Path.Combine(enEditorApplicationFolder.Game_StrayFog_UIWindowMgr.GetAttribute<EditorApplicationFolderAttribute>().path, "Enum").TransPathSeparatorCharToUnityChar();

        #region #Consts#
        string staticConstField_Mark = "#Consts#";
        string staticConstField_ReplaceTemplete = string.Empty;
        string staticConstField_Templete = string.Empty;
        StringBuilder sbStaticConstField_Replace = new StringBuilder();
        staticConstField_Templete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(txt_StaticConstField_ScriptTemplete, staticConstField_Mark, out staticConstField_ReplaceTemplete);
        #endregion

        EditorTextAssetConfig staticConstFieldScriptCfg = new EditorTextAssetConfig(string.Empty,
                       buildStaticConstFieldScriptFolder, enFileExt.CS,string.Empty);        

        string txt_StaticConstField_Script = string.Empty;
        string txt_StaticConstField_ClassName = string.Empty;
        string txt_StaticConstField_ScriptName = string.Empty;
        sbStaticConstField_Replace.Length = 0;

        #region 生成RenderMode静态类常量
        txt_StaticConstField_Script = string.Empty;
        txt_StaticConstField_ClassName = string.Empty;
        txt_StaticConstField_ScriptName = string.Empty;
        sbStaticConstField_Replace.Length = 0;
        List<RenderMode> renderModes = typeof(RenderMode).ToEnums<RenderMode>();
        txt_StaticConstField_ClassName = "UIWindowRenderMode";
        txt_StaticConstField_ScriptName = "en" + txt_StaticConstField_ClassName;
        foreach (RenderMode key in renderModes)
        {
            sbStaticConstField_Replace.Append(
                staticConstField_Templete
                .Replace("#Name#",key.ToString())
                .Replace("#Value#",((int)key).ToString())
                .Replace("#Desc#",key.ToString())
                );
        }

        txt_StaticConstField_Script = 
            txt_StaticConstField_ScriptTemplete
            .Replace(staticConstField_ReplaceTemplete, sbStaticConstField_Replace.ToString())
            .Replace("#StaticClassName#", txt_StaticConstField_ClassName)
            ;
        staticConstFieldScriptCfg.SetName(txt_StaticConstField_ScriptName);
        staticConstFieldScriptCfg.SetText(txt_StaticConstField_Script);
        staticConstFieldScriptCfg.CreateAsset();
        #endregion

        #region 生成enEditorUIWindowLayer静态类常量
        txt_StaticConstField_Script = string.Empty;
        txt_StaticConstField_ClassName = string.Empty;
        txt_StaticConstField_ScriptName = string.Empty;
        sbStaticConstField_Replace.Length = 0;
        Dictionary<enEditorUIWindowLayer, AliasTooltipAttribute> layers = typeof(enEditorUIWindowLayer).EnumToAttribute<enEditorUIWindowLayer, AliasTooltipAttribute>();
        txt_StaticConstField_ClassName = "UIWindowLayer";
        txt_StaticConstField_ScriptName = "en" + txt_StaticConstField_ClassName;
        foreach (KeyValuePair<enEditorUIWindowLayer, AliasTooltipAttribute> key in layers)
        {
            sbStaticConstField_Replace.Append(
                staticConstField_Templete
                .Replace("#Name#", key.Key.ToString())
                .Replace("#Value#", ((int)key.Key).ToString())
                .Replace("#Desc#", key.Value.alias)
                );
        }

        txt_StaticConstField_Script =
            txt_StaticConstField_ScriptTemplete
            .Replace(staticConstField_ReplaceTemplete, sbStaticConstField_Replace.ToString())
            .Replace("#StaticClassName#", txt_StaticConstField_ClassName)
            ;
        staticConstFieldScriptCfg.SetName(txt_StaticConstField_ScriptName);
        staticConstFieldScriptCfg.SetText(txt_StaticConstField_Script);
        staticConstFieldScriptCfg.CreateAsset();
        #endregion

        #region 生成enEditorUIWindowOpenMode静态类常量
        txt_StaticConstField_Script = string.Empty;
        txt_StaticConstField_ClassName = string.Empty;
        txt_StaticConstField_ScriptName = string.Empty;
        sbStaticConstField_Replace.Length = 0;
        Dictionary<enEditorUIWindowOpenMode, AliasTooltipAttribute> openModes = typeof(enEditorUIWindowOpenMode).EnumToAttribute<enEditorUIWindowOpenMode, AliasTooltipAttribute>();
        txt_StaticConstField_ClassName = "UIWindowOpenMode";
        txt_StaticConstField_ScriptName = "en" + txt_StaticConstField_ClassName;
        foreach (KeyValuePair<enEditorUIWindowOpenMode, AliasTooltipAttribute> key in openModes)
        {
            sbStaticConstField_Replace.Append(
                staticConstField_Templete
                .Replace("#Name#", key.Key.ToString())
                .Replace("#Value#", ((int)key.Key).ToString())
                .Replace("#Desc#", key.Value.alias)
                );
        }

        txt_StaticConstField_Script =
            txt_StaticConstField_ScriptTemplete
            .Replace(staticConstField_ReplaceTemplete, sbStaticConstField_Replace.ToString())
            .Replace("#StaticClassName#", txt_StaticConstField_ClassName)
            ;
        staticConstFieldScriptCfg.SetName(txt_StaticConstField_ScriptName);
        staticConstFieldScriptCfg.SetText(txt_StaticConstField_Script);
        staticConstFieldScriptCfg.CreateAsset();
        #endregion

        #region 生成enEditorUIWindowCloseMode静态类常量
        txt_StaticConstField_Script = string.Empty;
        txt_StaticConstField_ClassName = string.Empty;
        txt_StaticConstField_ScriptName = string.Empty;
        sbStaticConstField_Replace.Length = 0;
        Dictionary<enEditorUIWindowCloseMode, AliasTooltipAttribute> closeModes = typeof(enEditorUIWindowCloseMode).EnumToAttribute<enEditorUIWindowCloseMode, AliasTooltipAttribute>();
        txt_StaticConstField_ClassName = "UIWindowCloseMode";
        txt_StaticConstField_ScriptName = "en" + txt_StaticConstField_ClassName;
        foreach (KeyValuePair<enEditorUIWindowCloseMode, AliasTooltipAttribute> key in closeModes)
        {
            sbStaticConstField_Replace.Append(
                staticConstField_Templete
                .Replace("#Name#", key.Key.ToString())
                .Replace("#Value#", ((int)key.Key).ToString())
                .Replace("#Desc#", key.Value.alias)
                );
        }

        txt_StaticConstField_Script =
            txt_StaticConstField_ScriptTemplete
            .Replace(staticConstField_ReplaceTemplete, sbStaticConstField_Replace.ToString())
            .Replace("#StaticClassName#", txt_StaticConstField_ClassName)
            ;
        staticConstFieldScriptCfg.SetName(txt_StaticConstField_ScriptName);
        staticConstFieldScriptCfg.SetText(txt_StaticConstField_Script);
        staticConstFieldScriptCfg.CreateAsset();
        #endregion
        #endregion

        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log(sbLog);
    }
    #endregion

    #endregion

    #region Project菜单

    #region ExecuteBuildProjectAssets 生成工程资源
    /// <summary>
    /// 生成工程资源
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    public static void ExecuteBuildProjectAssets<T>()
        where T : AbsSingleScriptableObject
    {
        Type absInheritType = typeof(T);
        Type destType = null;
        int destCount = 0;
        StringBuilder sbLog = new StringBuilder();
        List<Assembly> asms = EditorStrayFogAssembly.GetDynamicAssemblies();
        if (asms != null && asms.Count > 0)
        {
            foreach (Assembly m in asms)
            {
                Type[] types = m.GetExportedTypes();
                if (types != null && types.Length > 0)
                {
                    foreach (Type t in types)
                    {
                        if (t.IsTypeOrSubTypeOf(absInheritType) && t.IsClass && !t.IsInterface && !t.IsAbstract)
                        {
                            destType = t;
                            destCount++;
                        }
                    }
                }
            }
            switch (destCount)
            {
                case 0:
                    throw new UnityException(string.Format("There is no class inherit '{0}'.", absInheritType.FullName));
                case 1:
                    EditorEngineAssetConfig absCfg = new EditorEngineAssetConfig(absInheritType.Name, enEditorApplicationFolder.Project_Resources.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Asset, destType.Name);
                    if (!absCfg.Exists())
                    {
                        absCfg.CreateAsset();
                        sbLog.AppendFormat("BuildProjectAssets=>【{0}】", absCfg.fileName);
                    }
                    break;
                default:
                    throw new UnityException(string.Format("It is must be one class inherit '{0}',please delete others.", absInheritType.FullName));
            }
        }

        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine(string.Format("ExecuteBuildProjectAssets 【{0}】Succeed!", absInheritType.FullName));
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #endregion

    #region SimulateMonoBehaviour菜单

    #region ExecuteBuildSimulateMonoBehaviour 生成模拟MonoBehaviour组件
    /// <summary>
    /// 模拟MonoBehaviour方法映射
    /// </summary>
    static Dictionary<int, List<EditorSimulateBehaviourMethod>> mSimulateMonoBehaviour_MethodMaping = new Dictionary<int, List<EditorSimulateBehaviourMethod>>();
    /// <summary>
    /// 收集模拟MonoBehaviourMethod
    /// </summary>
    /// <returns>方法与模拟属性</returns>
    public static List<EditorSimulateBehaviourMethod> CollectSimulateMonoBehaviourMethods()
    {
        Type type = typeof(Editor_SimulateMonoBehaviour_Templete);
        int key = type.FullName.UniqueHashCode();
        if (!mSimulateMonoBehaviour_MethodMaping.ContainsKey(key))
        {
            List<EditorSimulateBehaviourMethod> result = new List<EditorSimulateBehaviourMethod>();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            if (methods != null && methods.Length > 0)
            {
                foreach (MethodInfo m in methods)
                {
                    result.Add(new EditorSimulateBehaviourMethod(m, enEditorSimulateBehaviourClassify.MonoBehaviour));
                }
            }
            mSimulateMonoBehaviour_MethodMaping.Add(key, result);
        }
        return mSimulateMonoBehaviour_MethodMaping[key];
    }

    /// <summary>
    /// 模拟UIBehaviour方法映射
    /// </summary>
    static Dictionary<int, List<EditorSimulateBehaviourMethod>> mSimulateUIBehaviour_MethodMaping = new Dictionary<int, List<EditorSimulateBehaviourMethod>>();
    /// <summary>
    /// 收集模拟MonoBehaviourMethod
    /// </summary>
    /// <returns>方法与模拟属性</returns>
    public static List<EditorSimulateBehaviourMethod> CollectSimulateUIBehaviourMethods()
    {
        Type type = typeof(Editor_SimulateUIBehaviour_Templete);
        int key = type.FullName.UniqueHashCode();
        if (!mSimulateUIBehaviour_MethodMaping.ContainsKey(key))
        {
            List<EditorSimulateBehaviourMethod> result = new List<EditorSimulateBehaviourMethod>();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            if (methods != null && methods.Length > 0)
            {
                foreach (MethodInfo m in methods)
                {
                    result.Add(new EditorSimulateBehaviourMethod(m, enEditorSimulateBehaviourClassify.UIBehaviour));
                }
            }
            mSimulateUIBehaviour_MethodMaping.Add(key, result);
        }
        return mSimulateUIBehaviour_MethodMaping[key];
    }

    /// <summary>
    /// 生成模拟Behaviour组件
    /// </summary>
    public static void ExecuteBuildSimulateBehaviour()
    {
        StringBuilder sbLog = new StringBuilder();
        sbLog.AppendLine("Begin ExecuteBuildSimulateMonoBehaviour");
        string hotfix_SimulateBehaviourScriptRootFolder = enEditorApplicationFolder.Hotfix_SimulateBehaviour.GetAttribute<EditorApplicationFolderAttribute>().path;
        string runningSimulateBehaviourScriptRootFolder = enEditorApplicationFolder.StrayFog_Running_SimulateBehaviour.GetAttribute<EditorApplicationFolderAttribute>().path;

        EditorTextAssetConfig cfgEntityScript = new EditorTextAssetConfig("", "", enFileExt.CS, "");
        Dictionary<int, string> enumValueNames = new Dictionary<int, string>();        

        #region Behaviour_Enum 行为枚举
        string txt_BehaviourEnum_ScriptTemplete = EditorResxTemplete.Editor_GeneralEnum_ScriptTemplete;

        #region #Enums#
        string behaviour_Enum_Mark = "#Enums#";
        string behaviour_Enum_ReplaceTemplete = string.Empty;
        string behaviour_Enum_Templete = string.Empty;
        StringBuilder sbBehaviour_Enum_Replace = new StringBuilder();
        behaviour_Enum_Templete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(txt_BehaviourEnum_ScriptTemplete, behaviour_Enum_Mark, out behaviour_Enum_ReplaceTemplete);
        #endregion
        string txt_Hotfix_SimulateMonoBehaviour_Method_Enum_ClassName = "SimulateBehaviourMethod";
        string txt_Hotfix_SimulateMonoBehaviour_Method_Enum_Script = string.Empty;
        sbBehaviour_Enum_Replace.Length = 0;
        #endregion

        #region Hotfix_AbsMonoBehaviour_ISimulateBehaviour_Method Hotfix抽象模拟Behaviour行为方法
        string txt_AbsMonoBehaviour_SimulateBehaviour_Method_ScriptTemplete = EditorResxTemplete.Editor_AbsMonoBehaviour_ISimulateBehaviour_Method_ScriptTemplete;

        #region #AbsMonoBehaviour_ISimulateBehaviour_Method#
        string absMonoBehaviour_ISimulateBehaviour_Method_Mark = "#AbsMonoBehaviour_ISimulateBehaviour_Method#";
        string absMonoBehaviour_ISimulateBehaviour_Method_ReplaceTemplete = string.Empty;
        string absMonoBehaviour_ISimulateBehaviour_Method_Templete = string.Empty;
        StringBuilder sbAbsMonoBehaviour_ISimulateBehaviour_Method_Replace = new StringBuilder();
        absMonoBehaviour_ISimulateBehaviour_Method_Templete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(txt_AbsMonoBehaviour_SimulateBehaviour_Method_ScriptTemplete, absMonoBehaviour_ISimulateBehaviour_Method_Mark, out absMonoBehaviour_ISimulateBehaviour_Method_ReplaceTemplete);
        #endregion

        string hotfix_AbsMonoBehaviour_ISimulateBehaviour_Method_ScriptName = "AbsMonoBehaviour_ISimulateBehaviour_Method";
        string txt_Hotfix_AbsMonoBehaviour_ISimulateBehaviour_Method_Script = string.Empty;

        sbAbsMonoBehaviour_ISimulateBehaviour_Method_Replace.Length = 0;
        #endregion

        #region Hotfix_AbsMonoBehaviour_ISimulateBehaviour_MethodMap Hotfix抽象模拟Behaviour行为枚举与方法映射
        string txt_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_ScriptTemplete = EditorResxTemplete.Editor_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_ScriptTemplete;

        #region #AbsMonoBehaviour_ISimulateBehaviour_MethodMap#
        string absMonoBehaviour_ISimulateBehaviour_MethodMap_Mark = "#AbsMonoBehaviour_ISimulateBehaviour_MethodMap#";
        string absMonoBehaviour_ISimulateBehaviour_MethodMap_ReplaceTemplete = string.Empty;
        string absMonoBehaviour_ISimulateBehaviour_MethodMap_Templete = string.Empty;
        StringBuilder sbAbsMonoBehaviour_ISimulateBehaviour_MethodMap_Replace = new StringBuilder();
        absMonoBehaviour_ISimulateBehaviour_MethodMap_Templete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(txt_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_ScriptTemplete, absMonoBehaviour_ISimulateBehaviour_MethodMap_Mark, out absMonoBehaviour_ISimulateBehaviour_MethodMap_ReplaceTemplete);
        #endregion

        string hotfix_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_ScriptName = "AbsMonoBehaviour_ISimulateBehaviour_MethodMap";
        string txt_Hotfix_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_Script = string.Empty;

        sbAbsMonoBehaviour_ISimulateBehaviour_MethodMap_Replace.Length = 0;
        #endregion

        #region Running_ISimulateMonoBehaviour Running时ISimulateMonoBehaviour接口
        string txt_ISimulateMonoBehaviour_ScriptTemplete = EditorResxTemplete.Editor_ISimulateMonoBehaviour_ScriptTemplete;

        #region #ISimulateMonoBehaviour#
        string running_ISimulateMonoBehaviour_Mark = "#ISimulateMonoBehaviour#";
        string running_ISimulateMonoBehaviour_ReplaceTemplete = string.Empty;
        string running_ISimulateMonoBehaviour_Templete = string.Empty;
        StringBuilder sbRunning_ISimulateMonoBehaviour_Replace = new StringBuilder();
        running_ISimulateMonoBehaviour_Templete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(txt_ISimulateMonoBehaviour_ScriptTemplete, running_ISimulateMonoBehaviour_Mark, out running_ISimulateMonoBehaviour_ReplaceTemplete);
        #endregion

        string running_ISimulateMonoBehaviour_ScriptName = "ISimulateMonoBehaviour";
        string txt_Running_ISimulateMonoBehaviour_Script = string.Empty;

        sbRunning_ISimulateMonoBehaviour_Replace.Length = 0;
        #endregion

        #region SimulateBehaviour/MonoBehaviours 模拟MonoBehaviour组件
        string txt_SimulateBehaviour_MonoBehaviour_MethodComponent_ScriptTemplete = EditorResxTemplete.Editor_SimulateMonoBehaviour_MethodComponent_ScriptTemplete;
        string simulateBehaviour_MonoBehaviour_MethodComponent_Script_Folder = Path.Combine(runningSimulateBehaviourScriptRootFolder, "MonoBehaviours");

        //#region 无区域替换暂不用
        //string simulateMonoBehaviour_MethodComponent_Mark = "#无区域替换暂不用#";
        //string simulateMonoBehaviour_MethodComponent_ReplaceTemplete = string.Empty;
        //string simulateMonoBehaviour_MethodComponent_Templete = string.Empty;
        //StringBuilder sbSimulateMonoBehaviour_MethodComponent_Replace = new StringBuilder();
        //simulateMonoBehaviour_MethodComponent_Templete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(txt_SimulateMonoBehaviour_MethodComponent_ScriptTemplete, simulateMonoBehaviour_MethodComponent_Mark, out simulateMonoBehaviour_MethodComponent_ReplaceTemplete);
        //#endregion

        string txt_SimulateBehaviour_MonoBehaviour_MethodComponent_Script = string.Empty;

        Dictionary<string, string> simulateBehaviour_MonoBehaviour_MethodComponent_Script_Maping = new Dictionary<string, string>();
        #endregion        

        #region SimulateBehaviour/UIBehaviours 模拟MonoBehaviour组件
        string txt_SimulateBehaviour_UIBehaviour_MethodComponent_ScriptTemplete = EditorResxTemplete.Editor_SimulateMonoBehaviour_MethodComponent_ScriptTemplete;
        string simulateBehaviour_UIBehaviour_MethodComponent_Script_Folder = Path.Combine(runningSimulateBehaviourScriptRootFolder, "UIBehaviours");

        //#region 无区域替换暂不用
        //string simulateUIBehaviour_MethodComponent_Mark = "#无区域替换暂不用#";
        //string simulateUIBehaviour_MethodComponent_ReplaceTemplete = string.Empty;
        //string simulateUIBehaviour_MethodComponent_Templete = string.Empty;
        //StringBuilder sbSimulateUIBehaviour_MethodComponent_Replace = new StringBuilder();
        //simulateUIBehaviour_MethodComponent_Templete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(txt_SimulateUIBehaviour_MethodComponent_ScriptTemplete, simulateUIBehaviour_MethodComponent_Mark, out simulateUIBehaviour_MethodComponent_ReplaceTemplete);
        //#endregion

        string txt_SimulateBehaviour_UIBehaviour_MethodComponent_Script = string.Empty;

        Dictionary<string, string> simulateBehaviour_UIBehaviour_MethodComponent_Script_Maping = new Dictionary<string, string>();
        #endregion        

        //删除已有文件
        EditorStrayFogUtility.cmd.DeleteFolder(simulateBehaviour_MonoBehaviour_MethodComponent_Script_Folder);
        EditorStrayFogUtility.cmd.DeleteFolder(simulateBehaviour_UIBehaviour_MethodComponent_Script_Folder);
        //收集所有要模拟的方法       
        List<EditorSimulateBehaviourMethod> simulateMethods = new List<EditorSimulateBehaviourMethod>();
        simulateMethods.AddRange(CollectSimulateMonoBehaviourMethods());
        simulateMethods.AddRange(CollectSimulateUIBehaviourMethods());
        //进度
        float progress = 0;
        //已生成的方法Key
        List<int> tempMethodKey = new List<int>();
        #region 收集MonoBehaviour方法
        foreach (EditorSimulateBehaviourMethod m in simulateMethods)
        {           
            if (m.isBuildSimulate)
            {
                //收集枚举
                if (!enumValueNames.ContainsKey(m.methodEnumValue))
                {
                    enumValueNames.Add(m.methodEnumValue, m.methodEnumName);
                }
                switch (m.simulateBehaviourClassify)
                {
                    case enEditorSimulateBehaviourClassify.MonoBehaviour:
                        #region 收集要生成的模拟MonoBehaviour的组件
                        if (!simulateBehaviour_MonoBehaviour_MethodComponent_Script_Maping.ContainsKey(m.className))
                        {
                            txt_SimulateBehaviour_MonoBehaviour_MethodComponent_Script =
                                txt_SimulateBehaviour_MonoBehaviour_MethodComponent_ScriptTemplete
                                .Replace("#ClassName#",m.className)
                                .Replace("#MethodName#", m.methodInfo.Name)
                                .Replace("#MethodClassify#", m.methodEnumValue.ToString())
                                .Replace("#MethodFormalParameters#", m.methodFormalParameters.Join())
                                .Replace("#MethodInputParameters#", m.methodInputParameters.Join())
                                .Replace("#SimulateBehaviourClassify#", m.simulateBehaviourClassify.ToString())
                                .Replace("#MethodOverridePrefix#", m.methodOverridePrefix)
                                ;
                            simulateBehaviour_MonoBehaviour_MethodComponent_Script_Maping.Add(m.className, txt_SimulateBehaviour_MonoBehaviour_MethodComponent_Script);

                            sbAbsMonoBehaviour_ISimulateBehaviour_MethodMap_Replace.Append(
                                absMonoBehaviour_ISimulateBehaviour_MethodMap_Templete
                                    .Replace("#EnumClassName#", txt_Hotfix_SimulateMonoBehaviour_Method_Enum_ClassName)
                                    .Replace("#EnumName#", m.methodEnumName)
                                    .Replace("#BehaviourClassName#",m.className)
                            );
                        }
                        #endregion
                        break;
                    case enEditorSimulateBehaviourClassify.UIBehaviour:
                        #region 收集要生成的模拟UIBehaviour的组件
                        if (!simulateBehaviour_UIBehaviour_MethodComponent_Script_Maping.ContainsKey(m.className))
                        {
                            txt_SimulateBehaviour_UIBehaviour_MethodComponent_Script =
                                txt_SimulateBehaviour_UIBehaviour_MethodComponent_ScriptTemplete
                                .Replace("#ClassName#", m.className)
                                .Replace("#MethodName#", m.methodInfo.Name)
                                .Replace("#MethodClassify#", m.methodEnumValue.ToString())
                                .Replace("#MethodFormalParameters#", m.methodFormalParameters.Join())
                                .Replace("#MethodInputParameters#", m.methodInputParameters.Join())
                                .Replace("#SimulateBehaviourClassify#", m.simulateBehaviourClassify.ToString())
                                .Replace("#MethodOverridePrefix#", m.methodOverridePrefix)
                                ;
                            simulateBehaviour_UIBehaviour_MethodComponent_Script_Maping.Add(m.className, txt_SimulateBehaviour_UIBehaviour_MethodComponent_Script);

                            sbAbsMonoBehaviour_ISimulateBehaviour_MethodMap_Replace.Append(
                                absMonoBehaviour_ISimulateBehaviour_MethodMap_Templete
                                    .Replace("#EnumClassName#", txt_Hotfix_SimulateMonoBehaviour_Method_Enum_ClassName)
                                    .Replace("#EnumName#", m.methodEnumName)
                                    .Replace("#BehaviourClassName#", m.className)
                            );
                        }
                        #endregion
                        break;
                }
                if (!tempMethodKey.Contains(m.simulateKey))
                {//如果没有相同的实现，则生成实现
                    tempMethodKey.Add(m.simulateKey);
                    #region 生成AbsMonoBehaviour的实现
                    sbAbsMonoBehaviour_ISimulateBehaviour_Method_Replace.Append(
                        absMonoBehaviour_ISimulateBehaviour_Method_Templete
                            .Replace("#Name#", m.methodInfo.Name)
                            .Replace("#VirtualName#", m.vrtualMethodName)
                            .Replace("#Parameter#", m.methodFormalParameters.Join())
                            .Replace("#ParameterArg#", m.methodInputParameters.Join())
                        );
                    #endregion

                    #region 生成ISimulateMonoBehaviour接口
                    sbRunning_ISimulateMonoBehaviour_Replace.Append(
                        running_ISimulateMonoBehaviour_Templete
                            .Replace("#Name#", m.methodInfo.Name)
                            .Replace("#Parameter#", m.methodFormalParameters.Join())
                        );                    
                    #endregion
                }
            }
        }
        #endregion

        #region 创建Hotfix的AbsMonoBehaviour_ISimulateMonoBehaviour_Method.cs文件

        #region AbsMonoBehaviour抽象在Hotfix中实现MonoBehaviour方法
        txt_Hotfix_AbsMonoBehaviour_ISimulateBehaviour_Method_Script =
            txt_AbsMonoBehaviour_SimulateBehaviour_Method_ScriptTemplete
            .Replace(absMonoBehaviour_ISimulateBehaviour_Method_ReplaceTemplete, sbAbsMonoBehaviour_ISimulateBehaviour_Method_Replace.ToString());
        #endregion

        EditorUtility.DisplayProgressBar("Create Hotfix Script", "AbsMonoBehaviour_ISimulateMonoBehaviour_Method.cs", 0);
        cfgEntityScript.SetDirectory(hotfix_SimulateBehaviourScriptRootFolder);
        cfgEntityScript.SetName(hotfix_AbsMonoBehaviour_ISimulateBehaviour_Method_ScriptName);
        cfgEntityScript.SetText(txt_Hotfix_AbsMonoBehaviour_ISimulateBehaviour_Method_Script);
        cfgEntityScript.CreateAsset();
        EditorUtility.DisplayProgressBar("Create Hotfix Script", "AbsMonoBehaviour_ISimulateMonoBehaviour_Method.cs", 1);
        #endregion

        #region 创建Hotfix的模拟Behaviour的通用枚举脚本
        if (enumValueNames.Count > 0)
        {
            progress = 0;
            foreach (KeyValuePair<int, string> key in enumValueNames)
            {
                #region 生成Behaviour枚举
                sbBehaviour_Enum_Replace.Append(
                    behaviour_Enum_Templete
                        .Replace("#Name#", key.Value)
                        .Replace("#Value#", key.Key.ToString())
                        .Replace("#Desc#", key.Value.TransDescToSummary())
                    );
                #endregion

                progress++;
                EditorUtility.DisplayProgressBar("Create SimulateBehaviour Enum", key.Value, progress / enumValueNames.Count);
            }
            txt_Hotfix_SimulateMonoBehaviour_Method_Enum_Script =
                txt_BehaviourEnum_ScriptTemplete
                .Replace("#EnumClassName#", txt_Hotfix_SimulateMonoBehaviour_Method_Enum_ClassName)
                .Replace(behaviour_Enum_ReplaceTemplete, sbBehaviour_Enum_Replace.ToString())
                ;

            cfgEntityScript.SetDirectory(hotfix_SimulateBehaviourScriptRootFolder);
            cfgEntityScript.SetName("Enum_" + txt_Hotfix_SimulateMonoBehaviour_Method_Enum_ClassName);
            cfgEntityScript.SetText(txt_Hotfix_SimulateMonoBehaviour_Method_Enum_Script);
            cfgEntityScript.CreateAsset();
        }
        #endregion

        #region 创建Running时SimulateMonoBehaviour组件脚本
        if (simulateBehaviour_MonoBehaviour_MethodComponent_Script_Maping.Count > 0)
        {
            progress = 0;
            foreach (KeyValuePair<string, string> key in simulateBehaviour_MonoBehaviour_MethodComponent_Script_Maping)
            {
                cfgEntityScript.SetDirectory(simulateBehaviour_MonoBehaviour_MethodComponent_Script_Folder);
                cfgEntityScript.SetName(key.Key);
                cfgEntityScript.SetText(key.Value);
                cfgEntityScript.CreateAsset();
                sbLog.AppendLine(cfgEntityScript.fileName);
                EditorUtility.DisplayProgressBar("Create SimulateMonoBehaviour Component",
                    cfgEntityScript.fileName, progress / simulateBehaviour_MonoBehaviour_MethodComponent_Script_Maping.Count);                
            }
        }
        #endregion

        #region 创建Running时SimulateUIBehaviour组件脚本
        if (simulateBehaviour_UIBehaviour_MethodComponent_Script_Maping.Count > 0)
        {
            progress = 0;
            foreach (KeyValuePair<string, string> key in simulateBehaviour_UIBehaviour_MethodComponent_Script_Maping)
            {
                cfgEntityScript.SetDirectory(simulateBehaviour_UIBehaviour_MethodComponent_Script_Folder);
                cfgEntityScript.SetName(key.Key);
                cfgEntityScript.SetText(key.Value);
                cfgEntityScript.CreateAsset();
                sbLog.AppendLine(cfgEntityScript.fileName);
                EditorUtility.DisplayProgressBar("Create SimulateUIBehaviour Component",
                    cfgEntityScript.fileName, progress / simulateBehaviour_UIBehaviour_MethodComponent_Script_Maping.Count);
            }
        }
        #endregion

        #region 创建Running时SimulateBehaviour枚举与方法映射脚本
        txt_Hotfix_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_Script =
            txt_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_ScriptTemplete
            .Replace("#SummaryEnumClassName#", txt_Hotfix_SimulateMonoBehaviour_Method_Enum_ClassName)
            .Replace(absMonoBehaviour_ISimulateBehaviour_MethodMap_ReplaceTemplete, sbAbsMonoBehaviour_ISimulateBehaviour_MethodMap_Replace.ToString())            
            ;
        cfgEntityScript.SetDirectory(hotfix_SimulateBehaviourScriptRootFolder);
        cfgEntityScript.SetName(hotfix_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_ScriptName);
        cfgEntityScript.SetText(txt_Hotfix_AbsMonoBehaviour_ISimulateBehaviour_MethodMap_Script);
        cfgEntityScript.CreateAsset();
        sbLog.AppendLine(cfgEntityScript.fileName);
        #endregion

        #region 创建ISimulateMonoBehaviour接口
        txt_Running_ISimulateMonoBehaviour_Script =
            txt_ISimulateMonoBehaviour_ScriptTemplete
            .Replace(running_ISimulateMonoBehaviour_ReplaceTemplete, sbRunning_ISimulateMonoBehaviour_Replace.ToString())
            ;
        cfgEntityScript.SetDirectory(runningSimulateBehaviourScriptRootFolder);
        cfgEntityScript.SetName(running_ISimulateMonoBehaviour_ScriptName);
        cfgEntityScript.SetText(txt_Running_ISimulateMonoBehaviour_Script);
        cfgEntityScript.CreateAsset();
        sbLog.AppendLine(cfgEntityScript.fileName);
        #endregion

        EditorUtility.ClearProgressBar();
        sbLog.AppendLine("ExecuteBuildSimulateMonoBehaviour Succeed!");
        Debug.Log(sbLog.ToString());
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();

    }
    #endregion

    #endregion

    #region Shader菜单

    #region ExecuteBuildDefaultShader 生成默认Shader
    /// <summary>
    /// 生成默认Shader
    /// </summary>
    public static void ExecuteBuildDefaultShader()
    {
        EditorBinaryAssetConfig txtCfg = new EditorBinaryAssetConfig("", enEditorApplicationFolder.Project_Shader.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Shader, null);
        FileExtAttribute attShader = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Shader);
        string directory = enEditorApplicationFolder.Editor_ResxTemplete_Shader.GetAttribute<EditorApplicationFolderAttribute>().path;
        string[] shaders = Directory.GetFileSystemEntries(directory,"*"+ attShader.ext, SearchOption.AllDirectories);
        StringBuilder sbLog = new StringBuilder();
        if (shaders != null && shaders.Length > 0)
        {
            string dest = string.Empty;
            string src = string.Empty;
            string dir = string.Empty;
            for (int i = 0; i < shaders.Length; i++)
            {
                src = shaders[i];
                dest = src.Replace(directory, txtCfg.directory).TransPathSeparatorCharToUnityChar();
                dir = Path.GetDirectoryName(dest);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.Copy(src, dest, true);
                EditorUtility.DisplayProgressBar("Build Shader", dest, (i+1) / (float)shaders.Length);
            }
        }
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("BuildDefaultShader Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #endregion

    #region Guide菜单

    #endregion

    #region Animator菜单

    #region ExecuteBuildAnimatorControllerFMSMaping 生成AnimatorControllerFMS映射
    /// <summary>
    /// 生成AnimatorControllerFMS映射
    /// </summary>
    public static void ExecuteBuildAnimatorControllerFMSMaping()
    {
        EditorFolderConfigForAnimatorControllerFMSMaping cfg = EditorStrayFogSavedAssetConfig.setFolderConfigForAnimatorControllerFMSMaping;
        StringBuilder sbLog = new StringBuilder();

        FileExtAttribute animatorControllerExt = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.AnimatorController);
        List<EditorSelectionAnimatorControllerFMSMapingAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAnimatorControllerFMSMapingAsset>(cfg.paths, enEditorAssetFilterClassify.Object, enEditorDependencyClassify.InClude, (n) => { return n.ext.Equals(animatorControllerExt.ext); });
        if (nodes != null && nodes.Count > 0)
        {
            sbLog.AppendLine(OnBuilderAnimatorControllerMaping(nodes));
        }

        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExecuteBuildAnimatorControllerFMSMaping Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #region OnBuilderAnimatorControllerMaping 生成AnimatorController管理器
    /// <summary>
    /// 生成AnimatorController管理器
    /// </summary>
    /// <param name="_nodes">节点</param>
    /// <returns>映射脚本路径</returns>
    static string OnBuilderAnimatorControllerMaping(List<EditorSelectionAnimatorControllerFMSMapingAsset> _nodes)
    {
        SortedDictionary<string, List<string>> stateForMachineMaping = new SortedDictionary<string, List<string>>();
        SortedDictionary<string, List<string>> machineForStateMaping = new SortedDictionary<string, List<string>>();
        SortedDictionary<string, List<int>> stateForLayerMaping = new SortedDictionary<string, List<int>>();
        SortedDictionary<int, List<string>> layerForStateMaping = new SortedDictionary<int, List<string>>();
        SortedDictionary<string, List<int>> machineForLayerMaping = new SortedDictionary<string, List<int>>();
        SortedDictionary<int, List<string>> layerForMachineMaping = new SortedDictionary<int, List<string>>();
        SortedDictionary<string, int> stateForNameHashMaping = new SortedDictionary<string, int>();
        SortedDictionary<string, int> parameterForNameHashMaping = new SortedDictionary<string, int>();        
        float progress = 0;
        int maxLayerIndex = 0;
        foreach (EditorSelectionAnimatorControllerFMSMapingAsset n in _nodes)
        {
            progress++;
            n.Resolver();
            maxLayerIndex = Mathf.Max(maxLayerIndex, n.maxLayerIndex);

            #region StateForLayer                      
            foreach (KeyValuePair<string, List<int>> key in n.stateForLayerMaping)
            {
                if (!stateForLayerMaping.ContainsKey(key.Key))
                {
                    stateForLayerMaping.Add(key.Key, new List<int>());
                }
                foreach (int v in key.Value)
                {
                    if (!stateForLayerMaping[key.Key].Contains(v))
                    {
                        stateForLayerMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver StateForLayer",
                            n.path, progress / _nodes.Count);
            #endregion

            #region LayerForState            
            foreach (KeyValuePair<int, List<string>> key in n.layerForStateMaping)
            {
                if (!layerForStateMaping.ContainsKey(key.Key))
                {
                    layerForStateMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!layerForStateMaping[key.Key].Contains(v))
                    {
                        layerForStateMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver LayerForState",
                            n.path, progress / _nodes.Count);
            #endregion

            #region MachineForLayer           
            foreach (KeyValuePair<string, List<int>> key in n.machineForLayerMaping)
            {
                if (!machineForLayerMaping.ContainsKey(key.Key))
                {
                    machineForLayerMaping.Add(key.Key, new List<int>());
                }
                foreach (int v in key.Value)
                {
                    if (!machineForLayerMaping[key.Key].Contains(v))
                    {
                        machineForLayerMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver MachineForLayer",
                            n.path, progress / _nodes.Count);
            #endregion

            #region LayerForMachine            
            foreach (KeyValuePair<int, List<string>> key in n.layerForMachineMaping)
            {
                if (!layerForMachineMaping.ContainsKey(key.Key))
                {
                    layerForMachineMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!layerForMachineMaping[key.Key].Contains(v))
                    {
                        layerForMachineMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver LayerForMachine",
                            n.path, progress / _nodes.Count);
            #endregion

            #region StateForMachine            
            foreach (KeyValuePair<string, List<string>> key in n.stateForMachineMaping)
            {
                if (!stateForMachineMaping.ContainsKey(key.Key))
                {
                    stateForMachineMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!stateForMachineMaping[key.Key].Contains(v))
                    {
                        stateForMachineMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver StateForMachine",
                            n.path, progress / _nodes.Count);
            #endregion

            #region MachineForState            
            foreach (KeyValuePair<string, List<string>> key in n.machineForStateMaping)
            {
                if (!machineForStateMaping.ContainsKey(key.Key))
                {
                    machineForStateMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!machineForStateMaping[key.Key].Contains(v))
                    {
                        machineForStateMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver MachineForState",
                            n.path, progress / _nodes.Count);
            #endregion

            #region EnumMachine           
            foreach (KeyValuePair<string, List<string>> key in n.machineForStateMaping)
            {
                if (!machineForStateMaping.ContainsKey(key.Key))
                {
                    machineForStateMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!machineForStateMaping[key.Key].Contains(v))
                    {
                        machineForStateMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver EnumMachine",
                            n.path, progress / _nodes.Count);
            #endregion

            #region EnumState
            foreach (KeyValuePair<string, int> key in n.stateForNameHashMaping)
            {
                if (!stateForNameHashMaping.ContainsKey(key.Key))
                {
                    stateForNameHashMaping.Add(key.Key, key.Value);
                }
            }
            EditorUtility.DisplayProgressBar("Resolver EnumState",
                            n.path, progress / _nodes.Count);
            #endregion

            #region EnumParameter            
            foreach (KeyValuePair<string, int> key in n.parameterForNameHashMaping)
            {
                if (!parameterForNameHashMaping.ContainsKey(key.Key))
                {
                    parameterForNameHashMaping.Add(key.Key, key.Value);
                }
            }
            EditorUtility.DisplayProgressBar("Resolver EnumParameter",
                            n.path, progress / _nodes.Count);
            #endregion
        }

        string editorFMSMachineMapingScriptTemplete = EditorResxTemplete.EditorFMSMachineMapingScriptTemplete;
        string editorFMSMachineMapingResult = editorFMSMachineMapingScriptTemplete;

        string editorFMSMachineMapingReplaceTemplete = string.Empty;
        string editorFMSMachineMapingFormatTemplete = string.Empty;
        string editorFMSMachineMapingReplaceTempleteA = string.Empty;
        string editorFMSMachineMapingFormatTempleteA = string.Empty;
        StringBuilder editorFMSMachineMapingSbTemplete = new StringBuilder();
        StringBuilder editorFMSMachineMapingSbTempleteA = new StringBuilder();

        #region StateForLayer
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#STATEFORLAYER#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTLAYER#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<string, List<int>> key in stateForLayerMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (int layer in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#LAYER#", layer.ToString()));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key)).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("StateForLayer",
                            "State=>" + key.Key, progress / stateForLayerMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region LayerForState
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#LAYERFORSTATE#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTSTATE#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<int, List<string>> key in layerForStateMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (string state in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(state.ToString())));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#LAYER#", key.Key.ToString()).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("LayerForState",
                            "Layer=>" + key.Key, progress / layerForStateMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region MachineForLayer
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#MACHINEFORLAYER#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTLAYER#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<string, List<int>> key in machineForLayerMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (int layer in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#LAYER#", layer.ToString()));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key)).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("MachineForLayer",
                            "Machine=>" + key.Key, progress / machineForLayerMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region LayerForMachine
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#LAYERFORMACHINE#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTMACHINE#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<int, List<string>> key in layerForMachineMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (string state in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(state.ToString())));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#LAYER#", key.Key.ToString()).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("LayerForMachine",
                            "Layer=>" + key.Key, progress / layerForMachineMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region StateForMachine
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#STATEFORMACHINE#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTMACHINE#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<string, List<string>> key in stateForMachineMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (string m in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(m)));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key)).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("StateForMachine",
                            "State=>" + key.Key, progress / stateForMachineMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region MachineForState
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#MACHINEFORSTATE#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTSTATE#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<string, List<string>> key in machineForStateMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (string s in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(s)));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key)).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("MachineForState",
                            "Machine=>" + key.Key, progress / machineForStateMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region EnumLayer
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#ENUMLAYER#", out editorFMSMachineMapingReplaceTemplete);
        progress = 0;
        for (int i = 0; i < maxLayerIndex; i++)
        {
            progress++;
            editorFMSMachineMapingSbTemplete.AppendLine(
                editorFMSMachineMapingFormatTemplete
                .Replace("#VALUE#", i.ToString()));
            EditorUtility.DisplayProgressBar("ENUMLAYER",
                            "Layer=>" + i, progress / maxLayerIndex);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region EnumMachine
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#ENUMMACHINE#", out editorFMSMachineMapingReplaceTemplete);
        progress = 0;
        foreach (string key in machineForStateMaping.Keys)
        {
            progress++;
            editorFMSMachineMapingSbTemplete.AppendLine(
                editorFMSMachineMapingFormatTemplete
                .Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key))
                .Replace("#VALUE#", key.UniqueHashCode().ToString())
                .Replace("#MACHINEDESC#", key));
            EditorUtility.DisplayProgressBar("EnumMachine",
                            "Machine=>" + key, progress / machineForStateMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region EnumState
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#ENUMSTATE#", out editorFMSMachineMapingReplaceTemplete);
        progress = 0;
        foreach (KeyValuePair<string, int> key in stateForNameHashMaping)
        {
            progress++;
            editorFMSMachineMapingSbTemplete.AppendLine(
                editorFMSMachineMapingFormatTemplete
                .Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key))
                .Replace("#VALUE#", key.Value.ToString())
                .Replace("#STATEDESC#", key.Key));
            EditorUtility.DisplayProgressBar("EnumState",
                            "State=>" + key, progress / stateForNameHashMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region EnumParameter
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#ENUMPARAMETER#", out editorFMSMachineMapingReplaceTemplete);
        progress = 0;
        foreach (KeyValuePair<string, int> key in parameterForNameHashMaping)
        {
            progress++;
            editorFMSMachineMapingSbTemplete.AppendLine(
                editorFMSMachineMapingFormatTemplete
                .Replace("#NAME#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key))
                .Replace("#VALUE#", key.Value.ToString()));
            EditorUtility.DisplayProgressBar("EnumParameter",
                            "Parameter=>" + key, progress / parameterForNameHashMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        editorFMSMachineMapingResult = EditorStrayFogUtility.regex.ClearRepeatCRLF(editorFMSMachineMapingResult);

        EditorTextAssetConfig cfgScript = new EditorTextAssetConfig("FMSMachineMaping", enEditorApplicationFolder.Game_Script_FMS.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.CS, "");

        cfgScript.SetText(editorFMSMachineMapingResult);
        cfgScript.CreateAsset();

        return cfgScript.fileName;
    }
    #endregion

    #endregion

    #region AnimCurve菜单

    #region ExecuteBuildAnimCurves 生成AnimCurve
    /// <summary>
    /// 生成AnimCurve
    /// </summary>
    public static void ExecuteBuildAnimCurves()
    {
        StringBuilder sbLog = new StringBuilder();
        Type act = typeof(IEditorAnimCurve);
        Type[] srcs = Assembly.GetExecutingAssembly().GetExportedTypes();
        List<Type> dest = new List<Type>();
        float progress = 0;
        List<EditorAnimCurve> animCurves = new List<EditorAnimCurve>();

        #region Find Setting
        if (srcs != null && srcs.Length > 0)
        {
            for (int i = 0; i < srcs.Length; i++)
            {
                if (srcs[i].IsSubTypeOf(act))
                {
                    dest.Add(srcs[i]);
                }
                progress++;
                EditorUtility.DisplayProgressBar("Find Setting", srcs[i].FullName, progress / srcs.Length);
            }
        }
        #endregion

        #region Collect Setting            
        sbLog.AppendLine("Collect Anim Curve Settings");
        if (dest.Count > 0)
        {
            progress = 0;
            for (int i = 0; i < dest.Count; i++)
            {
                animCurves.Add(new EditorAnimCurve((IEditorAnimCurve)Activator.CreateInstance(dest[i])));
                progress++;
                EditorUtility.DisplayProgressBar("Collect Setting", dest[i].FullName, progress / dest.Count);
                sbLog.AppendLine(string.Format("{0}=>{1}", (i + 1).PadLeft(dest.Count), dest[i].FullName));
            }
        }
        #endregion

        #region Build Anim Curve
        string folder = enEditorApplicationFolder.Game_Editor.GetAttribute<EditorApplicationFolderAttribute>().path;
        string path = Path.Combine(folder, "AnimCurveAsset" + typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Curves).ext).TransPathSeparatorCharToUnityChar();
        ScriptableObject library = ScriptableObject.CreateInstance(EditorStrayFogApplication.curvePresetLibrary);
        MethodInfo addMehtod = EditorStrayFogApplication.curvePresetLibrary.GetMethod("Add");
        sbLog.AppendLine("Add Anim Curve");
        if (animCurves.Count > 0)
        {
            progress = 0;
            for (int i = 0; i < animCurves.Count; i++)
            {
                addMehtod.Invoke(library, new object[]
                {
                        animCurves[i].curve,
                        animCurves[i].name
                });
                EditorUtility.DisplayProgressBar("Add Curve", animCurves[i].name, progress / dest.Count);
                sbLog.AppendLine(string.Format("{0}=>{1}", (i + 1).PadLeft(dest.Count), animCurves[i].name));
            }
        }
        AssetDatabase.CreateAsset(library, path);
        AssetDatabase.SaveAssets();
        EditorStrayFogApplication.PingObject(path);
        #endregion

        EditorUtility.ClearProgressBar();
        AssetDatabase.SaveAssets();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExecuteBuildAnimCurves Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #endregion

    #region SQLite菜单
    /// <summary>
    /// 导出XLS数据到SQLite
    /// </summary>
    public static void ExecuteExportXlsDataToSqlite()
    {
        StringBuilder sbLog = new StringBuilder();
        EditorStrayFogXLS.ExportXlsDataToSqlite((t,n,p)=> {
            EditorUtility.DisplayProgressBar(t, n, p);
        });
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExportXlsDataToSqlite Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #region XLS菜单

    #region ExecuteExportXlsSchemaToSqlite 生成Xls表结构到Sqlite数据库
    /// <summary>
    /// 生成Xls表结构到Sqlite数据库
    /// </summary>
    public static void ExecuteExportXlsSchemaToSqlite()
    {
        StringBuilder sbLog = new StringBuilder();
        EditorStrayFogXLS.ExportXlsSchemaToSQLite();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExecuteExportXlsSchemaToSqlite Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #endregion

    #region SpriteAtlas菜单

    #region ExecuteSetSpritePackingTag 设置SpritePackingTage
    /// <summary>
    /// 设置SpritePackingTage
    /// </summary>
    public static void ExecuteSetSpritePackingTag()
    {
        EditorFolderConfigForSetSpritePackingTag cfg = EditorStrayFogSavedAssetConfig.setFolderConfigForSetSpritePackingTag;
        StringBuilder sbLog = new StringBuilder();
        List<EditorSelectionSpritePackingTagAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionSpritePackingTagAsset>(cfg.paths, enEditorAssetFilterClassify.Texture2D);
        float progress = 0;
        foreach (EditorSelectionSpritePackingTagAsset n in nodes)
        {
            progress++;
            n.SaveSpritePackingTag();
            EditorUtility.DisplayProgressBar("Save Sprite Packing Tag", n.path, progress / nodes.Count);
        }        
        AssetDatabase.SaveAssets();
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExecuteSetSpritePackingTag Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #region ExecuteClearSpritePackingTag 清除SpritePackingTag
    /// <summary>
    /// 清除SpritePackingTag
    /// </summary>
    /// <returns>执行节点</returns>
    public static void ExecuteClearSpritePackingTag()
    {
        EditorFolderConfigForSetSpritePackingTag cfg = EditorStrayFogSavedAssetConfig.setFolderConfigForSetSpritePackingTag;
        StringBuilder sbLog = new StringBuilder();
        List<EditorSelectionSpritePackingTagAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionSpritePackingTagAsset>(cfg.paths, enEditorAssetFilterClassify.Texture2D);
        float progress = 0;
        foreach (EditorSelectionSpritePackingTagAsset n in nodes)
        {
            progress++;
            n.ClearSpritePackingTag();
            EditorUtility.DisplayProgressBar("Clear Sprite Packing Tag", n.path, progress / nodes.Count);
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.SaveAssets();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExecuteClearSpritePackingTag Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #region ExecuteClearAllSpritePackingTag 清除所有SpritePackingTag
    /// <summary>
    /// 清除所有SpritePackingTag
    /// </summary>
    public static void ExecuteClearAllSpritePackingTag()
    {
        StringBuilder sbLog = new StringBuilder();
        List<EditorSelectionSpritePackingTagAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionSpritePackingTagAsset>(
            new string[1] { Path.GetFileName(Application.dataPath) }, enEditorAssetFilterClassify.Texture2D);
        float progress = 0;
        foreach (EditorSelectionSpritePackingTagAsset n in nodes)
        {
            progress++;
            n.ClearSpritePackingTag();
            EditorUtility.DisplayProgressBar("Clear Sprite Packing Tag", n.path, progress / nodes.Count);
        }        
        AssetDatabase.SaveAssets();
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExecuteClearAllSpritePackingTag Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #endregion

    #region AssetBundle菜单

    #region ExecuteSetAssetBundleName 设置AssetBundleName
    /// <summary>
    /// 设置AssetBundleName
    /// </summary>
    public static void ExecuteSetAssetBundleName()
    {
        EditorFolderConfigForSetAssetBundleName cfg = EditorStrayFogSavedAssetConfig.setFolderConfigForSetAssetBundleName;
        StringBuilder sbLog = new StringBuilder();
        string error = string.Empty;

        List<EditorSelectionAssetBundleNameAsset> nodes = EditorStrayFogUtility.assetBundleName.Collect<EditorSelectionAssetBundleNameAsset>(cfg.paths, out error);
        if (string.IsNullOrEmpty(error))
        {
            if (nodes != null && nodes.Count > 0)
            {
                float progress = 0;
                Dictionary<int, EditorSelectionAssetBundleNameAsset> nodeMaping = new Dictionary<int, EditorSelectionAssetBundleNameAsset>();
                #region 构建拓扑起始节点                        
                foreach (EditorSelectionAssetBundleNameAsset n in nodes)
                {
                    if (!nodeMaping.ContainsKey(n.guidHashCode))
                    {
                        nodeMaping.Add(n.guidHashCode, n);
                    }
                    progress++;
                    EditorUtility.DisplayProgressBar("Build Topolopy Node", n.path, progress / nodes.Count);
                }
                #endregion

                #region 构建依赖链      
                progress = 0;
                foreach (EditorSelectionAssetBundleNameAsset n in nodes)
                {
                    n.BuildDependencyLink(nodeMaping);
                    progress++;
                    EditorUtility.DisplayProgressBar("Build DependencyLink", n.path, progress / nodes.Count);
                }
                #endregion

                #region 收缩合并                        
                OnRecursiveShrinkMerge(nodeMaping);
                #endregion

                #region 设置AssetBundleName
                progress = 0;
                foreach (EditorSelectionAssetBundleNameAsset n in nodeMaping.Values)
                {
                    progress++;
                    n.SaveAssetBundleName(null);
                    EditorUtility.DisplayProgressBar("Set AssetBundleName", n.path, progress / nodeMaping.Count);
                }
                #endregion
                                
                AssetDatabase.SaveAssets();                
                AssetDatabase.RemoveUnusedAssetBundleNames();
                

                #region 节点日志
                progress++;
                foreach (EditorSelectionAssetBundleNameAsset n in nodeMaping.Values)
                {
                    sbLog.AppendLine(n.ToLog());
                    EditorUtility.DisplayProgressBar("Build Log", n.path, progress / nodeMaping.Count);
                }                
                if (EditorStrayFogApplication.IsExecuteMethodInCmd())
                {
                    //Debug.Log(sbLog.ToString());
                }
                else
                {
                    string logFilename = Path.Combine(Path.GetTempPath(), "AssetBundleName.log");
                    File.WriteAllText(logFilename, sbLog.ToString());
                    sbLog.AppendLine(string.Format("Log=>{0}", logFilename));
                }
                #endregion

                EditorUtility.ClearProgressBar();
                EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
            }
        }
        else
        {
            Debug.LogError(error);
        }

        sbLog.AppendLine("ExecuteSetAssetBundleName Succeed!");
        Debug.Log(sbLog.ToString());
    }

    /// <summary>
    /// 递归收缩合并
    /// </summary>
    /// <param name="_nodeMaping">需要合并的节点</param>
    static void OnRecursiveShrinkMerge(Dictionary<int, EditorSelectionAssetBundleNameAsset> _nodeMaping)
    {
        float progress = 0;
        List<int> clear = new List<int>();
        StringBuilder sbLog = new StringBuilder();
        foreach (KeyValuePair<int, EditorSelectionAssetBundleNameAsset> key in _nodeMaping)
        {
            if (key.Value.ShrinkMerge() && !clear.Contains(key.Key))
            {
                clear.Add(key.Key);
            }
            progress++;
            EditorUtility.DisplayProgressBar("Recursive Shrink Merge", key.Value.path, progress / _nodeMaping.Count);
        }
        if (clear.Count > 0)
        {
            foreach (int c in clear)
            {
                _nodeMaping.Remove(c);
            }
            OnRecursiveShrinkMerge(_nodeMaping);
        }
    }
    #endregion

    #region ExecuteClearAllAssetBundleName 清除所有的AssetBundleName
    /// <summary>
    /// 清除所有的AssetBundleName
    /// </summary>
    public static void ExecuteClearAllAssetBundleName()
    {
        string[] names = AssetDatabase.GetAllAssetBundleNames();
        StringBuilder sbLog = new StringBuilder();
        if (names != null && names.Length > 0)
        {
            float progress = 0;
            for (int i = 0; i < names.Length; i++)
            {
                progress++;
                AssetDatabase.RemoveAssetBundleName(names[i], true);
                EditorUtility.DisplayProgressBar("Clear All AssetBundleName", names[i], progress / names.Length);
            }
            AssetDatabase.RemoveUnusedAssetBundleNames();
            AssetDatabase.SaveAssets();
            EditorUtility.ClearProgressBar();
        }
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExecuteClearAllAssetBundleName Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #endregion

    #region AssetDiskMaping菜单
    
    #region ExecuteBuildAllAssetDiskMaping 生成资源磁盘映射
    /// <summary>
    /// 资源磁盘映射文件夹枚举
    /// </summary>
    readonly static string msrEnumAssetDiskMapingFolder = "AssetDiskMapingFolder";
    /// <summary>
    /// 资源磁盘映射文件枚举
    /// </summary>
    readonly static string msrEnumAssetDiskMapingFile = "AssetDiskMapingFile";
    /// <summary>
    /// 生成资源磁盘映射
    /// </summary>
    public static void ExecuteBuildAllAssetDiskMaping()
    {
        EditorFolderConfigForSetAssetBundleName cfg = EditorStrayFogSavedAssetConfig.setFolderConfigForSetAssetBundleName;
        string error = string.Empty;
        if (cfg.paths.Length > 0)
        {            
            List<EditorSelectionAssetDiskMaping> nodes = EditorStrayFogUtility.assetBundleName.Collect<EditorSelectionAssetDiskMaping>(cfg.paths, out error);
            if (string.IsNullOrEmpty(error))
            {
                OnBuildSingleAssetDiskMaping(nodes);
            }
            else
            {
                Debug.LogError(error);
                throw new UnityException(error);
            }
        }
        else
        {
            error = "ExecuteBuildAllAssetDiskMaping , there are not SetAssetBundleName folders,please set.";
            EditorUtility.DisplayDialog("Error", error, "Yes", "No");
            throw new UnityException(error);
        }
    }

    /// <summary>
    /// 生成单个资源磁盘映射
    /// </summary>
    /// <param name="_nodes">节点</param>
    static void OnBuildSingleAssetDiskMaping(List<EditorSelectionAssetDiskMaping> _nodes)
    {
        StringBuilder sbLog = new StringBuilder();
        sbLog.AppendLine("Build Asset Disk Maping");
        if (_nodes != null && _nodes.Count > 0)
        {
            Dictionary<int, string> fileEnum = new Dictionary<int, string>();
            Dictionary<int, string> folderEnum = new Dictionary<int, string>();
            List<int> appendEnum = new List<int>();
            float progress = 0;

            #region 分析资源
            foreach (EditorSelectionAssetDiskMaping n in _nodes)
            {
                n.Resolve();
                progress++;
                EditorUtility.DisplayProgressBar("Resolve Node",
                                n.path, progress / (float)_nodes.Count);
            }
            #endregion

            EditorUtility.ClearProgressBar();

            #region 插入文件            
            progress = 0;
            foreach (EditorSelectionAssetDiskMaping n in _nodes)
            {
                if (!fileEnum.ContainsKey(n.fileId))
                {
                    fileEnum.Add(n.fileId, n.fileScriptEnumName);
                }
                progress++;
                EditorUtility.DisplayProgressBar("File Enum",
                                n.path, progress / (float)_nodes.Count);
            }
            EditorStrayFogXLS.InsertDataToAssetDiskMapingFile(_nodes, (n, p) =>
            {
                EditorUtility.DisplayProgressBar("Insert Data To AssetDiskMapingFile", n, p);
            });
            #endregion

            #region 插入目录
            progress = 0;
            foreach (EditorSelectionAssetDiskMaping n in _nodes)
            {
                if (!folderEnum.ContainsKey(n.folderId))
                {
                    folderEnum.Add(n.folderId, n.folderEnumName);
                }
                progress++;
                EditorUtility.DisplayProgressBar("Folder Enum",
                                n.path, progress / _nodes.Count);
            }
            EditorStrayFogXLS.InsertDataToAssetDiskMapingFolder(_nodes, (n, p) =>
            {
                EditorUtility.DisplayProgressBar("Insert Data To AssetDiskMapingFolder", n, p);
            });
            #endregion

            #region 枚举模板
            EditorTextAssetConfig cfgEnumScript = new EditorTextAssetConfig("", enEditorApplicationFolder.Game_Script_AssetDiskMaping.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.CS, "");
            string assetDiskMapingScriptTemplete = EditorResxTemplete.AssetDiskMapingEnumTemplete;

            string enumMark = "#Enums#";
            string enumReplaceTemplete = string.Empty;
            string enumTemplete = string.Empty;
            StringBuilder sbEnumTableReplace = new StringBuilder();
            enumTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(assetDiskMapingScriptTemplete, enumMark, out enumReplaceTemplete);
            #endregion

            #region 生成目录枚举
            progress = 0;
            appendEnum.Clear();
            cfgEnumScript.SetName("Enum" + msrEnumAssetDiskMapingFolder);

            foreach (KeyValuePair<int, string> key in folderEnum)
            {
                progress++;
                sbEnumTableReplace.Append(
                  enumTemplete.Replace("#Name#", key.Value)
                  .Replace("#HashCode#", key.Key.ToString())
                    );
                EditorUtility.DisplayProgressBar("Build Folder Enum",
                                key.Value, progress / folderEnum.Count);
            }
            cfgEnumScript.SetText(assetDiskMapingScriptTemplete
                .Replace("#EnumName#", cfgEnumScript.name.Remove(0, 4))
                .Replace(enumReplaceTemplete, sbEnumTableReplace.ToString()));
            cfgEnumScript.CreateAsset();
            #endregion

            #region 生成文件枚举
            progress = 0;
            sbEnumTableReplace.Length = 0;
            appendEnum.Clear();
            cfgEnumScript.SetName("Enum" + msrEnumAssetDiskMapingFile);

            foreach (KeyValuePair<int, string> key in fileEnum)
            {
                progress++;
                sbEnumTableReplace.Append(
                  enumTemplete.Replace("#Name#", key.Value)
                  .Replace("#HashCode#", key.Key.ToString())
                    );
                EditorUtility.DisplayProgressBar("Build File Enum",
                                key.Value, progress / fileEnum.Count);
            }
            cfgEnumScript.SetText(assetDiskMapingScriptTemplete
                .Replace("#EnumName#", cfgEnumScript.name.Remove(0,4))
                .Replace(enumReplaceTemplete, sbEnumTableReplace.ToString()));
            cfgEnumScript.CreateAsset();
            #endregion

            EditorUtility.ClearProgressBar();
        }
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExecuteBuildSingleAssetDiskMaping Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #endregion

    #region XLua菜单

    #region ExportXLuaMapToXLS 导出XLua映射到XLS表
    /// <summary>
    /// 导出XLua映射到XLS表
    /// </summary>
    public static void ExportXLuaMapToXLS()
    {
        StringBuilder sbLog = new StringBuilder();                
        EditorStrayFogXLS.InsertXLuaMap((m, p) => {
            EditorUtility.DisplayProgressBar("Insert XLuaMap", m, p);
        });
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExportXLuaMapToXLS Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #endregion

    #region Dll菜单

    #region ExecuteLookPackageDll 查看要打包的dll
    /// <summary>
    /// 查看要打包的dll
    /// </summary>
    /// <returns>执行节点</returns>
    public static List<EditorSelectionAssetBundleNameAsset> ExecuteLookPackageDll()
    {
        List<EditorSelectionAssetBundleNameAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAssetBundleNameAsset>(
            new string[1] { enEditorApplicationFolder.Game.GetAttribute<EditorApplicationFolderAttribute>().path }, "", enEditorDependencyClassify.UnClude,
            (n) => { return EditorStrayFogUtility.assetBundleName.IsDllPlugins(n); });
        StringBuilder sbLog = new StringBuilder();
        sbLog.AppendLine("Package Dll");
        float progress = 0;
        foreach (EditorSelectionAssetBundleNameAsset n in nodes)
        {
            progress++;
            sbLog.AppendLine(n.path);
            EditorUtility.DisplayProgressBar("Build Log", n.path, progress / nodes.Count);
        }
        EditorUtility.ClearProgressBar();
        sbLog.AppendLine("ExecuteLookPackageDll Succeed!");
        Debug.Log(sbLog.ToString());
        return nodes;
    }
    #endregion   

    #region ExecuteBuildDllToPackage 生成dll到包
    /// <summary>
    /// 生成dll到包
    /// </summary>
    public static void ExecuteBuildDllToPackage()
    {
        float progress = 0;
        StringBuilder sbLog = new StringBuilder();
        List<EditorSelectionAssetBundleNameAsset> nodes = ExecuteLookPackageDll();
        foreach (EditorSelectionAssetBundleNameAsset n in nodes)
        {
            progress++;
            if (!string.IsNullOrEmpty(n.GetAssetBundleName()))
            {
                File.Copy(n.path, Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot, n.GetAssetBundleName()));
            }
            else
            {
                Debug.LogErrorFormat("Dll 【{0}】's AssetBundleName is empty.", n.path);
            }
            EditorUtility.DisplayProgressBar("Build Log", n.path, progress / nodes.Count);
        }
        EditorUtility.ClearProgressBar();
        sbLog.AppendLine("ExecuteBuildDllToPackage Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #region ExecuteBuildDynamicDll 生成动态Dll
    /// <summary>
    /// 动态Dll名称
    /// </summary>
    const string mDynamicDllName = "StrayFogDynamic";
    /// <summary>
    /// 获得动态Dll文件名称
    /// </summary>
    /// <returns>Dll文件名称</returns>
    static string OnGetDynamicDllFileName()
    {
        return mDynamicDllName + typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Dll).ext;
    }
    /// <summary>
    /// 生成动态Dll
    /// </summary>
    /// <returns>是否成功</returns>
    public static bool ExecuteBuildDynamicDll()
    {
        bool isSuccess = false;
        
        EditorCsFileConfigForDynamicCreateDll file = EditorStrayFogSavedAssetConfig.setCsFileConfigForDynamicCreateDll;
        EditorDllSaveFolderConfigForDynamicCreateDll folder = EditorStrayFogSavedAssetConfig.setDllSaveFolderConfigForDynamicCreateDll;
        enEditorCodeProviderLanguage language = enEditorCodeProviderLanguage.CSharp;

        CodeDomProvider provider = CodeDomProvider.CreateProvider(language.ToString());
        if (provider != null)
        {
            isSuccess = true;
            StringBuilder sbLog = new StringBuilder();
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = false;            

            List<string> srcFiles = new List<string>();
            List<MonoScript> srcMonoScripts = new List<MonoScript>();
            foreach (string f in file.paths)
            {
                srcFiles.Add(f.TransPathSeparatorCharToWindowChar());
                srcMonoScripts.Add((MonoScript)AssetDatabase.LoadMainAssetAtPath(f));
            }

            string assemblyLocation = string.Empty;
            Type classType = null;
            foreach (MonoScript m in srcMonoScripts)
            {
                classType = m.GetClass();
                if (classType != null)
                {
                    assemblyLocation = classType.Assembly.Location;
                    if (!compilerParams.ReferencedAssemblies.Contains(assemblyLocation))
                    {
                        compilerParams.ReferencedAssemblies.Add(assemblyLocation);
                    }

                    AssemblyName[] ans = classType.Assembly.GetReferencedAssemblies();
                    if (ans != null)
                    {
                        foreach (AssemblyName n in ans)
                        {
                            assemblyLocation = Assembly.Load(n.Name).Location;
                            if (!compilerParams.ReferencedAssemblies.Contains(assemblyLocation))
                            {
                                compilerParams.ReferencedAssemblies.Add(assemblyLocation);
                            }
                        }
                    }
                }                        
            }

            float progress = 0;
            string log = string.Empty;
            
            for (int i = 0; i < folder.paths.Length; i++)
            {
                compilerParams.OutputAssembly = Path.GetFullPath(Path.Combine(folder.paths[i], OnGetDynamicDllFileName()).TransPathSeparatorCharToWindowChar());                
                CompilerResults result = provider.CompileAssemblyFromFile(compilerParams, srcFiles.ToArray());
                isSuccess &= !result.Errors.HasErrors;
                if (result.Errors.HasErrors)
                {
                    for (int e = 0; e < result.Errors.Count; e++)
                    {
                        Debug.LogError(result.Errors[e].JsonSerialize());
                    }
                }
                progress = (i + 1) / (float)folder.paths.Length;
                log = string.Format("Builder Dll to =>{0}", compilerParams.OutputAssembly);
                sbLog.AppendLine(log);
                EditorUtility.DisplayProgressBar("Build Dynamic Dll", log, progress);
            }
            EditorUtility.ClearProgressBar();
            Debug.Log(sbLog.ToString());
        }
        else
        {
            Debug.LogFormat("Can't not CreateProvider 【{0}】", language.ToString());
        }
        return isSuccess;
    }
    #endregion
    #endregion

    #region Asmdef菜单

    #region FindAsmdefByAssembly 查的程序集所属的Asmdef
    /// <summary>
    /// 程序集与Asmdef映射
    /// </summary>
    static Dictionary<int, int> mAssemblyForAsmdefMaping = new Dictionary<int, int>();
    /// <summary>
    /// 查的程序集所属的Asmdef
    /// </summary>
    /// <param name="_assembly">程序集</param>
    /// <returns>Asmdef数据id</returns>
    public static int FindAssemblyForAsmdef(Assembly _assembly)
    {
        int key = _assembly.GetName().FullName.UniqueHashCode();
        if (!mAssemblyForAsmdefMaping.ContainsKey(key))
        {
            List<EditorSelectionAsmdefMapSetting> asmdefs = CollectAsmdef();
            foreach (EditorSelectionAsmdefMapSetting m in asmdefs)
            {
                m.Resolve();
                if (_assembly.ManifestModule.FullyQualifiedName.ToUpper().TransPathSeparatorCharToUnityChar().EndsWith(m.asmdefDllPath.ToUpper().TransPathSeparatorCharToUnityChar()))
                {
                    mAssemblyForAsmdefMaping.Add(key, m.asmdefId);
                    break;
                }
            }
        }
        return mAssemblyForAsmdefMaping.ContainsKey(key) ? mAssemblyForAsmdefMaping[key] : 0;
    }
    #endregion


    #region CollectAsmdef 收集Asmdef
    /// <summary>
    /// 查看要打包的Asmdef
    /// </summary>
    /// <returns>执行节点</returns>
    public static List<EditorSelectionAsmdefMapSetting> CollectAsmdef()
    {
        return EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAsmdefMapSetting>(
            new string[1] { Path.GetFileName(Application.dataPath) }, "", enEditorDependencyClassify.UnClude,
            (n) => { return EditorStrayFogUtility.assetBundleName.IsAsmdef(n); }, false);
    }
    #endregion

    #region ExecuteLookPackageAsmdef 查看要打包的Asmdef
    /// <summary>
    /// 查看要打包的Asmdef
    /// </summary>
    /// <returns>执行节点</returns>
    public static List<EditorSelectionAsmdefMapSetting> ExecuteLookPackageAsmdef()
    {
        List<EditorSelectionAsmdefMapSetting> nodes = CollectAsmdef();
        StringBuilder sbLog = new StringBuilder();
        sbLog.AppendLine("Package Asmdef");
        float progress = 0;
        foreach (EditorSelectionAssetBundleNameAsset n in nodes)
        {
            progress++;
            sbLog.AppendLine(n.path);
            EditorUtility.DisplayProgressBar("Build Log", n.path, progress / nodes.Count);
        }
        EditorUtility.ClearProgressBar();
        sbLog.AppendLine("ExecuteLookPackageAsmdef Succeed!");
        Debug.Log(sbLog.ToString());
        return nodes;
    }
    #endregion

    #region ExecuteAsmdefToXLS 生成Asmdef到XLS表
    /// <summary>
    /// 生成Asmdef到XLS表
    /// </summary>
    public static void ExecuteAsmdefToXLS()
    {
        StringBuilder sbLog = new StringBuilder();
        EditorStrayFogXLS.InsertAsmdefMap((m, p) =>
        {
            EditorUtility.DisplayProgressBar("Insert AsmdefMap", m, p);
        });
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExportAsmdefMapToXLS Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #region ExecuteBuildAsmdefToPackage 生成Asmdef到包
    /// <summary>
    /// 生成Asmdef到包
    /// </summary>
    public static void ExecuteBuildAsmdefToPackage()
    {
        float progress = 0;
        StringBuilder sbLog = new StringBuilder();
        List<EditorSelectionAsmdefMapSetting> nodes = ExecuteLookPackageAsmdef();
        foreach (EditorSelectionAsmdefMapSetting n in nodes)
        {
            progress++;
            n.Resolve();
            if (File.Exists(n.asmdefDllPath))
            {
                File.Copy(n.asmdefDllPath, Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot,
                    n.asmdefDllAssetbundleName), true);
            }
            else
            {
                Debug.LogErrorFormat("Can't find Asmdef maping dll【{0}】", n.asmdefDllPath);
            }
            if (File.Exists(n.asmdefPdbPath))
            {
                File.Copy(n.asmdefPdbPath, Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot,
                    n.asmdefPdbAssetbundleName), true);
            }
            else
            {
                Debug.LogErrorFormat("Can't find Asmdef maping dll【{0}】", n.asmdefDllPath);
            }

            EditorUtility.DisplayProgressBar("Build Log", n.path, progress / nodes.Count);
        }
        EditorUtility.ClearProgressBar();
        sbLog.AppendLine("ExecuteBuildAsmdefToPackage Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion
    #endregion

    #region Release菜单

    #region ExecuteBuildPackage 发布包
    /// <summary>
    /// 发布包
    /// </summary>
    public static void ExecuteBuildPackage()
    {
        EditorStrayFogApplication.IsInternalWhenUseSQLiteInEditorForResourceLoadMode();
        
        string path = Path.GetFullPath(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot);
        StringBuilder sbLog = new StringBuilder();
        #region 清理包目录
        EditorUtility.DisplayProgressBar("BuildPackage", string.Format("Clear AssetBundleRoot=>{0}", path), 0);
        List<EditorSelectionAssetBundleNameAsset> dlls = new List<EditorSelectionAssetBundleNameAsset>();
        EditorStrayFogUtility.cmd.DeleteFolder(path);
        if (Directory.Exists(path))
        {
            string error = string.Format("The folder can't delete, it will restart editor.");
            if (EditorUtility.DisplayDialog("Error", error, "Yes", "No"))
            {
                EditorStrayFogUtility.cmd.Restart();
            }
            throw new UnityException(error);
        }
        else
        {
            Directory.CreateDirectory(path);
        }
        #endregion

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteClearAllSpritePackingTag", 0);
        ExecuteClearAllSpritePackingTag();

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteClearAllAssetBundleName", 0);
        ExecuteClearAllAssetBundleName();

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteSetSpritePackingTag", 0);
        ExecuteSetSpritePackingTag();

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteSetAssetBundleName", 0);
        ExecuteSetAssetBundleName();

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteBuildSimulateBehaviour", 0);
        ExecuteBuildSimulateBehaviour();

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteExportXlsSchemaToSqlite", 0);
        ExecuteExportXlsSchemaToSqlite();

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteBuildAllXlsData", 0);
        OnExecuteBuildAllXlsData((t, p) =>
        {
            EditorUtility.DisplayProgressBar("BuildPackage", t, p);
        });

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteBuildDllToPackage", 0);
        ExecuteBuildDllToPackage();

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteBuildAsmdefToPackage", 0);
        ExecuteBuildAsmdefToPackage();

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteCopySQLiteDbToPackage", 0);
        ExecuteCopySQLiteDbToPackage();

        EditorUtility.DisplayProgressBar("BuildPackage", "ExecuteBuildBatToPackage", 0);
        ExecuteBuildBatToPackage();

        EditorUtility.DisplayProgressBar("BuildPackage", "BuildAssetBundles", 0);
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        BuildPipeline.BuildAssetBundles(path,
            BuildAssetBundleOptions.ChunkBasedCompression,
            EditorUserBuildSettings.activeBuildTarget);
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        EditorStrayFogUtility.cmd.ExcuteFile(Path.GetFullPath(mPackageManifestBat.fileName));
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        EditorUtility.RevealInFinder(path);
        sbLog.AppendLine(path);
        sbLog.AppendLine("ExecuteBuildPackage Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #region ExecuteBuildBatToPackage 生成打包后的bat批处理文件
    /// <summary>
    /// 打包Manifest批处理
    /// </summary>
    static readonly EditorTextAssetConfig mPackageManifestBat = new EditorTextAssetConfig("PackageManifest", enEditorApplicationFolder.Game_Editor_Bat.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Bat, EditorResxTemplete.Cmd_PackageManifestTemplete);

    /// <summary>
    /// DebugProfiler批处理
    /// </summary>
    static readonly EditorTextAssetConfig mDebugProfilerBat = new EditorTextAssetConfig("DebugProfiler", enEditorApplicationFolder.Game_Editor_Bat.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Bat, EditorResxTemplete.Cmd_DebugProfilerTemplete);

    /// <summary>
    /// ClearSvn批处理
    /// </summary>
    static readonly EditorTextAssetConfig mClearSvnReg = new EditorTextAssetConfig("ClearSvn", enEditorApplicationFolder.Game_Editor_Bat.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Bat, EditorResxTemplete.Cmd_ClearSvnTemplete);

    /// <summary>
    /// PlayerLog批处理
    /// </summary>
    static readonly EditorTextAssetConfig mPlayerLog = new EditorTextAssetConfig("PlayerLog", enEditorApplicationFolder.Game_Editor_Bat.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Bat, EditorResxTemplete.Cmd_PlayerLogTemplete);
    
    /// <summary>
    /// 生成打包后的bat批处理文件
    /// </summary>
    public static void ExecuteBuildBatToPackage()
    {
        StringBuilder sbLog = new StringBuilder();
        EditorTextAssetConfig packageManifestBat = (EditorTextAssetConfig)mPackageManifestBat.Clone();
        EditorTextAssetConfig debugProfilerBat = (EditorTextAssetConfig)mDebugProfilerBat.Clone();
        EditorTextAssetConfig clearSvnRegBat = (EditorTextAssetConfig)mClearSvnReg.Clone();
        EditorTextAssetConfig playerLogBat = (EditorTextAssetConfig)mPlayerLog.Clone();

        string path = Path.GetFullPath(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot);
        string scriptTemplete = packageManifestBat.text;
        string replaceTemplete = string.Empty;
        string formatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(scriptTemplete, @"#BatCmd#", out replaceTemplete);
        StringBuilder sbTemplete = new StringBuilder();
        string[] directories = new string[0];
        if (Directory.Exists(path))
        {
            directories = Directory.GetDirectories(path);
        }        
        foreach (string key in directories)
        {
            sbTemplete.AppendLine(formatTemplete.Replace("#Folder#", key));
        }
        sbTemplete.AppendLine(formatTemplete.Replace("#Folder#", path));
        string result = scriptTemplete.Replace(replaceTemplete, sbTemplete.ToString());
        result = EditorStrayFogUtility.regex.ClearRepeatCRLF(result);
        packageManifestBat.SetText(result);
        packageManifestBat.CreateAsset();

        debugProfilerBat.SetText(debugProfilerBat.text.Replace("#DebugProfiler#", PlayerSettings.applicationIdentifier));
        debugProfilerBat.CreateAsset();

        clearSvnRegBat.CreateAsset();


        playerLogBat.SetText(playerLogBat.text.Replace("#Path#",
            Regex.Replace(Application.persistentDataPath, "/" + Environment.UserName + "/", "/%username%/")));
        playerLogBat.CreateAsset();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        sbLog.AppendLine("ExecuteBuildBatToPackage Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #region ExecuteCopySQLiteDbToPackage 复制SQLite数据库到包
    /// <summary>
    /// 复制SQLite数据库到包
    /// </summary>
    public static void ExecuteCopySQLiteDbToPackage()
    {
        StringBuilder sbLog = new StringBuilder();
        List<EditorXlsTableSchema> tables = EditorStrayFogXLS.ReadXlsSchema();
        List<int> dbKeys = new List<int>();
        if (tables != null && tables.Count > 0)
        {
            float progress = 0;
            foreach (EditorXlsTableSchema t in tables)
            {
                progress++;
                EditorUtility.DisplayProgressBar("Copy SQLiteDb To Package", t.dbPath, progress);
                if (!dbKeys.Contains(t.dbKey))
                {
                    dbKeys.Add(t.dbKey);
                    string db = Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot, t.assetBundleDbName);
                    string dir = Path.GetDirectoryName(db);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }                    
                    File.Copy(t.dbPath, db,true);
                }
            }
        }
        EditorUtility.ClearProgressBar();
        sbLog.AppendLine("ExecuteBuildSQLiteDbToPackage Succeed!");
        Debug.Log(sbLog.ToString());
    }
    #endregion

    #region ExecuteBuildAllXlsData 生成所有XLS表数据
    /// <summary>
    /// 生成所有XLS表数据
    /// </summary>
    public static void ExecuteBuildAllXlsData()
    {
        OnExecuteBuildAllXlsData(null);
    }

    /// <summary>
    /// 生成所有XLS表数据
    /// </summary>
    /// <param name="_displayProgressBar">显示进度条</param>
    static void OnExecuteBuildAllXlsData(Action<string,float> _displayProgressBar)
    {
        _displayProgressBar?.Invoke("ExecuteBuildAllAssetDiskMaping", 0);
        ExecuteBuildAllAssetDiskMaping();

        _displayProgressBar?.Invoke("ExecuteBuildUIWindowSetting", 0);
        ExecuteBuildUIWindowSetting();

        _displayProgressBar?.Invoke("ExportXLuaMapToXLS", 0);
        ExportXLuaMapToXLS();

        _displayProgressBar?.Invoke("ExecuteAsmdefToXLS", 0);
        ExecuteAsmdefToXLS();

        _displayProgressBar?.Invoke("ExecuteExportXlsDataToSqlite", 0);
        ExecuteExportXlsDataToSqlite();
    }
    #endregion
    #endregion
}
#endif