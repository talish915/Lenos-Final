#pragma checksum "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f3980e3e7e464591ce2e96cc1865326ce7bf308"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BasketIndexPartial), @"mvc.1.0.view", @"/Views/Shared/_BasketIndexPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f3980e3e7e464591ce2e96cc1865326ce7bf308", @"/Views/Shared/_BasketIndexPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff1fc73dbed6952f45d1cbaede0aa837e501d3aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__BasketIndexPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BasketVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: red"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("deletecard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Basket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteCard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
  
    double subtotal = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Cart Table Area -->
<div class=""cart-table table-responsive"">
    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th class=""pro-thumbnail"">Image</th>
                <th class=""pro-title"">Product</th>
                <th class=""pro-price"">Price</th>
                <th class=""pro-quantity"">Quantity</th>
                <th class=""pro-subtotal"">Total</th>
                <th class=""pro-remove"">Remove</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 19 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
             foreach (BasketVM basketVM in Model)
            {
                subtotal += basketVM.Price * basketVM.Count;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"pro-thumbnail\"><a href=\"#\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8f3980e3e7e464591ce2e96cc1865326ce7bf3087661", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 809, "~/assets/img/product/", 809, 21, true);
#nullable restore
#line 23 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
AddHtmlAttributeValue("", 830, basketVM.Image, 830, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a></td>\r\n                    <td style=\"width: 30%\" class=\"pro-title\"><a href=\"#\">");
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
                                                                    Write(basketVM.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                    <td class=\"pro-price\"><span>$");
#nullable restore
#line 25 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
                                            Write(basketVM.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n\r\n                    <td class=\"pro-quantity\">\r\n                        <div class=\"pro-qty\">\r\n                            <span class=\"dec qtybtn\">-</span>\r\n                            <input type=\"text\" class=\"prodCount\" data-id=\"");
#nullable restore
#line 30 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
                                                                     Write(basketVM.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("value", " value=\"", 1304, "\"", 1327, 1);
#nullable restore
#line 30 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
WriteAttributeValue("", 1312, basketVM.Count, 1312, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <span class=\"inc qtybtn\">+</span>\r\n                        </div>\r\n                    </td>\r\n\r\n                    <td class=\"pro-subtotal\"><span>$");
#nullable restore
#line 35 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
                                                Write(basketVM.Price* basketVM.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                    <td class=\"pro-remove\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3980e3e7e464591ce2e96cc1865326ce7bf30811488", async() => {
                WriteLiteral("<i class=\"bi bi-trash\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
                                                                                                                                      WriteLiteral(basketVM.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 38 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<!-- Cart Update Option -->
<div class=""cart-update-option"">
    <div class=""cart-update"">
        <a href=""#"" class=""btn"">Update Cart</a>
    </div>
</div>


<div class=""row"">
    <div class=""col-lg-5 ml-auto"">
        <!-- Cart Calculation Area -->
        <div class=""cart-calculator-wrapper"">
            <div class=""cart-calculate-items"">
                <h3>Cart Totals</h3>
                <div class=""table-responsive"">
                    <table class=""table"">
                        <tr>
                            <td>Sub Total</td>
                            <td>$");
#nullable restore
#line 61 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
                            Write(subtotal);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                        </tr>
                        <tr>
                            <td>Shipping</td>
                            <td>$75</td>
                        </tr>
                        <tr class=""total"">
                            <td>Total</td>
                            <td class=""total-amount"">$");
#nullable restore
#line 69 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_BasketIndexPartial.cshtml"
                                                 Write(subtotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n            <a href=\"checkout.html\" class=\"btn d-block\">Proceed Checkout</a>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BasketVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
