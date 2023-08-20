using BusinessEntityLayer;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [Route("api/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            if(token != null)
            {
                var rs = AuthService.Logout(token);
                if (rs)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "successfully log out");
                }
                
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "invalid token to log out");
        }

        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(UserModel user)
        {
            var token = AuthService.Authenticate(user);
            if(token != null) {
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Found");
        }
    }
}
