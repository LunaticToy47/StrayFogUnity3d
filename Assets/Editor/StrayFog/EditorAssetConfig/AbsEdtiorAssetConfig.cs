#if UNITY_EDITOR 
using System;
using System.IO;
/// <summary>
/// 抽象资源配置
/// </summary>
public abstract class AbsEdtiorAssetConfig : ICloneable
{
    #region public 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_name">名称</param>
    /// <param name="_directory">目录</param>
    /// <param name="_ext">后缀</param>
    public AbsEdtiorAssetConfig(string _name, string _directory,
    enFileExt _ext)
    {
        OnSetName(_name);
        OnSetDirectory(_directory);
        OnSetExt(_ext);
        OnReset();
    }
    #endregion

    #region public 属性
    /// <summary>
    /// 文件名称
    /// </summary>
    public string name { get; private set; }
    /// <summary>
    /// 文件目录
    /// </summary>
    public string directory { get; private set; }
    /// <summary>
    /// 文件后缀
    /// </summary>
    public enFileExt ext { get; private set; }
    /// <summary>
    /// 后缀属性
    /// </summary>
    public FileExtAttribute extAttribute { get; private set; }
    /// <summary>
    /// 文件名称
    /// </summary>
    public string fileName { get; private set; }
    #endregion

    #region public 方法
    #region SetName 设置名称
    /// <summary>
    /// 设置名称
    /// </summary>
    /// <param name="_name">名称</param>
    public void SetName(string _name)
    {
        OnSetName(_name);
        OnReset();
    }
    /// <summary>
    /// 设置名称
    /// </summary>
    /// <param name="_name">名称</param>
    void OnSetName(string _name)
    {
        name = _name;
    }
    #endregion

    #region SetDirectory 设置目录
    /// <summary>
    /// 设置目录
    /// </summary>
    /// <param name="_directory">目录</param>
    public void SetDirectory(string _directory)
    {
        OnSetDirectory(_directory);
        OnReset();
    }
    /// <summary>
    /// 设置目录
    /// </summary>
    /// <param name="_directory">目录</param>
    void OnSetDirectory(string _directory)
    {
        directory = _directory;
    }
    #endregion

    #region SetExt 设置后缀
    /// <summary>
    /// 设置后缀
    /// </summary>
    /// <param name="_ext">后缀</param>
    public void SetExt(enFileExt _ext)
    {
        OnSetExt(_ext);
        OnReset();
    }
    /// <summary>
    /// 设置后缀
    /// </summary>
    /// <param name="_ext">后缀</param>
    void OnSetExt(enFileExt _ext)
    {
        ext = _ext;
        extAttribute = _ext.GetAttribute<FileExtAttribute>();
    }
    #endregion

    #region OnReset 重置
    /// <summary>
    /// 重置
    /// </summary>
    void OnReset()
    {
        directory = EditorStrayFogApplication.TryRelativeToProject(directory);
        fileName = Path.Combine(directory, name + extAttribute.ext).TransPathSeparatorCharToUnityChar();
    }
    #endregion
    #endregion

    #region public 抽象方法
    /// <summary>
    /// 配置资源是否存在
    /// </summary>
    /// <returns>true:存在,false:不存在</returns>
    public bool Exists()
    {
        OnReset();
        return File.Exists(fileName);
    }

    #region CreateAsset 创建资源
    /// <summary>
    /// 创建资源
    /// </summary>
    public void CreateAsset()
    {
        OnReset();
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        OnCreateAsset();
    }
    /// <summary>
    /// 创建资源
    /// </summary>
    protected abstract void OnCreateAsset();
    #endregion
    #endregion

    #region ICloneable
    /// <summary>
    /// 克隆
    /// </summary>
    /// <returns>克隆后对象</returns>
    public object Clone()
    {
        return OnClone();
    }
    /// <summary>
    /// 克隆对象
    /// </summary>
    protected abstract AbsEdtiorAssetConfig OnClone();
    #endregion
}
#endif