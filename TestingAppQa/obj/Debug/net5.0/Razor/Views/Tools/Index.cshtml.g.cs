#pragma checksum "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Tools\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b0de69cf58e39bb24c16753235ef8a25455db1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tools_Index), @"mvc.1.0.view", @"/Views/Tools/Index.cshtml")]
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
#line 1 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\_ViewImports.cshtml"
using TestingAppQa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\_ViewImports.cshtml"
using TestingAppQa.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\_ViewImports.cshtml"
using TestingAppQa.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b0de69cf58e39bb24c16753235ef8a25455db1f", @"/Views/Tools/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9236b2083388687c613f927809694d90881139b1", @"/Views/_ViewImports.cshtml")]
    public class Views_Tools_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TestingAppQa.Models.Tools>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/modales/modales.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n        <div class=\"content\">\r\n            <div class=\"d-flex justify-content-between\">\r\n            <!-- Animated -->\r\n            <h3 class=\"text-secondary\">Seleccion de herramientas</h3> \r\n\r\n              <a");
            BeginWriteAttribute("onclick", " onclick=\"", 261, "\"", 366, 5);
            WriteAttributeValue("", 271, "showInPopup(\'", 271, 13, true);
#nullable restore
#line 9 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Tools\Index.cshtml"
WriteAttributeValue("", 284, Url.Action("Create", "Tools", null,Context.Request.Scheme), 284, 59, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 343, "\',", 343, 2, true);
            WriteAttributeValue(" ", 345, "\'Herramienta", 346, 13, true);
            WriteAttributeValue(" ", 358, "Nueva\')", 359, 8, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-danger text-white""><i class=""fa fa-plus""></i>Nueva Herramienta</a>  
               
            </div>

            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""card"">
                        <div class=""card-body "">
                            
                           
                             <div class=""table-stats order-table ov-h"">
                                <table class=""table "">
                                    <thead>
                                        <tr>
                                            <th class=""serial"">Nombre de la Herramienta</th>
                                            <th class=""avatar"">Version</th>
                                            <th>Especificacion de uso</th>
                                            <th>Acción</th>
                                        </tr>
                                    </thead>
                                    <tbody>
            ");
            WriteLiteral("                            \r\n\r\n");
#nullable restore
#line 32 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Tools\Index.cshtml"
                                                 foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n\r\n                                            <td class=\"serial\">");
#nullable restore
#line 36 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Tools\Index.cshtml"
                                                          Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"serial\">");
#nullable restore
#line 37 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Tools\Index.cshtml"
                                                          Write(Html.DisplayFor(modelItem => item.Version));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"serial\">");
#nullable restore
#line 38 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Tools\Index.cshtml"
                                                          Write(Html.DisplayFor(modelItem => item.Specification));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"serial\">\r\n                                                <a>  \r\n                                                <i class=\"fa fa-pencil\"");
            BeginWriteAttribute("onclick", "  onclick=\"", 2089, "\"", 2236, 8);
            WriteAttributeValue("", 2100, "showInPopup(\'", 2100, 13, true);
#nullable restore
#line 41 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Tools\Index.cshtml"
WriteAttributeValue("", 2113, Url.Action("Edit","Tools",new {id=item.IdTool},Context.Request.Scheme), 2113, 71, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2184, "\',\'Modificar", 2184, 12, true);
            WriteAttributeValue(" ", 2196, "Informacion", 2197, 12, true);
            WriteAttributeValue(" ", 2208, "General", 2209, 8, true);
            WriteAttributeValue(" ", 2216, "De", 2217, 3, true);
            WriteAttributeValue(" ", 2219, "la", 2220, 3, true);
            WriteAttributeValue(" ", 2222, "herramienta\')", 2223, 14, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"fa fa-pencil p-2\">\r\n                                                </i></a>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b0de69cf58e39bb24c16753235ef8a25455db1f8979", async() => {
                WriteLiteral("<i class=\"fa fa-trash\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Tools\Index.cshtml"
                                                                     WriteLiteral(item.IdTool);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" \r\n                                                \r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 47 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Tools\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>
                </div><!-- /# column -->
                

            </div>
            <!-- .animated -->
        </div>
");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b0de69cf58e39bb24c16753235ef8a25455db1f11966", async() => {
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
                WriteLiteral(" ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TestingAppQa.Models.Tools>> Html { get; private set; }
    }
}
#pragma warning restore 1591
