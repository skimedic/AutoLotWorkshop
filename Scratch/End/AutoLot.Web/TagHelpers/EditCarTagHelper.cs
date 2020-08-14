// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - EditCarTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/08/10
// See License.txt for more information
// ==================================

using AutoLot.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AutoLot.Web.TagHelpers
{
    public class EditCarTagHelper : CarLinkTagHelperBase
    {
        public EditCarTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory) 
            : base(contextAccessor, urlHelperFactory) { }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            BuildContent(output,nameof(CarsController.Edit),"text-warning","Edit","edit");
        }
    }
}