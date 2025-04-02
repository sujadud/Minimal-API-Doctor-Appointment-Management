using AMS.MinimalAPI.Application.Users.Commands;
using FluentValidation;

namespace AMS.MinimalAPI.Application.Users.Validators;
public class UpdateteUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateteUserCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Username).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Role).NotEmpty();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.PhoneNumber).NotEmpty();
    }
}
