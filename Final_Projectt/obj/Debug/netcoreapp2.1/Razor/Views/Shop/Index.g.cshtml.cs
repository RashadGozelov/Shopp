#pragma checksum "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1b835264299e05aeb247b971c90b2d22723541d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Index), @"mvc.1.0.view", @"/Views/Shop/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shop/Index.cshtml", typeof(AspNetCore.Views_Shop_Index))]
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
#line 1 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\_ViewImports.cshtml"
using Final_Projectt.Models;

#line default
#line hidden
#line 2 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\_ViewImports.cshtml"
using Final_Projectt.ViewModel;

#line default
#line hidden
#line 3 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1b835264299e05aeb247b971c90b2d22723541d", @"/Views/Shop/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"520b62f1e838e28652472d902438a75fd471f3aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/product/Lg_phone_3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_searchPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
  
    ViewData["Title"] = "Aksesuarlar";

#line default
#line hidden
            BeginContext(65, 252, true);
            WriteLiteral("\r\n<!-- breadcrumb-area start -->\r\n<div class=\"breadcrumb-area\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <ul class=\"breadcrumb-list\">\r\n                    <li class=\"breadcrumb-item\">");
            EndContext();
            BeginContext(317, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6afb8837176498abd0be6ba0fdc9ef3", async() => {
                BeginContext(361, 11, true);
                WriteLiteral("Əsas səhifə");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(376, 657, true);
            WriteLiteral(@"</li>
                    <li class=""breadcrumb-item active""><i class=""fas fa-chevron-right""></i> Aksesuarlar</li>
                </ul>
            </div>
        </div>
    </div>
</div>
<!-- breadcrumb-area end -->
<!-- content-wraper start -->
<div class=""content-wraper"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-3 order-2 order-lg-1"">
                <!-- categories-box start -->
                <div class=""categories-box sidebar-categores-box"">
                    <div class=""secton-title"">
                        <h2>Kateqoriyalar</h2>
                    </div>
                    ");
            EndContext();
            BeginContext(1033, 1070, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c617e3a6a65c4f1c94eabb6b97d48d73", async() => {
                BeginContext(1052, 348, true);
                WriteLiteral(@"
                        <div class=""sidebar-categores-inner"">
                            <div class=""filter-group"">
                                <style>
                                    p {
                                        display: inline-block;
                                    }
                                </style>
");
                EndContext();
#line 38 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
                                 foreach (var category in Model.Categorys)
                                {

#line default
#line hidden
                BeginContext(1511, 61, true);
                WriteLiteral("                                    <a><input type=\"checkbox\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1572, "\"", 1592, 1);
#line 40 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
WriteAttributeValue("", 1580, category.Id, 1580, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1593, 34, true);
                WriteLiteral(" name=\"CategoryId\" id=\"Category\" >");
                EndContext();
                BeginContext(1628, 13, false);
#line 40 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
                                                                                                               Write(category.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1641, 6, true);
                WriteLiteral("</a>\r\n");
                EndContext();
#line 43 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
                                                                                                      
                              
                                }

#line default
#line hidden
                BeginContext(2008, 88, true);
                WriteLiteral("                            </div>\r\n                        </div>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2103, 620, true);
            WriteLiteral(@"

                </div>
                <!-- categories-box end -->
                <!-- marka-box start -->
                <div class=""categories-box sidebar-categores-box"">
                    <div class=""secton-title"">
                        <h2>Markalar</h2>
                    </div>
                    <div class=""sidebar-categores-inner"">
                        <div class=""filter-group"">
                            <style>
                                p {
                                    display: inline-block;
                                }
                            </style>
");
            EndContext();
#line 64 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
                             foreach (var marka in Model.Markas)
                            {

#line default
#line hidden
            BeginContext(2820, 57, true);
            WriteLiteral("                                <a><input type=\"checkbox\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2877, "\"", 2894, 1);
#line 66 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
WriteAttributeValue("", 2885, marka.Id, 2885, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2895, 27, true);
            WriteLiteral(" name=\"MarkaId\" id=\"Marka\">");
            EndContext();
            BeginContext(2923, 10, false);
#line 66 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
                                                                                                 Write(marka.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2933, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 68 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
                                                                                            
                            }

#line default
#line hidden
            BeginContext(3066, 293, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <!-- marka-box end -->
                <!-- single-benner start -->
                <div class=""single-benner mt-30 text-center"">
                    <a href=""#"">
                        ");
            EndContext();
            BeginContext(3359, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "28a4a00630fa43baa1072cf4faf9f6a0", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3406, 808, true);
            WriteLiteral(@"
                    </a>
                </div>
                <!-- single-benner start -->
            </div>
            <div class=""col-lg-9 order-1 order-lg-2"">
                <div class=""row"">
                    <div class=""col"">
                        <div class=""shop-top-bar"">
                            <div class=""shop-bar-inner"">
                                <div class=""product-view-mode"">
                                    <!-- shop-item-filter-list start -->
                                    <ul role=""tablist"" class=""nav shop-item-filter-list"">
                                        <li role=""presentation"" class=""active""><a href=""#grid"" aria-controls=""grid"" role=""tab"" data-toggle=""tab"" class=""active show"" aria-selected=""true""><i class=""fa fa-th""></i></a></li>
");
            EndContext();
            BeginContext(4388, 255, true);
            WriteLiteral("                                    </ul>\r\n                                    <!-- shop-item-filter-list end -->\r\n                                </div>\r\n\r\n                            </div>\r\n                            <div class=\"product-select-box\">\r\n");
            EndContext();
            BeginContext(6212, 339, true);
            WriteLiteral(@"                            </div>
                        </div>
                    </div>
                </div>
                <div class=""shop-products-wrapper"">
                    <div class=""tab-content"">
                        <div id=""grid"" class=""tab-pane fade active show"" role=""tabpanel"">
                            ");
            EndContext();
            BeginContext(6551, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "11bb460dda744fa6933442892b09d473", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#line 128 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Shop\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.Products;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6608, 36, true);
            WriteLiteral("\r\n                        </div>\r\n\r\n");
            EndContext();
            BeginContext(11457, 460, true);
            WriteLiteral(@"
                        <!-- paginatoin-area start -->
                        <div class=""paginatoin-area"">
                            <div class=""row"">
                                <div class=""col-lg-6 col-md-6"">
                                    <!-- <p>Bax 10-13  </p> -->
                                </div>
                                <div class=""col-lg-6 col-md-6"">
                                    <ul class=""pagination-box"">
");
            EndContext();
            BeginContext(12227, 986, true);
            WriteLiteral(@"
                                        <li>
                                            <a href=""#"" class=""Previous""> <i class=""fa fa-angle-double-left""></i> </a>
                                        </li>
                                        <li><a href=""#"" class=""active"">1</a></li>
                                        <li><a href=""#"">2</a></li>
                                        <li><a href=""#"">3</a></li>
                                        <li>
                                            <a href=""#"" class=""Next""> <i class=""fa fa-angle-double-right""></i> </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- paginatoin-area end -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- content-wraper end -->
");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
