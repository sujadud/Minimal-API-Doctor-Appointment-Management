using AMS.MinimalAPI.Application.Users.Queries;
using AMS.MinimalAPI.Domain.Interface;
using AMS.MinimalAPI.Shared.DTOs.UserAuth;
using MediatR;

namespace AMS.MinimalAPI.Application.Users.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null || user.IsDeleted)
            throw new KeyNotFoundException("User not found");

        return new UserResponseDto { Id = user.Id, FullName = user.FullName, Email = user.Email, UserName = user.UserName, RoleName = user.Role.Name, PhoneNumber = user.PhoneNumber, UpdatedAt = user.UpdatedAt };
    }
}