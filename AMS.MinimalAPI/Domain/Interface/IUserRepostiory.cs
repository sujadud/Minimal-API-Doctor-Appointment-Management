﻿using AMS.MinimalAPI.Domain.Entities;
using AMS.MinimalAPI.Domain.Interface.Base;

namespace AMS.MinimalAPI.Domain.Interface;
public interface IUserRepository : IBaseRepository<User>    
{
    Task<User?> GetByEmailAsync(string email);
}
