using AMS.MinimalAPI.Application.Roles.Commands;
using AMS.MinimalAPI.Domain.Interface;
using MediatR;

namespace AMS.MinimalAPI.Application.Roles.Handlers;

public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly IRoleRepository _roleRepository;
    public DeleteRoleHandler(IRoleRepository roleRepository) => _roleRepository = roleRepository;
    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.Id);
        return await _roleRepository.DeleteAsync(role);
    }
}