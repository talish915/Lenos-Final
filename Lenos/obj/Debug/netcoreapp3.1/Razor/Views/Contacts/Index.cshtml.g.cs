#pragma checksum "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Contacts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9a5b50b3f1322ed4c2447e837f6715e279fad88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contacts_Index), @"mvc.1.0.view", @"/Views/Contacts/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a5b50b3f1322ed4c2447e837f6715e279fad88", @"/Views/Contacts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"421ee863b1e44485acb14935daef01d0d99a21f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Contacts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Lenos-Final\Lenos\Views\Contacts\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<main id=\"main\">\r\n    <!-- Breadcrumb start -->\r\n    <section class=\"page-breadcrumb\">\r\n        <div class=\"content\">\r\n            <img src=\"assets/img/breadcrumb/banner.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 217, "\"", 223, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""crumbcontent"">
                <h1>Contacts</h1>
                <div>
                    <a href=""index.html"">Home</a> <span>/</span> <span>Contacts</span>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb end -->

    <section class=""map-section"">
        <div class=""container"">
            <iframe frameborder=""0"" width=""100%"" scrolling=""no"" marginheight=""0"" marginwidth=""0"" src=""https://maps.google.com/maps?q=London%20Eye%2C%20London%2C%20United%20Kingdom&amp;t=m&amp;z=15&amp;output=embed&amp;iwloc=near"" title=""London Eye, London, United Kingdom"" aria-label=""London Eye, London, United Kingdom""></iframe>
        </div>
    </section>

    <section class=""contact-section"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-6 left"">
                    <h2 class=""title"">How To Find Us</h2>
                    <p class=""subtitle"">Get in touch to discuss your employee wellbeing");
            WriteLiteral(@" needs today. Please give us a call, drop us an email or fill out the contact form and we’ll get back to you.</p>
                    <a class=""tel"" href=""tel: +8012356789"">+80 123 567 89</a>
                    <p class=""address"">283 N. Glenwood Street, Levittown, NY</p>
                    <a class=""mail"" href=""mailto: help.lenos@gmail.com"">help.lenos@gmail.com</a>
                    <div class=""socials"">
                        <ul>
                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1729, "\"", 1736, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-brands fa-facebook-f\"></i></a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1822, "\"", 1829, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-brands fa-twitter\"></i></a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1912, "\"", 1919, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-brands fa-pinterest-p\"></i></a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 2006, "\"", 2013, 0);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa-brands fa-youtube""></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class=""col-lg-6 right"">
                    <h2 class=""title"">Contact Us</h2>
                    <p class=""subtitle"">Your email address will not be published. Required fields are marked *</p>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9a5b50b3f1322ed4c2447e837f6715e279fad887767", async() => {
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-lg-6"">
                                <input name=""full_name"" placeholder=""Your Full Name *"" type=""text"" required>
                            </div>
                            <div class=""col-lg-6"">
                                <input name=""phone"" placeholder=""Your Phone *"" type=""text"" required>
                            </div>
                            <div class=""col-lg-12"">
                                <input name=""email_address"" placeholder=""Your Email *"" type=""text"" required>
                            </div>
                            <div class=""col-lg-12"">
                                <textarea placeholder=""Message *"" name=""message"" class=""form-control2"" required></textarea>
                            </div>
                            <div class=""col-lg-5"">
                                <button class=""btn-submit"" type=""submit"">SUBMIT</button>
                            </div>
");
                WriteLiteral("                        </div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
