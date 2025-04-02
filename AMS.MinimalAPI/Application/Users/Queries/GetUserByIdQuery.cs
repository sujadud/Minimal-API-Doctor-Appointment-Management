using AMS.MinimalAPI.Shared.DTOs.UserAuth;
using MediatR;

namespace AMS.MinimalAPI.Application.Users.Queries;
public record GetUserByIdQuery(Guid UserId): IRequest<UserResponseDto>;
