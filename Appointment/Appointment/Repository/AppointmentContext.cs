using Appointment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Appointment.Repository
{
    public class AppointmentContext: DbContext  
    {
        public AppointmentContext()
            : base("name=Appointment")  
        {
            //Disable initializer
            Database.SetInitializer<AppointmentContext>(null);
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var conventions = new List<PluralizingTableNameConvention>().ToArray();
        //    modelBuilder.Conventions.Remove(conventions);
        //}
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRole> Role { get; set; }
        public DbSet<AppointmentP> AppointmentP { get; set; } 
    }
}