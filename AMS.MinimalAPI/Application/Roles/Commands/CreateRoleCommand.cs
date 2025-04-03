using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Commands;
public record CreateRoleCommand(string Name) : IRequest<Guid>;