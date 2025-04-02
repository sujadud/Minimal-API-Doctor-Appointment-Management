using AMS.MinimalAPI.Application.Users.Commands;
using AMS.MinimalAPI.Domain.Interface;
using AMS.MinimalAPI.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AMS.MinimalAPI.Application.Users.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly UserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository repository)
    {
        _userRepository = repository as UserRepository;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null || user.IsDeleted) return false; 

        user.Delete();

        //await _userRepository .SaveChangesAsync(cancellationToken);
        return true;
    }
}
