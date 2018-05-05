using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SystemTimeRange
{
    /// <summary>
    /// 字符串是否是正确时间
    /// </summary>
    /// <param name="timesStr"></param>
    /// <returns></returns>
    public static bool IsTimeList(string timesStr)
    {
        string nowDate = DateTime.Now.ToString("yyyy-MM-dd ");
        List<string> list = OpenTimeList(timesStr);
        try
        {
            foreach (string time in list)
            {
                string[] times = time.Split('-');
                if (DateTime.Parse(nowDate + times[0]) < DateTime.Parse(nowDate + times[1]))
                    return true;
            }
        }
        catch
        { }
        return false;
    }

    /// <summary>
    /// 时间转列表
    /// </summary>
    /// <param name="times"></param>
    /// <returns></returns>
    private static List<string> OpenTimeList(string times)
    {
        if (!string.IsNullOrEmpty(times))
            return times.Split(';').Where(emp => !string.IsNullOrEmpty(emp)).ToList();
        return new List<string>();
    }

    /// <summary>
    /// 判断是否开启
    /// </summary>
    /// <param name="list"></param>
    /// <param name="nowtime"></param>
    /// <returns></returns>
    public static bool TimeIsClose(string times, DateTime nowtime)
    {
        if (IsTimeList(times))
        {
            return TimeInRange(OpenTimeList(times), nowtime);
        }
        return false;
    }

    /// <summary>
    /// 时间是否在该范围内
    /// </summary>
    /// <param name="list"></param>
    /// <param name="nowtime"></param>
    /// <returns></returns>
    private static bool TimeInRange(List<string> list, DateTime nowtime)
    {
        string nowDate = nowtime.ToString("yyyy-MM-dd ");
        foreach (string time in list)
        {
            string[] times = time.Split('-');
            if (DateTime.Parse(nowDate + times[0]) < nowtime && DateTime.Parse(nowDate + times[1]) > nowtime)
                return true;
        }
        return false;
    }
}
