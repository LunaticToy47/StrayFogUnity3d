using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 绘制遮罩【顶点版】
/// 依赖项
/// 1.UIGraphicMaskVertex.shader
/// </summary>
[AddComponentMenu("Game/UI/GraphicMask/Vertex")]
public class UIGraphicMaskVertex : AbsUIGraphicMask
{
    #region OnPopulateMesh
    /// <summary>
    /// Fill the vertex buffer data.
    /// </summary>
    /// <param name="_vh">顶点Helper</param>
    protected override void OnPopulateMesh(VertexHelper _vh)
    {
        if (graphicMasks != null && graphicMasks.Count > 0)
        {
            switch (graphicClassify)
            {
                case enGraphicMaskClassify.Scene:
                    OnFillScene(_vh, graphicMasks);
                    break;
                case enGraphicMaskClassify.Mask:
                    OnFillMask(_vh, graphicMasks);
                    break;
                case enGraphicMaskClassify.ExceptMask:
                    OnFillExceptMask(_vh, graphicMasks);
                    break;
            }
        }
        else
        {
            base.OnPopulateMesh(_vh);
        }
    }
    #endregion

    #region OnFillScene 全屏填充
    /// <summary>
    /// 全屏填充
    /// </summary>
    /// <param name="_vh">顶点Helper</param>
    /// <param name="_masks">绘制组</param>
    protected virtual void OnFillScene(VertexHelper _vh, List<Graphic> _masks)
    {
        _vh.Clear();
        List<UIVertex> vertexs = new List<UIVertex>();
        Vector3[] fourCorners = null;
        Vector4 uv = (sprite != null) ? UnityEngine.Sprites.DataUtility.GetOuterUV(sprite) : Vector4.zero;
        this.GraphicLocalCornersForVertexHelper(out fourCorners);
        vertexs.Add(new UIVertex() { position = fourCorners[0], color = color, uv0 = new Vector2(uv.x, uv.y) });
        vertexs.Add(new UIVertex() { position = fourCorners[1], color = color, uv0 = new Vector2(uv.x, uv.w) });
        vertexs.Add(new UIVertex() { position = fourCorners[2], color = color, uv0 = new Vector2(uv.z, uv.w) });
        vertexs.Add(new UIVertex() { position = fourCorners[3], color = color, uv0 = new Vector2(uv.z, uv.y) });
        _vh.AddUIVertexQuad(vertexs.ToArray());
    }
    #endregion

