using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Appointment.Models
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public long RoleID { get; set; }
        public string RoleName { get; set; }
    }
}