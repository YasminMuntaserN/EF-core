namespace study_center_ef.Entities.views
{
    public class TeacherDetail
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        => $"TeacherID {TeacherID} | TeacherName {TeacherName} |Gender {Gender}  |Qualification {Qualification} |Salary {Salary:c}";
    }


}
