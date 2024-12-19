using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiPractice.Filters;

public class ActionFilterrrr : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"Executingggg action: {context.ActionDescriptor.DisplayName}");
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"Executedddd action: {context.ActionDescriptor.DisplayName}");
    }
}
