using AMS.MinimalAPI.Shared.DTOs.Role;
using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Queries;

public record GetRoleByIdQuery(Guid Id) : IRequest<RoleDto>;
