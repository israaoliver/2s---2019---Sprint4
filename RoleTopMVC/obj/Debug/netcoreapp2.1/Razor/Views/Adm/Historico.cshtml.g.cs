#pragma checksum "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42d8ef175c19de8c7db5569def9e99afd671ec15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Adm_Historico), @"mvc.1.0.view", @"/Views/Adm/Historico.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Adm/Historico.cshtml", typeof(AspNetCore.Views_Adm_Historico))]
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
#line 1 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC;

#line default
#line hidden
#line 2 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42d8ef175c19de8c7db5569def9e99afd671ec15", @"/Views/Adm/Historico.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fae5be29b1d0446bbdb7fe81a11990f47b34647", @"/Views/_ViewImports.cshtml")]
    public class Views_Adm_Historico : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleTopMVC.ViewModels.DashboardViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Adm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 70, true);
            WriteLiteral("\r\n    <main class=\"flex geral tab\">\r\n        <div class=\"flex icon-2\">");
            EndContext();
            BeginContext(119, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42d8ef175c19de8c7db5569def9e99afd671ec153895", async() => {
                BeginContext(162, 42, true);
                WriteLiteral("<i class=\"back fas fa-backward fa-2x\"></i>");
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
            BeginContext(208, 787, true);
            WriteLiteral(@"</div>
        <div class=""flex cima "">
            <h1>Historico Geral</h1>
        </div>

        <section>
            <table>
                <thead>
                    <tr>
                        <th>Nome do Evento</th>
                        <th>Data</th>
                        <th>Email CLiente</th>
                        <th>Serviços</th>
                        <th>Tipo</th>
                        <th>Quantidade</th>
                        <th>Publico/Privado</th>
                        <th>Pagamento</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <td colspan=""9"">
                            <p>Eventos atualizados em ");
            EndContext();
            BeginContext(996, 12, false);
#line 27 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                                                 Write(DateTime.Now);

#line default
#line hidden
            EndContext();
            BeginContext(1008, 115, true);
            WriteLiteral("</p>\r\n                        </td>\r\n                    </tr>\r\n                </tfoot>\r\n                <tbody>\r\n");
            EndContext();
#line 32 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                     foreach (var e in Model.Eventos)
                    {

#line default
#line hidden
            BeginContext(1201, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(1264, 12, false);
#line 35 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                           Write(e.NomeEvento);

#line default
#line hidden
            EndContext();
            BeginContext(1276, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1316, 13, false);
#line 36 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                           Write(e.DiaDoEvento);

#line default
#line hidden
            EndContext();
            BeginContext(1329, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1369, 15, false);
#line 37 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                           Write(e.Cliente.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1384, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1424, 15, false);
#line 38 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                           Write(e.Servicos.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1439, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1479, 12, false);
#line 39 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                           Write(e.TipoEvento);

#line default
#line hidden
            EndContext();
            BeginContext(1491, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1531, 12, false);
#line 40 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                           Write(e.Quantidade);

#line default
#line hidden
            EndContext();
            BeginContext(1543, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 41 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                             if(e.Pub_priv)
                            {

#line default
#line hidden
            BeginContext(1626, 50, true);
            WriteLiteral("                                <td>Publico</td>\r\n");
            EndContext();
#line 44 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                            }else
                            {

#line default
#line hidden
            BeginContext(1742, 50, true);
            WriteLiteral("                                <td>Privado</td>\r\n");
            EndContext();
#line 47 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                            }

#line default
#line hidden
            BeginContext(1823, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 48 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                             if (e.Pago)
                            {

#line default
#line hidden
            BeginContext(1896, 65, true);
            WriteLiteral("                                <td class=\"aprovado\">Pagou</td>\r\n");
            EndContext();
#line 51 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(2057, 68, true);
            WriteLiteral("                                <td class=\"pendente\">Pendente</td>\r\n");
            EndContext();
#line 55 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                            }

#line default
#line hidden
            BeginContext(2156, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 56 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                             if(e.Status == 0)
                            {

#line default
#line hidden
            BeginContext(2235, 73, true);
            WriteLiteral("                                <td class=\"flex pendente\">Pendente</td>\r\n");
            EndContext();
#line 59 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                            }

#line default
#line hidden
            BeginContext(2339, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 60 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                             if(e.Status == 1)
                            {

#line default
#line hidden
            BeginContext(2418, 73, true);
            WriteLiteral("                                <td class=\"flex aprovado\">Aprovado</td>\r\n");
            EndContext();
#line 63 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                            }

#line default
#line hidden
            BeginContext(2522, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 64 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                             if(e.Status == 2)
                            {

#line default
#line hidden
            BeginContext(2601, 75, true);
            WriteLiteral("                                <td class=\"flex reprovado\">Reprovado</td>\r\n");
            EndContext();
#line 67 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                            }

#line default
#line hidden
            BeginContext(2707, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 68 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                             if (e.Status == 3)
                            {

#line default
#line hidden
            BeginContext(2787, 71, true);
            WriteLiteral("                                <td class=\"flex apagado\">Apagado</td>\r\n");
            EndContext();
#line 71 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                            }

#line default
#line hidden
            BeginContext(2889, 51, true);
            WriteLiteral("                        </tr>                    \r\n");
            EndContext();
#line 73 "C:\Users\44346823858\Documents\RoleTopMVC\RoleTopMVC\Views\Adm\Historico.cshtml"
                    }

#line default
#line hidden
            BeginContext(2963, 79, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </section>\r\n    </main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleTopMVC.ViewModels.DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591