using DotNetCoreIdentity.Mvc.TagHelpers.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace DotNetCoreIdentity.Mvc.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }

        //public override void Process(
        //    TagHelperContext context,
        //    TagHelperOutput output)
        //{
        //    output.TagName = "a";    // Replaces <email> with <a> tag
        //    output.Attributes.SetAttribute("href", $"mailto:{MailTo}");
        //    output.Content.SetContent(MailTo);
        //}

        public async override Task ProcessAsync(
            TagHelperContext context,
            TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent();
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
    [HtmlTargetElement(Attributes = nameof(Condition))]
    public class ConditionTagHelper : TagHelper
    {
        public bool Condition { get; set; }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            if (!Condition)
            {
                output.SuppressOutput();
            }
        }
    }
    [HtmlTargetElement(Attributes = "bold")]
    [HtmlTargetElement("bold")]
    public class BoldTagHelper : TagHelper
    {
        [HtmlAttributeName("my-style")]
        public MyStyle MyStyle { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("bold");
            output.PreContent.SetHtmlContent("<strong>");
            output.PostContent.SetHtmlContent("</strong>");
            output.Attributes
                .SetAttribute("style", $"color: {MyStyle.Color}; font-size: {MyStyle.FontSize}; font-family: {MyStyle.FontFamily};");
        }
    }
}
