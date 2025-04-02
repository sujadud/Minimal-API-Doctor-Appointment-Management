using AMS.MinimalAPI.Domain.Interface;
using Microsoft.AspNetCore.Identity;

namespace AMS.MinimalAPI.Domain.Entities;
public class Role : IdentityRole<Guid>, IEntity
{
    public Role() : base () {}            

    public DateTime? CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; } = false;

    public ICollection<User> Users { get; set; } = new List<User>();

    public Role(string roleName) : base(roleName) { }
    public void Update(string roleName)
    {
        Name = roleName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}
