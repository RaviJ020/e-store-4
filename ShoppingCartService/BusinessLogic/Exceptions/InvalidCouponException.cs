namespace ShoppingCartService.BusinessLogic.Exceptions
{
    using System;

    public class InvalidCouponException : Exception
    {
        public InvalidCouponException()
        {
        }

        public InvalidCouponException(string message)
            : base(message)
        {
        }

        public InvalidCouponException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
