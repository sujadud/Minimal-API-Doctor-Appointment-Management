using MediatR;
using Microsoft.AspNetCore.Identity;
using AMS.MinimalAPI.Domain.Entities;
using AutoMapper;
using AMS.MinimalAPI.Application.Users.Commands;
using AMS.MinimalAPI.Shared.DTOs.UserAuth;

namespace AMS.MinimalAPI.Application.Users.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResponseDto>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        if (user == null)
        {
            throw new ApplicationException("User not found.");
        }

        // Update user properties
        user.UpdateProfile(request.Name, request.Email, request.Username, request.PhoneNumber, request.RoleId);

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            throw new ApplicationException("User update failed.");
        }

        // Update role if provided
        var currentRoles = await _userManager.GetRolesAsync(user);
        if (currentRoles.Count > 0)
        {
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
        }
        await _userManager.AddToRoleAsync(user, request.Role);

        return _mapper.Map<UserResponseDto>(user);
    }
}