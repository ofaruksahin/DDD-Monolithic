namespace EShop.Domain.Core.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public List<ValidationFailure> Errors { get; private set; }
        public BusinessRuleValidationException(List<ValidationFailure> errors)
            : base(String.Join(Environment.NewLine, errors.Select(f => f.ErrorMessage)))
        {
            Errors = errors;
        }
    }
}

