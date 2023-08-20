using BusinessLogicLayer;
using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Auth;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors("*","*","*")]
    public class CourseController : ApiController
    {
        
        [Route("api/Course/All")]
        [HttpGet]
        public List<CourseModel> GetAll()
        {
            return CourseService.Get();
        }

        
        [Route("api/Course/Create")]
        [HttpGet]
        public List<CategoryModel> GetCat()
        {
            return CourseService.GetCategory();
        }

        [InstructorAuth]
        [Route("api/Course/Create")]
        [HttpPost]
        public void Add(CourseModel model)
        {
            CourseService.Add(model);
        }

        [InstructorAuth]
        [Route("api/Course/delete/{id}")]
        [HttpPost]
        public void Delete(int id)
        {
            CourseService.delete(id);
        }

        [InstructorAuth]
        [Route("api/Course/update/{id}")]
        [HttpPost]
        public void Edit(CourseModel model)
        {
            CourseService.Edit(model);
        }

    }

}
