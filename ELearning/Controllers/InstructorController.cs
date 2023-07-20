using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models;
using ELearning.Repository;
using System.Web.Security;

namespace ELearning.Controllers
{
    public class InstructorController : Controller
    {
        InstructorRepo repo;

        public InstructorController()
        {
            this.repo = new InstructorRepo();
        }
        // GET: Instructor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInstructor(InstructorModel ins)
        {
            if (ModelState.IsValid)
            {
                var count = repo.AddInstructor(ins);
                if (count > 0)
                {
                    ViewBag.Okay = "Data Added";
                }
            }
            return View();
            
        }

        public ActionResult LogIn() 
        { 
            return View(); 
        }

        [HttpPost]
        public ActionResult LogIn(InstructorModel ins)
        {
            
            var check = repo.VarifyInstructor(ins);
            if(check)
            {
                FormsAuthentication.SetAuthCookie(ins.Email, false);
                return RedirectToAction("GetAll", "Course");
            }
            ViewBag.msg = "log in credentials not valid";
            
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

    }
}