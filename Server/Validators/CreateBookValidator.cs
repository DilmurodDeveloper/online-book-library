using FluentValidation;
using OnlineBookLibrary.Server.Dtos;

namespace OnlineBookLibrary.Server.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Title is required.");

            RuleFor(b => b.Author)
                .NotEmpty().WithMessage("Author is required.");

            RuleFor(b => b.CategoryId)
                .GreaterThan(0).WithMessage("Category must be selected.");
        }
    }
}