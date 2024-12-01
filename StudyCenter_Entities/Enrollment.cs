using System.Text.RegularExpressions;

namespace study_center_ef.Entities
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
       
        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int GroupID { get; set; }
        public Group Group { get; set; }

        public DateTime DeletionDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }


    }


}
