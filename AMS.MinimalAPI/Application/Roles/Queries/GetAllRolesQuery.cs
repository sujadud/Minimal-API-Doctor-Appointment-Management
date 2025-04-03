using AMS.MinimalAPI.Shared.DTOs.Role;
using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Queries;
public record GetRolesQuery() : IRequest<IEnumerable<RoleDto>>;
