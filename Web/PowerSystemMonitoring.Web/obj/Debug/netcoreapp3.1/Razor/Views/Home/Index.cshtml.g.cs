#pragma checksum "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7245f7466a7849363442eedc9b57928dd7786f31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\_ViewImports.cshtml"
using PowerSystemMonitoring.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\_ViewImports.cshtml"
using PowerSystemMonitoring.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
using PowerSystemMonitoring.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7245f7466a7849363442eedc9b57928dd7786f31", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11041b78a0247bf94d919d496e09aaa0a7d4598d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PowerSystemMonitoring.Web.ViewModels.CurrentSensor.CurrentSensorViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/common/No_Image.jpg "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:inline-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
  
    this.ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to ");
#nullable restore
#line 9 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
                                Write(GlobalConstants.SystemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h1>\r\n    <div class=\"row \">\r\n");
#nullable restore
#line 11 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
         foreach (var sensor in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-3\">\r\n                <div class=\"card\" >\r\n");
#nullable restore
#line 15 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
                     if (sensor.ImageUrl != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img class=\"card-img-top img-responsive rounded-sm\" style=\"display:inline-block\"");
            BeginWriteAttribute("src", " src=\"", 611, "\"", 633, 1);
#nullable restore
#line 17 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 617, sensor.ImageUrl, 617, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n");
#nullable restore
#line 18 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7245f7466a7849363442eedc9b57928dd7786f316477", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 24 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">");
#nullable restore
#line 26 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
                                          Write(sensor.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n                        <h6 class=\"card-title\">Instalation on ");
#nullable restore
#line 29 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
                                                         Write(sensor.PowerLineName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                    </div>\r\n                    <ul class=\"list-group list-group-flush\">\r\n                        <li");
            BeginWriteAttribute("id", " id=\"", 1345, "\"", 1371, 1);
#nullable restore
#line 32 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1350, "curr" + sensor.Id, 1350, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item\"> - </li>\r\n                        <li");
            BeginWriteAttribute("id", " id=\"", 1434, "\"", 1460, 1);
#nullable restore
#line 33 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1439, "temp" + sensor.Id, 1439, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item\"> - </li>\r\n                    </ul>\r\n                    <div class=\"card-body\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1594, "\"", 1639, 2);
            WriteAttributeValue("", 1601, "/CurrentSensors/GetById/?id=", 1601, 28, true);
#nullable restore
#line 36 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1629, sensor.Id, 1629, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\" btn btn-primary\">View current sensor</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 40 "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var connection =
            new signalR.HubConnectionBuilder()
                .withUrl(""/sensors"")
                .build();

        connection.start().catch(function (err) {
            return console.error(err.toString());
        });

        connection.on(""NewMessage"", // ot huba
            function (model) {
                document.getElementById(""curr"".concat(model.currentSensorId)).innerHTML = ""Current: "".concat(model.current);
                document.getElementById(""temp"".concat(model.currentSensorId)).innerHTML = ""Temperature: "".concat(model.temperature);
            });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PowerSystemMonitoring.Web.ViewModels.CurrentSensor.CurrentSensorViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
