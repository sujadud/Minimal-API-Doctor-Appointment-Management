using AMS.MinimalAPI.Application.Roles.Commands;
using AMS.MinimalAPI.Domain.Interface;
using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Handlers;
public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, bool>
{
    private readonly IRoleRepository _roleRepository;
    public UpdateRoleHandler(IRoleRepository roleRepository) => _roleRepository = roleRepository;
    public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.Id);
        if (role == null) return false;
        role.Update(request.Name);
        await _roleRepository.UpdateAsync(role);
        return true;
    }
}