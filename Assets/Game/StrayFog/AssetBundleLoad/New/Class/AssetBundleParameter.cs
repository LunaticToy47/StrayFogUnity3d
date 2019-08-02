﻿using System.IO;
/// <summary>
/// 资源包参数
/// </summary>
public class AssetBundleParameter : IAssetBundleParameter
{
    /// <summary>
    /// 资源ID
    /// </summary>
    public int assetId { get; private set; }

    /// <summary>
    /// 资源路径
    /// </summary>
    public string assetPath { get; private set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_assetBundleName">资源包名称</param>
    public AssetBundleParameter(string _assetBundleName)
    {
        assetId = _assetBundleName.UniqueHashCode();
        assetPath = Path.Combine(StrayFogGamePools.setting.assetBundleRoot, _assetBundleName).TransPathSeparatorCharToUnityChar();
    }
}