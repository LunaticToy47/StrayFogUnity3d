using UnityEngine;
/// <summary>
/// 几何学工具
/// </summary>
public sealed class Geometry2DUtility
{
    /// <summary>
    /// 求三角形的外接圆
    /// </summary>
    /// <param name="_p1">顶点1</param>
    /// <param name="_p2">顶点2</param>
    /// <param name="_p3">顶点3</param>
    /// <returns>外接圆圆心</returns>
    public static Vector2 TriangleCircumCircle(Vector3 _p1, Vector3 _p2, Vector3 _p3)
    {
        Vector3 center = Vector3.zero;
        #region 三角形的外接圆
        /*参考文章
         * http://blog.sina.com.cn/s/blog_648868460100h2b8.html
         * http://jingyan.baidu.com/article/636f38bb3caa88d6b846109d.html
         * https://www.zhihu.com/question/40422123?sort=created
         * http://blog.sina.com.cn/s/blog_15ff6002b0102xxxf.html
         */
        float a1, b1, c1, d1;
        float a2, b2, c2, d2;
        float a3, b3, c3, d3;

        float x1 = _p1.x, y1 = _p1.y, z1 = _p1.z;
        float x2 = _p2.x, y2 = _p2.y, z2 = _p2.z;
        float x3 = _p3.x, y3 = _p3.y, z3 = _p3.z;

        a1 = (y1 * z2 - y2 * z1 - y1 * z3 + y3 * z1 + y2 * z3 - y3 * z2);
        b1 = -(x1 * z2 - x2 * z1 - x1 * z3 + x3 * z1 + x2 * z3 - x3 * z2);
        c1 = (x1 * y2 - x2 * y1 - x1 * y3 + x3 * y1 + x2 * y3 - x3 * y2);
        d1 = -(x1 * y2 * z3 - x1 * y3 * z2 - x2 * y1 * z3 + x2 * y3 * z1 + x3 * y1 * z2 - x3 * y2 * z1);

        a2 = 2 * (x2 - x1);
        b2 = 2 * (y2 - y1);
        c2 = 2 * (z2 - z1);
        d2 = x1 * x1 + y1 * y1 + z1 * z1 - x2 * x2 - y2 * y2 - z2 * z2;

        a3 = 2 * (x3 - x1);
        b3 = 2 * (y3 - y1);
        c3 = 2 * (z3 - z1);
        d3 = x1 * x1 + y1 * y1 + z1 * z1 - x3 * x3 - y3 * y3 - z3 * z3;

        center.x = -(b1 * c2 * d3 - b1 * c3 * d2 - b2 * c1 * d3 + b2 * c3 * d1 + b3 * c1 * d2 - b3 * c2 * d1)
            / (a1 * b2 * c3 - a1 * b3 * c2 - a2 * b1 * c3 + a2 * b3 * c1 + a3 * b1 * c2 - a3 * b2 * c1);
        center.y = (a1 * c2 * d3 - a1 * c3 * d2 - a2 * c1 * d3 + a2 * c3 * d1 + a3 * c1 * d2 - a3 * c2 * d1)
            / (a1 * b2 * c3 - a1 * b3 * c2 - a2 * b1 * c3 + a2 * b3 * c1 + a3 * b1 * c2 - a3 * b2 * c1);
        center.z = -(a1 * b2 * d3 - a1 * b3 * d2 - a2 * b1 * d3 + a2 * b3 * d1 + a3 * b1 * d2 - a3 * b2 * d1)
            / (a1 * b2 * c3 - a1 * b3 * c2 - a2 * b1 * c3 + a2 * b3 * c1 + a3 * b1 * c2 - a3 * b2 * c1);
        #endregion
        return center;
    }

    /// <summary>
    /// 边是否相交
    /// </summary>
    /// <param name="_edgeA">边A</param>
    /// <param name="_edgeB">边B</param>
    /// <returns>是否相交</returns>
    public static bool EdgeIntersection(PolygonEdge2D _edgeA, PolygonEdge2D _edgeB)
    {
        Vector3 p1 = _edgeA.vertexA.position;
        Vector3 p2 = _edgeA.vertexB.position;
        Vector3 q1 = _edgeB.vertexA.position;
        Vector3 q2 = _edgeB.vertexB.position;

        Vector3 v1 = Vector3.Cross(p2 - p1, q1 - p1).normalized;
        Vector3 v2 = Vector3.Cross(p2 - p1, q2 - p1).normalized;

        Vector3 v3 = Vector3.Cross(q2 - q1, p1 - q1).normalized;
        Vector3 v4 = Vector3.Cross(q2 - q1, p2 - q1).normalized;
        return Vector3.Dot(v1, v2) < 0 && Vector3.Dot(v3, v4) < 0;
    }

    /// <summary>
    /// 边是否相交
    /// </summary>
    /// <param name="_edgeA">边A</param>
    /// <param name="_edgeB">边B</param>
    /// <param name="_point">交点</param>
    /// <returns>是否相交</returns>
    public static bool EdgeIntersection(PolygonEdge2D _edgeA, PolygonEdge2D _edgeB, ref Vector3 _point)
    {
        bool isCross = EdgeIntersection(_edgeA, _edgeB);
        if (isCross)
        {
            float a1 = _edgeA.vertexA.position.x;
            float b1 = _edgeA.vertexA.position.y;
            float a2 = _edgeA.vertexB.position.x;
            float b2 = _edgeA.vertexB.position.y;
            float c1 = _edgeB.vertexA.position.x;
            float d1 = _edgeB.vertexA.position.y;
            float c2 = _edgeB.vertexB.position.x;
            float d2 = _edgeB.vertexB.position.y;
            _point = Vector3.zero;
            _point.x = ((a2 - a1) * (c2 - c1) * (d2 - b2) + (b2 - b1) * (c2 - c1) * a2 - (d2 - d1) * (a2 - a1) * c2) / ((b2 - b1) * (c2 - c1) - (d2 - d1) * (a2 - a1));
            _point.y = (b2 - b1) / (a2 - a1) * (_point.x - a2) + b2;
        }
        return isCross;
    }

    /// <summary>
    /// 点是否在矩形内
    /// </summary>
    /// <param name="_point">点</param>
    /// <param name="_rect">矩形</param>
    /// <returns>true:在矩形内,false:不在矩形内</returns>
    public static bool IsPointInRect(Vector2 _point, Rect _rect)
    {
        return _point.x >= _rect.xMin && _point.x <= _rect.xMax
                    && _point.y >= _rect.yMin && _point.y <= _rect.yMax;
    }
}
