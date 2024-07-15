using AuthorsAPI.DTO;
using FluentValidation;

namespace AuthorsAPI.Validation
{
    public class AuthorCreateDtoValidator : AbstractValidator<AuthorCreateDto>
    {
        public AuthorCreateDtoValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(a => a.LastName).NotEmpty().MaximumLength(50);
            RuleFor(a => a.BirthDate).LessThan(DateTime.Now);
        }
    }
}
