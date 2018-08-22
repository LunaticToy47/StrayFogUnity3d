using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UIGuideRegister注册器设置Graphic
/// </summary>
public class EditorUIGuideRegisterSetGraphic
{
    /// <summary>
    /// GameObject
    /// </summary>
    public GameObject gameObject { get; private set; }
    /// <summary>
    /// Graphic
    /// </summary>
    public Graphic graphic { get; private set; }
    /// <summary>
    /// 对象信息
    /// </summary>
    public StringBuilder info { get; private set; }
    /// <summary>
    /// 引导注册器
    /// </summary>
    public UIGuideRegister register { get; private set; }
    /// <summary>
    /// Graphics索引
    /// </summary>
    public int[] graphicsIndexs { get; private set; }
    /// <summary>
    /// 是否查找注册器
    /// </summary>
    public bool isFoundRegister { get; private set; }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_go">GameObject</param>
    public EditorUIGuideRegisterSetGraphic(GameObject _go)
    {
        gameObject = _go;
        info = new StringBuilder();
    }

    /// <summary>
    /// 解析
    /// </summary>
    public void Resolve()
    {
        graphic = gameObject.GetComponent<Graphic>();
        StringBuilder sbGraphicPath = new StringBuilder();
        StringBuilder sbGraphicIndex = new StringBuilder();
        StringBuilder sbRegisterPath = new StringBuilder();
        List<int> intGraphicIndex = new List<int>();
        Transform root = null;
        sbGraphicPath.Length = 0;
        sbGraphicIndex.Length = 0;
        sbRegisterPath.Length = 0;
        root = gameObject.transform;
        while (root != null)
        {
            if (register == null)
            {
                register = root.gameObject.GetComponent<UIGuideRegister>();
                if (register == null)
                {
                    sbGraphicPath.Insert(0, root.name + "/");
                    sbGraphicIndex.Insert(0, root.GetSiblingIndex() + ",");
                    intGraphicIndex.Insert(0, root.GetSiblingIndex());
                }
            }
            if (register != null)
            {
                sbRegisterPath.Insert(0, root.name + "/");
            }
            root = root.parent;
        }

        #region 去掉尾部符号
        if (sbGraphicPath.Length > 0)
        {
            sbGraphicPath.Remove(sbGraphicPath.Length - 1, 1);
        }
        if (sbGraphicIndex.Length > 0)
        {
            sbGraphicIndex.Remove(sbGraphicIndex.Length - 1, 1);
        }
        if (sbRegisterPath.Length > 0)
        {
            sbRegisterPath.Remove(sbRegisterPath.Length - 1, 1);
        }
        #endregion

        info.AppendLine(
            string.Format("RegisterPath=>【{0}】, GraphicPath=>【{1}】, GraphicIndex=>【{2}】",
            sbRegisterPath.ToString(), sbGraphicPath.ToString(), sbGraphicIndex.ToString()));

        graphicsIndexs = intGraphicIndex.ToArray();
        isFoundRegister = register != null;
    }
}
