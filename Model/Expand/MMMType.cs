using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum MMMOfferTimeType
{
    /// <summary>
    /// 排队期
    /// </summary>
    LineTime,

    /// <summary>
    /// 冻结期
    /// </summary>
    FreezeTime
}

public enum MMMMatchTimeType
{
    /// <summary>
    /// 打款
    /// </summary>
    PayLimitTime,

    /// <summary>
    /// 确认收款
    /// </summary>
    ConfirmLimitTime
}