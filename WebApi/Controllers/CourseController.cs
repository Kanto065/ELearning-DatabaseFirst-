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
        [CustomAuth]
        [Route("api/Course/All")]
        [HttpGet]
        public List<CourseModel> GetAll()
        {
            return CourseService.Get();
        }

        [Route("api/Course/Create")]
        [HttpPost]
        public void Add(CourseModel model)
        {
            CourseService.Add(model);
        }

    }

}
