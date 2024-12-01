namespace study_center_ef.Entities
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string? SubjectName { get; set; }

        public int GradeLevelId { get; set; }
        public GradeLevel GradeLevel { get; set; }

        public ICollection<GradeLevelSubject> GradeLevelSubjects { get; set; } = new List<GradeLevelSubject>();

    }


}
