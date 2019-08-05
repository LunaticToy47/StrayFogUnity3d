using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 资源AssetBundle资源结果组件
/// </summary>
[AddComponentMenu("StrayFog/Game/AssetBundle/AssetBundleResultMonoBehaviour")]
[DisallowMultipleComponent()]
public class AssetBundleResultMonoBehaviour : AbsMonoBehaviour
{
    /// <summary>
    /// 输入参数
    /// </summary>
    public IAssetBundleInputParameter inputParameter { get; private set; }

    /// <summary>
    /// 设置输入参数
    /// </summary>
    /// <param name="inputParameter">输入参数</param>
    public void SetInputParameter(IAssetBundleInputParameter _inputParameter)
    {
        inputParameter = _inputParameter;
    }

    /// <summary>
    /// 输出队列
    /// </summary>
    Queue<IAssetBundleOutputParameter> mQueueOutput = new Queue<IAssetBundleOutputParameter>();
    /// <summary>
    /// 添加请求
    /// </summary>
    /// <param name="_output">输出参数</param>
    public void AddRequest(IAssetBundleOutputParameter _output)
    {
        mQueueOutput.Enqueue(_output);
    }
}