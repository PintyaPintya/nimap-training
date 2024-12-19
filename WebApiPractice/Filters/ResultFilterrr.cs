using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiPractice.Filters;

public class ResultFilterrr : Attribute, IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        Console.WriteLine("Before resultttt");
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        Console.WriteLine("After resultttt");
    }
}
