#pragma checksum "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "223aa46593d99c18811d779ebbf10731fb28dba0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\_ViewImports.cshtml"
using DistroLabb2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\_ViewImports.cshtml"
using DistroLabb2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
using DistroLabb2.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"223aa46593d99c18811d779ebbf10731fb28dba0", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cecb5d9db0de0660076d5d33906791e7ae5a03ad", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DistroLabb2.Views.Home.ViewModels.IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
   ViewData["Title"] = "Home Page"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h2 class=\"display-4\">Welcome</h2>\r\n</div>\r\n\r\n");
#nullable restore
#line 13 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
 if (SignInManager.IsSignedIn(User))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        Username: ");
#nullable restore
#line 16 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
             Write(Model.nameOfUser);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
         if (@Model.latestLoginTime == DateTime.MinValue)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n");
#nullable restore
#line 20 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
         if (@Model.latestLoginTime != DateTime.MinValue)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>Last login: ");
#nullable restore
#line 24 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
                        Write(Html.DisplayFor(modelItem => Model.latestLoginTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 25 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        Number of logins this month: ");
#nullable restore
#line 27 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
                                Write(Model.amountMontlyLogin);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br />Number of unread messages: ");
#nullable restore
#line 28 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
                                    Write(Model.amountUnReadMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n");
#nullable restore
#line 31 "C:\Users\Emre\source\repos\DistroLabb2\DistroLabb2\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DistroLabb2.Views.Home.ViewModels.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
