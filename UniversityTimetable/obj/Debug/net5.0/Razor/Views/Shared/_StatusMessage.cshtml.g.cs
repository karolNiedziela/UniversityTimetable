#pragma checksum "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Shared\_StatusMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e59daef22decebe6962b61fda5dca2c5e5c1f82f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__StatusMessage), @"mvc.1.0.view", @"/Views/Shared/_StatusMessage.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\_ViewImports.cshtml"
using UniversityTimetable;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\_ViewImports.cshtml"
using UniversityTimetable.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e59daef22decebe6962b61fda5dca2c5e5c1f82f", @"/Views/Shared/_StatusMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f712a77e9487c18a625f091fd685ab61b2a2485", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__StatusMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Shared\_StatusMessage.cshtml"
   
    var type = (string)TempData["_alert.type"];
    var message = (string)TempData["_alert.message"];

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"alert-container\">\r\n");
#nullable restore
#line 6 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Shared\_StatusMessage.cshtml"
 if (!string.IsNullOrEmpty(message))
{ 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div");
            BeginWriteAttribute("class", " class=\"", 193, "\"", 242, 5);
            WriteAttributeValue("", 201, "alert", 201, 5, true);
            WriteAttributeValue(" ", 206, "alert", 207, 6, true);
            WriteAttributeValue(" ", 212, "alert-", 213, 7, true);
#nullable restore
#line 8 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Shared\_StatusMessage.cshtml"
WriteAttributeValue("", 219, type, 219, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 224, "alert-dismissible", 225, 18, true);
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n        ");
#nullable restore
#line 12 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Shared\_StatusMessage.cshtml"
   Write(message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 14 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Shared\_StatusMessage.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
