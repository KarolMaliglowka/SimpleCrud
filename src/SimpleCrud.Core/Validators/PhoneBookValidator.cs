using FluentValidation;
using SimpleCrud.Core.Entities;

namespace SimpleCrud.Core.Validators;

public class PhoneBookValidator : AbstractValidator<PhoneBook>
{
    public PhoneBookValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        
    }
}