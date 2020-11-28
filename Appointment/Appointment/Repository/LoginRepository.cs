using Appointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appointment.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private AppointmentContext _context;
        public LoginRepository()  
        {
            _context = new AppointmentContext();  
        }
        public LoginRepository(AppointmentContext Context)  
        {  
            this._context = Context;  
        }
        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.ToList();
        }
        public IEnumerable<UserRole> GetRole()
        {
            return _context.Role.ToList();
        }
        public void Add(Users Users)
        {
            _context.Users.Add(Users);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}