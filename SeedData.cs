using study_center_ef.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef
{
    public class SeedData
    {
        public static List<Person> LoadPeople() => new()
        {
            new Person
                {
                    PersonID = 1,
                    FirstName = "John",
                    SecondName = "Michael",
                    ThirdName = "David",
                    LastName = "Doe",
                    Gender = 1,
                    DateOfBirth = new DateTime(1990, 5, 14),
                    PhoneNumber = "123-456-7890",
                    Email = "john.doe@email.com",
                    Address = "123 Elm Street, Springfield",
                },
                new Person
                {
                    PersonID = 2,
                    FirstName = "Jane",
                    SecondName = "Maria",
                    ThirdName = "Ann",
                    LastName = "Smith",
                    Gender = 2,
                    DateOfBirth = new DateTime(1995, 8, 22),
                    PhoneNumber = "987-654-3210",
                    Email = "jane.smith@email.com",
                    Address = "456 Oak Avenue, Springfield",
                },
                new Person
                {
                    PersonID = 3,
                    FirstName = "Mark",
                    SecondName = "William",
                    ThirdName = "Edward",
                    LastName = "Johnson",
                    Gender = 1,
                    DateOfBirth = new DateTime(1988, 11, 30),
                    PhoneNumber = "555-123-4567",
                    Email = "mark.johnson@email.com",
                    Address = "789 Pine Road, Springfield",
                },
                new Person
                {
                    PersonID = 4,
                    FirstName = "Lucy",
                    SecondName = "Alice",
                    ThirdName = "Marie",
                    LastName = "Green",
                    Gender = 2,
                    DateOfBirth = new DateTime(2000, 3, 17),
                    PhoneNumber = "555-987-6543",
                    Email = "lucy.green@email.com",
                    Address = "101 Maple Drive, Springfield",
                },
                new Person
                {
                    PersonID = 5,
                    FirstName = "Tom",
                    SecondName = "Richard",
                    ThirdName = "Henry",
                    LastName = "Taylor",
                    Gender = 1,
                    DateOfBirth = new DateTime(1992, 7, 5),
                    PhoneNumber = "321-654-9870",
                    Email = "tom.taylor@email.com",
                    Address = "202 Birch Lane, Springfield",
                }
            };

        public static List<Class> LoadClasses() => new()
        {
            new Class { ClassID = 1, ClassName = "Math-101", Description = "Intro to Algebra", Capacity = 30 },
            new Class { ClassID = 2, ClassName = "Sci-102", Description = "Basic Chemistry", Capacity = 25 },
            new Class { ClassID = 3, ClassName = "Eng-201", Description = "Advanced Grammar", Capacity = 20 },
            new Class { ClassID = 4, ClassName = "Hist-301", Description = "World History", Capacity = 15 }
        };

        public static List<GradeLevel> LoadGradeLevels() => new()
        {
            new GradeLevel { GradeLevelID = 1, GradeLevelName = "6th Grade" },
            new GradeLevel { GradeLevelID = 2, GradeLevelName = "7th Grade" },
            new GradeLevel { GradeLevelID = 3, GradeLevelName = "8th Grade" },
            new GradeLevel { GradeLevelID = 4, GradeLevelName = "9th Grade" }
        };

        public static List<Subject> LoadSubjects() => new()
        {
            new Subject { SubjectID = 1,GradeLevelId = 1, SubjectName = "Mathematics" },
            new Subject { SubjectID = 2,GradeLevelId = 2, SubjectName = "Science" },
            new Subject { SubjectID = 3,GradeLevelId = 3, SubjectName = "English" },
            new Subject { SubjectID = 4, GradeLevelId = 5,SubjectName = "History" },
        };
        
        public static List<Student> LoadStudents() => new()
        {
         new Student { StudentID = 1,  GradeLevelID = 1, PersonID = 1 },
         new Student { StudentID = 2,  GradeLevelID = 2, PersonID = 2 },
         new Student { StudentID = 3,  GradeLevelID = 3, PersonID = 3 },
         new Student { StudentID = 4,  GradeLevelID = 4, PersonID = 4 }
        };

        public static List<Teacher> LoadTeachers() => new()
        {
            new Teacher
            {
                TeacherID = 1,
                PersonID = 1,
                HireDate = new DateTime(2015,9,4),
                Qualification = "MSc in Mathematics",
                Salary = 50000m,
            },
            new Teacher
            {
                TeacherID = 2,
                PersonID = 2,
                HireDate =new DateTime(2015,9,4),
                Qualification = "MSc in Physics",
                Salary = 55000m,
            },
            new Teacher
            {
                TeacherID = 3,
                PersonID = 3,
                HireDate =new DateTime(2015,9,4),
                Qualification = "BA in English Literature",
                Salary = 45000m,
            },
            new Teacher
            {
                TeacherID = 4,
                PersonID = 4,
                HireDate = new DateTime(2015,9,4),
                Qualification = "PhD in History",
                Salary = 60000m,
            }
        };

        public static List<GradeLevelSubject> LoadGradeLevelSubjects() => new()
        {
            new GradeLevelSubject
            {
                GradeLevelSubjectID = 1,
                GradeLevelID = 1,
                SubjectID = 1,
                Title = "6th Grade - Mathematics",
                Fees = 100
            },
            new GradeLevelSubject
            {
                GradeLevelSubjectID = 2,
                GradeLevelID = 2,
                SubjectID = 2,
                Title = "7th Grade - Science",
                Fees = 120
            },
            new GradeLevelSubject
            {
                GradeLevelSubjectID = 3,
                GradeLevelID = 3,
                SubjectID = 3,
                Title = "8th Grade - English",
                Fees = 110
            },
            new GradeLevelSubject
            {
                GradeLevelSubjectID = 4,
                GradeLevelID = 4,
                SubjectID = 4,
                Title = "9th Grade - History",
                Fees = 130
            }
        };

        public static List<TeacherSubject> LoadTeacherSubjects() => new()
        {
        new TeacherSubject { TeacherSubjectID = 1, TeacherID = 1, GradeLevelSubjectID = 1, IsActive = true },
        new TeacherSubject { TeacherSubjectID = 2, TeacherID = 2, GradeLevelSubjectID = 2, IsActive = true },
        new TeacherSubject { TeacherSubjectID = 3, TeacherID = 3, GradeLevelSubjectID = 3, IsActive = false },
        new TeacherSubject { TeacherSubjectID = 4, TeacherID = 4, GradeLevelSubjectID = 4, IsActive = true },
        };

        public static List<MeetingTime> LoadMeetingTimes() => new()
        {
            new MeetingTime
            {
                MeetingTimeID = 1,
                StartTime = new DateTime(2024, 8, 10, 9, 0, 0),
                EndTime = new DateTime(2024, 8, 10, 11, 0, 0)
            },
            new MeetingTime
            {
                MeetingTimeID = 2,
                StartTime = new DateTime(2024, 8, 11, 18, 0, 0),
                EndTime = new DateTime(2024, 8, 11, 20, 0, 0)
            }
        };

        public static List<Group> LoadGroups() => new()
        {
            new Group
            {
                GroupID = 1,
                GroupName = "Math Morning Group",
                ClassID = 1,
                GradeLevelSubjectID = 1,
                TeacherSubjectID = 1,
                GroupStudentCount = 20,
                IsActive = true,
                CreationDate = DateTime.ParseExact("2024-05-29T19:52:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                MeetingTimeID = 1
            },
            new Group
            {
                GroupID = 2,
                GroupName = "Science Evening Group",
                ClassID = 2,
                GradeLevelSubjectID = 2,
                TeacherSubjectID = 2,
                GroupStudentCount = 25,
                IsActive = true,
                CreationDate = DateTime.ParseExact("2024-04-29T19:52:01", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                MeetingTimeID = 2
            }
        };

        public static List<Enrollment> LoadEnrollments() => new()
        {
            new Enrollment
            {
                EnrollmentID = 1,
                StudentID = 1,
                GroupID = 1,
                EnrollmentDate = DateTime.Now.AddMonths(-2),
                DeletionDate = DateTime.MinValue,
                IsActive = true
            },
            new Enrollment
            {
                EnrollmentID = 2,
                StudentID = 2,
                GroupID = 2,
                EnrollmentDate = DateTime.Now.AddMonths(-1),
                DeletionDate = DateTime.MinValue,
                IsActive = true
            }
        };


    }
}
