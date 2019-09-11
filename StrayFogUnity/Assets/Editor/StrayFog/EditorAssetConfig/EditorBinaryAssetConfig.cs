#if UNITY_EDITOR 
using System;
using System.IO;
using UnityEditor;
/// <summary>
/// 二进制资源配置
/// </summary>
public class EditorBinaryAssetConfig : AbsEdtiorAssetConfig
{
    #region public 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_name">名称</param>
    /// <param name="_directory">目录</param>
    /// <param name="_ext">后缀</param>
    /// <param name="_bytes">数据流</param>
    public EditorBinaryAssetConfig(string _name, string _directory,
        enFileExt _ext, byte[] _bytes)
        : base(_name, _directory, _ext)
    {
        SetBinary(_bytes);
    }
    #endregion

    #region public 属性        
    /// <summary>
    /// 流内容
    /// </summary>
    public byte[] bytes { get; private set; }
    #endregion

    #region public 方法
    /// <summary>
    /// 设置数据流
    /// </summary>
    /// <param name="_bytes">数据流</param>
    public void SetBinary(byte[] _bytes)
    {
        bytes = _bytes;
    }
    #endregion

    #region OnCreateAsset 创建资源
    /// <summary>
    /// 创建资源
    /// </summary>
    protected override void OnCreateAsset()
    {
        File.WriteAllBytes(fileName, bytes);
        switch (ext)
        {
            case enFileExt.UnityPackage:
                AssetDatabase.ImportPackage(fileName, false);
                File.Delete(fileName);
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
        bytes = File.ReadAllBytes(fileName);
    }
    #endregion

    #region ICloneable
    /// <summary>
    /// 克隆对象
    /// </summary>
    protected override AbsEdtiorAssetConfig OnClone()
    {
        byte[] bts = new byte[0];
        if (bytes != null)
        {
            bts = new byte[bytes.LongLength];
            Array.Copy(bytes, bts, bytes.LongLength);
        }
        return new EditorBinaryAssetConfig(name, directory, ext, bts);
    }
    #endregion
}
#endif