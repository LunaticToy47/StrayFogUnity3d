using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
/// <summary>
/// 调整字间距
/// </summary>
[AddComponentMenu("UI/Effects/TextSpacing")]
public class TextSpacing : BaseMeshEffect
{
    /// <summary>
    /// 字间距
    /// </summary>
    [AliasTooltip("字间距")]
    public float textSpacing = 1f;
    /// <summary>
    /// ModifyMesh
    /// </summary>
    /// <param name="_vh">VertexHelper</param>
    public override void ModifyMesh(VertexHelper _vh)
    {
        if (!IsActive() || _vh.currentVertCount == 0)
        {
            return;
        }
        List<UIVertex> vertexs = new List<UIVertex>();
        _vh.GetUIVertexStream(vertexs);
        int indexCount = _vh.currentIndexCount;
        UIVertex vt;
        for (int i = 6; i < indexCount; i++)
        {
            //第一个字不用改变位置
            vt = vertexs[i];
            vt.position += new Vector3(textSpacing * (i / 6), 0, 0);
            vertexs[i] = vt;
            //以下注意点与索引的对应关系
            if (i % 6 <= 2)
            {
                _vh.SetUIVertex(vt, (i / 6) * 4 + i % 6);
            }
            if (i % 6 == 4)
            {
                _vh.SetUIVertex(vt, (i / 6) * 4 + i % 6 - 1);
            }
        }
    }
}