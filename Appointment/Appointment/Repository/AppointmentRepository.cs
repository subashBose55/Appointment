using Appointment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Appointment.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private AppointmentContext _context;
        public AppointmentRepository()  
        {
            _context = new AppointmentContext();  
        }  
        public AppointmentRepository(AppointmentContext Context)  
        {  
            this._context = Context;  
        }
        public IEnumerable<AppointmentP> GetAppointment()
        {
            return _context.AppointmentP.ToList();
        }
        public void Add(AppointmentP AppointmentP)
        {
            _context.AppointmentP.Add(AppointmentP);
        }
        public IEnumerable<AppointmentP> GetData()
        {           
            return _context.AppointmentP.ToList();
        }
        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.ToList();
        }
       
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }  
    }
}