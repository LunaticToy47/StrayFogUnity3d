#if UNITY_EDITOR 
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 引擎Asset资源配置
/// </summary>
public class EditorEngineAssetConfig : AbsEdtiorAssetConfig
{
    #region public 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_name">名称</param>
    /// <param name="_directory">目录</param>
    /// <param name="_ext">后缀</param>
    /// <param name="_typeFullName">类全名称</param>
    public EditorEngineAssetConfig(string _name, string _directory,
        enFileExt _ext, string _typeFullName)
        : base(_name, _directory, _ext)
    {
        SetType(_typeFullName);
    }
    #endregion

    #region public 属性
    /// <summary>
    /// 类全名称
    /// </summary>
    public string classFullName { get; private set; }
    /// <summary>
    /// 引擎资源
    /// </summary>
    public UnityEngine.Object engineAsset{ get; private set; }
    #endregion

    #region public 方法
/// <summary>
/// 设置类型
/// </summary>
/// <param name="_typeFullName">类全名称</param>
public void SetType(string _typeFullName)
    {
        classFullName = _typeFullName;
    }
    #endregion

    #region OnCreateAsset 创建资源
    /// <summary>
    /// 创建资源
    /// </summary>
    protected override void OnCreateAsset()
    {
        switch (ext)
        {
            case enFileExt.Prefab:
                #region Prefab
                GameObject winPrefab = new GameObject(name);
                GameObject emptyPrefab = PrefabUtility.SaveAsPrefabAsset(winPrefab,fileName);
                UnityEngine.Object.DestroyImmediate(winPrefab);
                #endregion
                break;
            default:
                #region 默认
                Assembly assembly = null;
                Type type = EditorStrayFogAssembly.GetType(classFullName, ref assembly);
                if (type != null)
                {
                    UnityEngine.Object obj = (UnityEngine.Object)assembly.CreateInstance(type.FullName);
                    if (obj != null)
                    {
                        AssetDatabase.CreateAsset(obj, fileName);
                        AssetDatabase.SaveAssets();
                        EditorGUIUtility.PingObject(obj);
                    }
                    else
                    {
                        throw new NullReferenceException(string.Format("Assembly【{0}】can not find type 【{1}】.", assembly.FullName, type.FullName));
                    }
                }
                else
                {
                    Debug.LogErrorFormat("Can not find 【{0}】asset script.", classFullName);
                }
                #endregion
                break;
        }
    }
    #endregion

    #region 加载资源
    /// <summary>
    /// 加载资源
    /// </summary>
    protected override void OnLoadAsset()
    {
        engineAsset = null;
        switch (ext)
        {
            case enFileExt.Prefab:
                #region Prefab
                engineAsset = AssetDatabase.LoadAssetAtPath<GameObject>(fileName);
                #endregion
                break;
            default:
                #region 默认
                Assembly assembly = null;
                Type type = EditorStrayFogAssembly.GetType(classFullName, ref assembly);
                if (type != null)
                {
                    engineAsset = AssetDatabase.LoadAssetAtPath(fileName, type);
                }
                else
                {
                    Debug.LogErrorFormat("Can not find 【{0}】asset in path 【{1}】.", classFullName, fileName);
                }
                #endregion
                break;
        }
    }
    #endregion

    #region ICloneable
    /// <summary>
    /// 克隆对象
    /// </summary>
    protected override AbsEdtiorAssetConfig OnClone()
    {
        return new EditorEngineAssetConfig(name, directory, ext, classFullName);
    }
    #endregion
}
#endif