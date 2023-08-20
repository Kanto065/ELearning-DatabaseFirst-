using BusinessEntityLayer;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RegisterController : ApiController
    {
        [Route("api/register")]
        [HttpGet]
        public List<RoleModel> Get()
        {
            return RegistrationService.GetRole();
        }

        [Route("api/register")]
        [HttpPost]
        public HttpResponseMessage Register(UserModel user)
        {
            var rs = RegistrationService.Add(user);
            if (rs)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Registration complete");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Email already registerd");
        }



    }
}
