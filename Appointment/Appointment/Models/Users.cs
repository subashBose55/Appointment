using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appointment.Models
{
    public class Users
    {        
        [Key]
        public long UserID { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public long RoleID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}