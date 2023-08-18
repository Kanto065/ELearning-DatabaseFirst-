using BusinessLogicLayer;
using BusinessLogicLayer.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CourseController : ApiController
    {
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
