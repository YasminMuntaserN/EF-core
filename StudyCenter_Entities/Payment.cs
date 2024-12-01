namespace study_center_ef.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int GroupID { get; set; }
        public Group Group { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }  

    }


}
