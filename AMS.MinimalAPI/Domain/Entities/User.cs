using AMS.MinimalAPI.Domain.Interface;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.MinimalAPI.Domain.Entities;

public class User : IdentityUser<Guid>, IEntity
{
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; } = false;

    [Required]
    [MaxLength(30)]
    public string FullName { get; private set; } = string.Empty;

    [Required]
    public Guid RoleId { get; set; }
    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }

    private User() { }

    public User(string fullName, string userName, string email, string phoneNumber, Guid roleId)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        UserName = userName;
        Email = email;
        PhoneNumber = phoneNumber;
        RoleId = roleId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateProfile(string fullName, string email, string userName, string phoneNumber, Guid roleId)
    {
        FullName = fullName;
        UserName = userName;
        Email = email;
        PhoneNumber = phoneNumber;
        RoleId = roleId;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}