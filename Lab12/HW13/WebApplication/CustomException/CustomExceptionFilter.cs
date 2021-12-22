using System;
using System.Web.Mvc;

namespace WebApplication.CustomException
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is NotImplementedException)
            {
            }
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}