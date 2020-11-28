using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Appointment.Models
{
     [Table("AppointmentP")]
    public class AppointmentP
    {
        [Key]
        public long ID { get; set; }
        public DateTime Date { get; set; }
        public long PatientID { get; set; }
        public long DoctorID { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }

    }
}