using MediatR;

namespace AMS.MinimalAPI.Application.Users.Commands;

public record DeleteUserCommand(Guid UserId) : IRequest<bool>;
