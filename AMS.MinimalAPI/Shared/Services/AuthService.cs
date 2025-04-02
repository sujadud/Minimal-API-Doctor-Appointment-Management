using AMS.MinimalAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AMS.MinimalAPI.Shared.Services;
public class AuthService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly JwtService _jwtService;

    public AuthService(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, JwtService jwtService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
    }

    public async Task<string> Register(string fullName, string userName, string email, string password, string phoneNumber, Guid roleId)
    {
        var user = new User(fullName, userName, email, phoneNumber, roleId);

        var result = await _userManager.CreateAsync(user, password); // UserManager handles password hashing

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Registration failed: {errors}");
        }

        // Fetch role by ID
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        if (role == null)
            throw new Exception("Invalid Role ID");

        // Assign role to user
        await _userManager.AddToRoleAsync(user, role.Name);

        return _jwtService.GenerateJwtToken(user);
    }

    public async Task<bool> UpdateUserRole(Guid userId, string newRole)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null) throw new Exception("User not found!");

        var existingRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, existingRoles);
        await _userManager.AddToRoleAsync(user, newRole);

        return true;
    }

    //private async Task AssignRole(User user, string roleName)
    //{
    //    if (!await _roleManager.RoleExistsAsync(roleName))
    //        await _roleManager.CreateAsync(new IdentityRole<Guid>(roleName));

    //    await _userManager.AddToRoleAsync(user, roleName);
    //}
}
