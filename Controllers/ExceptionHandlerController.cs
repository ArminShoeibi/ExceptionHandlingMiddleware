using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandlingMiddleware.Controllers;

[Route("/exception-handler")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ExceptionHandlerController : ControllerBase
{
    [HttpGet]
    public IActionResult HandleException()
    {
        IExceptionHandlerPathFeature exceptionHandlerPathFeature = 
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature.Error is not null)
        {
            ModelState.TryAddModelException("",exceptionHandlerPathFeature.Error);
        }
       
        return ValidationProblem(ModelState);
    }
}
