using UnityEngine;
/// <summary>
/// 多边形三角形
/// </summary>
public class PolygonTriangle2D
{
    /// <summary>
    /// 多边形三角形
    /// </summary>
    /// <param name="_vertexA">顶点A</param>
    /// <param name="_vertexB">顶点B</param>
    /// <param name="_vertexC">顶点C</param>
    public PolygonTriangle2D(PolygonPoint2D _vertexA, PolygonPoint2D _vertexB, PolygonPoint2D _vertexC)
    {
        //Vector3 ab = (_vertexB.position - _vertexA.position).normalized;
        //Vector3 ac = (_vertexC.position - _vertexA.position).normalized;
        //Vector3 vc = Vector3.Cross(ab, ac);
        //if (vc.z > 0)
        //{
        //    //逆时针三角形，B,C点交换
        //    PolygonPoint2D p = _vertexC;
        //    _vertexC = _vertexB;
        //    _vertexB = p;
        //}
        vertexs = new PolygonPoint2D[3] { _vertexA, _vertexB, _vertexC };
        edges = new PolygonEdge2D[3] { new PolygonEdge2D(_vertexA, _vertexB), new PolygonEdge2D(_vertexB, _vertexC), new PolygonEdge2D(_vertexC, _vertexA) };
        circumCircleCenter = Geometry2DUtility.TriangleCircumCircle(_vertexA.position, _vertexB.position, _vertexC.position);
        circumCircleRadius = Vector3.Distance(circumCircleCenter, _vertexA.position);

        key = (_vertexA.index.ToString() + _vertexB.index.ToString() + _vertexC.ToString()).UniqueHashCode();
    }

    /// <summary>
    /// 点是否在三角形外接圆内
    /// </summary>
    /// <param name="_point">点</param>
    /// <returns>True:是,False:否</returns>
    public bool IsInCircumCircle(Vector3 _point)
    {
        return Vector3.Distance(circumCircleCenter, _point) < circumCircleRadius;
    }

    /// <summary>
    /// 点是否在三角形内
    /// </summary>
    /// <param name="_point">点</param>
    /// <returns>True:是,False:否</returns>
    public bool IsInTriangle(Vector3 _point)
    {
        Vector3 a = vertexs[0].position;
        Vector3 b = vertexs[1].position;
        Vector3 c = vertexs[2].position;
        Vector3 p = _point;
        return SameSide(a, b, c, p) &&
        SameSide(b, c, a, p) &&
        SameSide(c, a, b, p);
    }

    // Determine whether two vectors v1 and v2 point to the same direction
    // v1 = Cross(AB, AC)
    // v2 = Cross(AB, AP)
    bool SameSide(Vector3 _a, Vector3 _b, Vector3 _c, Vector3 _p)
    {
        Vector3 ab = _b - _a;
        Vector3 ac = _c - _a;
        Vector3 ap = _p - _a;
        Vector3 v1 = Vector3.Cross(ab, ac);
        Vector3 v2 = Vector3.Cross(ab, ap);
        // v1 and v2 should point to the same direction
        return Vector3.Dot(v1, v2) >= 0;
    }
    /// <summary>
    /// Key
    /// </summary>
    public int key { get; private set; }
    /// <summary>
    /// 外接圆半径
    /// </summary>
    public float circumCircleRadius { get; private set; }
    /// <summary>
    /// 外接圆圆心
    /// </summary>
    public Vector3 circumCircleCenter { get; private set; }
    /// <summary>
    /// 顶点【A,B,C】【逆时针】
    /// </summary>
    public PolygonPoint2D[] vertexs { get; private set; }
    /// <summary>
    /// 边【逆时针】
    /// </summary>
    public PolygonEdge2D[] edges { get; private set; }
}