using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 编辑器程序集
/// </summary>
public sealed class EditorStrayFogAssembly
{
    #region IsExistsTypeInApplication 当前应用程序域是否有指定类型
    /// <summary>
    /// 当前应用程序域是否有指定类型
    /// </summary>
    /// <param name="_typeName">类型名称</param>
    /// <returns>True:有,False:否</returns>
    public static bool IsExistsTypeInApplication(string _typeName)
    {
        Assembly assembly = GetApplicationAssembly();
        Type type = assembly.GetType(_typeName);
        return type != null;
    }
    #endregion

    #region GetApplicationAssembly 获得当前应用程序域运行的程序集
    /// <summary>
    /// 获得当前应用程序域运行的程序集
    /// </summary>
    /// <returns>程序集</returns>
    public static Assembly GetApplicationAssembly()
    {
        string path = Path.GetFullPath("Library/ScriptAssemblies/Assembly-CSharp.dll");
        return File.Exists(path) ? Assembly.LoadFrom(path) : null;
    }
    #endregion

    #region GetUnityEngineAssembly 获得UnityEngine程序集
    /// <summary>
    /// 获得UnityEngine程序集
    /// </summary>
    /// <returns>程序集</returns>
    public static Assembly GetUnityEngineAssembly()
    {
        return Assembly.LoadFrom(EditorApplication.applicationContentsPath + @"/Managed/UnityEngine.dll");
    }
    #endregion

    #region GetEditorApplicationAssembly 获得当前应用程序域运行的Editor程序集
    /// <summary>
    /// 获得当前应用程序域运行的Editor程序集
    /// </summary>
    /// <returns>程序集</returns>
    public static Assembly GetEditorApplicationAssembly()
    {
        string path = Path.GetFullPath("Library/ScriptAssemblies/Assembly-CSharp-Editor.dll");
        return File.Exists(path) ? Assembly.LoadFrom(path) : null;
    }
    #endregion

    #region GetUnityEditorAssembly 获得UnityEditor程序集
    /// <summary>
    /// 获得UnityEditor程序集
    /// </summary>
    /// <returns>程序集</returns>
    public static Assembly GetUnityEditorAssembly()
    {
        return Assembly.LoadFrom(EditorApplication.applicationContentsPath + @"/Managed/UnityEditor.dll");
    }
    #endregion

    #region GetApplicationExportedTypes 获得应用程序域继承于指定类别的所有类别组
    /// <summary>
    /// 获得应用程序域继承于指定类别的所有类别组
    /// </summary>
    /// <returns>类别组</returns>
    public static Type[] GetApplicationExportedTypes(Type _parentType)
    {
        Type[] srcs = GetApplicationAssembly().GetExportedTypes();
        List<Type> dest = new List<Type>();
        if (srcs != null && srcs.Length > 0)
        {
            for (int i = 0; i < srcs.Length; i++)
            {
                if (srcs[i].IsTypeOrSubTypeOf(_parentType))
                {
                    dest.Add(srcs[i]);
                }
            }
        }
        return dest.ToArray();
    }
    #endregion

    #region GetEditorApplicationExportedTypes 获得Editor域下继承于指定类别的所有类别组
    /// <summary>
    /// 获得Editor域下继承于指定类别的所有类别组
    /// </summary>
    /// <returns>类别组</returns>
    public static Type[] GetEditorApplicationExportedTypes(Type _parentType)
    {
        Type[] srcs = GetEditorApplicationAssembly().GetExportedTypes();
        List<Type> dest = new List<Type>();
        if (srcs != null && srcs.Length > 0)
        {
            for (int i = 0; i < srcs.Length; i++)
            {
                if (srcs[i].IsTypeOrSubTypeOf(_parentType))
                {
                    dest.Add(srcs[i]);
                }
            }
        }
        return dest.ToArray();
    }
    #endregion

    #region GetUnityEditorExportedTypes 获得UnityEditor下继承于指定类别的所有类别组
    /// <summary>
    /// 获得UnityEditor下继承于指定类别的所有类别组
    /// </summary>
    /// <returns>类别组</returns>
    public static Type[] GetUnityEditorExportedTypes(Type _parentType)
    {
        Type[] srcs = GetUnityEditorAssembly().GetTypes();
        List<Type> dest = new List<Type>();
        if (srcs != null && srcs.Length > 0)
        {
            for (int i = 0; i < srcs.Length; i++)
            {
                if (srcs[i].IsTypeOrSubTypeOf(_parentType))
                {
                    dest.Add(srcs[i]);
                }
            }
        }
        return dest.ToArray();
    }
    #endregion

