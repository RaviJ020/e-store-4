namespace ShoppingCartService.BusinessLogic.Exceptions
{
    using System;

    public class CouponExpiredException : Exception
    {
        public CouponExpiredException() : base()
        {
        }

        public CouponExpiredException(string message) : base(message)
        {
        }

        public CouponExpiredException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}
