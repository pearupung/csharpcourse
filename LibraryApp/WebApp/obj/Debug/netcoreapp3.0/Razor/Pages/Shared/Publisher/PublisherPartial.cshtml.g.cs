#pragma checksum "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Shared/Publisher/PublisherPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d242ee2659ecb8a5347ddae0cef0c59a37b3fee6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.Shared.Publisher.Pages_Shared_Publisher_PublisherPartial), @"mvc.1.0.view", @"/Pages/Shared/Publisher/PublisherPartial.cshtml")]
namespace WebApp.Pages.Shared.Publisher
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d242ee2659ecb8a5347ddae0cef0c59a37b3fee6", @"/Pages/Shared/Publisher/PublisherPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56255396305d1d1888ad93afc9c47568e44a4220", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Publisher_PublisherPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PublisherPartialModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"form-group border\">\n    ");
#nullable restore
#line 4 "/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/LibraryApp/WebApp/Pages/Shared/Publisher/PublisherPartial.cshtml"
Write(Model.Publisher.PublisherName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" is the publisher\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PublisherPartialModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
