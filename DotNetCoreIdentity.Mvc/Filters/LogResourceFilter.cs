using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace DotNetCoreIdentity.Mvc.Filters
{
    public class LogResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Executing Resource Filter!");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.Write("Executed Resource Filter...");
        }
    }
}
