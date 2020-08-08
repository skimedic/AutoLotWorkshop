// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreRetryLimitExceededException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace AutoLot.Dal.Exceptions
{
    public class CustomRetryLimitExceededException : CustomException
    {
        public CustomRetryLimitExceededException()
        {
        }

        public CustomRetryLimitExceededException(string message) : base(message)
        {
        }

        public CustomRetryLimitExceededException(string message, RetryLimitExceededException innerException)
            : base(message, innerException)
        {
        }
    }
}