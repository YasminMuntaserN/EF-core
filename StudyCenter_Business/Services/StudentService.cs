using Microsoft.Extensions.Logging;
using study_center_ef.Entities;
using study_center_ef.StudyCenter_Business.Base;
using study_center_ef.StudyCenter_Exceptions;
using study_center_ef.StudyCenter_Validation.Validators;

public class StudentService : BaseService<Student>
{
    private readonly StudentValidator _validator;
    private readonly ILogger<StudentService> _logger;

    public StudentService(
        AppDbContext context,
        ILogger<StudentService> logger,
        StudentValidator validator) : base(context, logger)
    {
        _validator = validator;
        _logger = logger;
    }

    public async Task<Student?> AddStudentAsync(Student student)
    {
        var validationResult = await _validator.ValidateAsync(student);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                _logger.LogError($"Validation Error: {error}");
            }
            throw new ValidationException(validationResult.Errors); 
        }

        return await CreateAsync(student);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        var validationResult = await _validator.ValidateAsync(student);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                _logger.LogError($"Validation Error: {error}");
            }
            throw new ValidationException(validationResult.Errors);
        }

        await UpdateAsync(student);
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
        => await GetByIdAsync(id);

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        => await GetAllAsync();

    public async Task DeleteStudentAsync(int id)
    {
        var student = await GetByIdAsync(id);
        if (student == null)
        {
            _logger.LogWarning($"Student with ID {id} not found.");
            throw new KeyNotFoundException($"Student with ID {id} not found.");
        }

        await HardDeleteAsync(id);
    }

    public async Task<bool> Exists(int id)
        => await base.ExistsAsync(id);
}
