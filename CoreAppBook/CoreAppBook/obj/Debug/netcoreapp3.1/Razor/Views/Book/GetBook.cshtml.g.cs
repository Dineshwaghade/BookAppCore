#pragma checksum "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "060652c0128fc2a2e33a6547ea7b3d3fa26b8711"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_GetBook), @"mvc.1.0.view", @"/Views/Book/GetBook.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"060652c0128fc2a2e33a6547ea7b3d3fa26b8711", @"/Views/Book/GetBook.cshtml")]
    public class Views_Book_GetBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoreAppBook.Models.BookModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
  
    ViewData["Title"] = "GetBook";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <h3>Books Details</h3>
    <div class=""row"">
        <div class=""col-md-6"">

            <div id=""carouselExampleIndicators"" class=""carousel slide"" data-bs-ride=""carousel"">
                <div class=""carousel-indicators"">
                    <button type=""button"" data-bs-target=""#carouselExampleIndicators"" data-bs-slide-to=""0"" class=""active"" aria-current=""true"" aria-label=""Slide 1""></button>
                    <button type=""button"" data-bs-target=""#carouselExampleIndicators"" data-bs-slide-to=""1"" aria-label=""Slide 2""></button>
                    <button type=""button"" data-bs-target=""#carouselExampleIndicators"" data-bs-slide-to=""2"" aria-label=""Slide 3""></button>
                </div>
                <div class=""carousel-inner"">
                    <div class=""carousel-item active"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "060652c0128fc2a2e33a6547ea7b3d3fa26b87115454", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <div class=""carousel-item"">
                        <img src=""..."" class=""d-block w-100"" alt=""..."">
                    </div>
                    <div class=""carousel-item"">
                        <img src=""..."" class=""d-block w-100"" alt=""..."">
                    </div>
                </div>
                <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#carouselExampleIndicators"" data-bs-slide=""prev"">
                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                    <span class=""visually-hidden"">Previous</span>
                </button>
                <button class=""carousel-control-next"" type=""button"" data-bs-target=""#carouselExampleIndicators"" data-bs-slide=""next"">
                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                    <span class=""visually-hidden"">Next</span>
                </button>
            </div>

        </div>
");
            WriteLiteral("        <div class=\"col-md-6\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    <h1>");
#nullable restore
#line 43 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
                   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </div>\r\n            </div>\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12 text-primary\">\r\n                    <span >By ");
#nullable restore
#line 48 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
                         Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n            </div>\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    <p class=\"text-muted\">");
#nullable restore
#line 53 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
                                     Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-4"">
                    <a class=""btn btn-outline-primary"" href=""#"">Read Now</a>
                </div>
            </div>
            <hr />
            <div class=""row"">
                <div class=""col-md-12"">
                    <ul class=""list-group"">
                        <li class=""list-group-item""><span class=""font-weight-bold"">Category-</span>");
#nullable restore
#line 65 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
                                                                                              Write(Model.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        <li class=\"list-group-item\"><span class=\"font-weight-bold\">Total Pages-</span>");
#nullable restore
#line 66 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
                                                                                                 Write(Model.ToTalPages);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        <li class=\"list-group-item\"><span class=\"font-weight-bold\">Language-</span>");
#nullable restore
#line 67 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
                                                                                              Write(Model.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"py-5 bg-light\">\r\n\r\n    <div class=\"container\">\r\n        <h3>Similar Books</h3>\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 82 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
             for(int i=0;i<5;i++)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-md-4"">
                    <div class=""card mb-4 shadow-sm"">
                        <svg class=""card-img-top"" width=""100%"" height=""225""></svg>
                        <div class=""card-body"">
                            <h3 class=""card-title"">");
#nullable restore
#line 89 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
                                              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <p class=\"card-text\">");
#nullable restore
#line 90 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
                                            Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <div class=\"d-flex justify-content-between align-items-center\">\r\n                                <div class=\"btn-group\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 4153, "\"", 4183, 2);
            WriteAttributeValue("", 4160, "/book/getbook/", 4160, 14, true);
#nullable restore
#line 93 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
WriteAttributeValue("", 4174, Model.Id, 4174, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-secondary\">View Details</a>\r\n                                </div>\r\n                                <small class=\"text-muted\">");
#nullable restore
#line 95 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"
                                                     Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n");
#nullable restore
#line 103 "D:\Practice\CorePractice\CoreGitProject\CoreAppBook\CoreAppBook\Views\Book\GetBook.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoreAppBook.Models.BookModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
