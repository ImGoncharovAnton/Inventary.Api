using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Inventary.Web.ActionFilters;

public class ValidateModelStateAttribute: ActionFilterAttribute
{
    // Validates Model automatically 
    // <param name="context"></param>
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }

}