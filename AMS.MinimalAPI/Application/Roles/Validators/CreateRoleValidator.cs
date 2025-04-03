using AMS.MinimalAPI.Application.Roles.Commands;
using FluentValidation;

namespace AMS.MinimalAPI.Application.Roles.Validators;

public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleValidator()
    {
        RuleFor(r => r.Name).MinimumLength(2).NotEmpty().WithMessage("Role name is required.");
    }
}