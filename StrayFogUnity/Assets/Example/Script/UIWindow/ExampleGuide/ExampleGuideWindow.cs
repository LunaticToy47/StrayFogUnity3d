using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ExampleGuideWindow
/// </summary>
[AddComponentMenu("StrayFog/Example/UIWindow/ExampleGuideWindow")]
public class ExampleGuideWindow : AbsUIGuideWindowView
{
    /// <summary>
    /// 材质文件
    /// </summary>
    protected override enAssetDiskMapingFile materialFile { get { return enAssetDiskMapingFile.f_GuideMaskShader_mat; } }

    /// <summary>
    /// 材质文件夹
    /// </summary>
    protected override enAssetDiskMapingFolder materialFolder { get { return enAssetDiskMapingFolder.Assets_Game_AssetBundles_Materials; } }
    
}