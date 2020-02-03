using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace ReportApi.AttributeFilter
{
    public class InputValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var id = actionContext.ActionArguments["id"];
            int num = 0;
            var isNumeric = int.TryParse(id?.ToString(), out num);
            if (isNumeric)
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                var responseMessage = new HttpResponseException(HttpStatusCode.BadRequest);
                throw responseMessage;
            }
        }
    }
}