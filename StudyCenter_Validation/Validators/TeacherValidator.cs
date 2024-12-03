using Microsoft.EntityFrameworkCore;
using study_center_ef.Entities;
using study_center_ef.StudyCenter_Validation.Base;
using study_center_ef.StudyCenter_Validation.Results;

namespace study_center_ef.StudyCenter_Validation.Validators
{
    public class TeacherValidator : BaseValidator<Teacher>
    {
        public TeacherValidator(AppDbContext context) : base(context)
        {
        }

        public override async Task<ValidationResult> ValidateAsync(Teacher teacher)
        {
            var validationResult = CreateValidationResult(); 

            if (!HasValidTeacherId(teacher.TeacherID))
                validationResult.AddError("TeacherID must be a positive integer.");

            if (!HasValidPersonId(teacher.PersonID))
                validationResult.AddError("PersonID must be a positive integer.");

            if (!await PersonExistsAsync(teacher.PersonID))
                validationResult.AddError("Person does not exist.");

            if (!HasValidHireDate(teacher.HireDate))
                validationResult.AddError("HireDate must be a valid date not in the future.");

            if (!HasValidQualification(teacher.Qualification))
                validationResult.AddError("Qualification is required and must not exceed 255 characters.");

            if (!HasValidSalary(teacher.Salary))
                validationResult.AddError("Salary must be greater than zero.");

            if (!HasValidTeacherSubjects(teacher.TeacherSubjects))
                validationResult.AddError("Teacher must be assigned to at least one subject.");

            return validationResult;
        }

        private bool HasValidTeacherId(int teacherId)
        {
            return teacherId >= 0;
        }

        private bool HasValidPersonId(int personId)
        {
            return personId > 0;
        }

        private async Task<bool> PersonExistsAsync(int personId)
        {
            return await _context.People.AnyAsync(p => p.PersonID == personId);
        }

        private bool HasValidHireDate(DateTime? hireDate)
        {
            if (!hireDate.HasValue)
                return false;

            return hireDate.Value <= DateTime.UtcNow
                && hireDate.Value > DateTime.UtcNow.AddYears(-50);
        }

        private bool HasValidQualification(string qualification)
        {
            return !string.IsNullOrWhiteSpace(qualification)
                && qualification.Length <= 255;
        }

        private bool HasValidSalary(decimal salary)
        {
            return salary > 0;
        }

        private bool HasValidTeacherSubjects(ICollection<TeacherSubject> teacherSubjects)
        {
            return teacherSubjects != null && teacherSubjects.Any();
        }
    }
}