    #region OnFillMask 仅填充遮罩
    /// <summary>
    /// 仅填充遮罩
    /// </summary>
    /// <param name="_vh">顶点Helper</param>
    /// <param name="_masks">绘制组</param>
    protected virtual void OnFillMask(VertexHelper _vh, List<Graphic> _masks)
    {
        _vh.Clear();
        List<UIVertex> vertexs = new List<UIVertex>();
        Vector3[] fourCorners = null;
        GraphicRect2D sceneRect = new GraphicRect2D(-1, this);
        Vector4 uv = (sprite != null) ? UnityEngine.Sprites.DataUtility.GetOuterUV(sprite) : Vector4.zero;
        foreach (Graphic g in _masks)
        {
            g.GraphicLocalCornersForVertexHelper(out fourCorners);
            vertexs = new List<UIVertex>();
            switch (graphicSpriteFillClassify)
            {
                case enGraphicSpriteFillClassify.SceneRatioFill:
                    fourCorners[0].x = Mathf.Clamp(fourCorners[0].x, sceneRect.rect.xMin, sceneRect.rect.xMax);
                    fourCorners[0].y = Mathf.Clamp(fourCorners[0].y, sceneRect.rect.yMin, sceneRect.rect.yMax);
                    vertexs.Add(new UIVertex() { position = fourCorners[0], color = color, uv0 = Rect.PointToNormalized(sceneRect.rect, fourCorners[0]) });

                    fourCorners[1].x = Mathf.Clamp(fourCorners[1].x, sceneRect.rect.xMin, sceneRect.rect.xMax);
                    fourCorners[1].y = Mathf.Clamp(fourCorners[1].y, sceneRect.rect.yMin, sceneRect.rect.yMax);
                    vertexs.Add(new UIVertex() { position = fourCorners[1], color = color, uv0 = Rect.PointToNormalized(sceneRect.rect, fourCorners[1]) });

                    fourCorners[2].x = Mathf.Clamp(fourCorners[2].x, sceneRect.rect.xMin, sceneRect.rect.xMax);
                    fourCorners[2].y = Mathf.Clamp(fourCorners[2].y, sceneRect.rect.yMin, sceneRect.rect.yMax);
                    vertexs.Add(new UIVertex() { position = fourCorners[2], color = color, uv0 = Rect.PointToNormalized(sceneRect.rect, fourCorners[2]) });

                    fourCorners[3].x = Mathf.Clamp(fourCorners[3].x, sceneRect.rect.xMin, sceneRect.rect.xMax);
                    fourCorners[3].y = Mathf.Clamp(fourCorners[3].y, sceneRect.rect.yMin, sceneRect.rect.yMax);
                    vertexs.Add(new UIVertex() { position = fourCorners[3], color = color, uv0 = Rect.PointToNormalized(sceneRect.rect, fourCorners[3]) });
                    break;
                case enGraphicSpriteFillClassify.MaskAloneFill:
                    vertexs.Add(new UIVertex() { position = fourCorners[0], color = color, uv0 = new Vector2(uv.x, uv.y) });
                    vertexs.Add(new UIVertex() { position = fourCorners[1], color = color, uv0 = new Vector2(uv.x, uv.w) });
                    vertexs.Add(new UIVertex() { position = fourCorners[2], color = color, uv0 = new Vector2(uv.z, uv.w) });
                    vertexs.Add(new UIVertex() { position = fourCorners[3], color = color, uv0 = new Vector2(uv.z, uv.y) });
                    break;
            }
            _vh.AddUIVertexQuad(vertexs.ToArray());
        }
    }
    #endregion

