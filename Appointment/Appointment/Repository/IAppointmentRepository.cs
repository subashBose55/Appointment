using Appointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appointment.Repository
{
    public interface IAppointmentRepository : IDisposable  
    {
        IEnumerable<AppointmentP> GetData();
        IEnumerable<AppointmentP> GetAppointment();
        void Add(AppointmentP Users);
        IEnumerable<Users> GetUsers();      
        void Save();      
    }
}