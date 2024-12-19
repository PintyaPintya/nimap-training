using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ExceptionFilterrr : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        Console.WriteLine("Inside exception filter");
        context.Result = new ContentResult
        {
            Content = context.Exception.ToString()
        };
    }
}