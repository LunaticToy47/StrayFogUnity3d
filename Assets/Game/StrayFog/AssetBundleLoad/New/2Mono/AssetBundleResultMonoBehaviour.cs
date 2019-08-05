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
    /// 内存组件
    /// </summary>
    AssetBundleMemoryMonoBehaviour mMemoryMono;

    /// <summary>
    /// 设置输入参数
    /// </summary>
    /// <param name="_memoryMono">内存组件</param>
    /// <param name="_inputParameter">输入参数</param>
    public void SetInputParameter(AssetBundleMemoryMonoBehaviour _memoryMono,IAssetBundleInputParameter _inputParameter)
    {
        mMemoryMono = _memoryMono;
        inputParameter = _inputParameter;
        mMemoryMono.OnMemoryLoadComplete += MMemoryMono_OnMemoryLoadComplete;
        mMemoryMono.OnMemoryLoadProgress += MMemoryMono_OnMemoryLoadProgress;
    }

    void MMemoryMono_OnMemoryLoadProgress(AssetBundleMemoryMonoBehaviour _mono)
    {
        foreach (IAssetBundleOutputParameter p in mQueueOutput)
        {
            p.progressCallback?.Invoke(_mono.progress, inputParameter);
        }
    }

    /// <summary>
    /// 内存加载完成
    /// </summary>
    /// <param name="_mono">组件</param>
    void MMemoryMono_OnMemoryLoadComplete(AssetBundleMemoryMonoBehaviour _mono)
    {
        IAssetBundleResult result = _mono.CreateResult(inputParameter);
        while (mQueueOutput.Count > 0)
        {
            IAssetBundleOutputParameter output = mQueueOutput.Dequeue();
            output.resultCallback?.Invoke(result);
        }
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
        if (mMemoryMono.isDone)
        {
            MMemoryMono_OnMemoryLoadComplete(mMemoryMono);
        }
        else
        {
            mQueueOutput.Enqueue(_output);
        }        
    }
}