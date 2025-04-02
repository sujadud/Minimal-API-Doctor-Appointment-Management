using AMS.MinimalAPI.Domain.Interface;
using System.ComponentModel.DataAnnotations;

namespace AMS.MinimalAPI.Domain.Entities;

public class Patient : IEntity
{
    [Key]
    public Guid Id { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; } = false;


    [Required]
    [MaxLength(100)]
    public string FullName { get; private set; } = string.Empty;

    [Required]
    [MaxLength(15)]
    public string PhoneNumber { get; private set; } = string.Empty;

    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; private set; } = string.Empty;

    [Required]
    public DateTime DateOfBirth { get; private set; }

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

    private Patient() { }

    public Patient(Guid id, string fullName, string phoneNumber, string email, DateTime dateOfBirth)
    {
        Id = id;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        DateOfBirth = dateOfBirth;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string fullName, string phoneNumber, string email)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}
