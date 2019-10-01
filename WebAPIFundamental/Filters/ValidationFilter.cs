using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using WebAPIFundamental.Models;

namespace WebAPIFundamental.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public ValidationFilter()
        {

        }

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var errorsInModelState = actionContext.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();
                var errorResponse = new ErrorResponse();
                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        ErrorModel errorModel = new ErrorModel() { FieldName = error.Key.ToString(), Message = subError };
                        errorResponse.Errors.Add(errorModel);
                    }
                }
                return Task.FromResult(actionContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    errorsInModelState, JsonMediaTypeFormatter.DefaultMediaType));
            }

            var result = continuation();
            return result;
        }

        public bool AllowMultiple
        {
            get { return true; }
        }
    }
}