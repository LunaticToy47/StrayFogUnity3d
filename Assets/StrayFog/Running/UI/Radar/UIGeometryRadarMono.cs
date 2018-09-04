using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 多边形雷达组件
/// </summary>
[AddComponentMenu("Game/UI/Radar/UIGeometryRadarMono")]
public class UIGeometryRadarMono : MaskableGraphic, ICanvasRaycastFilter
{
    #region IsRaycastLocationValid 是否通过Raycast验证
    /// <summary>
    /// 是否通过Raycast验证
    /// </summary>
    /// <param name="_screenPoint">屏幕坐标</param>
    /// <param name="_eventCamera">检测相机</param>
    /// <returns>True:检测到有效目标【事件停止传递】,False:未检测到有效目标【事件继续传递】</returns>
    public bool IsRaycastLocationValid(Vector2 _screenPoint, Camera _eventCamera)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, _screenPoint, _eventCamera);
    }
    #endregion

    /// <summary>
    /// 精灵图
    /// </summary>
    [AliasTooltip("精灵图")]
    public Sprite sprite;
    /// <summary>
    /// 边数
    /// </summary>
    [AliasTooltip("边数")]
    [Range(3, byte.MaxValue)]
    public int edgeNum;
    /// <summary>
    /// 半径
    /// </summary>
    [AliasTooltip("半径")]
    [Range(0, short.MaxValue)]
    public int radius;
    /// <summary>
    /// 边长比率[0-1]
    /// </summary>
    [AliasTooltip("边长比率[0-1]")]
    public float[] edgeRatios;

    #region 这个属性必须重写返回当前的Sprite
    /// <summary>
    /// Image's texture comes from the UnityEngine.Image.
    /// </summary>
    public override Texture mainTexture
    {
        get
        {
            return sprite == null ? s_WhiteTexture : sprite.texture;
        }
    }
    #endregion

    #region OnPopulateMesh
    /// <summary>
    /// Fill the vertex buffer data.
    /// </summary>
    /// <param name="_vh">顶点Helper</param>
    protected override void OnPopulateMesh(VertexHelper _vh)
    {
        _vh.Clear();
        Vector4 originPos = sprite != null ? this.GraphicDrawingDimensionsForVertexHelper(sprite, false) : Vector4.zero;
        Vector3 startRay = Vector3.up;
        float angle = 360f / edgeNum;
        if (edgeNum % 2 == 0)
        {//如果边数是偶数，则起始射线为向左偏移半个平均角度
            startRay = Quaternion.AngleAxis(-angle * 0.5f, Vector3.up) * startRay;
        }
        Vector3[] vertexs = new Vector3[edgeNum + 1];
        vertexs[0] = new Vector3(originPos.x + originPos.z, originPos.y + originPos.w, 0) * 0.5f;
        List<UIVertex> uiVertexs = new List<UIVertex>();
        List<int> indices = new List<int>();
        UIVertex vtx;
        uiVertexs.Add(new UIVertex() { position = vertexs[0], color = color, uv0 = Vector2.one * 0.5f });
        Vector3 vec3 = Vector3.zero;
        Vector2 vecUv0 = Vector2.zero;
        float ratio = 0;
        for (int i = 0; i < edgeNum; i++)
        {
            vec3 = Quaternion.AngleAxis(angle * i, Vector3.back) * startRay;
            ratio = 0;
            if (edgeRatios != null && edgeRatios.Length > i)
            {
                ratio = Mathf.Clamp01(edgeRatios[i]);
            }
            vertexs[i + 1] = vec3 * radius * ratio + vertexs[0];

            vecUv0 = vec3 + Vector3.one * 0.5f;
            vtx = new UIVertex() { position = vertexs[i + 1], color = color, uv0 = vecUv0 };
            uiVertexs.Add(vtx);
            indices.Add(0);
            if (i >= edgeNum - 1)
            {
                indices.Add(i + 1);
                indices.Add(1);
            }
            else
            {
                indices.Add(i + 1);
                indices.Add(i + 2);
            }
            //Debug.Log(" uv:" + vtx.uv0 + " pos:" + vertexs[i + 1]);
        }
        _vh.AddUIVertexStream(uiVertexs, indices);
    }
    #endregion
}
