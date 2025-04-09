using AMS.MinimalAPI.Application.Users.Queries;
using AMS.MinimalAPI.Domain.Interface;
using AMS.MinimalAPI.Shared.DTOs.UserAuth;
using MediatR;

namespace AMS.MinimalAPI.Application.Users.Handlers;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserResponseDto>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserResponseDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();  

        return users
                .Where(u => !u.IsDeleted)
                .Select(u => new UserResponseDto { Id = u.Id, FullName = u.FullName, Email = u.Email, UserName = u.UserName, RoleName = u.Role.Name, PhoneNumber = u.PhoneNumber, UpdatedAt = u.UpdatedAt })
                .ToList();
    }
}