using Microsoft.EntityFrameworkCore;
using study_center_ef.Entities;
using study_center_ef.StudyCenter_Validation.Base;
using study_center_ef.StudyCenter_Validation.Results;


namespace study_center_ef.StudyCenter_Validation.Validators
{
    public class StudentValidator : BaseValidator<Student>
    {
        public StudentValidator(AppDbContext context) : base(context)
        {
        }

        public override async Task<ValidationResult> ValidateAsync(Student student)
        {
            var validationResult = CreateValidationResult();

            if (!HasValidStudentId(student.StudentID))
                validationResult.AddError("StudentID must be a positive integer.");

            if (!HasValidPersonId(student.PersonID))
                validationResult.AddError("PersonID must be a positive integer.");

            if (!await PersonExistsAsync(student.PersonID))
                validationResult.AddError("Person does not exist.");

            if (!HasValidGradeLevelId(student.GradeLevelID))
                validationResult.AddError("GradeLevelID must be a positive integer.");

            if (!await GradeLevelExistsAsync(student.GradeLevelID))
                validationResult.AddError("GradeLevel does not exist.");

            return validationResult;
        }

        private bool HasValidStudentId(int studentId)
        {
            return studentId >= 0;
        }

        private bool HasValidPersonId(int personId)
        {
            return personId > 0;
        }

        private async Task<bool> PersonExistsAsync(int personId)
        {
            return await _context.People.AnyAsync(p => p.PersonID == personId);
        }

        private bool HasValidGradeLevelId(int gradeLevelId)
        {
            return gradeLevelId > 0;
        }

        private async Task<bool> GradeLevelExistsAsync(int gradeLevelId)
        {
            return await _context.GradeLevels.AnyAsync(gl => gl.GradeLevelID == gradeLevelId);
        }
    }
}
