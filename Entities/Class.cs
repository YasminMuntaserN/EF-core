namespace study_center_ef.Entities
{
    public class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public byte Capacity { get; set; }
        public string? Description { get; set; }

     //   public ICollection<Group> Groups { get; set; } = new List<Group>();
    }


}
