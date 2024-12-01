using Microsoft.Extensions.Logging;
using study_center_ef.Entities;
using study_center_ef.StudyCenter_Business.Base;
using study_center_ef.StudyCenter_Exceptions;
using study_center_ef.StudyCenter_Validation.Validators;

public class ClassService : BaseService<Class>
{
    private readonly ClassValidator _validator;
    private readonly ILogger<ClassService> _logger;

    public ClassService(
        AppDbContext context,
        ILogger<ClassService> logger,
        ClassValidator validator) : base(context, logger)
    {
        _validator = validator;
        _logger = logger;
    }

    public async Task<Class?> AddClassAsync(Class Class)
    {
        var validationResult = await _validator.ValidateAsync(Class);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                _logger.LogError($"Validation Error: {error}");
            }
            throw new ValidationException(validationResult.Errors);

        }

        return await CreateAsync(Class);
    }

    public async Task UpdateClassAsync(Class Class)
    {
        var validationResult = await _validator.ValidateAsync(Class);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                _logger.LogError($"Validation Error: {error}");
            }
            throw new ValidationException(validationResult.Errors);
        }

        await UpdateAsync(Class);
    }

    public async Task<Class?> GetClassByIdAsync(int id)
           => await GetByIdAsync(id);

    public async Task<IEnumerable<Class>> GetAllClasssAsync()
          => await GetAllAsync();

    public async Task DeleteClassAsync(int id)
    {
        var Class = await GetByIdAsync(id);
        if (Class == null)
        {
            _logger.LogWarning($"Class with ID {id} not found.");
            throw new KeyNotFoundException($"Class with ID {id} not found.");
        }

        await HardDeleteAsync(id);
    }

    public async Task<bool> Exists(int id)
            => await base.ExistsAsync(id);
}
