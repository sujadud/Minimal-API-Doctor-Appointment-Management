using AMS.MinimalAPI.Application.Roles.Commands;
using FluentValidation;

namespace AMS.MinimalAPI.Application.Roles.Validators;

public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleValidator()
    {
        RuleFor(r => r.Id).NotEmpty();
        RuleFor(r => r.Name).MinimumLength(2).NotEmpty().WithMessage("Role name is required.");
    }
}