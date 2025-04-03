using AMS.MinimalAPI.Application.Roles.Commands;
using AMS.MinimalAPI.Domain.Entities;
using AMS.MinimalAPI.Domain.Interface;
using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Handlers;
public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IRoleRepository _roleRepository;
    public CreateRoleHandler(IRoleRepository roleRepository) => _roleRepository = roleRepository;
    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role(request.Name);
        await _roleRepository.CreateAsync(role);
        return role.Id;
    }
}