    #region OnFillExceptMask 除遮罩之外都填充
    /// <summary>
    /// 三角剖分结果
    /// </summary>
    PolygonDelaunayResult2D mDelaunayResult = null;
    /// <summary>
    /// 除遮罩之外都填充
    /// </summary>
    /// <param name="_vh">顶点Helper</param>
    /// <param name="_masks">绘制组</param>
    protected virtual void OnFillExceptMask(VertexHelper _vh, List<Graphic> _masks)
    {
        #region 屏幕矩形
        GraphicRect2D sceneRect = new GraphicRect2D(-1, this);
        #endregion

        #region 遮罩矩形
        List<GraphicRect2D> maskRect = new List<GraphicRect2D>();
        GraphicRect2D rect;
        for (int i = 0; i < _masks.Count; i++)
        {
            rect = new GraphicRect2D(i, _masks[i]);
            maskRect.Add(rect);
        }

        //求两矩形填充点和矩形在屏幕上的填充点
        List<Vector3> useVertexs = new List<Vector3>();
        List<Vector3> tempVertexs = new List<Vector3>();
        List<Vector3> validateVertexs = new List<Vector3>();
        if (maskRect.Count <= 1)
        {
            tempVertexs = maskRect[0].IntersectionFill(sceneRect);
            if (tempVertexs.Count > 0)
            {
                validateVertexs.AddRange(tempVertexs);
            }
        }
        else
        {
            foreach (GraphicRect2D a in maskRect)
            {
                foreach (GraphicRect2D b in maskRect)
                {
                    tempVertexs = a.IntersectionFill(b);
                    if (tempVertexs.Count > 0)
                    {
                        validateVertexs.AddRange(tempVertexs);
                    }
                }
            }
        }
        #endregion

        validateVertexs.InsertRange(0, sceneRect.corners);

        #region 清理重复的点
        List<int> hasPoint = new List<int>();
        int pk = 0;
        Vector3 tp = Vector3.zero;
        foreach (Vector3 cv in validateVertexs)
        {
            //顶点不超过屏幕
            tp.x = cv.x;
            tp.x = Mathf.Max(tp.x, sceneRect.rect.xMin);
            tp.x = Mathf.Min(tp.x, sceneRect.rect.xMax);
            tp.y = cv.y;
            tp.y = Mathf.Max(tp.y, sceneRect.rect.yMin);
            tp.y = Mathf.Min(tp.y, sceneRect.rect.yMax);
            //过滤重复点
            pk = (tp.x.ToString() + tp.y.ToString()).UniqueHashCode();
            if (!hasPoint.Contains(pk))
            {
                hasPoint.Add(pk);
                useVertexs.Add(tp);
            }
        }
        #endregion

        mDelaunayResult = Polygon2DUtility.BuilderDelaunay2D(useVertexs, new List<int>() { 0, 1, 2, 3 });

        #region 绘制三角面
        _vh.Clear();
        Vector4 uv = (sprite != null) ? UnityEngine.Sprites.DataUtility.GetOuterUV(sprite) : Vector4.zero;
        UIVertex[] vertexs = new UIVertex[mDelaunayResult.vertexs.Count];
        List<int> vertexIndexs = new List<int>();
        foreach (PolygonPoint2D p in mDelaunayResult.vertexs)
        {
            vertexs[p.index] = new UIVertex() { position = p.position, color = color, uv0 = Rect.PointToNormalized(sceneRect.rect, p.position) };
        }

        bool isInAnyRect = false;
        foreach (PolygonTriangle2D tri in mDelaunayResult.delaunayTriangle)
        {
            foreach (GraphicRect2D r in maskRect)
            {
                isInAnyRect =
                    Geometry2DUtility.IsPointInRect(tri.vertexs[0].position, r.rect) &&
                    Geometry2DUtility.IsPointInRect(tri.vertexs[1].position, r.rect) &&
                    Geometry2DUtility.IsPointInRect(tri.vertexs[2].position, r.rect);
                if (isInAnyRect)
                {
                    break;
                }
            }
            if (!isInAnyRect)
            {
                vertexIndexs.Add(tri.vertexs[0].index);
                vertexIndexs.Add(tri.vertexs[1].index);
                vertexIndexs.Add(tri.vertexs[2].index);
            }
        }
        _vh.AddUIVertexStream(new List<UIVertex>(vertexs), vertexIndexs);
        #endregion
    }
    /// <summary>
    /// Graphic矩形2D
    /// </summary>
    class GraphicRect2D
    {
        /// <summary>
        /// 索引
        /// </summary>
        public int index { get; private set; }
        /// <summary>
        /// 四角
        /// </summary>
        public Vector3[] corners { get; private set; }
        /// <summary>
        /// 矩形
        /// </summary>
        public Rect rect { get; private set; }
        /// <summary>
        /// 包围盒
        /// </summary>
        public Bounds bounds { get; private set; }
        /// <summary>
        /// 矩形四角
        /// </summary>
        /// <param name="_index">矩形索引</param>
        /// <param name="_graphic">Graphic</param>
        public GraphicRect2D(int _index, Graphic _graphic)
        {
            index = _index;
            Vector3[] cns = null;
            rect = _graphic.GraphicLocalRectForVertexHelper(ref cns);
            bounds = rect.TransRectToBounds();
            corners = cns;
        }

