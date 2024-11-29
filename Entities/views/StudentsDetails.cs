namespace study_center_ef.Entities
{
    public class StudentDetail
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public string GradeLevel { get; set; }

        public override string ToString()
        => $"StudentID {StudentID} | TeacherName {StudentName} |Gender {Gender}  |GradeLevel {GradeLevel}";
    }


}
