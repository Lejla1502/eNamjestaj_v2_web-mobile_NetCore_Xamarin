#pragma checksum "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29eeba440e9dd6f13e4de0870b7b50d2ea953c58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ModulAdministrator_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/ModulAdministrator/Views/Dashboard/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ModulAdministrator/Views/Dashboard/Index.cshtml", typeof(AspNetCore.Areas_ModulAdministrator_Views_Dashboard_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29eeba440e9dd6f13e4de0870b7b50d2ea953c58", @"/Areas/ModulAdministrator/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75d1de2be480932e6593590e71e3561d65160e1", @"/Areas/ModulAdministrator/Views/_ViewImports.cshtml")]
    public class Areas_ModulAdministrator_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eNamjestaj.Web.Areas.ModulAdministrator.ViewModels.DashboardViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("sb-nav-fixed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
  
    //Layout = "_Layout";

#line default
#line hidden
            BeginContext(112, 31, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n\r\n");
            EndContext();
            BeginContext(143, 207, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "29eeba440e9dd6f13e4de0870b7b50d2ea953c584351", async() => {
                BeginContext(149, 194, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Index</title>\r\n\r\n    <link href=\"https://fonts.googleapis.com/icon?family=Material+Icons\"\r\n          rel=\"stylesheet\">\r\n\r\n");
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
            BeginContext(350, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(356, 11984, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "29eeba440e9dd6f13e4de0870b7b50d2ea953c585752", async() => {
                BeginContext(383, 711, true);
                WriteLiteral(@"

        <div>
            <main>
                <div class=""container-fluid"">

                    <div class=""row"">
                        <div class=""col-xl-4 col-md-6"">
                            <div class=""card bg-primary text-white mb-4"">
                                <div class=""card-header card-header-icon "">


                                    <span class=""d-inline-block "">
                                        <i class=""fas fa-store-alt""></i>
                                    </span>
                                    <span class=""d-inline-block card-category"" style=""padding-bottom:13px;"">Zarada</span>

                                    <h3 class=""card-title"">");
                EndContext();
                BeginContext(1095, 29, false);
#line 35 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
                                                      Write(Model.Zarada.ToString("0.00"));

#line default
#line hidden
                EndContext();
                BeginContext(1124, 1015, true);
                WriteLiteral(@" KM</h3>
                                </div>
                                <div class=""card-footer"">
                                    <div class=""stats"">
                                        <i class=""material-icons"">date_range</i> Zadnja 24 Sata
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-xl-4 col-md-6"">
                            <div class=""card bg-warning text-white mb-4"">
                                <div class=""card-header  card-header-icon"">

                                    <span class=""d-inline-block "">
                                        <i class=""fas fa-shopping-cart""></i>
                                    </span>
                                    <span class=""d-inline-block card-category"" style=""padding-bottom:13px;"">Kupljeni proizvodi</span>


                                    <h3 class=""card-title"">");
                EndContext();
                BeginContext(2140, 25, false);
#line 54 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
                                                      Write(Model.BrProdanihProizvoda);

#line default
#line hidden
                EndContext();
                BeginContext(2165, 1008, true);
                WriteLiteral(@"</h3>
                                </div>
                                <div class=""card-footer"">
                                    <div class=""stats"">
                                        <i class=""material-icons"">date_range</i> Zadnja 24 Sata
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-xl-4 col-md-6"">
                            <div class=""card bg-danger text-white mb-4"">
                                <div class=""card-header  card-header-icon"">

                                    <span class=""d-inline-block "">
                                        <i class=""fas fa-percent""></i>
                                    </span>
                                    <span class=""d-inline-block card-category"" style=""padding-bottom:13px;"">Proizvoda na akciji</span>



                                    <h3 class=""card-title"">");
                EndContext();
                BeginContext(3174, 27, false);
#line 74 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
                                                      Write(Model.BrProizvodaNaSnizenju);

#line default
#line hidden
                EndContext();
                BeginContext(3201, 250, true);
                WriteLiteral("</h3>\r\n                                </div>\r\n                                <div class=\"card-footer\">\r\n                                    <div class=\"stats\">\r\n                                        <i class=\"material-icons\">date_range</i> Od <b>");
                EndContext();
                BeginContext(3452, 36, false);
#line 78 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
                                                                                  Write(Model.DatumOd.ToString("dd/MM/yyyy"));

#line default
#line hidden
                EndContext();
                BeginContext(3488, 11, true);
                WriteLiteral("</b> do <b>");
                EndContext();
                BeginContext(3500, 36, false);
#line 78 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
                                                                                                                                  Write(Model.DatumDo.ToString("dd/MM/yyyy"));

#line default
#line hidden
                EndContext();
                BeginContext(3536, 420, true);
                WriteLiteral(@"</b>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <!--
                        <div class=""col-xl-3 col-md-6"">
                            <div class=""card bg-danger text-white mb-4"">
                                <div class=""card-body"" style=""margin-left:5px; font-size:23px;""><b>");
                EndContext();
                BeginContext(3957, 27, false);
#line 87 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
                                                                                              Write(Model.BrProizvodaNaSnizenju);

#line default
#line hidden
                EndContext();
                BeginContext(3984, 2317, true);
                WriteLiteral(@"</b></div>
                                <div style=""margin-left:7px; padding-left:17px;"">Proizvoda na snizenju</div>
                            </div>
                        </div>-->
                    </div>
                    <div class=""row"">
                        <div class=""col-xl-6"">
                            <div class=""card mb-4"">
                                <div class=""card-header"">
                                    <i class=""fas fa-chart-area mr-1""></i>
                                    Broj prodatih proizvoda za 2021. godinu
                                </div>
                                <div class=""card-body""><canvas id=""myAreaChart"" width=""100%"" height=""50""></canvas></div>
                            </div>
                        </div>
                        <div class=""col-xl-6"">
                            <div class=""card mb-4"">
                                <div class=""card-header"">
                                    <i class=""fas fa-chart-ba");
                WriteLiteral(@"r mr-1""></i>
                                    Najprodavaniji proizvodi u 2021. godini
                                </div>
                                <div class=""card-body""><canvas id=""myBarChart"" width=""100%"" height=""50""></canvas></div>
                            </div>
                        </div>
                    </div>

                </div>
            </main>
        </div>
       
        <script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js"" crossorigin=""anonymous""></script>
        <script src=""https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"" crossorigin=""anonymous""></script>
        <script src=""https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js"" crossorigin=""anonymous""></script>
        <script src=""assets/demo/datatables-demo.js""></script>
        <script src=""https://www.jsdelivr.com/package/npm/chart.js""></script>
        <script src=""https://cdnjs.cloudflare.com/ajax/libs/chartjs-plugin-datalabels/2.0.0/c");
                WriteLiteral(@"hartjs-plugin-datalabels.min.js"" integrity=""sha512-R/QOHLpV1Ggq22vfDAWYOaMd5RopHrJNMxi8/lJu8Oihwi4Ho4BRFeiMiCefn9rasajKjnx9/fTQ/xkWnkDACg=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>





        <script>
        var BrProdanihPoMjesecima = ");
                EndContext();
                BeginContext(6302, 62, false);
#line 129 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
                               Write(Html.Raw(Json.Serialize(Model.BrProdanihProizvodaPoMjesecima)));

#line default
#line hidden
                EndContext();
                BeginContext(6364, 2625, true);
                WriteLiteral(@";
        // Set new default font family and font color to mimic Bootstrap's default styling
        Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,""Segoe UI"",Roboto,""Helvetica Neue"",Arial,sans-serif';
        Chart.defaults.global.defaultFontColor = '#292b2c';

        // Area Chart Example
        var ctx = document.getElementById(""myAreaChart"");
        var myLineChart = new Chart(ctx, {
            type: 'line',
            data: {

                labels: [""Januar"", ""Februar"", ""Mart"", ""April"", ""Maj"", ""Juni"", ""Juli"", ""August"", ""Septembar"", ""Oktobar"", ""Novembar"", ""Decembar""],
                datasets: [{

                    label: ""Broj proizvoda"",
                    lineTension: 0.3,
                    backgroundColor: ""rgba(2,117,216,0.2)"",
                    borderColor: ""rgba(2,117,216,1)"",
                    pointRadius: 5,
                    pointBackgroundColor: ""rgba(2,117,216,1)"",
                    pointBorderColor: ""rgba(255,255,2");
                WriteLiteral(@"55,0.8)"",
                    pointHoverRadius: 5,
                    pointHoverBackgroundColor: ""rgba(2,117,216,1)"",
                    pointHitRadius: 50,
                    pointBorderWidth: 2,
                    data: BrProdanihPoMjesecima,
                }],
            },
            options: {
                scales: {
                    xAxes: [{
                        time: {
                            unit: 'date'
                        },
                        gridLines: {
                            display: false
                        },
                        ticks: {
                            maxTicksLimit: 7
                        }
                    }],
                    yAxes: [{
                        scaleLabel: {
                            display: true,
                            labelString: 'Broj prodanih proizvoda'
                        },
                        ticks: {
                            min: 0,
                        ");
                WriteLiteral(@"    max: 40,
                            maxTicksLimit: 5
                        },
                        gridLines: {
                            color: ""rgba(0, 0, 0, .125)"",
                        }
                    }],
                },
                legend: {
                    display: false,
                    title: {
                        display: true,
                        text: 'Broj prodanih proizvoda od 01.01.2021 do 31.12.2021'
                    }
                }
            }
        });



        var NaziviTop5 = ");
                EndContext();
                BeginContext(8990, 62, false);
#line 197 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
                    Write(Html.Raw(Json.Serialize(Model.NaziviNajprodavanijihProizvoda)));

#line default
#line hidden
                EndContext();
                BeginContext(9052, 30, true);
                WriteLiteral(";\r\n        var KolicineTop5 = ");
                EndContext();
                BeginContext(9083, 64, false);
#line 198 "C:\Users\HP\source\repos\eNamjestaj_v2_web-mobile_NetCore_Xamarin\eNamjestaj.Web\Areas\ModulAdministrator\Views\Dashboard\Index.cshtml"
                      Write(Html.Raw(Json.Serialize(Model.KolicineNajprodavanijihProizvoda)));

#line default
#line hidden
                EndContext();
                BeginContext(9147, 3186, true);
                WriteLiteral(@";

        // Bar Chart Example
        var ctx = document.getElementById(""myBarChart"");
        var myLineChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: NaziviTop5,
                datasets: [{
                    label: ""Kolicina"",
                    backgroundColor: ""rgba(2,117,216,1)"",
                    borderColor: ""rgba(2,117,216,1)"",
                    barThickness: 1,
                    data: KolicineTop5,
                    xAxis: {
                        gridLineWidth: 0
                    },
                    yAxis: {
                        gridLineWidth: 0,
                        minorTickInterval: null
                    }
                }],
            },


            options: {
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 15,
                        bottom: 0
                    }
              ");
                WriteLiteral(@"  },
                scales: {

                    xAxes: [{
                        gridLines: {
                            display: false,
                            drawBorder: false,

                        },
                        ticks: {


                            maxTicksLimit: 6
                        }

                    }],
                    yAxes: [{
                        ticks: {
                            min:0,
                            maxTicksLimit: 5,
                            display: false,
                            mirror: true,
                            labelOffset: -12
                        },
                        barThickness: 10,
                        gridLines: {
                            display: false,
                            drawBorder: false,

                        }
                    }],
                },

                animation: {
                    duration: 1,
                    onComplete: fun");
                WriteLiteral(@"ction () {
                        var chartInstance = this.chart,
                            ctx = chartInstance.ctx;

                        ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                        ctx.textAlign = 'center';
                        ctx.textBaseline = 'bottom';

                        this.data.datasets.forEach(function (dataset, i) {
                            var meta = chartInstance.controller.getDatasetMeta(i);
                            meta.data.forEach(function (bar, index) {
                                if (dataset.data[index] > 0) {
                                    var data = dataset.data[index];
                                    ctx.fillText(data, bar._model.x, bar._model.y);
                                }
                            });
                        });
                    }
                },
                legen");
                WriteLiteral("d: {\r\n                    display: false\r\n                }\r\n            }\r\n        });\r\n\r\n        </script>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(12340, 13, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eNamjestaj.Web.Areas.ModulAdministrator.ViewModels.DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591