using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using HealthCareSystem.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core
{
   public interface IAppointmentRepository
    {

        void CreateAppointment(Appointment appointment);

        Task<Appointment> GetAppointmentAsync(int id);

        Task<IEnumerable<Appointment>> GetAppointmentsAsync(QueryResource query);

        Task<IEnumerable<Appointment>> GetScheduledAppointmentsAsync(QueryResource query);

        void UpdateAppointment(Appointment appointment);

        void DeleteAppointment(Appointment appointment);
    }
}
