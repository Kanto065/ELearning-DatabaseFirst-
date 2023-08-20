using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BusinessLogicLayer;

namespace WebApi.Auth
{
    public class InstructorAuth: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;
            
            if (authHeader == null) {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "u not authorized");
            }
            else
            {
                if (AuthService.IsRoleAuthenticated(authHeader.ToString()))
                {

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "u not authorized");
                }
            }

            base.OnAuthorization(actionContext);
        }
    }
}