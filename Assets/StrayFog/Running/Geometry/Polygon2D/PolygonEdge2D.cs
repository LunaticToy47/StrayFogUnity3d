using System.Collections.Generic;
using System.Text;
/// <summary>
/// 多边形边
/// </summary>
public class PolygonEdge2D
{
    /// <summary>
    /// 多边形边
    /// </summary>
    /// <param name="_vertexA">顶点A</param>
    /// <param name="_vertexB">顶点B</param>
    public PolygonEdge2D(PolygonPoint2D _vertexA, PolygonPoint2D _vertexB)
    {
        vertexA = _vertexA;
        vertexB = _vertexB;
        List<int> sort = new List<int>() { _vertexA.index, _vertexB.index };
        sort.Sort();
        StringBuilder sb = new StringBuilder();
        foreach (int k in sort)
        {
            sb.Append(k);
        }
        key = sb.ToString().UniqueHashCode();
    }
    /// <summary>
    /// 边Key值
    /// </summary>
    public int key { get; private set; }
    /// <summary>
    /// 顶点A
    /// </summary>
    public PolygonPoint2D vertexA { get; private set; }
    /// <summary>
    /// 顶点B
    /// </summary>
    public PolygonPoint2D vertexB { get; private set; }
}
