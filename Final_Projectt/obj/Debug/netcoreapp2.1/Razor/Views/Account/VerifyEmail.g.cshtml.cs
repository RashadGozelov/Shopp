#pragma checksum "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Account\VerifyEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9d917ff0f27482f23463249761b37fc2abb14a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_VerifyEmail), @"mvc.1.0.view", @"/Views/Account/VerifyEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/VerifyEmail.cshtml", typeof(AspNetCore.Views_Account_VerifyEmail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9d917ff0f27482f23463249761b37fc2abb14a2", @"/Views/Account/VerifyEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"520b62f1e838e28652472d902438a75fd471f3aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_VerifyEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Code Academy\Desktop\Final Code Academy\Final_Projectt\Final_Projectt\Views\Account\VerifyEmail.cshtml"
  
    ViewData["Title"] = "VerifyEmail";

#line default
#line hidden
            BeginContext(49, 524, true);
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""alert alert-success my-5"">
                Biz sizin e-poçtunuza təsdiq mesajı göndərdik.Zəhmət olmasa yoxlayın
            </div>
            <div class=""pb-4"">
                <a class=""btn btn-outline-link""style=""color:black;""  href=""/"">Əsas səhifə</a>
                <a class=""btn btn-outline-success"" href=""/Account/Login"">Daxil ol</a>
            </div>
            
        </div>
    </div>
</div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
