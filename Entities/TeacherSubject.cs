using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.Entities
{
    public class TeacherSubject
    {
        public int TeacherSubjectID {  get; set; }

        public int TeacherID {  get; set; }
        public Teacher Teacher { get; set; }

        public int GradeLevelSubjectID {  get; set; }
        public GradeLevelSubject GradeLevelSubject { get; set; }


        public bool IsActive {  get; set; }

        public ICollection<Group> Groups { get; set; } = new List<Group>();


    }
}
