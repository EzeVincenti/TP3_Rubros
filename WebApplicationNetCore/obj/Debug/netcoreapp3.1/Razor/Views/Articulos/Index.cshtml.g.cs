#pragma checksum "C:\Users\Eze Vincenti\Desktop\Software\APP\WebApplicationNetCore\WebApplicationNetCore\Views\Articulos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4deb67f649472e2d5a77f76439b0b965cb4bda41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Articulos_Index), @"mvc.1.0.view", @"/Views/Articulos/Index.cshtml")]
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
#line 1 "C:\Users\Eze Vincenti\Desktop\Software\APP\WebApplicationNetCore\WebApplicationNetCore\Views\_ViewImports.cshtml"
using WebApplicationNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eze Vincenti\Desktop\Software\APP\WebApplicationNetCore\WebApplicationNetCore\Views\_ViewImports.cshtml"
using WebApplicationNetCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4deb67f649472e2d5a77f76439b0b965cb4bda41", @"/Views/Articulos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8640c02910a0b1a51a691a1e9cdd9e9e61ffd35", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Articulos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplicationNetCore.Models.Articulo>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Articulo-01.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Eze Vincenti\Desktop\Software\APP\WebApplicationNetCore\WebApplicationNetCore\Views\Articulos\Index.cshtml"
  
    ViewData["Title"] = "Artículo";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Articulos\r\n\r\n");
            WriteLiteral("\r\n</h1>\r\n<button type=\"button\" onclick=\"AbrirModal()\" class=\"btn btn-light m-1\" data-toggle=\"modal\" data-target=\"#modalAbrir\">\r\n  Nuevo Artículo \r\n</button>\r\n\r\n\r\n");
            WriteLiteral(@"
<table class=""table table-boardered"">
    <thead class=""table"" style=""color:White; background-color:#3F72AF"">
       
        <tr>
            <th></th>
            <th>Descripción</th>
             <th>Actualización</th>
              <th>Costo</th>
              <th>Ganancia</th>
              <th>Venta</th>
              <th>Subrubro</th>
              <th>Rubro</th>
             
            <th class=""text-center"">Opciones</th>
        </tr>
    </thead>
    <tbody id=""tbody-articulos"">


    </tbody>
</table>


");
            WriteLiteral(@"
<div class=""modal"" id=""Articulos"" tabindex=""-1"" role=""dialog"">
  <div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"" style=""color:white; background-color: #769FCD;"">
        <h5 class=""modal-title"" id=""Titulo""></h5>
        <button type=""button"" class=""close"" onclick=""VaciarFormulario()"" data-dismiss=""modal"" aria-label=""Close"">
          <span aria-hidden=""true"">&times;</span>
        </button>
      </div>
      <div class=""modal-body"" style=""color:black; background-color: #F7FBFC;"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4deb67f649472e2d5a77f76439b0b965cb4bda415696", async() => {
                WriteLiteral("\r\n         <input type=\"hidden\" id=\"ArticuloID\" value=\"0\"/>\r\n          <input type=\"hidden\" id=\"ArticuloEliminado\" value=false/>\r\n         <div class=\"form-grup\">\r\n");
                WriteLiteral(@"         <label >Descripción del artículo.</label>        
           <input required id=""ArticuloNombre"" type=""text"" class=""form-control p-3 bg-white rounded"" autocomplete=""off"" placeholder=""Descripción"" aria-label=""Username"" aria-describedby=""basic-addon1""  />
           <p id=""Error-ArticuloNombre"" class=""text-danger"" style=""font-size:small""></p> 
         </div>
");
                WriteLiteral(@"         <div class=""row"">
         <div class=""form-group col-lg-4"">
            <label class=""control-label"">Precio Costo:</label>
            <div class=""input-group-append"">
            <span class=""input-group-text"">$</span>
            <input type=""tel"" class=""form-control"" value=""0"" maxlength=""9"" onKeypress=""if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;""  style=""text-transform:uppercase"" autocomplete=""off"" required onKeyUp=""CalcularImportes(1)"" onKeyDown=""CalcularImportes(1)"" id=""PrecioCosto"">
        </div>
        </div>
         <div class=""form-group col-lg-4"">
            <label class=""control-label"">Porc. Ganancia:</label>
            <div class=""input-group-append"">
            <span class=""input-group-text"">%</span>
            <input type=""tel"" class=""form-control"" value=""0"" maxlength=""9"" onKeypress=""if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;""  style=""text-transform:uppercase"" autocomplete=""off"" required onKeyUp=""CalcularImpo");
                WriteLiteral(@"rtes(2)"" onKeyDown=""CalcularImportes(2)"" id=""PorcentajeGanancia"">
         </div>
         </div>
         <div class=""form-group col-lg-4"">
            <label class=""control-label"">Precio Venta:</label>
            <div class=""input-group-append"">
            <span class=""input-group-text"">$</span>
            <input type=""tel"" class=""form-control"" value=""0"" maxlength=""9"" onKeypress=""if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;""  style=""text-transform:uppercase"" autocomplete=""off"" required onKeyUp=""CalcularImportes(3)"" onKeyDown=""CalcularImportes(3)"" id=""PrecioVenta"">
         </div>
         </div>
         </div>
");
                WriteLiteral("         <div class=\"row\">   \r\n         <div class=\"form-grup col-lg-6\">\r\n            <label class=\"control-label\">Rubro:</label>\r\n            ");
#nullable restore
#line 91 "C:\Users\Eze Vincenti\Desktop\Software\APP\WebApplicationNetCore\WebApplicationNetCore\Views\Articulos\Index.cshtml"
       Write(Html.DropDownList("RubroID", null, htmlAttributes:new {@class = "form-control"}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            \r\n            <div class=\"form-grup col-lg-6\">\r\n            <label class=\"control-label\">Subrubro:</label> \r\n            ");
#nullable restore
#line 96 "C:\Users\Eze Vincenti\Desktop\Software\APP\WebApplicationNetCore\WebApplicationNetCore\Views\Articulos\Index.cshtml"
       Write(Html.DropDownList("SubRubroID", null, htmlAttributes:new {@class = "form-control"}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n         </div>\r\n         </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
       </div>
      <div class=""modal-footer"" style=""color:white; background-color: #B9D7EA;"">
        <button type=""button"" class=""btn btn-secondary"" onclick=""VaciarFormulario()"" data-dismiss=""modal""><i class=""bi bi-x-square"" style=""font-size: 1.2rem; color: white;""></i></button>
        <button type=""button"" onclick =""GuardarArticulo()"" class=""btn btn-success""><i class=""bi bi-save"" style=""font-size: 1.2rem; color: white;""></i></button>
      
      </div>
    </div>
  </div>
</div>


");
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4deb67f649472e2d5a77f76439b0b965cb4bda4111107", async() => {
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
                WriteLiteral("\r\n<script>\r\nwindow.onload = CompletarTablaArticulos();\r\n</script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplicationNetCore.Models.Articulo>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591