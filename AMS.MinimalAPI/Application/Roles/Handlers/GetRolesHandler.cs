using AMS.MinimalAPI.Application.Roles.Queries;
using AMS.MinimalAPI.Domain.Interface;
using AMS.MinimalAPI.Shared.DTOs.Role;
using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Handlers;

public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<RoleDto>>
{
    private readonly IRoleRepository _roleRepository;
    public GetRolesHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllAsync();
        return roles.Select(role => new RoleDto { Id = role.Id, Name = role.Name });
    }
}