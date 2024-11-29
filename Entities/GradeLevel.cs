namespace study_center_ef.Entities
{
    public class GradeLevel
    {
        public int GradeLevelID { get; set; }
        public string GradeLevelName { get; set; }
      
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        public ICollection<Student> Students { get; set; } = new List<Student>();
      
        public ICollection<GradeLevelSubject> GradeLevelSubjects { get; set; } = new List<GradeLevelSubject>();


    }


}
