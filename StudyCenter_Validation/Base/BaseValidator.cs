using Microsoft.EntityFrameworkCore;
using study_center_ef.StudyCenter_Validation.Interfaces;
using study_center_ef.StudyCenter_Validation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.StudyCenter_Validation.Base
{

    // Abstract base class that provides a common framework for validating entities of a generic type T
    public abstract class BaseValidator<T> : IValidator<T>
    {
        // Protected field to hold the database context, allowing access to the database for validation checks
        protected readonly AppDbContext _context;

        //  initialize the database context
        protected BaseValidator(AppDbContext context)
        {
            _context = context;
        }

        // Abstract method that must be implemented by derived classes to perform validation on an entity of type T
        public abstract Task<ValidationResult> ValidateAsync(T entity);

        // Utility method to create and return a new ValidationResult instance
        protected ValidationResult CreateValidationResult()
        {
            return new ValidationResult();
        }

        // Asynchronous method to check if an entity in a database query is unique
        // Parameters:
        // - query: The database query to check for existing records
        // - errorMessage: The error message to add if the entity is not unique
        // - result: The ValidationResult to store any validation errors
        protected async Task<bool> IsUniqueAsync<TEntity>(
            IQueryable<TEntity> query,
            string errorMessage,
            ValidationResult result)
        {
            // Check if any records matching the query exist in the database
            var exists = await query.AnyAsync();

            // If a matching record exists, add the error message to the ValidationResult
            if (exists)
            {
                result.AddError(errorMessage);
                return false;  // Return false to indicate the uniqueness check failed
            }

            return true;  // Return true if the entity is unique
        }
    }
}

