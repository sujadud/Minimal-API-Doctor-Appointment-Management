using AMS.MinimalAPI.Domain.Entities;
using AMS.MinimalAPI.Domain.Interface.Base;
using System.Collections.ObjectModel;

namespace AMS.MinimalAPI.Domain.Interface
{
    public interface IUserRepository : IBaseRepository<User>    
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
