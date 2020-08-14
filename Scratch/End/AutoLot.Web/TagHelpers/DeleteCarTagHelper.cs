// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - DeleteCarTagHelper.cs
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
    public class DeleteCarTagHelper : CarLinkTagHelperBase
    {
        public DeleteCarTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory) 
            : base(contextAccessor, urlHelperFactory) { }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //    <a asp-action="Details" asp-route-id="@item.Id" class="text-info">Details <i class="fas fa-info-circle"></i></a>&nbsp;&nbsp;|&nbsp;&nbsp;
            BuildContent(output,nameof(CarsController.Delete),"text-danger","Delete","trash");
        }
    }
}