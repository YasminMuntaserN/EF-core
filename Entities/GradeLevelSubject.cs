namespace study_center_ef.Entities
{
    public class GradeLevelSubject
    {
        public int GradeLevelSubjectID { get; set; }
        public int SubjectID { get; set; }
        public int GradeLevelID { get; set; }
        public string? Title { get; set; }
        public int Fees { get; set; }
        public Subject Subject { get; set; }
        public GradeLevel GradeLevel { get; set; }
    }
}