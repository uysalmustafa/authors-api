using AuthorsAPI.DTO;
using FluentValidation;

namespace AuthorsAPI.Validation
{
    public class AuthorUpdateDtoValidator : AbstractValidator<AuthorUpdateDto>
    {
        public AuthorUpdateDtoValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(a => a.LastName).NotEmpty().MaximumLength(50);
            RuleFor(a => a.BirthDate).LessThan(DateTime.Now);
        }
    }
}
