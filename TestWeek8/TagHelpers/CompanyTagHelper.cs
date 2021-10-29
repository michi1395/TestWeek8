using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeek8.Models;

namespace TestWeek8.MVC.TagHelpers
{
    public class CompanyTagHelper : TagHelper
    {
        public Organization Organization { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("itemscope itemtype", "http://schema.org/Organization");
            output.Content.SetHtmlContent(
            $@"<span itemprop=""name"">{Organization.Name}</span><br/>
            <address itemprop=""address"">
            <span itemprop=""streetAddress"">{Organization.StreetAddress}</span><br/>
            <span itemprop=""addressLocality"">{Organization.AddressLocality}</span><br/>
            <span itemprop=""streetRegion"">{Organization.AddressRegion}</span><br/>
            <span itemprop=""postalCode"">{Organization.PostalCode}</span>");
            output.Attributes.SetAttribute("class", "row col-5");
        }


    }
}
