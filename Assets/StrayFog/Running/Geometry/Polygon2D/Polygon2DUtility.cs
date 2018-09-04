using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 三角剖分工具
/// </summary>
public sealed class Polygon2DUtility
{
    /// <summary>
    /// 生成三角剖分结果
    /// </summary>
    /// <param name="_vertexs">离散顶点集</param>
    /// <returns>三角剖分结果</returns>
    public static PolygonDelaunayResult2D BuilderDelaunay2D(List<Vector3> _vertexs)
    {
        return BuilderDelaunay2D(_vertexs, null);
    }
    /// <summary>
    /// 生成三角剖分结果
    /// </summary>
    /// <param name="_vertexs">离散顶点集</param>
    /// <param name="_polygonBoundsPointIndexs">多边形边界点索引</param>
    /// <returns>三角剖分结果</returns>
    public static PolygonDelaunayResult2D BuilderDelaunay2D(List<Vector3> _vertexs, List<int> _polygonBoundsPointIndexs)
    {
        List<PolygonPoint2D> polygonVertexs = new List<PolygonPoint2D>();
        Bounds polygonBounds = new Bounds();
        PolygonTriangle2D polygonSupperTriangle = new PolygonTriangle2D(new PolygonPoint2D(0, Vector3.zero), new PolygonPoint2D(1, Vector3.zero), new PolygonPoint2D(2, Vector3.zero));
        //已完成的剖分三角形
        List<PolygonTriangle2D> polygonDelaunayTriangles = new List<PolygonTriangle2D>();
        //多边形边界边
        Dictionary<int, PolygonEdge2D> polygonBoundsEdgeMaping = new Dictionary<int, PolygonEdge2D>();
        if (_vertexs.Count >= 3)
        {
            #region 分析点
            Vector3 max = Vector3.one * float.MinValue;
            Vector3 min = Vector3.one * float.MaxValue;
            //构建顶点
            for (int i = 0; i < _vertexs.Count; i++)
            {
                polygonVertexs.Add(new PolygonPoint2D(i, _vertexs[i]));
                min.x = Mathf.Min(min.x, _vertexs[i].x);
                min.y = Mathf.Min(min.y, _vertexs[i].y);
                min.z = Mathf.Min(min.z, _vertexs[i].z);
                max.x = Mathf.Max(max.x, _vertexs[i].x);
                max.y = Mathf.Max(max.y, _vertexs[i].y);
                max.z = Mathf.Max(max.z, _vertexs[i].z);
            }

            PolygonEdge2D tempPolygonEdge2D = null;
            if (_polygonBoundsPointIndexs != null && _polygonBoundsPointIndexs.Count > 0)
            {
                for (int i = 0; i < _polygonBoundsPointIndexs.Count; i++)
                {
                    if (i < _polygonBoundsPointIndexs.Count - 1)
                    {
                        tempPolygonEdge2D = new PolygonEdge2D(polygonVertexs[i], polygonVertexs[i + 1]);
                    }
                    else
                    {
                        tempPolygonEdge2D = new PolygonEdge2D(polygonVertexs[i], polygonVertexs[0]);
                    }

                    polygonBoundsEdgeMaping.Add(tempPolygonEdge2D.key, tempPolygonEdge2D);
                }
            }

            //x轴从左往右排序
            polygonVertexs.Sort((x, y) => { return x.position.x >= y.position.x ? 1 : -1; });
            //y轴从下往上排序
            polygonVertexs.Sort((x, y) => { return (x.position.x == y.position.x && x.position.y >= y.position.y) ? 1 : -1; });

            //构建一个包含所有点集的三角形
            polygonBounds = new Bounds(Vector3.Lerp(min, max, 0.5f), Vector3.zero);
            polygonBounds.SetMinMax(min, max);
            float raudis = Vector3.Distance(polygonBounds.min, polygonBounds.max) * 0.6f;
            Vector3 tvc = polygonBounds.center + Vector3.back * raudis;
            Vector3 tvl = polygonBounds.min + Vector3.back * (raudis - Mathf.Abs(polygonBounds.extents.z));
            Vector3 axis = tvc - polygonBounds.center;
            Vector3 vc = (tvl - tvc).normalized * raudis * 2;
            Vector3 tp0 = vc + tvc;
            vc = Quaternion.AngleAxis(120, axis) * vc;
            Vector3 tp1 = vc + tvc;
            vc = Quaternion.AngleAxis(120, axis) * vc;
            Vector3 tp2 = vc + tvc;
            tp0.z = tp1.z = tp2.z = 0;
            polygonSupperTriangle = new PolygonTriangle2D(new PolygonPoint2D(_vertexs.Count, tp0, true), new PolygonPoint2D(_vertexs.Count + 1, tp1, true), new PolygonPoint2D(_vertexs.Count + 2, tp2, true));
            #endregion

            #region 三角剖分
            //缓存的剖分三角形
            List<PolygonTriangle2D> tempDelaunayTriangles = new List<PolygonTriangle2D>();
            //等待检测的三角形
            List<PolygonTriangle2D> validateTriangles = new List<PolygonTriangle2D>() { polygonSupperTriangle };
            //从第一个顶点开始，进行三角剖分检测
            int count = polygonVertexs.Count;
            for (int i = 0; i < count; i++)
            {
                List<PolygonTriangle2D> delTris = FindDelaunayTriangle(polygonVertexs[i], ref validateTriangles);
                if (delTris.Count > 0)
                {
                    tempDelaunayTriangles.AddRange(delTris);
                }
            }
            tempDelaunayTriangles.AddRange(validateTriangles);
            #endregion

            #region 删除超级三角形
            //需要补边的三角形
            List<PolygonTriangle2D> pushEdgeTriangles = new List<PolygonTriangle2D>();
            int supperPointCount = 0;
            foreach (PolygonTriangle2D tri in tempDelaunayTriangles)
            {
                //缓存三角形有任意点是超三角形的点
                supperPointCount = 0;
                foreach (PolygonPoint2D v in tri.vertexs)
                {
                    if (v.isSupperPoint)
                    {
                        supperPointCount++;
                    }
                }
                if (supperPointCount > 0)
                {
                    pushEdgeTriangles.Add(tri);
                }
                else
                {
                    polygonDelaunayTriangles.Add(tri);
                    foreach (PolygonEdge2D edge in tri.edges)
                    {
                        polygonBoundsEdgeMaping.Remove(edge.key);
                    }
                }
            }
            #endregion

            #region 对删除的超级三角形与边界比对，补充未绘制的边界三角形
            //点索引
            int pointIndex = _vertexs.Count;
            //交点
            Vector3 point = Vector3.zero;
            //边是否相交
            bool isIntersection = false;
            //边交点
            Dictionary<int, Dictionary<int, PolygonPoint2D>> edgePoint = new Dictionary<int, Dictionary<int, PolygonPoint2D>>();
            //三角形被边界线切割后的多边形点
            Dictionary<int, PolygonPoint2D> polygonPoints = new Dictionary<int, PolygonPoint2D>();
            //检测三角形
            foreach (PolygonTriangle2D tri in pushEdgeTriangles)
            {
                polygonPoints.Clear();
                foreach (PolygonEdge2D triEdge in tri.edges)
                {
                    foreach (PolygonEdge2D edge in polygonBoundsEdgeMaping.Values)
                    {
                        #region 求交点
                        isIntersection = false;
                        point = Vector3.zero;
                        if (edgePoint.ContainsKey(triEdge.key) && edgePoint[triEdge.key].ContainsKey(edge.key))
                        {
                            isIntersection = true;
                        }
                        else if (Geometry2DUtility.EdgeIntersection(triEdge, edge, ref point))
                        {
                            isIntersection = true;
                            if (!edgePoint.ContainsKey(triEdge.key))
                            {
                                edgePoint.Add(triEdge.key, new Dictionary<int, PolygonPoint2D>());
                            }
                            if (!edgePoint[triEdge.key].ContainsKey(edge.key))
                            {
                                edgePoint[triEdge.key].Add(edge.key, new PolygonPoint2D(pointIndex, point));
                            }
                            polygonVertexs.Add(edgePoint[triEdge.key][edge.key]);
                            pointIndex++;
                        }
                        if (isIntersection)
                        {
                            //加入交点
                            if (!polygonPoints.ContainsKey(edgePoint[triEdge.key][edge.key].index))
                            {
                                polygonPoints.Add(edgePoint[triEdge.key][edge.key].index, edgePoint[triEdge.key][edge.key]);
                            }
                        }
                        #endregion
                    }
                }
                if (polygonPoints.Count > 0)
                {
                    //如果有任意交点，保留三角形非超级点
                    foreach (PolygonPoint2D p in tri.vertexs)
                    {
                        if (!p.isSupperPoint)
                        {
                            if (!polygonPoints.ContainsKey(p.index))
                            {
                                polygonPoints.Add(p.index, p);
                            }
                        }
                    }
                    if (polygonPoints.Count >= 3)
                    {
                        List<PolygonPoint2D> pps = new List<PolygonPoint2D>(polygonPoints.Values);
                        if (pps.Count == 3)
                        {
                            polygonDelaunayTriangles.Add(
                               new PolygonTriangle2D(pps[0], pps[1], pps[2]));
                        }
                        else if (pps.Count == 4)
                        {
                            //如果有两个交点，则pps中前两个是交点，后两个是原三角形的两个顶点
                            //交点与顶点各取一点组成两条边，然后看两条边是否相交，相交则是对角线，不相交则不是
                            //找到对角线后，与非对角线点的另外一个交点和顶点组成新的两个三角形
                            PolygonEdge2D edge1 = new PolygonEdge2D(pps[0], pps[2]);
                            PolygonEdge2D edge2 = new PolygonEdge2D(pps[1], pps[3]);
                            if (Geometry2DUtility.EdgeIntersection(edge1, edge2))
                            {
                                //0,2,1 和0,2,3 组成两个新的三角形
                                polygonDelaunayTriangles.Add(
                                    new PolygonTriangle2D(pps[0], pps[2], pps[1]));
                                polygonDelaunayTriangles.Add(
                                    new PolygonTriangle2D(pps[0], pps[2], pps[3]));
                            }
                            else
                            {
                                //0,3,1 和 0,3,2 组成两个新的三角形
                                polygonDelaunayTriangles.Add(
                                    new PolygonTriangle2D(pps[0], pps[3], pps[1]));
                                polygonDelaunayTriangles.Add(
                                    new PolygonTriangle2D(pps[0], pps[3], pps[2]));
                            }
                        }
                    }
                }
            }
            #endregion
        }
        else
        {
            throw new UnityException("There are not enough vertexs to constitute polygon,the vertexs are least of three.");
        }
        return new PolygonDelaunayResult2D(polygonVertexs, polygonBounds, polygonSupperTriangle, polygonDelaunayTriangles);
    }

