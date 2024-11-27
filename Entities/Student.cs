using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.Entities
{
    public class Student
    {
      public int StudentID {  get; set; }
      public int PersonID { get; set; }
      public int  GradeLevelID {  get; set; }
    
     // public int CreatedByUserID { get; set; }
      public Person Person { get; set; }
     
      public GradeLevel GradeLevel { get; set; }

    }
}
