using System;
using System.IO;

/// <summary>
/// 资源结果回调处理
/// </summary>
/// <param name="_assetDiskMaping">资源磁盘映射</param>
/// <param name="_type">资源类型</param>
/// <param name="_params">额外参数</param>
/// <param name="_callback">回调函数【参数一：资源实例，参数二：额外参数】</param>
public delegate void AssetBundleResultCallbackEventHandle(XLS_Config_View_AssetDiskMaping _assetDiskMaping, Type _type, object[] _params,Action<UnityEngine.Object, object[]> _callback);

/// <summary>
/// AssetBundle结果
/// </summary>
public class AssetBundleResult
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_assetDiskMaping">资源磁盘映射</param>
    /// <param name="_instantiate">实例化函数</param>
    /// <param name="_extraParameter">额外参数</param>
    public AssetBundleResult(XLS_Config_View_AssetDiskMaping _assetDiskMaping,
        AssetBundleResultCallbackEventHandle _instantiate,
        object[] _extraParameter)
    {
        assetDiskMaping = _assetDiskMaping;
        mInstantiate = _instantiate;
        extraParameter = _extraParameter;
        assetName = Path.GetFileNameWithoutExtension(_assetDiskMaping.fileName);
    }
    /// <summary>
    /// 资源名称
    /// </summary>
    public string assetName { get; private set; }
    /// <summary>
    /// 资源磁盘映射
    /// </summary>
    public XLS_Config_View_AssetDiskMaping assetDiskMaping { get; private set; }
    /// <summary>
    /// 额外参数
    /// </summary>
    public object[] extraParameter { get; private set; }
    /// <summary>
    /// 实例化
    /// </summary>
    AssetBundleResultCallbackEventHandle mInstantiate;
    /// <summary>
    /// 实例化对象
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="_callback">回调</param>
    /// <param name="_extraParameter">额外参数</param>
    /// <returns>对象</returns>
    public void Instantiate<T>(Action<T, object[]> _callback, params object[] _extraParameter) where T : UnityEngine.Object
    {
        Instantiate<T>(true, _callback, _extraParameter);
    }
    /// <summary>
    /// 实例化对象
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="_isActive">是否激活</param>
    /// <param name="_callback">回调</param>
    /// <param name="_extraParameter">额外参数</param>
    /// <returns>对象</returns>
    public void Instantiate<T>(bool _isActive,Action<T,object[]> _callback,params object[] _extraParameter) where T : UnityEngine.Object
    {
        mInstantiate(assetDiskMaping, typeof(T), new object[3] { _callback, _extraParameter,_isActive },(asset,args)=> {
            Action<T, object[]> cb = (Action<T, object[]>)args[0];
            object[] eps = (object[])args[1];
            cb((T)asset, eps);
        });
    }
}
