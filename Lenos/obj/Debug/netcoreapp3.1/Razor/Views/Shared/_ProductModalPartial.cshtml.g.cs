#pragma checksum "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac4fe97ae9988da8b7fde251b6382eda58c60b04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductModalPartial), @"mvc.1.0.view", @"/Views/Shared/_ProductModalPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac4fe97ae9988da8b7fde251b6382eda58c60b04", @"/Views/Shared/_ProductModalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff1fc73dbed6952f45d1cbaede0aa837e501d3aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductModalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("add-btn addbasketbtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Basket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToBasket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"modal-overlay\"></div>\r\n<div class=\"product-content\">\r\n    <div class=\"left\">\r\n        <div class=\"img modal-slick\">\r\n");
#nullable restore
#line 7 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
             foreach (ProductImage productImage in Model.ProductImages)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ac4fe97ae9988da8b7fde251b6382eda58c60b046277", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 261, "~/assets/img/product/", 261, 21, true);
#nullable restore
#line 9 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
AddHtmlAttributeValue("", 282, productImage.Image, 282, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"right\">\r\n        <i class=\"bi bi-x-lg modal-close\"></i>\r\n        <h3>");
#nullable restore
#line 15 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <div class=\"price-box\">\r\n");
#nullable restore
#line 17 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
             if (Model.DiscountPrice > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"price\">$");
#nullable restore
#line 19 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
                                Write(Model.DiscountPrice.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span class=\"line-price\">$");
#nullable restore
#line 20 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
                                     Write(Model.Price.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 21 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"price\">$");
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
                                Write(Model.Price.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 25 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <p class=\"description\">");
#nullable restore
#line 27 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
                          Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 28 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
         if (Model.Availability == true)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"availability\">In Stock</p>\r\n");
#nullable restore
#line 31 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"availability text-danger\">Stock Out</p>\r\n");
#nullable restore
#line 35 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""cart-qty-add"">
            <div class=""quantity"">
                <div class=""pro-qty"">
                    <span class=""dec qtybtn"">-</span>
                    <input id=""productcount"" type=""text"" value=""1"">
                    <span class=""inc qtybtn"">+</span>
                </div>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac4fe97ae9988da8b7fde251b6382eda58c60b0411608", async() => {
                WriteLiteral("ADD TO CART");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Shared\_ProductModalPartial.cshtml"
                                                                                               WriteLiteral(Model.Id);

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
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
