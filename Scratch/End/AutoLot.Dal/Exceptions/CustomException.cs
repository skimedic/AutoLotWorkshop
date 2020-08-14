// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;

namespace AutoLot.Dal.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}