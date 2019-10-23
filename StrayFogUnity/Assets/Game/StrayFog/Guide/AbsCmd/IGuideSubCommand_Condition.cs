/// <summary>
/// 引导子命令_条件接口
/// </summary>
public interface IGuideSubCommand_Condition
{
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    void ResolveConfig(XLS_Config_Table_UserGuideConfig _config);
}
