using System;
using UnityEngine;

#region enFileExt 文件扩展名
/// <summary>
/// 文件扩展名
/// </summary>
public enum enFileExt
{
    /// <summary>
    /// 未知扩展名
    /// </summary>
    [FileExt(".unknown")]
    Unknown,
    /// <summary>
    /// 动画文件扩展名
    /// </summary>
    [FileExt(".anim")]
    Animation,
    /// <summary>
    /// 动画控制器扩展名
    /// </summary>
    [FileExt(".controller")]
    AnimatorController,
    /// <summary>
    /// 重载动画控制器扩展名
    /// </summary>
    [FileExt(".overrideController")]
    AnimatorOverrideController,
    /// <summary>
    /// 资源扩展名
    /// </summary>
    [FileExt(".asset")]
    Asset,
    /// <summary>
    /// 曲线
    /// </summary>
    [FileExt(".curves")]
    Curves,
    /// <summary>
    /// 阿凡达遮罩
    /// </summary>
    [FileExt(".mask")]
    AvatarMask,
    /// <summary>
    /// 立方体贴图
    /// </summary>
    [FileExt(".cubemap")]
    Cubemap,
    /// <summary>
    /// 闪光
    /// </summary>
    [FileExt(".flare")]
    Flare,
    /// <summary>
    /// 字体
    /// </summary>
    [FileExt(".fontsettings")]
    Font,
    /// <summary>
    /// GUI皮肤
    /// </summary>
    [FileExt(".guiskin")]
    GUISkin,
    /// <summary>
    /// 光照贴图参数
    /// </summary>
    [FileExt(".giparams")]
    LightmapParameters,
    /// <summary>
    /// 材质
    /// </summary>
    [FileExt(".mat")]
    Material,
    /// <summary>
    /// 物理材质
    /// </summary>
    [FileExt(".physicMaterial")]
    PhysicMaterial,
    /// <summary>
    /// 2D物理材质
    /// </summary>
    [FileExt(".physicsMaterial2D")]
    Physics2DMaterial,
    /// <summary>
    /// Prefab预置
    /// </summary>
    [FileExt(".prefab")]
    Prefab,
    /// <summary>
    /// RenderTexture
    /// </summary>
    [FileExt(".renderTexture")]
    RenderTexture,
    /// <summary>
    /// 音频混合器
    /// </summary>
    [FileExt(".mixer")]
    AudioMixer,
    /// <summary>
    /// C#脚本
    /// </summary>
    [FileExt(".cs")]
    CS,
    /// <summary>
    /// javascript脚本
    /// </summary>
    [FileExt(".js")]
    Javascript,
    /// <summary>
    /// Shader变体
    /// </summary>
    [FileExt(".shadervariants")]
    ShaderVariants,
    /// <summary>
    /// Shader
    /// </summary>
    [FileExt(".shader")]
    Shader,
    /// <summary>
    /// UnityPackage
    /// </summary>
    [FileExt(".unitypackage")]
    UnityPackage,
    /// <summary>
    /// 场景文件
    /// </summary>
    [FileExt(".unity")]
    Scene,
    /// <summary>
    /// Exr光照烘焙贴图
    /// </summary>
    [FileExt(".exr")]
    LightMapExr,
    /// <summary>
    /// Manifest文件
    /// </summary>
    [FileExt(".manifest")]
    Manifest,
    /// <summary>
    /// TextAsset文本
    /// </summary>
    [FileExt(".txt")]
    TextAsset,
    /// <summary>
    /// Sql
    /// </summary>
    [FileExt(".sql")]
    Sql,
    /// <summary>
    /// 二进制数据
    /// </summary>
    [FileExt(".bytes")]
    Bytes,
    /// <summary>
    /// Lzma
    /// </summary>
    [FileExt(".Lzma")]
    Lzma,
    /// <summary>
    /// zip
    /// </summary>
    [FileExt(".zip")]
    ZIP,
    /// <summary>
    /// 7z
    /// </summary>
    [FileExt(".7z")]
    _7z,
    /// <summary>
    /// xml文件
    /// </summary>
    [FileExt(".xml")]
    Xml,
    /// <summary>
    /// xlsx
    /// </summary>
    [FileExt(".xlsx")]
    Xlsx,
    /// <summary>
    /// Config配置文件
    /// </summary>
    [FileExt(".cfg")]
    Cfg,
    /// <summary>
    /// bat批处理文件
    /// </summary>
    [FileExt(".bat")]
    Bat,
    /// <summary>
    /// 注册表文件
    /// </summary>
    [FileExt(".reg")]
    Reg,
    /// <summary>
    /// dll动态链接库
    /// </summary>
    [FileExt(".dll")]
    Dll,
    /// <summary>
    /// dll动态链接库pdb文件
    /// </summary>
    [FileExt(".pdb")]
    Dll_PDB,
    /// <summary>
    /// dll动态链接库mdb文件
    /// </summary>
    [FileExt(".mdb")]
    Dll_MDB,
    /// <summary>
    /// Cginc库
    /// </summary>
    [FileExt(".cginc")]
    Cginc,
    /// <summary>
    /// xlua文件
    /// </summary>
    [FileExt(".xlua.txt")]
    XLuaTxt,
    /// <summary>
    /// SQLite数据库
    /// </summary>
    [FileExt(".db")]
    SQLiteDb,
    /// <summary>
    /// asmdef文件
    /// </summary>
    [FileExt(".asmdef")]
    Asmdef,
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
