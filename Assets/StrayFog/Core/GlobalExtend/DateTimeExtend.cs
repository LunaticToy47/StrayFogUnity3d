using System;
/// <summary>
/// 日期时间扩展
/// </summary>
public static class DateTimeExtend
{
    #region UTC转日期时间
    /// <summary>
    /// Utc转日期时间
    /// </summary>
    /// <param name="_utc">utc值</param>
    /// <returns>日期</returns>
    public static DateTime Utc2Date(this double _utc)
    {
        DateTime dtZone = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return TimeZone.CurrentTimeZone.ToLocalTime(dtZone.AddSeconds(_utc));
    }
    #endregion

    #region 日期时间转UTC
    /// <summary>
    /// 日期时间转UTC
    /// </summary>
    /// <param name="_time">时间</param>
    /// <returns>utc值</returns>
    public static double ToUtc(this DateTime _time)
    {
        DateTime dtZone = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
        return (_time - dtZone).TotalSeconds;
    }
    #endregion
}
