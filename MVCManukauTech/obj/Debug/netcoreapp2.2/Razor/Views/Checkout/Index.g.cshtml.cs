#pragma checksum "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "715ebb4d2dd4824cf436da305e625e65ec9d1ac7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Checkout_Index), @"mvc.1.0.view", @"/Views/Checkout/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Checkout/Index.cshtml", typeof(AspNetCore.Views_Checkout_Index))]
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
#line 1 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\_ViewImports.cshtml"
using MVCManukauTech;

#line default
#line hidden
#line 2 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\_ViewImports.cshtml"
using MVCManukauTech.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"715ebb4d2dd4824cf436da305e625e65ec9d1ac7", @"/Views/Checkout/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c8c3f1b54521ca6ded33f5c95f0e5a26707cceb", @"/Views/_ViewImports.cshtml")]
    public class Views_Checkout_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVCManukauTech.ViewModels.CheckoutViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "OrderDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
  
    ViewData["Title"] = "Checkout";

#line default
#line hidden
            BeginContext(98, 100, true);
            WriteLiteral("\r\n<h1>Checkout</h1>\r\n\r\n\r\n<script src=\"https://www.paypalobjects.com/api/checkout.js\"></script>\r\n\r\n\r\n");
            EndContext();
#line 13 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(233, 23, false);
#line 15 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(260, 31, true);
            WriteLiteral("    <h3>Shipping Details</h3>\r\n");
            EndContext();
            BeginContext(293, 293, true);
            WriteLiteral(@"    <div class=""form-horizontal"">
        <hr />
        <div class=""form-group"">
            <label for=""CustomerName"" class=""control-label col-md-2"" style=""display:inline"">Name:</label>
            <div class=""col-md-10"">
                <input type=""text"" id=""ShipName"" name=""ShipName""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 586, "\"", 609, 1);
