#pragma checksum "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "adece12e0ad3171533e819ceca697f0998c33c31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Products_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Products/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Products/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Products_Index))]
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
#line 1 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\_ViewImports.cshtml"
using GraniteHouse_sw2;

#line default
#line hidden
#line 2 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\_ViewImports.cshtml"
using GraniteHouse_sw2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adece12e0ad3171533e819ceca697f0998c33c31", @"/Areas/Admin/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b62b9f31bdeda4b94be41c4066eb24f43483aeb6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GraniteHouse_sw2.Models.Products>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(95, 176, true);
            WriteLiteral("\r\n<br />\r\n<br />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        <h2 class=\"text-info\"> Product Type List </h2>\r\n    </div>\r\n    <div class=\"col-6 text-right\">\r\n        ");
            EndContext();
            BeginContext(271, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2362971aa1d845428981d377446978ce", async() => {
                BeginContext(315, 46, true);
                WriteLiteral("<i class=\"fas fa-plus\"></i>&nbsp; New Product ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(365, 154, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n<div>\r\n    <table class=\"table table-striped border\">\r\n        <tr class=\"table-info\">\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(520, 32, false);
#line 23 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
            EndContext();
            BeginContext(552, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(608, 33, false);
#line 26 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Price));

#line default
#line hidden
            EndContext();
            BeginContext(641, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(697, 37, false);
#line 29 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Available));

#line default
#line hidden
            EndContext();
            BeginContext(734, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(790, 40, false);
#line 32 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.ProductTypes));

#line default
#line hidden
            EndContext();
            BeginContext(830, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(886, 39, false);
#line 35 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.SpecialTags));

#line default
#line hidden
            EndContext();
            BeginContext(925, 84, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
            EndContext();
#line 41 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1058, 36, true);
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1095, 31, false);
#line 45 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
       Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1126, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1170, 32, false);
#line 48 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
       Write(Html.DisplayFor(m => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1202, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1246, 36, false);
#line 51 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
       Write(Html.DisplayFor(m => item.Available));

#line default
#line hidden
            EndContext();
            BeginContext(1282, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1326, 44, false);
#line 54 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
       Write(Html.DisplayFor(m => item.ProductTypes.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1370, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1414, 43, false);
#line 57 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
       Write(Html.DisplayFor(m => item.SpecialTags.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1457, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1500, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "75a54615f2a54926811e9307b9484295", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 60 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1554, 28, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
            EndContext();
#line 63 "C:\Users\Maria Majid\Desktop\githubmirettezfeta\GraniteHouse_sw2\GraniteHouse_sw2\GraniteHouse_sw2\Areas\Admin\Views\Products\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1593, 20, true);
            WriteLiteral("    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GraniteHouse_sw2.Models.Products>> Html { get; private set; }
    }
}
#pragma warning restore 1591
