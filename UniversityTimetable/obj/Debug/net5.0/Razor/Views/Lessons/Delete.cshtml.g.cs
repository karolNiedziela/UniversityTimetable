#pragma checksum "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42ecdc7e64200c117cd8ed4785d9712ec0bab2e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lessons_Delete), @"mvc.1.0.view", @"/Views/Lessons/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42ecdc7e64200c117cd8ed4785d9712ec0bab2e2", @"/Views/Lessons/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f712a77e9487c18a625f091fd685ab61b2a2485", @"/Views/_ViewImports.cshtml")]
    public class Views_Lessons_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Lesson>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("ml-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
  
    ViewData["Title"] = "Usuń zajęcia";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Usuwanie zajęć</h1>\r\n\r\n<h3>Czy chcesz usunąć zajęcia o podanych poniżej danych?</h3>\r\n<hr />\r\n\r\n<div>\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 15 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DayId));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 18 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Day.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 22 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.GroupId));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 25 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Group.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 29 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LessonHourId));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 32 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayFor(model => model.LessonHour.HourName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 36 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.RoomId));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 39 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Room.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 43 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SubjectId));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 46 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Subject.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 50 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TeacherId));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 53 "C:\Users\niedz\Desktop\C#\UniversityTimetable\UniversityTimetable\Views\Lessons\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Teacher.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42ecdc7e64200c117cd8ed4785d9712ec0bab2e28831", async() => {
                WriteLiteral("\r\n        <input type=\"submit\" class=\"btn btn-danger\" onclick=\"onDelete()\" value=\"Usuń\" />\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42ecdc7e64200c117cd8ed4785d9712ec0bab2e29197", async() => {
                    WriteLiteral("Cofnij");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Lesson> Html { get; private set; }
    }
}
#pragma warning restore 1591