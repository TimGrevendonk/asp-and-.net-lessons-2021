#pragma checksum "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\Order\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15f74fe5840f18340383cc93959ea0d18b01cccf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Create), @"mvc.1.0.view", @"/Views/Order/Create.cshtml")]
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
#line 1 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\_ViewImports.cshtml"
using MyShop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\_ViewImports.cshtml"
using MyShop.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15f74fe5840f18340383cc93959ea0d18b01cccf", @"/Views/Order/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7ded7ce34b44ae537591d6ad72e0fcf8f0236eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyShop.Domain.Models.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\Order\Create.cshtml"
  
    ViewData["Title"] = "Create a new order";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create a new order</h1>
<div class=""row"">
    <div class=""col-4"">
        <strong>Add items to order</strong>
        <div class=""form-row mb-lg-5"">
            <div class=""col"">
                <label>Select product</label>
                <select v-model=""selectedProduct"" class=""form-control"" id=""product"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "15f74fe5840f18340383cc93959ea0d18b01cccf4196", async() => {
                WriteLiteral("Please select one");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\Order\Create.cshtml"
                     foreach (var product in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "15f74fe5840f18340383cc93959ea0d18b01cccf6019", async() => {
                WriteLiteral("\r\n                            ");
#nullable restore
#line 20 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\Order\Create.cshtml"
                       Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\Order\Create.cshtml"
                           WriteLiteral(product.ProductID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "v-bind:value", 12, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 686, "{", 686, 1, true);
            AddHtmlAttributeValue(" ", 687, "productId:", 688, 11, true);
            AddHtmlAttributeValue(" ", 698, "\'", 699, 2, true);
#nullable restore
#line 19 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\Order\Create.cshtml"
AddHtmlAttributeValue("", 700, product.ProductID, 700, 18, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 718, "\',", 718, 2, true);
            AddHtmlAttributeValue(" ", 720, "name:", 721, 6, true);
            AddHtmlAttributeValue(" ", 726, "\'", 727, 2, true);
#nullable restore
#line 19 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\Order\Create.cshtml"
AddHtmlAttributeValue("", 728, product.Name, 728, 13, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 741, "\',", 741, 2, true);
            AddHtmlAttributeValue(" ", 743, "price:", 744, 7, true);
#nullable restore
#line 19 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\Order\Create.cshtml"
AddHtmlAttributeValue(" ", 750, product.Price.ToString(System.Globalization.CultureInfo.InvariantCulture), 751, 74, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue(" ", 825, "}", 826, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\timgr\OneDrive\Desktop\stuff\school\asp.net\DOT.net\www\3_repository_pattern\MyShop\MyShop.Web\Views\Order\Create.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </select>
            </div>
            <div class=""col"">
                <label>Quantity</label>
                <input v-model=""selectedQuantity"" class=""form-control"" id=""quantity"" type=""number"" value=""1"" />
            </div>
        </div>
        <button v-on:click=""add"" :disabled='canAddToOrder' class=""btn btn-outline-success"">Add to order</button>
    </div>
    <div class=""col-4"">
        <strong>Current order</strong>
        <div class=""mb-lg-5"">
            <div class=""mb-lg-5"">
                Items
                <ul class=""list-group"">
                    <li v-for=""line in lineitems"" :key=""product.productId"" class=""list-group-item d-flex justify-content-between lh-condensed"">
                        <div>
                            <h6 class=""my-0"">{{ line.product.name }}</h6>
                            <small class=""text-muted"">Quantity: {{ line.quantity }}</small>
                        </div>
                        <span class=""text-muted"">${{ line.p");
            WriteLiteral(@"roduct.price *  line.quantity }}</span>
                    </li>

                    <li class=""list-group-item d-flex justify-content-between"">
                        <span>Total (USD)</span>
                        <strong>${{ totalPrice }}</strong>
                    </li>
                </ul>
            </div>
            <div>
                Customer details
                <div class=""form-group mb-lg-5"">
                    <div class=""form-group"">
                        <input v-model=""fullname"" placeholder=""Customer name"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                        <input v-model=""shippingAddress"" placeholder=""Customer address"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                        <input v-model=""city"" placeholder=""Geel"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                      ");
            WriteLiteral(@"  <input v-model=""postalCode"" placeholder=""####"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                        <input v-model=""country"" placeholder=""Belgium"" class=""form-control"">
                    </div>
                </div>
            </div>
            <button v-on:click=""submit"" :disabled='canSubmitOrder' class=""btn btn-success"">CREATE ORDER</button>
        </div>
    </div>
</div>

<div id=""orderSuccess"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Order Creation</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                
            </div>
        </div>
    </div>
<");
            WriteLiteral("/div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
		

            var app = new Vue({
                el: '#app',
                data: {
                    fullname: null,
                    shippingAddress: null,
                    city: null,
                    postalCode: null,
                    country: null,

                    selectedProduct: '',
                    selectedQuantity: 1,
                    totalPrice: 0,
					lineitems: new Array()
                },
                computed: {
                    canSubmitOrder: function () {
						return this.lineitems.length == 0 || this.fullname == null
                    },
                    canAddToOrder: function () {
                        return this.selectedProduct == ''
                    }
                },
                methods: {
                    add: function () {
                        var lineitem = {
                            product: this.selectedProduct,
                            quantity: th");
                WriteLiteral(@"is.selectedQuantity
                        }

                        if (product == null) return

						this.lineitems.push(lineitem)

                        this.totalPrice += lineitem.product.price * lineitem.quantity
                    },
                    submit: function () {
                        var data = {
                            customer: {
                                name: this.fullname,
                                shippingAddress: this.shippingAddress,
                                city: this.city,
                                postalCode: this.postalCode,
                                country: this.country
                            },
							lineitems: this.lineitems.map(function (line) {
                                return {
                                    productId: line.product.productId,
                                    quantity: line.quantity
                                }
                            })
                        ");
                WriteLiteral(@"}

                        $.ajax({
                            url: ""/Order/Create"",
                            data: data,
                            type: 'post',
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                $("".modal-body"").html(""<strong>ERROR</strong><p>"" + XMLHttpRequest.responseText + ""</p>"")
                                $('#orderSuccess').modal('show')
                            },
                            success: function (data) {
                                $("".modal-body"").html(""<strong>Success!</strong><p>The order was successfully created</p>"")
                                $('#orderSuccess').modal('show')
                            }
                        });
                    }
                }
            })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyShop.Domain.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
