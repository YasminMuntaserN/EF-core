using Microsoft.Extensions.Logging;
using study_center_ef.Entities;
using study_center_ef.StudyCenter_Business.Base;
using study_center_ef.StudyCenter_Exceptions;
using study_center_ef.StudyCenter_Validation.Validators;

public class TeacherService : BaseService<Teacher>
{
    private readonly TeacherValidator _validator;
    private readonly ILogger<TeacherService> _logger;

    public TeacherService(
        AppDbContext context,
        ILogger<TeacherService> logger,
        TeacherValidator validator) : base(context, logger)
    {
        _validator = validator;
        _logger = logger;
    }

    public async Task<Teacher?> AddTeacherAsync(Teacher teacher)
    {
        var validationResult = await _validator.ValidateAsync(teacher);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                _logger.LogError($"Validation Error: {error}");
            }
            throw new ValidationException(validationResult.Errors);

        }

        return await CreateAsync(teacher);
    }

    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        var validationResult = await _validator.ValidateAsync(teacher);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                _logger.LogError($"Validation Error: {error}");
            }
            throw new ValidationException(validationResult.Errors);
        }

        await UpdateAsync(teacher);
    }

    public async Task<Teacher?> GetTeacherByIdAsync(int id)
           => await GetByIdAsync(id);

    public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
          => await GetAllAsync();

    public async Task DeleteTeacherAsync(int id)
    {
        var teacher = await GetByIdAsync(id);
        if (teacher == null)
        {
            _logger.LogWarning($"Teacher with ID {id} not found.");
            throw new KeyNotFoundException($"Teacher with ID {id} not found.");
        }

        await HardDeleteAsync(id);
    }

    public async Task<bool> Exists(int id)
            => await base.ExistsAsync(id);
}
