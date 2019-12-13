using System;
using System.Text;
/// <summary>
/// 引擎工具
/// </summary>
public sealed class StrayFogRunningUtility
{
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

