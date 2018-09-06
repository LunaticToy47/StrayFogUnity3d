using System;
using System.Text;
using UnityEngine;
/// <summary>
/// 引擎工具
/// </summary>
public sealed class StrayFogUtility
{
    #region NewGlobalUniqueId 新生成全局唯一ID
    /// <summary>
    /// 新生成全局唯一ID
    /// </summary>
    /// <returns>全局唯一ID</returns>
    public static int NewGlobalUniqueId()
    {
        return (Guid.NewGuid().ToString() + SystemInfo.deviceUniqueIdentifier).UniqueHashCode();
    }
    #endregion

    #region Profiler性能调试
    /// <summary>
    /// 内存性能信息
    /// </summary>
    static StringBuilder mProfilerMemorySb = new StringBuilder();
    /// <summary>
    /// 获得性能调试内存信息
    /// </summary>
    /// <returns>内存信息</returns>
    public static string GetProfilerMemoryInfo()
    {
        return GetProfilerMemoryInfo(null);
    }
    /// <summary>
    /// 获得性能调试内存信息
    /// </summary>
    /// <param name="_process">进程</param>
    /// <returns>内存信息</returns>
    public static string GetProfilerMemoryInfo(System.Diagnostics.Process _process)
    {
        mProfilerMemorySb.Length = 0;
        mProfilerMemorySb.AppendLine("Profiler=>");
        long len = 0;
        double size = 0;
        len = UnityEngine.Profiling.Profiler.usedHeapSizeLong;
        size = len.ToRAM(enRAMUnit.MB);
        mProfilerMemorySb.AppendLine(string.Format("usedHeapSize(当前使用堆)=>{0}MB", size.ToString("f2")));

        len = UnityEngine.Profiling.Profiler.GetMonoHeapSizeLong();
        size = len.ToRAM(enRAMUnit.MB);
        mProfilerMemorySb.AppendLine(string.Format("GetMonoHeapSize(Mono堆)=>{0}MB", size.ToString("f2")));

        len = UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong();
        size = len.ToRAM(enRAMUnit.MB);
        mProfilerMemorySb.AppendLine(string.Format("GetMonoUsedSize(Mono堆已使用)=>{0}MB", size.ToString("f2")));

        len = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();
        size = len.ToRAM(enRAMUnit.MB);
        mProfilerMemorySb.AppendLine(string.Format("GetTotalAllocatedMemory(总分配内存)=>{0}MB", size.ToString("f2")));

        len = UnityEngine.Profiling.Profiler.GetTotalReservedMemoryLong();
        size = len.ToRAM(enRAMUnit.MB);
        mProfilerMemorySb.AppendLine(string.Format("GetTotalReservedMemory(保留内存)=>{0}MB", size.ToString("f2")));

        len = UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemoryLong();
        size = len.ToRAM(enRAMUnit.MB);
        mProfilerMemorySb.AppendLine(string.Format("GetTotalUnusedReservedMemory(未使用保留内存)=>{0}MB", size.ToString("f2")));

        if (_process != null)
        {
            len = _process.NonpagedSystemMemorySize64;
            size = len.ToRAM(enRAMUnit.MB);
            mProfilerMemorySb.AppendLine(string.Format("NonpagedSystemMemorySize64(获取为关联的进程分配的非分页系统内存量)=>{0}MB", size.ToString("f2")));
            len = _process.PagedMemorySize64;
            size = len.ToRAM(enRAMUnit.MB);
            mProfilerMemorySb.AppendLine(string.Format("PagedMemorySize64(获取为关联的进程分配的分页内存量)=>{0}MB", size.ToString("f2")));
            len = _process.PagedSystemMemorySize64;
            size = len.ToRAM(enRAMUnit.MB);
            mProfilerMemorySb.AppendLine(string.Format("PagedSystemMemorySize64(获取为关联的进程分配的可分页系统内存量)=>{0}MB", size.ToString("f2")));
            len = _process.PeakPagedMemorySize64;
            size = len.ToRAM(enRAMUnit.MB);
            mProfilerMemorySb.AppendLine(string.Format("PeakPagedMemorySize64(获取关联的进程使用的虚拟内存分页文件中的最大内存量)=>{0}MB", size.ToString("f2")));
            len = _process.PeakVirtualMemorySize64;
            size = len.ToRAM(enRAMUnit.MB);
            mProfilerMemorySb.AppendLine(string.Format("PeakVirtualMemorySize64(获取关联的进程使用的最大虚拟内存量)=>{0}MB", size.ToString("f2")));
            len = _process.PrivateMemorySize64;
            size = len.ToRAM(enRAMUnit.MB);
            mProfilerMemorySb.AppendLine(string.Format("PrivateMemorySize64(获取为关联的进程分配的专用内存量)=>{0}MB", size.ToString("f2")));
            len = _process.VirtualMemorySize64;
            size = len.ToRAM(enRAMUnit.MB);
            mProfilerMemorySb.AppendLine(string.Format("VirtualMemorySize64(获取为关联的进程分配的虚拟内存量)=>{0}MB", size.ToString("f2")));
        }
        return mProfilerMemorySb.ToString();
    }
    #endregion

    #region SingleMonoBehaviour 单例AbsSingleMonoBehaviour对象扩展
    /// <summary>
    /// 单例AbsSingleMonoBehaviour对象扩展
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <returns>对象</returns>
    public static T SingleMonoBehaviour<T>()
        where T : AbsSingleMonoBehaviour
    {
        return AbsSingleMonoBehaviour.current<T>();
    }
    #endregion

    #region Single 单例AbsSingle对象扩展
    /// <summary>
    /// 单例AbsSingle对象扩展
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <returns>对象</returns>
    public static T Single<T>()
        where T : AbsSingle
    {
        return AbsSingle.current<T>();
    }
    #endregion

    #region SingleScriptableObject 单例AbsSingleScriptableObject对象扩展
    /// <summary>
    /// 单例AbsSingleScriptableObject对象扩展
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <returns>对象</returns>
    public static T SingleScriptableObject<T>()
        where T : AbsSingleScriptableObject
    {
        return AbsSingleScriptableObject.current<T>();
    }
    #endregion
}

