#pragma checksum "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9b13df77c1ec9bbe772525a598a4bd15303a798"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
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
#line 2 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\_ViewImports.cshtml"
using Lenos.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\_ViewImports.cshtml"
using Lenos.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\_ViewImports.cshtml"
using Lenos.ViewModels.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\_ViewImports.cshtml"
using Lenos.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\_ViewImports.cshtml"
using Lenos.ViewModels.Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\_ViewImports.cshtml"
using Lenos.ViewModels.Wishlist;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\_ViewImports.cshtml"
using Lenos.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\_ViewImports.cshtml"
using Lenos.ViewModels.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\_ViewImports.cshtml"
using Lenos.ViewModels.About;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9b13df77c1ec9bbe772525a598a4bd15303a798", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff1fc73dbed6952f45d1cbaede0aa837e501d3aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LoginVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Account\Login.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<main id=\"main\">\r\n    <!-- Breadcrumb start -->\r\n    <section class=\"page-breadcrumb\">\r\n        <div class=\"content\">\r\n            <img src=\"assets/img/breadcrumb/banner.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 233, "\"", 239, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""crumbcontent"">
                <h1>Login</h1>
                <div>
                    <a href=""index.html"">Home</a> <span>/</span> <span>Login</span>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb end -->

    <section class=""login-section"">
        <div class=""container"">
            <div class=""col-lg-8 mx-auto sign-in"">
                ");
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Account\Login.cshtml"
           Write(await Html.PartialAsync("_LoginPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </section>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoginVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
