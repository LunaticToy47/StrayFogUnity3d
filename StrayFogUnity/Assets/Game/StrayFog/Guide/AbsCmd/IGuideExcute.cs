/// <summary>
/// 引导执行接口
/// </summary>
public interface IGuideExcute
{
    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">执行发起者</param>
    /// <param name="_parameters">参数</param>
    void Excute(IGuideCommand _sender, IGuideMatchCondition _sponsor, params object[] _parameters);
}