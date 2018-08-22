using System.IO;
/// <summary>
/// TextAsset资源配置
/// </summary>
public class EditorTextAssetConfig : AbsEdtiorAssetConfig
{
    #region public 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_name">名称</param>
    /// <param name="_directory">目录</param>
    /// <param name="_ext">后缀</param>
    /// <param name="_text">文本</param>
    public EditorTextAssetConfig(string _name, string _directory,
        enFileExt _ext, string _text)
        : base(_name, _directory, _ext)
    {
        SetText(_text);
    }
    #endregion

    #region public 属性        
    /// <summary>
    /// 文本内容
    /// </summary>
    public string text { get; private set; }
    #endregion

    #region public 方法
    /// <summary>
    /// 设置文本
    /// </summary>
    /// <param name="_text">文本</param>
    public void SetText(string _text)
    {
        text = _text;
    }
    #endregion

    #region OnCreateAsset 创建资源
    /// <summary>
    /// 创建资源
    /// </summary>
    protected override void OnCreateAsset()
    {
        File.WriteAllText(fileName, text);
    }
    #endregion
}