    /// <summary>
    /// 边切割三角形
    /// </summary>
    /// <param name="_triangle">三角形</param>
    /// <param name="_edge">边</param>
    /// <returns></returns>
    static List<PolygonTriangle2D> EdgeCutTriangle(PolygonTriangle2D _triangle, PolygonEdge2D _edge)
    {
        List<PolygonTriangle2D> triangles = new List<PolygonTriangle2D>();

        return triangles;
    }

    /// <summary>
    /// 找到三角剖分三角形
    /// </summary>
    /// <param name="_point">点</param>
    /// <param name="_validateTriangles">待检测三形</param>
    static List<PolygonTriangle2D> FindDelaunayTriangle(PolygonPoint2D _point, ref List<PolygonTriangle2D> _validateTriangles)
    {
        List<PolygonTriangle2D> result = new List<PolygonTriangle2D>();
        List<PolygonTriangle2D> cache = new List<PolygonTriangle2D>();
        Dictionary<int, PolygonEdge2D> edges = new Dictionary<int, PolygonEdge2D>();
        //两个或两个以上三角形用到的边为共同边，要用等组合边中去掉
        Dictionary<int, int> edgeUseNum = new Dictionary<int, int>();
        for (int i = 0; i < _validateTriangles.Count; i++)
        {
            if (!_validateTriangles[i].IsInCircumCircle(_point.position))
            {
                if (_validateTriangles[i].circumCircleCenter.x + _validateTriangles[i].circumCircleRadius <= _point.position.x)
                {
                    result.Add(_validateTriangles[i]);
                }
                else
                {
                    cache.Add(_validateTriangles[i]);
                }
            }
            else
            {
                foreach (PolygonEdge2D d in _validateTriangles[i].edges)
                {
                    if (!edges.ContainsKey(d.key))
                    {
                        edges.Add(d.key, d);
                    }
                    if (!edgeUseNum.ContainsKey(d.key))
                    {
                        edgeUseNum.Add(d.key, 0);
                    }
                    edgeUseNum[d.key]++;
                }
            }
        }

        //未确定的边重建三角形
        foreach (PolygonEdge2D d in edges.Values)
        {
            //只重建非共用的边，共用边是两个相邻三角形的对角线，不需要再重建了。
            if (edgeUseNum[d.key] <= 1)
            {
                cache.Add(new PolygonTriangle2D(d.vertexA, d.vertexB, _point));
            }
        }

        _validateTriangles = cache;
        return result;
    }
}