    #region GetUnityEngineExportedTypes 获得UnityEngine下继承于指定类别的所有类别组
    /// <summary>
    /// 获得UnityEngine下继承于指定类别的所有类别组
    /// </summary>
    /// <returns>类别组</returns>
    public static Type[] GetUnityEngineExportedTypes(Type _parentType)
    {
        Type[] srcs = GetUnityEngineAssembly().GetTypes();
        List<Type> dest = new List<Type>();
        if (srcs != null && srcs.Length > 0)
        {
            for (int i = 0; i < srcs.Length; i++)
            {
                if (srcs[i].IsTypeOrSubTypeOf(_parentType))
                {
                    dest.Add(srcs[i]);
                }
            }
        }
        return dest.ToArray();
    }
    #endregion

    #region GetType 获得类别
    /// <summary>
    /// 获得类别
    /// </summary>
    /// <param name="_name">类别名称</param>
    public static Type GetType(string _name)
    {
        Assembly assembly = null;
        return GetType(_name, ref assembly);
    }

    /// <summary>
    /// 获得类别
    /// </summary>
    /// <param name="_typeName">类别名称</param>
    /// <param name="_assembly">程序集</param>
    /// <returns>类别</returns>
    public static Type GetType(string _typeName, ref Assembly _assembly)
    {
        Type type = null;
        List<Assembly> assemblies = GetDynamicAssemblies();
        if (assemblies != null && assemblies.Count > 0)
        {
            foreach (Assembly m in assemblies)
            {
                type = m.GetType(_typeName);
                if (type == null)
                {
                    type = m.GetType(m.GetName().Name + "." + _typeName);
                }
                if (type != null)
                {
                    _assembly = m;
                    break;
                }
            }
        }
        return type;
    }
    #endregion

    #region GetExportedTypes 获得继承于指定类别的所有类别组
    /// <summary>
    /// 子类组映射
    /// </summary>
    static Dictionary<int, List<Type>> mExportedTypesMaping = new Dictionary<int, List<Type>>();
    /// <summary>
    /// 获得继承于指定类别的所有类别组
    /// </summary>
    /// <param name="_parentType">父类别</param>
    /// <returns>类别组</returns>
    public static List<Type> GetExportedTypes(Type _parentType)
    {
        int key = _parentType.GetHashCode();
        if (!mExportedTypesMaping.ContainsKey(key))
        {
            mExportedTypesMaping.Add(key, new List<Type>());
            Type[] types = null;
            foreach (Assembly m in GetDynamicAssemblies())
            {
                types = m.GetExportedTypes();
                if (types != null && types.Length > 0)
                {
                    foreach (Type t in types)
                    {
                        if (t.IsTypeOrSubTypeOf(_parentType))
                        {
                            mExportedTypesMaping[key].Add(t);
                        }
                    }
                }
            }
        }
        return mExportedTypesMaping[key];
    }
    #endregion

    #region GetDynamicAssemblies 获得动态程序集组
    /// <summary>
    /// 获得动态程序集组
    /// </summary>
    /// <returns>程序集组</returns>
    public static List<Assembly> GetDynamicAssemblies()
    {
        List<EditorSelectionAsset> dlls =
            EditorStrayFogUtility.collectAsset.CollectAsset(
                new string[1] { EditorStrayFogApplication.TryRelativeToProject("") }, "",
                false, (n) => { return n.ext.Equals(enFileExt.Dll.GetAttribute<FileExtAttribute>().ext); });
        List<Assembly> assemblies = new List<Assembly>();
        Assembly tempAssembly = null;
        if (dlls != null && dlls.Count > 0)
        {
            foreach (EditorSelectionAsset d in dlls)
            {
                try
                {
                    assemblies.Add(Assembly.LoadFrom(d.path));
                }
                catch (Exception ep)
                {
                    Debug.Log(ep.Message);
                }
            }
        }
        tempAssembly = GetApplicationAssembly();
        if (tempAssembly != null)
        {
            assemblies.Add(tempAssembly);
        }
        tempAssembly = GetEditorApplicationAssembly();
        if (tempAssembly != null)
        {
            assemblies.Add(tempAssembly);
        }
        assemblies.Add(GetUnityEngineAssembly());
        assemblies.Add(GetUnityEditorAssembly());
        return assemblies;
    }
    #endregion
}
