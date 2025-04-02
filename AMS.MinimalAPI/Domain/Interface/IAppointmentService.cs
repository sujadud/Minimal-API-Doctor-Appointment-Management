using AMS.MinimalAPI.Domain.Entities;
using AMS.MinimalAPI.Domain.Interface.Base;

namespace AMS.MinimalAPI.Domain.Interface
{
    public interface IAppointmentService : IBaseRepository<Appointment>
    {
        //Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync();
        //Task<AppointmentDto?> GetAppointmentByIdAsync(Guid id);
        //Task<Guid> CreateAppointmentAsync(AppointmentCreateDto dto);
        //Task<bool> UpdateAppointmentAsync(Guid id, AppointmentUpdateDto dto);
        //Task<bool> DeleteAppointmentAsync(Guid id);

    }
}
