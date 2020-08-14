// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - CarDetailsTagHelper.cs
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
    public class CarDetailsTagHelper : CarLinkTagHelperBase
    {
        public CarDetailsTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory) 
            : base(contextAccessor, urlHelperFactory) { }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            BuildContent(output, nameof(CarsController.Details), "text-info", "Details", "info-circle");
        }
    }
}