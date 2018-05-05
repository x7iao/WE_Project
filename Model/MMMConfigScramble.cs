/**  版本信息模板在安装目录下，可自行修改。
* MMMConfigScramble.cs
*
* 功 能： N/A
* 类 名： MMMConfigScramble
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/22 17:06:43   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
namespace WE_Project.Model
{
    /// <summary>
    /// MMMConfigScramble:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MMMConfigScramble
    {
        public MMMConfigScramble()
        { }

        # region Model
        private int _paylimittimes;
        private int _confirmlimittimes;
        private string _opentime;
        private bool _openswitch;
        private int _freezetimes;
        private decimal _scramblereward;
        private int _scramblelixidays;
        private int _disappeartimes;
        /// <summary>
        /// 打款时间
        /// </summary>
        public int PayLimitTimes
        {
            set { _paylimittimes = value; }
            get { return _paylimittimes; }
        }
        /// <summary>
        /// 收款时间
        /// </summary>
        public int ConfirmLimitTimes
        {
            set { _confirmlimittimes = value; }
            get { return _confirmlimittimes; }
        }
        /// <summary>
        /// 抢单开放时间
        /// </summary>
        public List<string> OpenTimeList
        {
            get
            {
                if (!string.IsNullOrEmpty(OpenTime))
                    return OpenTime.Split(';').Where(emp => !string.IsNullOrEmpty(emp)).ToList();
                return new List<string>();
            }
        }
        /// <summary>
        /// 抢单开放时间
        /// </summary>
        public string OpenTime
        {
            set { _opentime = value; }
            get { return _opentime; }
        }
        /// <summary>
        /// 抢单开放开关
        /// </summary>
        public bool OpenSwitch
        {
            set { _openswitch = value; }
            get { return _openswitch; }
        }
        /// <summary>
        /// 冻结时间(交易完成)
        /// </summary>
        public int FreezeTimes
        {
            set { _freezetimes = value; }
            get { return _freezetimes; }
        }
        /// <summary>
        /// 抢单交易完成奖金
        /// </summary>
        public decimal ScrambleReward
        {
            set { _scramblereward = value; }
            get { return _scramblereward; }
        }
        /// <summary>
        /// 抢单获得利息天数
        /// </summary>
        public int ScrambleLiXiDays
        {
            set { _scramblelixidays = value; }
            get { return _scramblelixidays; }
        }
        /// <summary>
        /// 消失时间
        /// </summary>
        public int DisappearTimes
        {
            set { _disappeartimes = value; }
            get { return _disappeartimes; }
        }

        # endregion Model

    }
}

