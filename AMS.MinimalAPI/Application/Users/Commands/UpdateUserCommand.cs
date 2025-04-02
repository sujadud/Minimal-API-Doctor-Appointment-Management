using AMS.MinimalAPI.Shared.DTOs.UserAuth;
using MediatR;

namespace AMS.MinimalAPI.Application.Users.Commands;
public record UpdateUserCommand(
    Guid Id, 
    string Name,
    string Email,
    string Role,
    string Username,
    string Password,
    string PhoneNumber,
    Guid RoleId
) : IRequest<UserResponseDto>;
