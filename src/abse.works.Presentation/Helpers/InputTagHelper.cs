using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace abse.works.Web.Helpers
{
    [HtmlTargetElement("text-input")]
    public class TextInputTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName("name")]
        public string Name { get; set; }

        [HtmlAttributeName("asp-for")]
        public ModelExpression AspFor { get; set; }

        public string Label { get; set; }
        public string Placeholder { get; set; } = "";
        public string Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string propertyName = AspFor?.Name ?? Name;
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Należy określić 'asp-for' lub 'name'.");
            }

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            var label = new TagBuilder("label");
            label.Attributes.Add("for", propertyName);
            label.InnerHtml.Append(Label);
            output.Content.AppendHtml(label);

            var input = new TagBuilder("input");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("class", "form-control");
            input.Attributes.Add("id", propertyName);
            input.Attributes.Add("name", propertyName);

            if (!string.IsNullOrEmpty(Placeholder))
            {
                input.Attributes.Add("placeholder", Placeholder);
            }

            string inputValue = Value ?? AspFor?.Model?.ToString();
            if (!string.IsNullOrEmpty(inputValue))
            {
                input.Attributes.Add("value", inputValue);
            }

            output.Content.AppendHtml(input);

            var validation = new TagBuilder("span");
            validation.Attributes.Add("class", "text-danger field-validation-valid");
            validation.Attributes.Add("data-valmsg-for", propertyName);
            validation.Attributes.Add("data-valmsg-replace", "true");

            var modelState = ViewContext.ViewData.ModelState;
            if (modelState.TryGetValue(propertyName, out var entry) && entry.Errors.Count > 0)
            {
                validation.InnerHtml.Append(entry.Errors[0].ErrorMessage);
            }

            output.Content.AppendHtml(validation);
        }
    }

    [HtmlTargetElement("select-input")]
    public class SelectInputTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression AspFor { get; set; }

        [HtmlAttributeName("name")]
        public string Name { get; set; }

        [HtmlAttributeName("selected-value")]
        public string SelectedValue { get; set; }

        public string Label { get; set; }
        public List<SelectListItem> Items { get; set; } = new List<SelectListItem>();

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string propertyName = AspFor?.Name ?? Name;
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Należy określić wartość dla 'asp-for' lub 'name'.");
            }

            string selectedValue = !string.IsNullOrEmpty(SelectedValue) ? SelectedValue : AspFor?.Model?.ToString();

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            var labelTag = new TagBuilder("label");
            labelTag.Attributes.Add("for", propertyName);
            labelTag.InnerHtml.Append(Label);
            output.Content.AppendHtml(labelTag);

            var select = new TagBuilder("select");
            select.Attributes.Add("class", "form-control");
            select.Attributes.Add("id", propertyName);
            select.Attributes.Add("name", propertyName);

            foreach (var item in Items)
            {
                var option = new TagBuilder("option");
                option.Attributes.Add("value", item.Value);
                option.InnerHtml.Append(item.Text);

                if (item.Value == selectedValue)
                {
                    option.Attributes.Add("selected", "selected");
                }

                select.InnerHtml.AppendHtml(option);
            }

            output.Content.AppendHtml(select);

            var validation = new TagBuilder("span");
            validation.Attributes.Add("class", "text-danger field-validation-valid");
            validation.Attributes.Add("data-valmsg-for", propertyName);
            validation.Attributes.Add("data-valmsg-replace", "true");

            var modelState = ViewContext.ViewData.ModelState;
            if (modelState.ContainsKey(propertyName) && modelState[propertyName].Errors.Count > 0)
            {
                var errorMessage = modelState[propertyName].Errors.First().ErrorMessage;
                validation.InnerHtml.Append(errorMessage);
            }

            output.Content.AppendHtml(validation);
        }
    }


    [HtmlTargetElement("date-picker")]
    public class DatePickerTagHelper : TagHelper
    {
        public ModelExpression AspFor { get; set; }
        public string Label { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            var label = new TagBuilder("label");
            label.Attributes.Add("for", AspFor.Name);
            label.InnerHtml.Append(Label);
            output.Content.AppendHtml(label);

            var input = new TagBuilder("input");
            input.Attributes.Add("type", "date");
            input.Attributes.Add("class", "form-control");
            input.Attributes.Add("id", AspFor.Name);
            input.Attributes.Add("name", AspFor.Name);

            if (AspFor.Model is DateTime date && date != default)
            {
                input.Attributes.Add("value", date.ToString("yyyy-MM-dd"));
            }

            output.Content.AppendHtml(input);

            var validation = new TagBuilder("span");
            validation.Attributes.Add("class", "text-danger field-validation-valid");
            validation.Attributes.Add("data-valmsg-for", AspFor.Name);
            validation.Attributes.Add("data-valmsg-replace", "true");

            var modelState = ViewContext.ViewData.ModelState;
            if (modelState.ContainsKey(AspFor.Name) && modelState[AspFor.Name].Errors.Count > 0)
            {
                var errorMessage = modelState[AspFor.Name].Errors.First().ErrorMessage;
                validation.InnerHtml.Append(errorMessage);
            }

            output.Content.AppendHtml(validation);
        }
    }

    [HtmlTargetElement("toggle-switch")]
    public class ToggleSwitchTagHelper : TagHelper
    {
        public ModelExpression AspFor { get; set; }
        public string Label { get; set; }

        [HtmlAttributeName("id")]
        public string Id { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group"); 

            if (Label != null)
            {
                var label = new TagBuilder("label");
                label.Attributes.Add("for", AspFor.Name);
                label.InnerHtml.Append(Label);
                output.Content.AppendHtml(label);
            }

            var switchContainer = new TagBuilder("div");
            switchContainer.AddCssClass("form-check form-switch");
            switchContainer.Attributes.Add("style", "margin-left:10px; margin-top:7px;");

            var input = new TagBuilder("input");
            input.Attributes.Add("type", "checkbox");
            input.Attributes.Add("class", "form-check-input from-control toggle-switch");
            input.Attributes.Add("role", "switch");
            input.Attributes.Add("id", AspFor.Name);
            input.Attributes.Add("name", AspFor.Name);
            input.Attributes.Add("value", "true");
            input.Attributes.Add("style", "transform: scale(1.5); ;padding-left:1.5em");
            input.Attributes.Add("data-target", $"#{Id}Fields");

            if (AspFor.Model is bool value && value)
            {
                input.Attributes.Add("checked", "checked");
            }
            switchContainer.InnerHtml.AppendHtml(input);

            var hiddenInput = new TagBuilder("input");
            hiddenInput.Attributes.Add("type", "hidden");
            hiddenInput.Attributes.Add("name", AspFor.Name);
            hiddenInput.Attributes.Add("value", "false");
            switchContainer.InnerHtml.AppendHtml(hiddenInput);

            output.Content.AppendHtml(switchContainer);
        }
    }
}
