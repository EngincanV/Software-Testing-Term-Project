#pragma checksum "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aada2792988c674e6161b6de2444f787917d364c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Test_Exam), @"mvc.1.0.view", @"/Views/Test/Exam.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Test/Exam.cshtml", typeof(AspNetCore.Views_Test_Exam))]
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
#line 1 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\_ViewImports.cshtml"
using QuestionAnswer.WebUI;

#line default
#line hidden
#line 2 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\_ViewImports.cshtml"
using QuestionAnswer.WebUI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aada2792988c674e6161b6de2444f787917d364c", @"/Views/Test/Exam.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22ccd22d233497e21b9b6dd730bfed7106c43d3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Test_Exam : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ExamViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
  
    ViewData["Title"] = "Exam";

#line default
#line hidden
            BeginContext(64, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aada2792988c674e6161b6de2444f787917d364c4721", async() => {
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
            BeginContext(115, 3410, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        $(""#instantQuestion"").text(1);
        var questionNo = 1;

        var minuteCounter = 60;
        var secondCounter = 0;
        var minute = $(""#minute"");
        var seconds = $(""#seconds"");

        minute.text(minuteCounter);
        seconds.text(""0"" + secondCounter);

        setInterval(function () {
            setTimeout(function () {
                if (secondCounter === 0) {
                    minuteCounter--;
                    secondCounter = 60;
                }
                secondCounter--;
                secondCounter >= 0 && secondCounter <= 9
                    ? (seconds.text(""0"" + secondCounter))
                    : (seconds.text(secondCounter));

                minuteCounter >= 0 && minuteCounter <= 9
                    ? (minute.text(""0"" + minuteCounter))
                    : (minute.text(minuteCounter));

                if (secondCounter === 0 && minuteCounter === 0) ");
            WriteLiteral(@"{
                    clearTimeout();
                    clearInterval();
                }
            }, 1000);
        }, 1000);

        var tempAnswer = """";
        $(""#first"").click(function () { tempAnswer = $(""#firstContent"").val() });
        $(""#second"").click(function () { tempAnswer = $(""#secondContent"").val() });
        $(""#third"").click(function () { tempAnswer = $(""#thirdContent"").val() });
        $(""#fourth"").click(function () { tempAnswer = $(""#fourthContent"").val() });

        $(""#submittedForm"").click(function () {
            questionNo++;

            var id = $(""#questionId"").text();
            $(""#studentAnswer"").val(tempAnswer);
            console.log(id);

            var studentAnswer = $(""#studentAnswer"").val();
            console.log(studentAnswer);

            var jsonData = JSON.stringify({
                AnswerContent: studentAnswer,
                QuestionId: id
            });
            console.log(jsonData);

            $.ajax({
    ");
            WriteLiteral(@"            type: ""POST"",
                url: ""/Test/Exam"",
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: jsonData,
                success: function (data) {
                    if (data == ""testResult"") {
                        window.location.href = ""/Test/ExamResult"";
                    }
                    else if (data !== """") {
                        $(""#first"").text(""A) "" + data.firstContent);
                        $(""#firstContent"").val(data.firstContent);

                        $(""#second"").text(""B) "" + data.secondContent);
                        $(""#secondContent"").val(data.secondContent);

                        $(""#third"").text(""C) "" + data.thirdContent);
                        $(""#thirdContent"").val(data.thirdContent);

                        $(""#fourth"").text(""D) "" + data.fourthContent);
                        $(""#fourthContent"").val(data.fourthContent);

                        $(""#que");
            WriteLiteral(@"stionId"").text(data.id);
                        $(""#questionImg"").attr(""src"", data.questionImage);

                        $(""#instantQuestion"").text(questionNo);
                    }
                    else
                        window.location.reload();
                }
            });
        });
    });
</script>
");
            EndContext();
#line 99 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
 if (ViewData["notExistQuestions"] == null)
{

#line default
#line hidden
            BeginContext(3573, 227, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-9\">\r\n            <div class=\"card mb-3 text-center\" style=\"width: 70%; margin-left: auto; margin-right: auto\">\r\n                <p style=\"display: none !important\" id=\"questionId\">");
            EndContext();
            BeginContext(3801, 17, false);
#line 104 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
                                                               Write(Model.Question.Id);

#line default
#line hidden
            EndContext();
            BeginContext(3818, 26, true);
            WriteLiteral("</p>\r\n                <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3844, "\"", 3879, 1);
#line 105 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
WriteAttributeValue("", 3850, Model.Question.QuestionImage, 3850, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3880, 95, true);
            WriteLiteral(" class=\"card-img-top\" style=\"width: 80%; height: 80%\" id=\"questionImg\"><br />\r\n                ");
            EndContext();
            BeginContext(3975, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aada2792988c674e6161b6de2444f787917d364c10969", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 106 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Question.QuestionImage);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4031, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(4049, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aada2792988c674e6161b6de2444f787917d364c12755", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 107 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4115, 243, true);
            WriteLiteral("\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">\r\n                        <div class=\"form-group ml-5 mr-5\">\r\n                            <button type=\"button\" id=\"first\" class=\"btn btn-info btn-block\">A) ");
            EndContext();
            BeginContext(4359, 27, false);
#line 111 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
                                                                                          Write(Model.Question.FirstContent);

#line default
#line hidden
            EndContext();
            BeginContext(4386, 131, true);
            WriteLiteral("</button>\r\n                            <input type=\"hidden\" id=\"studentAnswer\" />\r\n                            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4517, "\"", 4553, 1);
#line 113 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
WriteAttributeValue("", 4525, Model.Question.FirstContent, 4525, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4554, 211, true);
            WriteLiteral(" id=\"firstContent\" />\r\n                        </div>\r\n                        <div class=\"form-group ml-5 mr-5\">\r\n                            <button type=\"button\" id=\"second\" class=\"btn btn-info btn-block\">B) ");
            EndContext();
            BeginContext(4766, 28, false);
#line 116 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
                                                                                           Write(Model.Question.SecondContent);

#line default
#line hidden
            EndContext();
            BeginContext(4794, 59, true);
            WriteLiteral("</button>\r\n                            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4853, "\"", 4890, 1);
#line 117 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
WriteAttributeValue("", 4861, Model.Question.SecondContent, 4861, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4891, 211, true);
            WriteLiteral(" id=\"secondContent\" />\r\n                        </div>\r\n                        <div class=\"form-group ml-5 mr-5\">\r\n                            <button type=\"button\" id=\"third\" class=\"btn btn-info btn-block\">C) ");
            EndContext();
            BeginContext(5103, 27, false);
#line 120 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
                                                                                          Write(Model.Question.ThirdContent);

#line default
#line hidden
            EndContext();
            BeginContext(5130, 59, true);
            WriteLiteral("</button>\r\n                            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5189, "\"", 5225, 1);
#line 121 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
WriteAttributeValue("", 5197, Model.Question.ThirdContent, 5197, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5226, 211, true);
            WriteLiteral(" id=\"thirdContent\" />\r\n                        </div>\r\n                        <div class=\"form-group ml-5 mr-5\">\r\n                            <button type=\"button\" id=\"fourth\" class=\"btn btn-info btn-block\">D) ");
            EndContext();
            BeginContext(5438, 28, false);
#line 124 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
                                                                                           Write(Model.Question.FourthContent);

#line default
#line hidden
            EndContext();
            BeginContext(5466, 59, true);
            WriteLiteral("</button>\r\n                            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5525, "\"", 5562, 1);
#line 125 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
WriteAttributeValue("", 5533, Model.Question.FourthContent, 5533, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5563, 691, true);
            WriteLiteral(@" id=""fourthContent"" />
                        </div>
                    </h5><br />
                    <input type=""submit"" class=""btn btn-success btn-block"" id=""submittedForm"" value=""Cevabı Onayla"" />
                </div>
            </div>
        </div>
        <div class=""col-3"">
            <div class=""card"">
                <div class=""card-body btn btn-warning text-center"" style=""font-weight: bold"">
                    <span id=""minute""></span>:<span id=""seconds""></span>
                    <hr style=""width: 100% !important"" />
                    <span id=""instantQuestion""></span> / 50
                </div>
            </div>
        </div>
    </div>
");
            EndContext();
#line 142 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(6266, 71, true);
            WriteLiteral("    <div class=\"alert alert-danger text-center justify-content-center\">");
            EndContext();
            BeginContext(6338, 29, false);
#line 145 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
                                                                  Write(ViewData["notExistQuestions"]);

#line default
#line hidden
            EndContext();
            BeginContext(6367, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 146 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
}

#line default
#line hidden
            BeginContext(6379, 27, false);
#line 147 "C:\Users\engin\OneDrive\Masaüstü\QuestionAnswer\QuestionAnswer.WebUI\Views\Test\Exam.cshtml"
Write(ViewData["trueAnswerCount"]);

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExamViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
