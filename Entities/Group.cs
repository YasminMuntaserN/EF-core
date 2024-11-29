using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.Entities
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
       
        public int ClassID { get; set; }
        public Class Class { get; set; }

        public int GradeLevelSubjectID { get; set; }
        public GradeLevelSubject GradeLevelSubject { get; set; }
       
        public int TeacherSubjectID { get; set; }
        public TeacherSubject TeacherSubject { get; set; }

        public int GroupStudentCount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

         public int MeetingTimeID { get; set; }
         public MeetingTime MeetingTime { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}
