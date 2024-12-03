using Microsoft.EntityFrameworkCore;
using study_center_ef.Entities;
using study_center_ef.StudyCenter_Validation.Base;
using study_center_ef.StudyCenter_Validation.Results;

namespace study_center_ef.StudyCenter_Validation.Validators
{
    public class ClassValidator : BaseValidator<Class>
    {
        public ClassValidator(AppDbContext context) : base(context)
        {
        }

        public override async Task<ValidationResult> ValidateAsync(Class classEntity)
        {
            var validationResult = CreateValidationResult();

            if (!HasValidClassId(classEntity.ClassID))
                validationResult.AddError("ClassID must be a positive integer.");

            if (!HasValidClassName(classEntity.ClassName))
                validationResult.AddError("ClassName is required and must not exceed 255 characters.");

            if (!HasValidCapacity(classEntity.Capacity))
                validationResult.AddError("Capacity must be a positive integer and cannot exceed 255.");

            if (!HasValidDescription(classEntity.Description))
                validationResult.AddError("Description must not exceed 500 characters.");

            if (classEntity.Groups != null && classEntity.Groups.Any())
            {
                foreach (var group in classEntity.Groups)
                {
                    if (!await GroupExistsAsync(group.GroupID))
                        validationResult.AddError($"Group with ID {group.GroupID} does not exist.");
                }
            }

            return validationResult;
        }

        private bool HasValidClassId(int classId)
        {
            return classId > 0;
        }

        private bool HasValidClassName(string className)
        {
            return !string.IsNullOrWhiteSpace(className) && className.Length <= 255;
        }

        private bool HasValidCapacity(byte capacity)
        {
            return capacity > 0 && capacity <= 255;
        }

        private bool HasValidDescription(string? description)
        {
            return string.IsNullOrWhiteSpace(description) || description.Length <= 500;
        }

        private async Task<bool> GroupExistsAsync(int groupId)
        {
            return await _context.Groups.AnyAsync(g => g.GroupID == groupId);
        }
    }
}
