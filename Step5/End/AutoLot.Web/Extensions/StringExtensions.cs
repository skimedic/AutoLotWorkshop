// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - StringExtensions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/08/10
// See License.txt for more information
// ==================================

using System;

namespace AutoLot.Web.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveController(this string original)
            => original.Replace("Controller", "", StringComparison.OrdinalIgnoreCase);
    }
}