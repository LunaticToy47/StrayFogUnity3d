/// <summary>
/// 参考对象_无
/// </summary>
public class UserGuideReferObject_None_Command : AbsGuideSubCommand_ReferObject
{
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected override bool OnIsMatchCondition()
    {
        return true;
    }
}
