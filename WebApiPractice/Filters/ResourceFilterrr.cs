using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiPractice.Filters;

public class ResourceFilterrr : Attribute, IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        Console.WriteLine("Resource execteddd");
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        Console.WriteLine("before resource executing");
    }
}
