using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Extensions.Alerts
{
    public class AlertDecoratorResult : IActionResult
    {
        public IActionResult Result { get; }

        public string Type { get; }

        public string Message { get; }

        public AlertDecoratorResult(IActionResult result, string type, string message)
        {
            Result = result;
            Type = type;
            Message = message;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var factory = context.HttpContext.RequestServices.GetService<ITempDataDictionaryFactory>();

            var tempData = factory.GetTempData(context.HttpContext);
            tempData["_alert.type"] = Type;
            tempData["_alert.message"] = Message;

            await Result.ExecuteResultAsync(context);
        }
    }
}
