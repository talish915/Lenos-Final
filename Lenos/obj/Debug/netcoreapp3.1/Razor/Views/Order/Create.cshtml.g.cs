#pragma checksum "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Order\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a4c4dc31b7961ecfd7ee8c72c291603011d7d04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Create), @"mvc.1.0.view", @"/Views/Order/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a4c4dc31b7961ecfd7ee8c72c291603011d7d04", @"/Views/Order/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bcf456618e408ee6439495691a30e3d488e6a36", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Order\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<main id=\"main\">\r\n    <!-- Breadcrumb start -->\r\n    <section class=\"page-breadcrumb\">\r\n        <div class=\"content\">\r\n            <img src=\"assets/img/breadcrumb/banner.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 234, "\"", 240, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""crumbcontent"">
                <h1>Checkout</h1>
                <div>
                    <a href=""index.html"">Home</a> <span>/</span> <span>Checkout</span>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb end -->

    <section class=""checkout-section"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-6"">
                    <h2>Billing Details</h2>
                    ");
#nullable restore
#line 26 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Order\Create.cshtml"
               Write(await Html.PartialAsync("_OrderPartial",Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <div class=""col-lg-6"">
                    <h2>Your Order Summary</h2>
                    <div class=""order-summary-table text-center"">
                        <table class=""table table-bordered"">
                            <thead>
                                <tr>
                                    <th>Products</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <a href=""product-details.html"">Suscipit Vestibulum <strong> × 1</strong></a>
                                    </td>
                                    <td>$165.00</td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href=""product-details.html""");
            WriteLiteral(@">Ami Vestibulum suscipit <strong> × 4</strong></a>
                                    </td>
                                    <td>$165.00</td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href=""product-details.html"">Vestibulum suscipit <strong> × 2</strong></a>
                                    </td>
                                    <td>$165.00</td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td>Sub Total</td>
                                    <td><strong>$400</strong></td>
                                </tr>
                                <tr>
                                    <td>Shipping</td>
                                    <td class=""d-flex justify-content-center"">
                                        <ul class=""sh");
            WriteLiteral(@"ipping-type"">
                                            <li>
                                                <div class=""custom-control custom-radio"">
                                                    <input type=""radio"" id=""flatrate"" name=""shipping"" class=""custom-control-input"" checked />
                                                    <label class=""custom-control-label"" for=""flatrate"">
                                                        Flat
                                                        Rate: $70.00
                                                    </label>
                                                </div>
                                            </li>
                                            <li>
                                                <div class=""custom-control custom-radio"">
                                                    <input type=""radio"" id=""freeshipping"" name=""shipping"" class=""custom-control-input"" />
                                       ");
            WriteLiteral(@"             <label class=""custom-control-label"" for=""freeshipping"">
                                                        Free
                                                        Shipping
                                                    </label>
                                                </div>
                                            </li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Total Amount</td>
                                    <td><strong>$470</strong></td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <div class=""order-btn"">
                        <button type=""submit"" form=""orderForm"">PLACE ORDER</button>
                    </div>
                </div>
            </div>
        </div>
    </");
            WriteLiteral("section>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderVM> Html { get; private set; }
    }
}
#pragma warning restore 1591