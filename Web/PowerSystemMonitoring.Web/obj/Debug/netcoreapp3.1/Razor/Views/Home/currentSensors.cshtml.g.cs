#pragma checksum "C:\PowerSystemMonitoring\Web\PowerSystemMonitoring.Web\Views\Home\currentSensors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91b12ced45da8b6ce6c1d97c811a21a2925ca914"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_currentSensors), @"mvc.1.0.view", @"/Views/Home/currentSensors.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91b12ced45da8b6ce6c1d97c811a21a2925ca914", @"/Views/Home/currentSensors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11041b78a0247bf94d919d496e09aaa0a7d4598d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_currentSensors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<table id=\"table\" border=\"1\">\r\n\r\n    <tr>\r\n        <th>Current</th>\r\n        <th>Temperature</th>\r\n    </tr>\r\n\r\n    <tr>\r\n        <td>-</td>\r\n        <td>-</td>\r\n\r\n    </tr>\r\n\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var connection =
            new signalR.HubConnectionBuilder()
                .withUrl(""/sensors"")
                .build();

        //connection.on(""NewMessage"", // ot huba
        //    function (model) {
        //        var chatInfo = `<div>Current : [${model.current}]  Temperature : [${model.temperature}] ${escapeHtml(model.temperature)}</div>`;
        //        $(""#messagesList"").append(model.current);
        //    });



        $(""#sendButton"").click(function () { // natisnat buton
            var message = $(""#messageInput"").val();
            connection.invoke(""Send"", message);
            $(""#messageInput"").val("""");
        });

        connection.start().catch(function (err) {
            return console.error(err.toString());
        });

        function escapeHtml(unsafe) {
            return unsafe
                .replace(/&/g, ""&amp;"")
                .replace(/</g, ""&lt;"")
                .replace(/>/g, ""&gt;"")
                .replac");
                WriteLiteral(@"e(/""/g, ""&quot;"")
                .replace(/'/g, ""&#039;"");
        }
            connection.on(""NewMessage"", // ot huba
                function (model) {

                table.rows[1].cells[0].innerHTML = model.current;
                table.rows[1].cells[1].innerHTML = model.temperature;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
