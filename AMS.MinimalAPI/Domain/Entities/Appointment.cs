using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AMS.MinimalAPI.Domain.Enums;
using AMS.MinimalAPI.Domain.Interface;

namespace AMS.MinimalAPI.Domain.Entities;

public class Appointment : IEntity
{
    [Key]
    public Guid Id { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; } = false;


    [Required]
    public DateTime AppointmentDate { get; private set; }

    [Required]
    public AppointmentStatus Status { get; private set; }

    public Guid PatientId { get; private set; }

    [ForeignKey("PatientId")]
    public Patient Patient { get; private set; }

    public Guid DoctorId { get; private set; }

    [ForeignKey("DoctorId")]
    public Doctor Doctor { get; private set; }

    private Appointment() { }

    public Appointment(Guid id, DateTime appointmentDate, AppointmentStatus status, Guid patientId, Guid doctorId)
    {
        Id = id;
        AppointmentDate = appointmentDate;
        Status = status;
        PatientId = patientId;
        DoctorId = doctorId;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateStatus(AppointmentStatus newStatus)
    {
        Status = newStatus;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}

