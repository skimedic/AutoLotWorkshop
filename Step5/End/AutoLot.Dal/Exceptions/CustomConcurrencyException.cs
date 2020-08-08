// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreConcurrencyException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Exceptions
{
    public class CustomConcurrencyException : CustomException
    {
        public CustomConcurrencyException()
        {
        }

        public CustomConcurrencyException(string message) : base(message)
        {
        }

        public CustomConcurrencyException(string message, DbUpdateConcurrencyException innerException)
            : base(message, innerException)
        {
        }
    }
}