using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class MConfigChange
    {
        public string MID { get; set; }
        public string SHMID { get; set; }
        public string ConfigName { get; set; }
        public string ConfigValue { get; set; }
        public DateTime ChangeDate { get; set; }
        public System.Data.SqlDbType DataType { get; set; }
        public bool IsValue { get; set; }
    }
}
