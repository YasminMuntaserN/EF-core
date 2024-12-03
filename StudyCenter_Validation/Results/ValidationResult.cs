using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.StudyCenter_Validation.Results
{
    public class ValidationResult
    {
        //  list to store validation error messages
        private readonly List<string> _errors = new();

        // Public property providing read-only access to the list of error messages
        public IReadOnlyList<string> Errors => _errors;

        public bool IsValid => !_errors.Any();

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public void AddErrors(IEnumerable<string> errors)
        {
            _errors.AddRange(errors);
        }
    }
}
