#pragma checksum "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\Info\ListRiders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71796bc97d2d3b37796cdea349af4563c24c5c1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Info_ListRiders), @"mvc.1.0.view", @"/Views/Info/ListRiders.cshtml")]
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
#line 1 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\_ViewImports.cshtml"
using MotoGP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\_ViewImports.cshtml"
using MotoGP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71796bc97d2d3b37796cdea349af4563c24c5c1c", @"/Views/Info/ListRiders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28c11a21fd0de2028889f3b1a931d0560cbec79e", @"/Views/_ViewImports.cshtml")]
    public class Views_Info_ListRiders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MotoGP.Models.Rider>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\Info\ListRiders.cshtml"
  
    ViewData["Title"] = "Riders";
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
  .cards {
   display: flex;
   flex-wrap: wrap;
   justify-content: space-between;
  }
  .column {
    align-content: center;
    float: left;
    width: 30%;
    padding: 1rem;
  }
  .card {
      background: lightgrey;
      width: 60%;
      margin: auto;
      padding: 1rem;
      text-align: center;
  }
</style>

<!-- Back button that goes to previous page.-->
<a href=""javascript:history.back()""><b>Back</b></a>

<section class=""cards"">
");
#nullable restore
#line 32 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\Info\ListRiders.cshtml"
 foreach (var item in Model)
{
    // Get the value "number" from Model that has table content Riders in it.
    var rider = "/images/riders/" + item.Number + ".jpg";
    // Get the value "CountryID" from Model that has table content Riders in it.
    var flag = "/images/flags/" + item.CountryID + ".png";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"column\">\r\n        <article class=\"card\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 957, "\"", 969, 1);
#nullable restore
#line 40 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\Info\ListRiders.cshtml"
WriteAttributeValue("", 963, rider, 963, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"rider\"/>\r\n                <h2 class=\"number\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 1047, "\"", 1058, 1);
#nullable restore
#line 42 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\Info\ListRiders.cshtml"
WriteAttributeValue("", 1053, flag, 1053, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"flag\" class=\"flag\"/>\r\n                    ");
#nullable restore
#line 43 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\Info\ListRiders.cshtml"
               Write(item.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h2>\r\n            <p>    \r\n                ");
#nullable restore
#line 46 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\Info\ListRiders.cshtml"
           Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 46 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\Info\ListRiders.cshtml"
                           Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>     \r\n        </article>\r\n    </div>\r\n");
#nullable restore
#line 50 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\www\MotoGP\MotoGP\Views\Info\ListRiders.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </section>\r\n    <p><a href=\"javascript:history.back()\">Back</a></p>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MotoGP.Models.Rider>> Html { get; private set; }
    }
}
#pragma warning restore 1591
