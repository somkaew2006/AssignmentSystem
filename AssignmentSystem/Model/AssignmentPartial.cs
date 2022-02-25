using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSystem.Model
{
    class AssignmentPartial :Assignment
    {
        public string HasDoc { get; set; }
        public string HasSub1 { get; set; }
        public string HasSub2 { get; set; }
        public string HasSub3 { get; set; }
        public DateTime A_DateCov { get; set; }
    }
}
