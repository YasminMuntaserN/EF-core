using Microsoft.Extensions.Logging;
using study_center_ef.Entities;
using study_center_ef.StudyCenter_Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.StudyCenter_Console
{
    public class StudentServiceTests
    {
        private readonly StudentService _service;

        public StudentServiceTests()
        {
            var dbContext = new AppDbContext();
            var logger = new LoggerFactory().CreateLogger<StudentService>();
            var validator = new StudentValidator(dbContext);
            _service = new StudentService(dbContext, logger, validator);
        }

        public async Task AddStudent()
        {
            var student = new Student { GradeLevelID = 1, PersonID = 4 };

            var result = await _service.AddStudentAsync(student);

            Console.WriteLine(result.StudentID);
        }

        public async Task UpdateStudent()
        {
            var student = new Student {StudentID=7, PersonID = 1, GradeLevelID = 3 };

            await _service.UpdateStudentAsync(student);

            var updatedStudent = await _service.GetStudentByIdAsync(7);
            Console.WriteLine($"StudentID :{ updatedStudent.StudentID} |StudentID :{updatedStudent.PersonID} |StudentID :{updatedStudent.GradeLevelID} ");
        }


        public async Task GetAllStudents()
        {
            var result = await _service.GetAllStudentsAsync();

            foreach( var student in result )
            {
                Console.WriteLine($"StudentID :{student.StudentID} |StudentID :{student.PersonID} |StudentID :{student.GradeLevelID} ");
            }
        }

        public async Task DeleteStudentWhenStudentExists()
        {
            await _service.DeleteStudentAsync(1);

            var student = await _service.GetStudentByIdAsync(1);

            Console.WriteLine(student);

        }
        public async Task Exists()
        {
            var result = await _service.Exists(5);
          
            Console.WriteLine(result.ToString());
        }


    }
}