#pragma checksum "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9984da5a1eb4f97f9b0950c68ddc6fdfeae49e5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
#line 1 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\_ViewImports.cshtml"
using MyShop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\_ViewImports.cshtml"
using MyShop.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9984da5a1eb4f97f9b0950c68ddc6fdfeae49e5e", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7ded7ce34b44ae537591d6ad72e0fcf8f0236eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyShop.Domain.Models.Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "All orders";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Orders</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
 foreach (var order in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row mb-lg-5\">\r\n        <div class=\"col-lg-8\">\r\n            <h4 class=\"d-flex justify-content-between align-items-center mb-3\">\r\n                <span class=\"text-muted\">Order # (");
#nullable restore
#line 14 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
                                              Write(order.Customer.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span>\r\n                <span class=\"badge badge-secondary badge-pill\">");
#nullable restore
#line 15 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
                                                          Write(order.OrderID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </h4>\r\n            <ul class=\"list-group\">\r\n");
#nullable restore
#line 18 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
                 foreach (var item in order.Orderlines)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"list-group-item d-flex justify-content-between lh-condensed\">\r\n                        <div>\r\n                            <h6 class=\"my-0\">");
#nullable restore
#line 22 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
                                        Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                            <small class=\"text-muted\">Quantity: ");
#nullable restore
#line 23 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
                                                           Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                        </div>\r\n                        <span class=\"text-muted\">$");
#nullable restore
#line 25 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
                                              Write(item.Product.Price * item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </li>\r\n");
#nullable restore
#line 27 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <li class=\"list-group-item d-flex justify-content-between\">\r\n                    <span>Total (USD)</span>\r\n                    <strong>$");
#nullable restore
#line 31 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
                        Write(order.OrderTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 36 "C:\School\2ITF\sem2\NET development\www\MyShop\MyShop.Web\Views\Order\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyShop.Domain.Models.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
