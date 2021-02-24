using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Extensions.Alerts
{
    public static class AlertExtensions
    {
        public static IActionResult Alert(IActionResult result, string type, string message)
            => new AlertDecoratorResult(result, type, message);

        public static IActionResult WithSuccess(this IActionResult result, string message)
            => Alert(result, "success", message);

        public static IActionResult WithInfo(this IActionResult result, string message)
            => Alert(result, "info", message);

        public static IActionResult WithWarning(this IActionResult result, string message)
            => Alert(result, "warning", message);

        public static IActionResult WithDanger(this IActionResult result, string message)
            => Alert(result, "danger", message);
    }
}
