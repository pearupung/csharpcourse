#pragma checksum "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f648398007f2980fcd3c6ac6d0b8d99a8ee86a3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace WebApp.Pages
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
#line 1 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f648398007f2980fcd3c6ac6d0b8d99a8ee86a3d", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56255396305d1d1888ad93afc9c47568e44a4220", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("haioo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"hello rounded\">\n    <div class=\"container justify-content-center align-content-center\">\n        <div class=\"row d-inline-flex\">\n            <div class=\"col-auto\"></div>\n            <div class=\"col-lg d-inline-flex\">\n                \n");
#nullable restore
#line 13 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
                 for (var i = 0; i < Model.SearchButtons.Count; i++)
                {
                    var item = Model.SearchButtons[i];

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"m-2 col-auto\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f648398007f2980fcd3c6ac6d0b8d99a8ee86a3d4737", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 17 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.SearchButtons[i].IsChecked);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                        <label");
            BeginWriteAttribute("for", "\n                            for=\"", 615, "\"", 678, 3);
            WriteAttributeValue("", 649, "SearchButtons_", 649, 14, true);
#nullable restore
#line 19 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
WriteAttributeValue("", 663, i, 663, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 667, "__IsChecked", 667, 11, true);
            EndWriteAttribute();
            WriteLiteral("\n                            style=\"width: 8em\"");
            BeginWriteAttribute("class", "\n                            class=\"", 726, "\"", 827, 2);
            WriteAttributeValue("", 762, "toggle-label", 762, 12, true);
#nullable restore
#line 21 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
WriteAttributeValue(" ", 774, item.IsChecked ? "btn btn-light" : "btn btn-dark", 775, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            ");
#nullable restore
#line 22 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </label>\n                    </div>\n");
#nullable restore
#line 25 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\n            <div class=\"col-auto\"></div>\n        </div>\n    \n        <div class=\"row\">\n                        <div class=\"col-auto\"></div>\n<div class=\"col-lg\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f648398007f2980fcd3c6ac6d0b8d99a8ee86a3d8178", async() => {
                WriteLiteral(@"

        <div class=""form-group d-inline-flex"">
            <input type=""text"" class=""form-control d-inline-flex"" id=""inlineFormInputName2"" placeholder=""Moby Dick"">
        </div>
        <button type=""submit"" class=""btn btn-primary d-inline-flex"">Go fetch!</button>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n                        <div class=\"col-auto\"></div>\n\n        </div>\n    </div>\n</div>\n\n\n<div class=\"container-fluid\">\n    <div class=\"row justify-content-center\">\n");
#nullable restore
#line 50 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
         foreach (var item in Model.Books)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card col-sm m-3 p-3\">\n                <img src=\"resources/uzbekistan-forests.jpg\" class=\"card-img-top rounded\" alt=\"...\">\n                <div class=\"card-body\">\n                    <h5 class=\"card-title\">");
#nullable restore
#line 55 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
                                      Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                    <p class=\"card-text\">");
#nullable restore
#line 56 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
                                    Write(item.Summary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                    <a href=\"#\" class=\"btn btn-primary\">Look at this book!</a>\n                </div>\n            </div>\n");
#nullable restore
#line 60 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591