#line 24 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
WriteAttributeValue("", 594, Model.ShipName, 594, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(610, 337, true);
            WriteLiteral(@" style=""display:inline"" required/>
            </div>
        </div>

        <div class=""form-group"">
            <label for=""StreetAddress"" class=""control-label col-md-2"" style=""display:inline"">Street Address:</label>
            <div class=""col-md-10"">
                <input type=""text"" id=""StreetAddress"" name=""StreetAddress""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 947, "\"", 975, 1);
#line 31 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
WriteAttributeValue("", 955, Model.StreetAddress, 955, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(976, 300, true);
            WriteLiteral(@" style=""display:inline"" required/>
            </div>
        </div>

        <div class=""form-group"">
            <label for=""City"" class=""control-label col-md-2"" style=""display:inline"">City:</label>
            <div class=""col-md-10"">
                <input type=""text"" id=""City"" name=""City""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1276, "\"", 1295, 1);
#line 38 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
WriteAttributeValue("", 1284, Model.City, 1284, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1296, 319, true);
            WriteLiteral(@" style=""display:inline"" required/>
            </div>
        </div>

        <div class=""form-group"">
            <label for=""PostCode"" class=""control-label col-md-2"" style=""display:inline"">Postal Code:</label>
            <div class=""col-md-10"">
                <input type=""text"" id=""PostCode"" name=""PostCode""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1615, "\"", 1640, 1);
#line 45 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
WriteAttributeValue("", 1623, Model.PostalCode, 1623, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1641, 175, true);
            WriteLiteral(" style=\"display:inline\" required/>\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <b>Net Total : $");
            EndContext();
            BeginContext(1817, 31, false);
#line 50 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
                           Write(Math.Round(Model.GrossTotal, 2));

#line default
#line hidden
            EndContext();
            BeginContext(1848, 144, true);
            WriteLiteral("</b>\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <b>Discount : $");
            EndContext();
            BeginContext(1993, 29, false);
#line 55 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
                          Write(Math.Round(Model.Discount, 2));

#line default
#line hidden
            EndContext();
            BeginContext(2022, 147, true);
            WriteLiteral("</b>\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <b>Grand total : $");
            EndContext();
            BeginContext(2170, 22, false);
#line 60 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
                             Write(ViewData["GrandTotal"]);

#line default
#line hidden
            EndContext();
            BeginContext(2192, 150, true);
            WriteLiteral("</b>\r\n\r\n                <p></p>\r\n\r\n                <div id=\"paypal-button\"></div>\r\n            </div>\r\n        </div>\r\n\r\n\r\n        <div>\r\n            ");
            EndContext();
            BeginContext(2342, 116, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "715ebb4d2dd4824cf436da305e625e65ec9d1ac710116", async() => {
                BeginContext(2434, 20, true);
                WriteLiteral(" &lt; Return to Cart");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2458, 34, true);
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n    </div>\r\n");
            EndContext();
#line 75 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2495, 123, true);
            WriteLiteral("\r\n    <script>\r\n\r\n        //document.addEventListener(\'contextmenu\', event => event.preventDefault());\r\n         //Paypal\r\n");
            EndContext();
            BeginContext(2710, 923, true);
            WriteLiteral(@"

        paypal.Button.render({
            env: 'sandbox',
            client: {
                sandbox: 'AbNIc71vv_VWq2Rh2YfssLM2sq9lmIVzv9-1qOzssa8-_B-OJ5BfEj5G88YtI1sf6D7kBXxV_34p_16z'
            },
            commit: true, // Show a 'Pay Now' button

            style: {
                label: 'checkout',
                fundingicons: true, // optional
                branding: true, // optional
                size: 'responsive', // small | medium | large | responsive
                shape: 'pill',   // pill | rect
                color: 'gold'   // gold | blue | silve | black
            },

            payment: function (data, actions) {
                return actions.payment.create({
                    payment: {
                        transactions: [
                            {
                                amount: {
                                    total: Number(");
            EndContext();
            BeginContext(3634, 18, false);
#line 107 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
                                             Write(ViewBag.GrandTotal);

#line default
#line hidden
            EndContext();
            BeginContext(3652, 2533, true);
            WriteLiteral(@").toFixed(2),
                                    currency: 'NZD'
                                }
                            }
                        ]
                    },
                    experience: {
                        input_fields: {
                            no_shipping: 1
                        }
                    }
                });
            },

            onAuthorize: function (data, actions) {
                /*
                 * Execute the payment here
                 */
                //location.replace(""checkout/checkoutresult"")

                //  https://stackoverflow.com/questions/45383047/how-to-get-the-transaction-id-using-paypal-express-checkout-integration-client?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa

                return actions.payment.execute().then(function (payment) {

                    var paypalID = payment.transactions[0].related_resources[0].sale.id;

                    var xhttp = new ");
            WriteLiteral(@"XMLHttpRequest();
                    xhttp.open(""GET"", ""/Checkout/PaypalResult?paypalID="" + paypalID, false);
                    xhttp.send();


                    var Res = xhttp.responseText;
                    if (Res == ""Done"") {
                        //sucessful payment
                        UpdateDatabase();                        
                        location.replace(""Checkout/CheckoutResult"");
                    }
                    else {                        
                        alert(""Error"");
                    }
                    
                });
            },

            onCancel: function (data, actions) {
                /*
                 * Buyer cancelled the payment
                 */
                location.replace(""OrderDetails/ShoppingCart"")
            },

            onError: function (err) {
                //NV In case of failed payment
                alert(""Payment unsuccessful"");
            }
    }, '#paypal-button');
");
            WriteLiteral(@"

    function UpdateDatabase() {
        var shipName = document.getElementById(""ShipName"").value;
        var shipAddress = document.getElementById(""StreetAddress"").value + "", "" + document.getElementById(""City"").value
            + "", "" + document.getElementById(""PostCode"").value;

        var xmlhttp = new XMLHttpRequest();
        xmlhttp.open(""GET"", ""/Checkout/CheckoutUpdateDatabase?shipName="" + shipName + ""&shipAddress="" + shipAddress
            + ""&grossTotal="" + ");
            EndContext();
            BeginContext(6186, 16, false);
#line 172 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
                          Write(Model.GrossTotal);

#line default
#line hidden
            EndContext();
            BeginContext(6202, 18, true);
            WriteLiteral(" + \"&discount=\" + ");
            EndContext();
            BeginContext(6221, 14, false);
#line 172 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
                                                             Write(Model.Discount);

#line default
#line hidden
            EndContext();
            BeginContext(6235, 18, true);
            WriteLiteral(" + \"&netTotal=\" + ");
            EndContext();
            BeginContext(6254, 22, false);
#line 172 "C:\Users\Sanket\Desktop\Project\MVCManukauTech\Views\Checkout\Index.cshtml"
                                                                                              Write(ViewData["GrandTotal"]);

#line default
#line hidden
            EndContext();
            BeginContext(6276, 64, true);
            WriteLiteral(", false);\r\n        xmlhttp.send();\r\n    }\r\n\r\n    </script>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVCManukauTech.ViewModels.CheckoutViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
