using AMS.MinimalAPI.Domain.Entities;
using AMS.MinimalAPI.Domain.Interface;
using AMS.MinimalAPI.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AMS.MinimalAPI.Infrastructure.Repositories;
public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public override async Task<ICollection<Role>> GetAllAsync() => await base.GetAllAsync();
    public override async Task<Role?> GetByIdAsync(Guid id) => await base.GetByIdAsync(id);
    //public async Task AddAsync(Role role) { await base.CreateAsync(role); await base._appContext.SaveChangesAsync(); }
    //public async Task UpdateAsync(Role role) { base.UpdateAsync(role); await base._appContext.SaveChangesAsync(); }
    //public async Task DeleteAsync(Guid id) { var role = await _context.Roles.FindAsync(id); if (role != null) { _context.Roles.Remove(role); await _context.SaveChangesAsync(); } }
}
