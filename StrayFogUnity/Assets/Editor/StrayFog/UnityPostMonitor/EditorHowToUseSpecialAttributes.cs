#if UNITY_EDITOR
using System.Runtime.CompilerServices;
/// <summary>
/// 如果使用一些特殊的属性
/// </summary>
static class EditorHowToUseSpecialAttributes
{
    [MethodImpl(MethodImplOptions.Synchronized)]
    //https://www.cnblogs.com/zhuawang/archive/2013/05/27/3102834.htm
    //这里使用后线程同步锁，会超成死锁，不可以用
    static void MethodImpl()
    {

    }

    /*
     *==============[InitializeOnLoad]
     * Unity监听[InitializeOnLoad]在Unity启动时调用。
     * 参考：EditorUnityMonitor
     */
    /*
    * ==============UnityEditor.AssetModificationProcessor
    * https://docs.unity3d.com/ScriptReference/AssetModificationProcessor.html
    * Unity编辑器资源修改监听。
    * 参考：EditorUnityAssetModificationProcessor
    */
    /*
    * ==============AssetPostprocessor
    * https://blog.csdn.net/linxinfa/article/details/51801319
    * https://docs.unity3d.com/ScriptReference/AssetPostprocessor.html
    * Unity编辑器资源导入监听。
    * 参考：EditorUnityAssetPostprocessor
    */
}
#endif
