#pragma checksum "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Sprints\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63c1ea577439043c841882106349a95da38ab065"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sprints_Index), @"mvc.1.0.view", @"/Views/Sprints/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63c1ea577439043c841882106349a95da38ab065", @"/Views/Sprints/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5439faa0bb0be046417d68fc14cddc50a9df2a3a", @"/Views/_ViewImports.cshtml")]
    public class Views_Sprints_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TestingAppQa.Models.Sprint>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/modales/modales.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"content\">\r\n    <div class=\"d-flex justify-content-between\">\r\n        <!-- Animated -->\r\n        <h3 class=\"text-secondary\">Sprints</h3>\r\n        <div>\r\n            <div id=\"PlaceHolderHere\">\r\n\r\n            </div>\r\n<a");
            BeginWriteAttribute("onclick", " onclick=\"", 278, "\"", 380, 5);
            WriteAttributeValue("", 288, "showInPopup(\'", 288, 13, true);
#nullable restore
#line 11 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Sprints\Index.cshtml"
WriteAttributeValue("", 301, Url.Action("Create", "Sprints", null,Context.Request.Scheme), 301, 61, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 362, "\',", 362, 2, true);
            WriteAttributeValue(" ", 364, "\'Sprint", 365, 8, true);
            WriteAttributeValue(" ", 372, "Nuevo\')", 373, 8, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-danger text-white""><i class=""fa fa-plus""></i>Nuevo Sprint</a>


            <button type=""button"" class=""btn btn-outline-danger"" data-toggle=""modal"" data-target=""#nuevomember""> <i class=""fa fa-users""></i> Invite</button>
        </div>
    </div>

");
#nullable restore
#line 18 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Sprints\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-lg-6\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-body d-flex justify-content-between\">\r\n\r\n                        <div>\r\n\r\n                            ");
#nullable restore
#line 27 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Sprints\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div>
                            <i class=""fa fa-check "" data-toggle=""modal"" data-target=""#exampleModal""></i>
                            <i class=""fa fa-pencil"" data-toggle=""modal"" data-target=""#exampleModal""></i>
                        </div>

                    </div>

                </div>
            </div><!-- /# column -->
            <div class=""col-lg-4 "">
                <div class=""card pb-2"">
                    <div class=""card-body d-flex justify-content-around"">

                        <div>

                            <p>Members</p>
                        </div>

                    </div>

                </div>
            </div><!-- /# column -->

        </div>
");
#nullable restore
#line 53 "C:\Users\FabianArenas\source\repos\TestingAppQa\TestingAppQa\Views\Sprints\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n    <!-- .animated -->\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63c1ea577439043c841882106349a95da38ab0656684", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TestingAppQa.Models.Sprint>> Html { get; private set; }
    }
}
#pragma warning restore 1591
