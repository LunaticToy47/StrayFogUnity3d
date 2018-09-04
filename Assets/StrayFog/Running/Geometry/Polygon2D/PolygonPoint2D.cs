using UnityEngine;
/// <summary>
/// 多边形点
/// </summary>
public class PolygonPoint2D
{
    /// <summary>
    /// 多边形点
    /// </summary>
    /// <param name="_index">点索引</param>
    /// <param name="_position">点位置</param>
    public PolygonPoint2D(int _index, Vector3 _position)
        : this(_index, _position, false)
    {
    }

    /// <summary>
    /// 多边形点
    /// </summary>
    /// <param name="_index">点索引</param>
    /// <param name="_position">点位置</param>
    /// <param name="_isSupperPoint">是否是超级点</param>
    public PolygonPoint2D(int _index, Vector3 _position, bool _isSupperPoint)
    {
        index = _index;
        position = new Vector3(_position.x, _position.y, 0);
        isSupperPoint = _isSupperPoint;
    }
    /// <summary>
    /// 索引
    /// </summary>
    public int index { get; private set; }
    /// <summary>
    /// 位置
    /// </summary>
    public Vector3 position { get; private set; }
    /// <summary>
    /// 是否是超级点
    /// </summary>
    public bool isSupperPoint { get; private set; }
}