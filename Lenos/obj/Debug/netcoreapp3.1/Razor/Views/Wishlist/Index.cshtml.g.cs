#pragma checksum "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Wishlist\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6aacdc5cbdcffad8e3631fdce97c350f413a852b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wishlist_Index), @"mvc.1.0.view", @"/Views/Wishlist/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6aacdc5cbdcffad8e3631fdce97c350f413a852b", @"/Views/Wishlist/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bcf456618e408ee6439495691a30e3d488e6a36", @"/Views/_ViewImports.cshtml")]
    public class Views_Wishlist_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WishlistVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Wishlist\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<main id=\"main\">\r\n    <!-- Breadcrumb start -->\r\n    <section class=\"page-breadcrumb\">\r\n        <div class=\"content\">\r\n            <img src=\"assets/img/breadcrumb/banner.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 242, "\"", 248, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""crumbcontent"">
                <h1>Wishlist</h1>
                <div>
                    <a href=""index.html"">Home</a> <span>/</span> <span>Wishlist</span>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb end -->

    <section class=""wishlist-section"">
        <div class=""container wishlist-container"">
            ");
#nullable restore
#line 23 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Wishlist\Index.cshtml"
       Write(await Html.PartialAsync("_WishlistIndexPartial",Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </section>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WishlistVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
