using System.ComponentModel.DataAnnotations;
using AMS.MinimalAPI.Domain.Interface;

namespace AMS.MinimalAPI.Domain.Entities;

public class Doctor : IEntity
{
    [Key]
    public Guid Id { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; set; } = false;

    [Required]
    [MaxLength(100)]
    public string FullName { get; private set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Specialty { get; private set; } = string.Empty;

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

    private Doctor() { }

    public Doctor(Guid id, string fullName, string specialty)
    {
        Id = id;
        FullName = fullName;
        Specialty = specialty;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string fullName, string specialty)
    {
        FullName = fullName;
        Specialty = specialty;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}