        /// <summary>
        /// 求矩形B在当前矩形上的投影填充点
        /// </summary>
        /// <param name="_b">矩形B</param>
        /// <returns>填充点</returns>
        public List<Vector3> IntersectionFill(GraphicRect2D _b)
        {
            List<Vector3> vertexs = new List<Vector3>();
            if (index != _b.index)
            {
                Vector3 va = Vector3.zero;
                Vector3 vb = Vector3.zero;
                Vector3 vp = Vector3.zero;
                Vector3 ab = Vector3.zero;
                Vector3 ap = Vector3.zero;
                Vector3 pab = Vector3.zero;
                for (int i = 0; i < corners.Length; i++)
                {
                    va = corners[i];
                    vertexs.Add(va);
                    if (i >= corners.Length - 1)
                    {
                        vb = corners[0];
                    }
                    else
                    {
                        vb = corners[i + 1];
                    }
                    for (int p = 0; p < _b.corners.Length; p++)
                    {
                        vp = _b.corners[p];
                        ab = vb - va;
                        ap = vp - va;
                        //P点在AB上的投影点pab
                        pab = Vector3.Project(ap, ab);
                        //如果投影点的方向与ab方向一致，并且ab的长度大于ap的长度，则投影点在ab边上，为矩形交点
                        if (Vector3.Dot(ab, pab) >= 0 && ab.magnitude >= ap.magnitude)
                        {
                            vertexs.Add(va + pab);
                        }
                    }
                }
            }
            return vertexs;
        }
    }
    #endregion

    #region OnDrawGizmos
#if UNITY_EDITOR
    /// <summary>
    /// OnDrawGizmos
    /// </summary>
    void OnDrawGizmos()
    {
        if (mDelaunayResult != null && mDelaunayResult.vertexs != null)
        {
            Gizmos.color = Color.yellow;
            float raudis = Vector3.Distance(mDelaunayResult.bounds.min, mDelaunayResult.bounds.max) * 0.5f;
            foreach (PolygonPoint2D point in mDelaunayResult.vertexs)
            {
                Gizmos.DrawSphere(point.position, raudis / mDelaunayResult.vertexs.Count * 0.3f);
            }
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(mDelaunayResult.bounds.min, mDelaunayResult.bounds.max);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(mDelaunayResult.bounds.center, mDelaunayResult.bounds.size);
            Gizmos.color = Color.grey;
            Gizmos.DrawWireSphere(mDelaunayResult.bounds.center, raudis);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(mDelaunayResult.supperTriangle.vertexs[0].position, raudis / mDelaunayResult.vertexs.Count * 0.3f);
            Gizmos.DrawSphere(mDelaunayResult.supperTriangle.vertexs[1].position, raudis / mDelaunayResult.vertexs.Count * 0.3f);
            Gizmos.DrawSphere(mDelaunayResult.supperTriangle.vertexs[2].position, raudis / mDelaunayResult.vertexs.Count * 0.3f);

            Gizmos.DrawLine(mDelaunayResult.supperTriangle.vertexs[0].position, mDelaunayResult.supperTriangle.vertexs[1].position);
            Gizmos.DrawLine(mDelaunayResult.supperTriangle.vertexs[1].position, mDelaunayResult.supperTriangle.vertexs[2].position);
            Gizmos.DrawLine(mDelaunayResult.supperTriangle.vertexs[2].position, mDelaunayResult.supperTriangle.vertexs[0].position);

            Light light = FindObjectOfType<Light>();
            if (light != null)
            {
                light.transform.position = mDelaunayResult.bounds.center;
            }

            foreach (PolygonTriangle2D tri in mDelaunayResult.delaunayTriangle)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(tri.vertexs[0].position, tri.vertexs[1].position);
                Gizmos.DrawLine(tri.vertexs[1].position, tri.vertexs[2].position);
                Gizmos.DrawLine(tri.vertexs[2].position, tri.vertexs[0].position);
                //Gizmos.color = Color.white;
                //Gizmos.DrawWireSphere(tri.circumCircleCenter, tri.circumCircleRadius);
            }
        }
    }
#endif
    #endregion
}