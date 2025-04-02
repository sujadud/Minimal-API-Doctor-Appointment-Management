using AMS.MinimalAPI.Shared.DTOs.UserAuth;
using MediatR;

namespace AMS.MinimalAPI.Application.Users.Commands;
public class LoginUserCommand(string Email, string Password) : IRequest<AuthResponseDto>;
