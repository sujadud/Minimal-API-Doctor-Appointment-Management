using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Commands;
public record DeleteRoleCommand(Guid Id) : IRequest<bool>;
