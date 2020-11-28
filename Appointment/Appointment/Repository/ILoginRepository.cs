using Appointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appointment.Repository
{
    public interface ILoginRepository
    {
        IEnumerable<Users> GetUsers();
        IEnumerable<UserRole> GetRole();
        void Add(Users Users);
        void Save(); 
    }
}