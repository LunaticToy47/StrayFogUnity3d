using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Transform扩展
/// </summary>
public static class TransformExtendEngine
{
    #region 设置父节点偏移
    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.位置偏移
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_offsetPosition">偏移位置</param>
    public static void SetParentOffsetPosition(this Transform _self, Transform _parent, Vector3 _offsetPosition)
    {
        _self.SetParentOffset(_parent, false, Matrix4x4.identity.SetPosition(_offsetPosition));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.旋转偏移
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_offsetRotate">偏移旋转</param>
    public static void SetParentOffsetQuaternion(this Transform _self, Transform _parent, Quaternion _offsetRotate)
    {
        _self.SetParentOffset(_parent, false, Matrix4x4.identity.SetRotation(_offsetRotate));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.缩放偏移
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_offsetScale">偏移缩放</param>
    public static void SetParentOffsetScale(this Transform _self, Transform _parent, Vector3 _offsetScale)
    {
        _self.SetParentOffset(_parent, false, Matrix4x4.identity.SetScale(_offsetScale));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.矩阵偏移
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_offsetMatrix">偏移矩阵</param>
    public static void SetParentOffset(this Transform _self, Transform _parent, Matrix4x4 _offsetMatrix)
    {
        _self.SetParentOffset(_parent, false, _offsetMatrix);
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.位置偏移
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
    /// <param name="_offsetPosition">偏移位置</param>
    public static void SetParentOffsetPosition(this Transform _self, Transform _parent, bool _worldPositionStays, Vector3 _offsetPosition)
    {
        _self.SetParentOffset(_parent, _worldPositionStays, Matrix4x4.identity.SetPosition(_offsetPosition));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.旋转偏移
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
    /// <param name="_offsetRotate">偏移旋转</param>
    public static void SetParentOffsetQuaternion(this Transform _self, Transform _parent, bool _worldPositionStays, Quaternion _offsetRotate)
    {
        _self.SetParentOffset(_parent, _worldPositionStays, Matrix4x4.identity.SetRotation(_offsetRotate));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.缩放偏移
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
    /// <param name="_offsetScale">偏移缩放</param>
    public static void SetParentOffsetScale(this Transform _self, Transform _parent, bool _worldPositionStays, Vector3 _offsetScale)
    {
        _self.SetParentOffset(_parent, _worldPositionStays, Matrix4x4.identity.SetScale(_offsetScale));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.矩阵偏移
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>
    /// <param name="_worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
    /// <param name="_offsetMatrix">偏移矩阵</param>
    public static void SetParentOffset(this Transform _self, Transform _parent, bool _worldPositionStays,
        Matrix4x4 _offsetMatrix)
    {
        _self.SetParent(_parent, _worldPositionStays);

        Vector3 p = _self.transform.localPosition;
        p = _offsetMatrix.MultiplyPoint3x4(p);
        Vector3 q = _self.transform.localEulerAngles;
        q = _offsetMatrix.MultiplyPoint(q);
        Vector3 c = _self.transform.localScale;
        c = _offsetMatrix.MultiplyPoint(c);

        _self.transform.localPosition = p;
        _self.transform.localEulerAngles = q;
        _self.transform.localScale = c;
    }
    #endregion

    #region 设置父节点
    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.位置
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_position">位置</param>
    public static void SetParentPosition(this Transform _self, Transform _parent, Vector3 _position)
    {
        _self.SetParent(_parent, false, Matrix4x4.identity.SetPosition(_position));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.旋转
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_rotate">旋转</param>
    public static void SetParentQuaternion(this Transform _self, Transform _parent, Quaternion _rotate)
    {
        _self.SetParent(_parent, false, Matrix4x4.identity.SetRotation(_rotate));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.缩放
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_offsetScale">缩放</param>
    public static void SetParentScale(this Transform _self, Transform _parent, Vector3 _scale)
    {
        _self.SetParent(_parent, false, Matrix4x4.identity.SetScale(_scale));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.矩阵
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_matrix">矩阵</param>
    public static void SetParent(this Transform _self, Transform _parent, Matrix4x4 _matrix)
    {
        _self.SetParent(_parent, false, _matrix);
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.位置
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
    /// <param name="_position">位置</param>
    public static void SetParentPosition(this Transform _self, Transform _parent, bool _worldPositionStays, Vector3 _position)
    {
        _self.SetParent(_parent, _worldPositionStays, Matrix4x4.identity.SetPosition(_position));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.旋转
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
    /// <param name="_rotate">旋转</param>
    public static void SetParentQuaternion(this Transform _self, Transform _parent, bool _worldPositionStays, Quaternion _rotate)
    {
        _self.SetParent(_parent, _worldPositionStays, Matrix4x4.identity.SetRotation(_rotate));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.缩放
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>    
    /// <param name="_worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
    /// <param name="_scale">缩放</param>
    public static void SetParentScale(this Transform _self, Transform _parent, bool _worldPositionStays, Vector3 _scale)
    {
        _self.SetParent(_parent, _worldPositionStays, Matrix4x4.identity.SetScale(_scale));
    }

    /// <summary>
    /// 设置父节点
    /// 1.设置父节点
    /// 2.矩阵
    /// </summary>
    /// <param name="_self">要设置的节点</param>
    /// <param name="_parent">父节点</param>
    /// <param name="_worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
    /// <param name="_matrix">矩阵</param>
    public static void SetParent(this Transform _self, Transform _parent, bool _worldPositionStays,
        Matrix4x4 _matrix)
    {
        _self.SetParent(_parent, _worldPositionStays);
        _self.transform.localPosition = _matrix.MultiplyPoint3x4(Vector3.zero);
        _self.transform.localEulerAngles = _matrix.MultiplyPoint3x4(Vector3.zero);
        _self.transform.localScale = _matrix.MultiplyPoint3x4(Vector3.one);
    }
    #endregion    

    #region FindNode 查找节点
    /// <summary>
    /// 查找节点
    /// </summary>
    /// <param name="_parent">父节点</param>
    /// <param name="_nodeName">节点名称</param>
    public static Transform FindNode(this Transform _parent, string _nodeName)
    {
        Transform node = null;
        for (int i = 0; i < _parent.childCount; i++)
        {
            if (_parent.GetChild(i).name.Equals(_nodeName))
            {
                node = _parent.GetChild(i).transform;
            }
            else
            {
                node = FindNode(_parent.GetChild(i), _nodeName);
            }
            if (node != null)
            {
                break;
            }
        }
        return node;
    }
    #endregion

    #region ProjectOnPlaneDirection 投影平面方向
    /// <summary>
    /// 指定世界方向相对Transfrom的平面投影方向
    /// </summary>
    /// <param name="_transform">变换对象</param>
    /// <param name="_transformLocalPlaneNormal">变换对象本地平面法线</param>
    /// <param name="_worldForward">世界方向</param>
    /// <returns>投影方向</returns>
    public static Vector3 ProjectOnPlaneDirection(this Transform _transform, Vector3 _transformLocalPlaneNormal, Vector3 _worldForward)
    {
        _worldForward = _transform.InverseTransformDirection(_worldForward);
        _transformLocalPlaneNormal = _transform.InverseTransformDirection(_transformLocalPlaneNormal);
        _worldForward = Vector3.ProjectOnPlane(_worldForward, _transformLocalPlaneNormal);
        _worldForward = _transform.TransformDirection(_worldForward);
        return _worldForward.normalized;
    }
    #endregion

    #region CombineMesh 合并网格
    /// <summary>
    /// 合并网格
    /// </summary>
    /// <param name="_self">源网格</param>
    /// <param name="_combine">要合并的网格</param>
    public static Mesh CombineMesh(this Mesh _self, Mesh _combine)
    {
        if (_combine.vertexCount > 0 && _combine.bounds.size != Vector3.zero)
        {
            List<CombineInstance> coms = new List<CombineInstance>();
            CombineInstance ins = new CombineInstance();
            ins.mesh = _combine;
            ins.transform = Matrix4x4.identity;
            coms.Add(ins);
            _self.CombineMeshes(coms.ToArray());
            _self.RecalculateNormals();
            _self.RecalculateBounds();
            //_self.Optimize();
        }
        return _self;
    }

    /// <summary>
    /// 合并骨骼网格
    /// </summary>
    /// <param name="_renders">骨骼Renders</param>
    public static Mesh CombineBoneMesh(this SkinnedMeshRenderer[] _renders)
    {
        Mesh mesh = new Mesh();
        CombineInstance ins;
        List<CombineInstance> coms = new List<CombineInstance>();
        if (_renders != null && _renders.Length > 0)
        {
            for (int i = 0; i < _renders.Length; i++)
            {
                if (_renders[i].sharedMesh != null)
                {
                    ins = new CombineInstance();
                    ins.mesh = _renders[i].sharedMesh;
                    ins.transform = _renders[i].localToWorldMatrix;
                    coms.Add(ins);
                }
            }
        }
        mesh.CombineMeshes(coms.ToArray());
        //mesh.Optimize();
        mesh.RecalculateBounds();
        return mesh;
    }

    /// <summary>
    /// 计算骨骼中心点
    /// </summary>
    /// <param name="_trans">骨骼Render</param>
    /// <returns>骨骼中心点</returns>
    public static Vector3 CalculateBoneCenter(this Transform[] _trans)
    {
        Vector3 center = Vector3.zero;
        if (_trans != null && _trans.Length > 0)
        {
            for (int i = 0; i < _trans.Length; i++)
            {
                center += _trans[i].position;
            }
            center /= _trans.Length;
        }
        return center;
    }
    #endregion
}
