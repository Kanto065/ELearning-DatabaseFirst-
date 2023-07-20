using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ELearning.Models;
using ELearning.Repository;

namespace ELearning.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        CourseRepo repo;
        public CourseController()
        {
            this.repo = new CourseRepo();
        }
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        /*public ActionResult GetCategory() 
        {
            var data = repo.GetCategory();
            return View(data); 
        } */   
        public ActionResult GetCategory()
        {
            var data = repo.GetCategory();
            ViewBag.categoryData = data;
            return View(data);   
        }

        public ActionResult AddCourse()
        {
            var data = repo.GetCategory();
            ViewBag.categoryData = data;

            /*CourseCategoryViewModel objccvm = new CourseCategoryViewModel();
            objccvm.CategoryViewModel = data;*/

            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(CourseModel course)
        {
            var data = repo.GetCategory();
            ViewBag.categoryData = data;

            if (ModelState.IsValid)
            {
                var count = repo.AddCourse(course);
                if (count > 0)
                {
                    ViewBag.Okay = "Data Added";
                    //return View("GetAll");
                }
            }
            return View();
        }

        public ActionResult GetAll()
        {
            var data = repo.GetAllData();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            var data = repo.GetDetails(id);
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var cat = repo.GetCategory();
            ViewBag.categoryData = cat;

            var data = repo.GetDetails(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, CourseModel student)
        {
            var cat = repo.GetCategory();
            ViewBag.categoryData = cat;

            if (ModelState.IsValid)
            {
                var count = repo.UpdateData(id, student);

                return RedirectToAction("GetAll");

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var data = repo.DeleteData(id);
            return RedirectToAction("GetAll");
        }
    }
}