using Appointment.Models;
using Appointment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appointment.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _Repository;

        public AppointmentController()
        {
            _Repository = new AppointmentRepository(new AppointmentContext());
        }

        public AppointmentController(IAppointmentRepository Repository)
        {
            _Repository = Repository;
        }


        public JsonResult GetAppointment(AppointmentP obj)
        {
            try
            {
                string result = string.Empty;
                obj.PatientID = Convert.ToInt64(Session["UserID"]);
                var myUser = _Repository.GetAppointment()
                .FirstOrDefault(u => u.Date == obj.Date && u.DoctorID == obj.DoctorID);
                if (myUser == null)    //User was found
                {
                    _Repository.Add(obj);
                    _Repository.Save();
                    result = "You got a appointment Successfully";
                }
                else    //User was not found
                {
                    result = "Doctor has appointment on this time.";
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Approve(AppointmentP obj)
        {
            try { 
            var user = _Repository.GetAppointment().FirstOrDefault(u => u.ID == obj.ID);
            user.IsApproved = obj.IsApproved;
            _Repository.Save();
            string result = obj.IsApproved ? "Approved successfully." : "Rejected Successfully.";
            return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetApproveList(AppointmentP obj)
        {
            try { 
            obj.DoctorID = Convert.ToInt64(Session["UserID"]);
            var ApproveList = _Repository.GetData().Where(x => x.DoctorID == obj.DoctorID).ToList();
            var users = _Repository.GetUsers();

            var list = ApproveList
 .Join(users,
       a => a.PatientID,
       u => u.UserID,
       (a, u) => new
       {
           ID = a.ID,
           Patient = u.UserName,
           Datetime = a.Date.ToString("yyyy-MM-dd hh:mm"),
           Description = a.Description,
           Status = a.IsApproved ? "Approved" : "Rejected/Waiting",
       });
            return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}