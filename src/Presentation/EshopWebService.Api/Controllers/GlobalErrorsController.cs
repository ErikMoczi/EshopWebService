using System.Collections.Generic;
using System.Net;
using EshopWebService.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace EshopWebService.Api.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GlobalErrorsController : ControllerBase
    {
        [HttpGet]
        [Route("/error")]
        public IActionResult HandleError([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            HttpStatusCode responseStatusCode;
            switch (exceptionHandlerFeature.Error)
            {
                case ApiException:
                {
                    responseStatusCode = HttpStatusCode.BadRequest;
                    break;
                }
                case KeyNotFoundException:
                {
                    responseStatusCode = HttpStatusCode.NotFound;
                    break;
                }
                default:
                {
                    responseStatusCode = HttpStatusCode.InternalServerError;
                    break;
                }
            }

            return Problem(
                webHostEnvironment.EnvironmentName == Environments.Development ? exceptionHandlerFeature.Error.StackTrace : null,
                statusCode: (int)responseStatusCode,
                title: exceptionHandlerFeature.Error.Message
            );
        }
    }
}