using System;

namespace AMS.MinimalAPI.Domain.Interface;

public interface IEntity
{
    public Guid Id { get; }

    // Auditable Entity Properties 
    DateTime? CreatedAt { get; }
    DateTime? UpdatedAt { get; }

}
