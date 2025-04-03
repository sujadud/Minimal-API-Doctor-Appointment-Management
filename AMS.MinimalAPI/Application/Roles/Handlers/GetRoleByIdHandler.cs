using AMS.MinimalAPI.Application.Roles.Queries;
using AMS.MinimalAPI.Domain.Interface;
using AMS.MinimalAPI.Shared.DTOs.Role;
using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Handlers;

public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
{
    private readonly IRoleRepository _roleRepository;
    public GetRoleByIdHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.Id);
        return role is null ? null : new RoleDto { Id = role.Id, Name = role.Name };
    }
}
