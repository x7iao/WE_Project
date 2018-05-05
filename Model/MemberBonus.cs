using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class MemberBonus
    {
        public string MID { get; set; }
        public int TotalPoints { get; set; }
        public int ValidPoints { get; set; }
        public int TotalBonus { get; set; }
        public int ValidBonus { get; set; }
    }
}
