#pragma checksum "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24024a61084760e13fa604006a3144ed5f2b800b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Shared__CategoryIndexPartial), @"mvc.1.0.view", @"/Areas/Manage/Views/Shared/_CategoryIndexPartial.cshtml")]
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
#line 2 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\_ViewImports.cshtml"
using Lenos.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\_ViewImports.cshtml"
using Lenos.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\_ViewImports.cshtml"
using Lenos.ViewModels.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24024a61084760e13fa604006a3144ed5f2b800b", @"/Areas/Manage/Views/Shared/_CategoryIndexPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae5f3a3b7c8b6dfeba431ba50cbaf1c7197147c6", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Shared__CategoryIndexPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Category>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning w-25"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
   int count = (ViewBag.PageIndex - 1) * 5; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<table class=""table table-striped text-center"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Product Count</th>
            <th scope=""col"">Status</th>
            <th scope=""col"">Setting</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 16 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
         foreach (Category category in Model)
        {
            count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <th scope=\"row\">");
#nullable restore
#line 20 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
               Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n    <td>");
#nullable restore
#line 21 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
   Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 22 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
   Write(category.Products.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td");
            BeginWriteAttribute("style", " style=\"", 601, "\"", 652, 2);
            WriteAttributeValue("", 609, "color:", 609, 6, true);
#nullable restore
#line 23 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
WriteAttributeValue("", 615, category.IsDeleted ? "red":"green", 615, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                        Write(category.IsDeleted ? "DeActive":"Active");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24024a61084760e13fa604006a3144ed5f2b800b6547", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                              WriteLiteral(category.Id);

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
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24024a61084760e13fa604006a3144ed5f2b800b8831", async() => {
#nullable restore
#line 26 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                                                                                                                                                                                                      Write(category.IsDeleted ? "Restore":"Delete");

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 26 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
AddHtmlAttributeValue("", 829, category.IsDeleted ? "restoreCategory":"deleteCategory", 829, 58, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 896, "btn", 896, 3, true);
            AddHtmlAttributeValue(" ", 899, "w-25", 900, 5, true);
#nullable restore
#line 26 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
AddHtmlAttributeValue(" ", 904, category.IsDeleted ? "btn-primary":"btn-danger", 905, 50, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-status", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                                                     WriteLiteral(ViewBag.Status);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-status", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                                                                                      WriteLiteral(ViewBag.PageIndex);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                                                                                                                       WriteLiteral(category.IsDeleted ? "Restore":"Delete");

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
                                                                                                                                                                                                                                                                                WriteLiteral(category.Id);

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
            WriteLiteral("\r\n    </td>\r\n</tr>\r\n");
#nullable restore
#line 29 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Areas\Manage\Views\Shared\_CategoryIndexPartial.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
