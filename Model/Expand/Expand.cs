using System;

public static class Expand
{
    /// <summary>
    /// 固定长度字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string ToString(this string str, int length)
    {
        string result = str;
        if (str.Length > length)
        {
            result = str.Substring(0, length) + "...";
        }
        return result;
    }

    /// <summary>
    /// 转换成字符串
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime ToShortDate(this DateTime dateTime)
    {
        return Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd hh:mm:ss:fff"));
    }

    /// <summary>
    /// 转换成字符串
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime ToShortDate(this DateTime dateTime, string format)
    {
        return Convert.ToDateTime(dateTime.ToString(format));
    }

    /// <summary>
    /// 获取当前日期的前几天0时
    /// </summary>
    /// <param name="days">前几天(默认当天)</param>
    /// <returns></returns>
    public static DateTime GetDaysAgo(this DateTime dateTime, int days = 0)
    {
        var date = dateTime.AddDays(-1 * days);
        date = Convert.ToDateTime(string.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day));
        return date;
    }

    /// <summary>
    /// 获取当前日期的前几天0时
    /// </summary>
    /// <param name="months">前几月(默认本月)</param>
    /// <returns></returns>
    public static DateTime GetMonthsAgo(this DateTime dateTime, int months = 0)
    {
        var date = dateTime.AddMonths(-1 * months);
        date = Convert.ToDateTime(string.Format("{0}-{1}-{2}", date.Year, date.Month, 1));
        return date;
    }

    /// <summary>
    /// 保留指定位数的小数
    /// </summary>
    /// <param name="dvalue">数值</param>
    /// <param name="le">保留位数(默认2位)</param>
    /// <param name="RoundUp">是否四舍五入(默认舍去后面的值)</param>
    /// <returns></returns>
    public static string ToFixedString(this decimal dvalue, int le = 2)
    {
        return Math.Round(dvalue, le).ToString();
    }

    /// <summary>
    /// 保留指定位数的小数
    /// </summary>
    /// <param name="dvalue">数值</param>
    /// <param name="le">保留位数(默认2位)</param>
    /// <param name="RoundUp">是否四舍五入(默认舍去后面的值)</param>
    /// <returns></returns>
    public static decimal ToFixedDecimal(this decimal dvalue, int le = 2)
    {
        return Math.Round(dvalue, le);
    }

    /// <summary>
    /// 转换成百分比形式
    /// </summary>
    /// <param name="dvalue">数值</param>
    /// <param name="le">保留位数(默认2位)</param>
    /// <param name="RoundUp">是否四舍五入(默认舍去后面的值)</param>
    /// <returns></returns>
    public static string ToPercent(this decimal dvalue, int le = 2)
    {
        decimal value = Math.Round(dvalue, le);
        return value + "%";
    }
}