using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Commands;
public record UpdateRoleCommand(Guid Id, string Name) : IRequest<bool>;
