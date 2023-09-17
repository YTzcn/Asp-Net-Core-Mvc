﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApplication1.Filters
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public string ViewName { get; set; } = "Error";
        public Type ExceptionType { get; set; }
        public override void OnException(ExceptionContext context)
        {
            if (this.ExceptionType != null)
            {
                if (context.Exception.GetType() == ExceptionType)
                {
                    var result = new ViewResult { ViewName = ViewName };
                    var modelDataProvider = new EmptyModelMetadataProvider();
                    result.ViewData = new ViewDataDictionary(modelDataProvider, context.ModelState);
                    result.ViewData.Add("HandleException", context.Exception);
                    context.Result = result;
                    context.ExceptionHandled = true;
                }
            }

        }
    }
}
