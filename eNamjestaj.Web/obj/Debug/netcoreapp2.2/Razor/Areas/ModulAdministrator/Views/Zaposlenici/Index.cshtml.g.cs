#pragma checksum "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9341ac8df30592e0a0d9b44ddb05d91fff427ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ModulAdministrator_Views_Zaposlenici_Index), @"mvc.1.0.view", @"/Areas/ModulAdministrator/Views/Zaposlenici/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ModulAdministrator/Views/Zaposlenici/Index.cshtml", typeof(AspNetCore.Areas_ModulAdministrator_Views_Zaposlenici_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9341ac8df30592e0a0d9b44ddb05d91fff427ca", @"/Areas/ModulAdministrator/Views/Zaposlenici/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75d1de2be480932e6593590e71e3561d65160e1", @"/Areas/ModulAdministrator/Views/_ViewImports.cshtml")]
    public class Areas_ModulAdministrator_Views_Zaposlenici_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eNamjestaj.Web.Areas.ModulAdministrator.ViewModels.ZaposleniciIndexVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Ime i/ili prezime"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left:10px; margin-right:15px; width:200px !important;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/ModulAdministrator/Zaposlenici/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Obrisi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "ModulAdministrator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(198, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(200, 468, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9341ac8df30592e0a0d9b44ddb05d91fff427ca7135", async() => {
                BeginContext(273, 113, true);
                WriteLiteral("\r\n    <div class=\"form-group\">\r\n        <label for=\"ZaposlenikPretraga\">Pretraga zaposlenika:</label>\r\n\r\n        ");
                EndContext();
                BeginContext(386, 187, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d9341ac8df30592e0a0d9b44ddb05d91fff427ca7640", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#line 9 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ZaposlenikPretraga);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(573, 88, true);
                WriteLiteral("\r\n\r\n    </div>\r\n\r\n    <input type=\"submit\" value=\"Pretraga\" class=\"btn btn-primary\" />\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(668, 522, true);
            WriteLiteral(@"
<br />

<div class=""card-body"">
    <div class=""table-responsive"">
        <table class="" table table-bordered"" width=""100%"" cellspacing=""0"">
            <thead>
                <tr>
                    <th>Ime</th>
                    <th>Prezime</th>
                    <th>Korisničko ime</th>
                    <th>Email</th>
                    <th>Telefon</th>
                    <th>Uloga</th>
                    <th>Akcija</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 33 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
                 foreach (var x in Model.Zaposlenici)
                {

#line default
#line hidden
            BeginContext(1264, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1319, 5, false);
#line 36 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
                       Write(x.Ime);

#line default
#line hidden
            EndContext();
            BeginContext(1324, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1360, 9, false);
#line 37 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
                       Write(x.Prezime);

#line default
#line hidden
            EndContext();
            BeginContext(1369, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1405, 15, false);
#line 38 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
                       Write(x.KorisnickoIme);

#line default
#line hidden
            EndContext();
            BeginContext(1420, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1456, 7, false);
#line 39 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
                       Write(x.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1463, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1499, 9, false);
#line 40 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
                       Write(x.Telefon);

#line default
#line hidden
            EndContext();
            BeginContext(1508, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1544, 7, false);
#line 41 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
                       Write(x.Uloga);

#line default
#line hidden
            EndContext();
            BeginContext(1551, 123, true);
            WriteLiteral("</td>\r\n                        <td>\r\n                            <button ajax-poziv=\"da\" ajax-rezultat=\"divUrediZaposlenik\"");
            EndContext();
            BeginWriteAttribute("ajax-url", " ajax-url=\"", 1674, "\"", 1751, 2);
            WriteAttributeValue("", 1685, "/ModulAdministrator/Zaposlenici/Uredi?zaposlenikId=", 1685, 51, true);
#line 43 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
WriteAttributeValue("", 1736, x.ZaposlenikId, 1736, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1752, 70, true);
            WriteLiteral(" class=\"btn btn-primary\">Uredi</button>|\r\n                            ");
            EndContext();
            BeginContext(1822, 117, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9341ac8df30592e0a0d9b44ddb05d91fff427ca15388", async() => {
                BeginContext(1929, 6, true);
                WriteLiteral("Obrisi");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 44 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
                                                                            WriteLiteral(x.ZaposlenikId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1939, 64, true);
            WriteLiteral("\r\n\r\n\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 49 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Zaposlenici\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2022, 463, true);
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<br />
<br />

<div id=""divUrediZaposlenik""></div>
<br />



<script>
    $(""button[ajax-poziv='da']"").click(function (event) {

        var btn = $(this);

        var url = btn.attr(""ajax-url"");
        var r = btn.attr(""ajax-rezultat"");

        $.get(url,
            function (rezultat, status) {
                $(""#"" + r).html(rezultat);

            });
    });
</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eNamjestaj.Web.Areas.ModulAdministrator.ViewModels.ZaposleniciIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591