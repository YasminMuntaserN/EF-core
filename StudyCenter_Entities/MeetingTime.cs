using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.Entities
{
    public class MeetingTime
    {
        public int MeetingTimeID {  get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Group Group { get; set; }
    }
}
