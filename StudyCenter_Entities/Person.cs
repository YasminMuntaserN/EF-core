﻿namespace study_center_ef.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        public ICollection<Student> Students { get; set; } = new List<Student>();



    }


}
