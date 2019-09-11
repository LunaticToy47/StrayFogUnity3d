using UnityEngine;
/// <summary>
/// 矩阵扩展
/// </summary>
public static class Matrix4x4ExtendEngine
{
    /// <summary>
    /// 设置位置
    /// </summary>
    /// <param name="_position">位移</param>
    /// <returns>矩阵</returns>
    public static Matrix4x4 SetPosition(this Matrix4x4 matrix4x4, Vector3 _position)
    {
        return matrix4x4 * Matrix4x4.TRS(_position, Quaternion.identity, Vector3.one);
    }

    /// <summary>
    /// 设置旋转
    /// </summary>
    /// <param name="_quaternion">旋转</param>
    /// <returns>矩阵</returns>
    public static Matrix4x4 SetRotation(this Matrix4x4 matrix4x4, Quaternion _quaternion)
    {
        return matrix4x4 * Matrix4x4.TRS(Vector3.zero, _quaternion, Vector3.one);
    }

    /// <summary>
    /// 设置缩放
    /// </summary>
    /// <param name="_scale">缩放</param>
    /// <returns>矩阵</returns>
    public static Matrix4x4 SetScale(this Matrix4x4 matrix4x4, Vector3 _scale)
    {
        return matrix4x4 * Matrix4x4.TRS(Vector3.zero, Quaternion.identity, _scale);
    }
}
