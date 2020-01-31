using System;
using UnityEngine;

#region enFileExt 文件扩展名
/// <summary>
/// 文件扩展名
/// </summary>
public static class enFileExt
{
    /// <summary>
    /// 未知扩展名
    /// </summary>
    [FileExt(".unknown")]
    public const int Unknown = 0;
    /// <summary>
    /// 动画文件扩展名
    /// </summary>
    [FileExt(".anim")]
    public const int Animation = 1;
    /// <summary>
    /// 动画控制器扩展名
    /// </summary>
    [FileExt(".controller")]
    public const int AnimatorController = 2;
    /// <summary>
    /// 重载动画控制器扩展名
    /// </summary>
    [FileExt(".overrideController")]
    public const int AnimatorOverrideController = 3;
    /// <summary>
    /// 资源扩展名
    /// </summary>
    [FileExt(".asset")]
    public const int Asset = 4;
    /// <summary>
    /// 曲线
    /// </summary>
    [FileExt(".curves")]
    public const int Curves = 5;
    /// <summary>
    /// 阿凡达遮罩
    /// </summary>
    [FileExt(".mask")]
    public const int AvatarMask = 6;
    /// <summary>
    /// 立方体贴图
    /// </summary>
    [FileExt(".cubemap")]
    public const int Cubemap = 7;
    /// <summary>
    /// 闪光
    /// </summary>
    [FileExt(".flare")]
    public const int Flare = 8;
    /// <summary>
    /// 字体
    /// </summary>
    [FileExt(".fontsettings")]
    public const int Font = 9;
    /// <summary>
    /// GUI皮肤
    /// </summary>
    [FileExt(".guiskin")]
    public const int GUISkin = 10;
    /// <summary>
    /// 光照贴图参数
    /// </summary>
    [FileExt(".giparams")]
    public const int LightmapParameters = 11;
    /// <summary>
    /// 材质
    /// </summary>
    [FileExt(".mat")]
    public const int Material = 12;
    /// <summary>
    /// 物理材质
    /// </summary>
    [FileExt(".physicMaterial")]
    public const int PhysicMaterial = 13;
    /// <summary>
    /// 2D物理材质
    /// </summary>
    [FileExt(".physicsMaterial2D")]
    public const int Physics2DMaterial = 14;
    /// <summary>
    /// Prefab预置
    /// </summary>
    [FileExt(".prefab")]
    public const int Prefab = 15;
    /// <summary>
    /// RenderTexture
    /// </summary>
    [FileExt(".renderTexture")]
    public const int RenderTexture = 16;
    /// <summary>
    /// 音频混合器
    /// </summary>
    [FileExt(".mixer")]
    public const int AudioMixer = 17;
    /// <summary>
    /// C#脚本
    /// </summary>
    [FileExt(".cs")]
    public const int CS = 18;
    /// <summary>
    /// javascript脚本
    /// </summary>
    [FileExt(".js")]
    public const int Javascript = 19;
    /// <summary>
    /// Shader变体
    /// </summary>
    [FileExt(".shadervariants")]
    public const int ShaderVariants = 20;
    /// <summary>
    /// Shader
    /// </summary>
    [FileExt(".shader")]
    public const int Shader = 21;
    /// <summary>
    /// UnityPackage
    /// </summary>
    [FileExt(".unitypackage")]
    public const int UnityPackage = 22;
    /// <summary>
    /// 场景文件
    /// </summary>
    [FileExt(".unity")]
    public const int Scene = 23;
    /// <summary>
    /// Exr光照烘焙贴图
    /// </summary>
    [FileExt(".exr")]
    public const int LightMapExr = 24;
    /// <summary>
    /// Manifest文件
    /// </summary>
    [FileExt(".manifest")]
    public const int Manifest = 25;
    /// <summary>
    /// TextAsset文本
    /// </summary>
    [FileExt(".txt")]
    public const int TextAsset = 26;
    /// <summary>
    /// Sql
    /// </summary>
    [FileExt(".sql")]
    public const int Sql = 27;
    /// <summary>
    /// 二进制数据
    /// </summary>
    [FileExt(".bytes")]
    public const int Bytes = 28;
    /// <summary>
    /// Lzma
    /// </summary>
    [FileExt(".Lzma")]
    public const int Lzma = 29;
    /// <summary>
    /// zip
    /// </summary>
    [FileExt(".zip")]
    public const int ZIP = 30;
    /// <summary>
    /// 7z
    /// </summary>
    [FileExt(".7z")]
    public const int _7z = 31;
    /// <summary>
    /// xml文件
    /// </summary>
    [FileExt(".xml")]
    public const int Xml = 32;
    /// <summary>
    /// xlsx
    /// </summary>
    [FileExt(".xlsx")]
    public const int Xlsx = 33;
    /// <summary>
    /// Config配置文件
    /// </summary>
    [FileExt(".cfg")]
    public const int Cfg = 34;
    /// <summary>
    /// bat批处理文件
    /// </summary>
    [FileExt(".bat")]
    public const int Bat = 35;
    /// <summary>
    /// 注册表文件
    /// </summary>
    [FileExt(".reg")]
    public const int Reg = 36;
    /// <summary>
    /// dll动态链接库
    /// </summary>
    [FileExt(".dll")]
    public const int Dll = 37;
    /// <summary>
    /// dll动态链接库pdb文件
    /// </summary>
    [FileExt(".pdb")]
    public const int Dll_PDB = 38;
    /// <summary>
    /// dll动态链接库mdb文件
    /// </summary>
    [FileExt(".mdb")]
    public const int Dll_MDB = 39;
    /// <summary>
    /// Cginc库
    /// </summary>
    [FileExt(".cginc")]
    public const int Cginc = 40;
    /// <summary>
    /// xlua文件
    /// </summary>
    [FileExt(".lua.txt")]
    public const int XLuaTxt = 41;
    /// <summary>
    /// SQLite数据库
    /// </summary>
    [FileExt(".db")]
    public const int SQLiteDb = 42;
    /// <summary>
    /// asmdef文件
    /// </summary>
    [FileExt(".asmdef")]
    public const int Asmdef = 43;
}
#endregion

/// <summary>
/// 文件后续属性
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class FileExtAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_ext">后缀</param>
    public FileExtAttribute(string _ext)
    {
        ext = _ext;
        noDotExt = _ext.Replace(".", "");
    }
    /// <summary>
    /// 扩展名
    /// </summary>
    public string ext { get; private set; }
    /// <summary>
    /// 不带点扩展名
    /// </summary>
    public string noDotExt { get; private set; }

    /// <summary>
    /// 是否是指定的后缀
    /// </summary>
    /// <param name="_ext">指定的后缀</param>
    /// <returns>true:是,false:否</returns>
    public bool IsExt(string _ext)
    {
        return !string.IsNullOrEmpty(_ext) && ext.ToUpper().Equals(_ext.ToUpper());
    }
}
