#pragma checksum "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c05fe4de3f0a58ccd75e1a436bf86f3a44ab875"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Erro), @"mvc.1.0.view", @"/Views/Shared/Erro.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Erro.cshtml", typeof(AspNetCore.Views_Shared_Erro))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c05fe4de3f0a58ccd75e1a436bf86f3a44ab875", @"/Views/Shared/Erro.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fae5be29b1d0446bbdb7fe81a11990f47b34647", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Erro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleTopMVC.ViewModels.MensagemViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icones/Erro_cadastro.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(48, 49, true);
            WriteLiteral("<main>\r\n    <section class=\"flex conf\">\r\n        ");
            EndContext();
            BeginContext(97, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c05fe4de3f0a58ccd75e1a436bf86f3a44ab8753675", async() => {
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
            BeginContext(139, 28, true);
            WriteLiteral("\r\n        <br>\r\n        <p> ");
            EndContext();
            BeginContext(168, 14, false);
#line 6 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
       Write(Model.Mensagem);

#line default
#line hidden
            EndContext();
            BeginContext(182, 29, true);
            WriteLiteral("! <br> Tente Novamente!</p>\r\n");
            EndContext();
#line 7 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
     if("Cadastro".Equals(Model.NomeView)){

#line default
#line hidden
            BeginContext(256, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 266, "\'", 305, 1);
#line 8 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
WriteAttributeValue("", 273, Url.Action("Index", "Cadastro"), 273, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(306, 45, true);
            WriteLiteral("><button class=\"margin\">Voltar</button></a>\r\n");
            EndContext();
#line 9 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
    }

#line default
#line hidden
            BeginContext(358, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 10 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
     if("Login".Equals(Model.NomeView)){

#line default
#line hidden
            BeginContext(400, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 410, "\'", 448, 1);
#line 11 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
WriteAttributeValue("", 417, Url.Action("Login", "Cliente"), 417, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(449, 45, true);
            WriteLiteral("><button class=\"margin\">Voltar</button></a>\r\n");
            EndContext();
#line 12 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
    }

#line default
#line hidden
            BeginContext(501, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 13 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
     if("Usuario".Equals(Model.NomeView)){

#line default
#line hidden
            BeginContext(545, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 555, "\'", 593, 1);
#line 14 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
WriteAttributeValue("", 562, Url.Action("Index", "Usuario"), 562, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(594, 45, true);
            WriteLiteral("><button class=\"margin\">Voltar</button></a>\r\n");
            EndContext();
#line 15 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
    }

#line default
#line hidden
            BeginContext(646, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 16 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
     if("Adm".Equals(Model.NomeView))
    {

#line default
#line hidden
            BeginContext(692, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 702, "\'", 736, 1);
#line 18 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
WriteAttributeValue("", 709, Url.Action("Index", "Adm"), 709, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(737, 45, true);
            WriteLiteral("><button class=\"margin\">Voltar</button></a>\r\n");
            EndContext();
#line 19 "C:\Users\44346823858\Documents\2s---2019---Sprint4\RoleTopMVC\Views\Shared\Erro.cshtml"
    }

#line default
#line hidden
            BeginContext(789, 25, true);
            WriteLiteral("    </section>\r\n\r\n</main>");
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