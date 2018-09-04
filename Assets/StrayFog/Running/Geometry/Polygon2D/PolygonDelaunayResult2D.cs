using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 多边形三角剖分结果
/// </summary>
public class PolygonDelaunayResult2D
{
    /// <summary>
    /// 网格顶点
    /// </summary>
    public List<PolygonPoint2D> vertexs { get; private set; }
    /// <summary>
    /// 包围盒
    /// </summary>
    public Bounds bounds { get; private set; }
    /// <summary>
    /// 超级三角形(包含所有点集的三角形)
    /// </summary>
    public PolygonTriangle2D supperTriangle { get; private set; }
    /// <summary>
    /// 剖分三角形
    /// </summary>
    public List<PolygonTriangle2D> delaunayTriangle { get; private set; }
    /// <summary>
    /// 添加顶点
    /// </summary>
    /// <param name="_vertexs">顶点</param>
    /// <param name="_bounds">包围盒</param>
    /// <param name="_supperTriangle">超级三角形</param>
    /// <param name="_delaunayTriangle">剖分三角形</param>
    public PolygonDelaunayResult2D(List<PolygonPoint2D> _vertexs, Bounds _bounds, PolygonTriangle2D _supperTriangle, List<PolygonTriangle2D> _delaunayTriangle)
    {
        vertexs = _vertexs;
        bounds = _bounds;
        supperTriangle = _supperTriangle;
        delaunayTriangle = _delaunayTriangle;
    }
}
