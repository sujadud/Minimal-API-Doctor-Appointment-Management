using AMS.MinimalAPI.Application.Roles.Commands;
using FluentValidation;

namespace AMS.MinimalAPI.Application.Roles.Validators;

public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleValidator()
    {
        RuleFor(r => r.Id).NotEmpty().WithMessage("Role ID not found.");
    }
}