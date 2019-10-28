using System;
using UnityEngine.UI;
/// <summary>
/// UI引导Graphic抽象
/// </summary>
public abstract class AbsUIGuideGraphic
{
    /// <summary>
    /// 类型
    /// </summary>
    public int type { get; private set; }
    /// <summary>
    /// Graphic
    /// </summary>
    public Graphic graphic { get; private set; }
    /// <summary>
    /// 索引
    /// </summary>
    public int index { get; private set; }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_type">Graphic类型</param>
    /// <param name="_graphic">Graphic</param>
    /// <param name="_index">索引</param>
    public AbsUIGuideGraphic(int _type, Graphic _graphic,int _index)
    {
        type = _type;
        graphic = _graphic;
        index = _index;
    }
}
