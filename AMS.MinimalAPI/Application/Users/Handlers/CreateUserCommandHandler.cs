using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using AMS.MinimalAPI.Application.Users.Commands;
using AMS.MinimalAPI.Shared.DTOs.UserAuth;
using Org.BouncyCastle.Crypto;
using AMS.MinimalAPI.Domain.Entities;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponseDto>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(
            request.Name,
            request.Username,
            request.Email,
            request.PhoneNumber,
            request.RoleId
        );
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("User creation failed.");
        }

        await _userManager.AddToRoleAsync(user, request.Role);

        return _mapper.Map<UserResponseDto>(user);
    }
}
