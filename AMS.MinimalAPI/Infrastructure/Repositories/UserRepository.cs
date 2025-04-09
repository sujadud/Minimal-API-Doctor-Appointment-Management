using AMS.MinimalAPI.Domain.Entities;
using AMS.MinimalAPI.Domain.Interface;
using AMS.MinimalAPI.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AMS.MinimalAPI.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public IQueryable<User> ActiveUsers => this._appContext.Users.Where(u => !u.IsDeleted);

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _appContext.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<ICollection<User>> GetAllAsync()
        {
            return (ICollection<User>)_appContext.Users.Include(r => r.Role).Where(x => x.IsDeleted == true || x.IsDeleted == false);
        }

        public override Task<User?> GetByIdAsync(Guid id)
        {
            return _appContext.Users.Include(r => r.Role).FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<bool> DeleteAsync(User entity)
        {
            var userRoles = _appContext.UserRoles.Where(ur => ur.UserId == entity.Id);
            if(userRoles != null) _appContext.UserRoles.RemoveRange(userRoles);
            
            if (entity != null)
            {
                //_appContext.Users.Remove(entity);
                entity.Delete();
                await _appContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
