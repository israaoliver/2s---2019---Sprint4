#pragma checksum "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19768342f57438e3cf731842c71418c65ba35e89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Sucesso), @"mvc.1.0.view", @"/Views/Shared/Sucesso.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Sucesso.cshtml", typeof(AspNetCore.Views_Shared_Sucesso))]
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
#line 1 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC;

#line default
#line hidden
#line 2 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19768342f57438e3cf731842c71418c65ba35e89", @"/Views/Shared/Sucesso.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fae5be29b1d0446bbdb7fe81a11990f47b34647", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Sucesso : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleTopMVC.ViewModels.MensagemViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icones/Suc_cadastro.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icones/Suport.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 47, true);
            WriteLiteral("<main>\r\n    \r\n    <section class=\"flex conf\">\r\n");
            EndContext();
#line 5 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
     if("Cadastro".Equals(Model.NomeView))
    {

#line default
#line hidden
            BeginContext(146, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(154, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "19768342f57438e3cf731842c71418c65ba35e894347", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(195, 117, true);
            WriteLiteral("\r\n        <br>\r\n        <p>Obrigado!!!! <br> Você concluiu seu cadastro, <br> siga para o seu perfil.</p>\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 312, "\'", 350, 1);
#line 10 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
WriteAttributeValue("", 319, Url.Action("Index", "Usuario"), 319, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(351, 48, true);
            WriteLiteral("><button class=\"margin\">Continuar</button></a>\r\n");
            EndContext();
#line 11 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"

    }

#line default
#line hidden
            BeginContext(408, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 13 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
     if("Suporte".Equals(Model.NomeView2))
    {

#line default
#line hidden
            BeginContext(459, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(467, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "19768342f57438e3cf731842c71418c65ba35e896644", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(502, 97, true);
            WriteLiteral("\r\n        <p>Sua mensagem foi enviada com sucesso! <br> Responderemos em até 48hr</p>\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 599, "\'", 637, 1);
#line 17 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
WriteAttributeValue("", 606, Url.Action("Index", "Usuario"), 606, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(638, 45, true);
            WriteLiteral("><button class=\"margin\">Voltar</button></a>\r\n");
            EndContext();
#line 18 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
    }

#line default
#line hidden
            BeginContext(690, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 19 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
     if("Cadastro".Equals(Model.NomeView2))
    {

#line default
#line hidden
            BeginContext(742, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(750, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "19768342f57438e3cf731842c71418c65ba35e898914", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(791, 77, true);
            WriteLiteral("\r\n        <p>Voce conclui o cadastro do seu evento Obrigado! </p>\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 868, "\'", 908, 1);
#line 23 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
WriteAttributeValue("", 875, Url.Action("Eventos", "Usuario"), 875, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(909, 48, true);
            WriteLiteral("><button class=\"margin\">Continuar</button></a>\r\n");
            EndContext();
#line 24 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
    }

#line default
#line hidden
            BeginContext(964, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 25 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
     if("Informacao".Equals(Model.NomeView2))
    {

#line default
#line hidden
            BeginContext(1018, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(1026, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "19768342f57438e3cf731842c71418c65ba35e8911173", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1067, 13, true);
            WriteLiteral("\r\n        <p>");
            EndContext();
            BeginContext(1081, 14, false);
#line 28 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
      Write(Model.Mensagem);

#line default
#line hidden
            EndContext();
            BeginContext(1095, 29, true);
            WriteLiteral(" com sucesso!</p>\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 1124, "\'", 1168, 1);
#line 29 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
WriteAttributeValue("", 1131, Url.Action("Informacoes", "Usuario"), 1131, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1169, 48, true);
            WriteLiteral("><button class=\"margin\">Continuar</button></a>\r\n");
            EndContext();
#line 30 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Sucesso.cshtml"
    }

#line default
#line hidden
            BeginContext(1224, 35, true);
            WriteLiteral("\r\n\r\n    </section>\r\n    \r\n\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleTopMVC.ViewModels.MensagemViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
