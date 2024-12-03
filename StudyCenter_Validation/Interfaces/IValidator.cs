using study_center_ef.StudyCenter_Validation.Results;

namespace study_center_ef.StudyCenter_Validation.Interfaces
{
    public interface IValidator<T>
    {
        Task<ValidationResult> ValidateAsync(T entity);
    }
}
