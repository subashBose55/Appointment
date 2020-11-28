using Appointment.Models;
using Appointment.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserController.Controllers
{
    public class UserController : Controller
    {
        private readonly ILoginRepository _Repository;

        public UserController()
        {
            _Repository = new LoginRepository(new AppointmentContext());
        }

        public UserController(ILoginRepository Repository)
        {
            _Repository = Repository;
        }

        public ActionResult Index()
        {
            Role_Bind();
            return View();
        }

        public void Role_Bind()
        {
            var result = new SelectList(_Repository.GetRole().ToList(), "RoleID", "RoleName");
            ViewBag.Roles = result;
        }
        public void AdminRole_Bind()
        {
            var result = new SelectList(_Repository.GetRole().Where(x => x.RoleID != 1).ToList(), "RoleID", "RoleName");
            ViewBag.AdminRoles = result;
        }
        public void Doctor_Bind()
        {
            var result = new SelectList(_Repository.GetUsers().Where(x => x.RoleID == 2).ToList(), "UserID", "UserName");
            ViewBag.Doctor = result;
        }
        [HttpPost]
        public string Login(Users user)
        {
            try{
            string result = string.Empty;
            //The ".FirstOrDefault()" method will return either the first matched
            //result or null
            var myUser = _Repository.GetUsers()
                .FirstOrDefault(u => u.UserName == user.UserName
                             && u.Password == user.Password && u.RoleID == user.RoleID);

            if (myUser != null)    //User was found
            {
                result = "1";
                //Proceed with your login process...
                Session["UserID"] = myUser.UserID.ToString();
                Session["Username"] = myUser.FirstName.ToString() + " " + myUser.LastName.ToString();
                Session["RoleID"] = myUser.RoleID.ToString();
            }
            else    //User was not found
            {
                //Do something to let them know that their credentials were not valid
                result = "0";
            }
            return result;
            }
            catch (Exception ex)
            {
                //return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
                return ex.ToString();
            }
        }

        public ActionResult Admin()
        {
            if (Session["UserID"] != null && Session["RoleID"].ToString() == "1")
            {
                AdminRole_Bind();
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Doctor()
        {
            if (Session["UserID"] != null && Session["RoleID"].ToString() == "2")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Patient()
        {
            if (Session["UserID"] != null && Session["RoleID"].ToString() == "3")
            {
                Doctor_Bind();
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public JsonResult AddUser(Users obj)
        {
            try{
            string result = string.Empty;
            var myUser = _Repository.GetUsers()
            .FirstOrDefault(u => u.UserName == obj.UserName && u.RoleID == obj.RoleID);
            if (myUser == null)    //User was found
            {
                result = "Saved Successfully";
                _Repository.Add(obj);
                _Repository.Save();
            }
            else    //User was not found
            {
                result = "Username has already exists.";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}