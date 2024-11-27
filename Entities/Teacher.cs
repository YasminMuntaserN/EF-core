using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.Entities
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public int PersonID { get; set; }
        public DateTime HireDate { get; set; }
        public string Qualification { get; set; }
        public decimal Salary { get; set; }
    
        // public int UserID { get; set; }

        public Person Person { get; set; }
       // public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

    }
}
