#pragma checksum "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4af53c2a9aba2dab51eade14bbee8e8a46b048ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ModulAdministrator_Views_Shared__Layout), @"mvc.1.0.view", @"/Areas/ModulAdministrator/Views/Shared/_Layout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ModulAdministrator/Views/Shared/_Layout.cshtml", typeof(AspNetCore.Areas_ModulAdministrator_Views_Shared__Layout))]
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
#line 1 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\_ViewImports.cshtml"
using eNamjestaj.Web;

#line default
#line hidden
#line 2 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\_ViewImports.cshtml"
using eNamjestaj.Web.Models;

#line default
#line hidden
#line 1 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 2 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
using eNamjestaj.Data.Helper;

#line default
#line hidden
#line 3 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
using eNamjestaj.Data.Models;

#line default
#line hidden
#line 4 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
using eNamjestaj.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4af53c2a9aba2dab51eade14bbee8e8a46b048ad", @"/Areas/ModulAdministrator/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75d1de2be480932e6593590e71e3561d65160e1", @"/Areas/ModulAdministrator/Views/_ViewImports.cshtml")]
    public class Areas_ModulAdministrator_Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/styles.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/startbootstrap-sb-admin/css/sb-admin.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-none d-md-inline-block form-inline ml-auto mr-0 mr-md-3 my-2 my-md-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/scripts.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("sb-nav-fixed "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(120, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 7 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
  
    MojContext ctx = new MojContext();
    Korisnik k = Context.GetLogiraniKorisnik();
    Zaposlenik admin = ctx.Zaposlenik.Where(m => m.KorisnikId == k.Id).First();

#line default
#line hidden
            BeginContext(301, 29, true);
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(330, 1132, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4af53c2a9aba2dab51eade14bbee8e8a46b048ad8001", async() => {
                BeginContext(336, 121, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
                EndContext();
                BeginContext(458, 17, false);
#line 19 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(475, 33, true);
                WriteLiteral(" - eNamjestaj.Web</title>\r\n\r\n    ");
                EndContext();
                BeginContext(508, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4af53c2a9aba2dab51eade14bbee8e8a46b048ad8950", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(557, 269, true);
                WriteLiteral(@"




    <link href=""https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css"" rel=""stylesheet"" crossorigin=""anonymous"" />
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/js/all.min.js"" crossorigin=""anonymous""></script>

");
                EndContext();
                BeginContext(906, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(910, 83, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4af53c2a9aba2dab51eade14bbee8e8a46b048ad10671", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(993, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(1001, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4af53c2a9aba2dab51eade14bbee8e8a46b048ad12009", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1048, 358, true);
                WriteLiteral(@"


    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js""></script>

    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.17.0/jquery.validate.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js""></script>

");
                EndContext();
                BeginContext(1451, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1462, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(1466, 4731, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4af53c2a9aba2dab51eade14bbee8e8a46b048ad14629", async() => {
                BeginContext(1494, 300, true);
                WriteLiteral(@"
    <nav class=""sb-topnav navbar navbar-expand navbar-dark bg-dark"">
        <a class=""navbar-brand"" href=""/ModulAdministrator/Dashboard/Index"">eNamještaj</a>
        <button class=""btn btn-link btn-sm order-1 order-lg-0"" id=""sidebarToggle"" href=""#""><i class=""fas fa-bars""></i></button>
        ");
                EndContext();
                BeginContext(1794, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4af53c2a9aba2dab51eade14bbee8e8a46b048ad15326", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1886, 828, true);
                WriteLiteral(@"

        <!-- Navbar-->
        <ul class=""navbar-nav ml-auto ml-md-0"">
            <li class=""nav-item dropdown"">
                <a class=""nav-link"" id=""userDropdown"" href=""#"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""><i class=""fa fa-user""></i><i class=""fa fa-caret-down""></i></a>
                <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""userDropdown"">
                    <a class=""dropdown-item"" href=""/Autentifikacija/Logout"">Logout</a>

                </div>
            </li>
        </ul>

    </nav>
    <div id=""layoutSidenav"">
        <div id=""layoutSidenav_nav"">
            <nav class=""sb-sidenav accordion sb-sidenav-dark"" id=""sidenavAccordion"">
                <div class=""sb-sidenav-menu"">
                    <div class=""nav"">

");
                EndContext();
#line 69 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
                         if (admin != null)
                        {

#line default
#line hidden
                BeginContext(2784, 37, true);
                WriteLiteral("<div class=\"sb-sidenav-menu-heading\">");
                EndContext();
                BeginContext(2822, 9, false);
#line 70 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
                                                         Write(admin.Ime);

#line default
#line hidden
                EndContext();
                BeginContext(2831, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(2833, 13, false);
#line 70 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
                                                                    Write(admin.Prezime);

#line default
#line hidden
                EndContext();
                BeginContext(2846, 6, true);
                WriteLiteral("</div>");
                EndContext();
#line 70 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
                                                                                             }

#line default
#line hidden
                BeginContext(2855, 1535, true);
                WriteLiteral(@"
                        <div class=""nav-link""></div>
                        <a class=""nav-link"" href=""/ModulAdministrator/Dashboard/Index"">
                            <div class=""sb-nav-link-icon""><i class=""fas fa-tachometer-alt""></i></div>
                            Dashboard
                        </a>

                        <a class=""nav-link collapsed"" href=""#"" data-toggle=""collapse"" data-target=""#collapseLayouts"" aria-expanded=""false"" aria-controls=""collapseLayouts"">
                            <div class=""sb-nav-link-icon""><i class=""far fa-address-card""></i></div>
                            Zaposlenici
                            <div class=""sb-sidenav-collapse-arrow""><i class=""fas fa-angle-down""></i></div>
                        </a>
                        <div class=""collapse"" id=""collapseLayouts"" aria-labelledby=""headingOne"" data-parent=""#sidenavAccordion"">
                            <nav class=""sb-sidenav-menu-nested nav"">
                                <a class=""nav-link"" ");
                WriteLiteral(@"href=""/ModulAdministrator/Zaposlenici/Index"">Pregled zaposlenika</a>
                                <a class=""nav-link"" href=""/ModulAdministrator/Zaposlenici/Dodaj"">Dodaj zaposlenika</a>
                            </nav>
                        </div>


                        <a class=""nav-link"" href=""/ModulAdministrator/Kupci/Index"">
                            <div class=""sb-nav-link-icon""><i class=""fa fa-users""></i></div>
                            Kupci
                        </a>



");
                EndContext();
                BeginContext(4643, 54, true);
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
                EndContext();
#line 105 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
                 if (k != null)
                {

#line default
#line hidden
                BeginContext(4749, 142, true);
                WriteLiteral("                    <div class=\"sb-sidenav-footer\">\r\n\r\n                        <div class=\"small\">Logiran kao:</div>\r\n                        ");
                EndContext();
                BeginContext(4892, 15, false);
#line 110 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
                   Write(k.KorisnickoIme);

#line default
#line hidden
                EndContext();
                BeginContext(4907, 32, true);
                WriteLiteral("\r\n\r\n                    </div>\r\n");
                EndContext();
#line 113 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
                }

#line default
#line hidden
                BeginContext(4958, 146, true);
                WriteLiteral("            </nav>\r\n        </div>\r\n        <div id=\"layoutSidenav_content\">\r\n\r\n            <div class=\"container body-content\">\r\n                ");
                EndContext();
                BeginContext(5105, 12, false);
#line 119 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(5117, 916, true);
                WriteLiteral(@"
                <footer class=""py-4 bg-light mt-auto "">
                    <div class=""container-fluid"">
                        <div class=""d-flex align-items-center justify-content-between small"">
                            <div class=""text-muted"">Copyright &copy; eNamještaj 2021</div>
                            <div>
                                <a href=""#"">Privacy Policy</a>
                                &middot;
                                <a href=""#"">Terms &amp; Conditions</a>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
    </div>
 
    <script src=""https://code.jquery.com/jquery-3.5.1.min.js"" crossorigin=""anonymous""></script>
    <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js"" crossorigin=""anonymous""></script>
    ");
                EndContext();
                BeginContext(6033, 39, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4af53c2a9aba2dab51eade14bbee8e8a46b048ad23950", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6072, 118, true);
                WriteLiteral("\r\n    <script src=\"https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js\" crossorigin=\"anonymous\"></script>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6197, 10, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            BeginContext(6208, 41, false);
#line 145 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Shared\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
            EndContext();
            BeginContext(6249, 13, true);
            WriteLiteral("\r\n</html>\r\n\r\n");
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
