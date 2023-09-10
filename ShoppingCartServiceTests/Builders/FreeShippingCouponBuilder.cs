using ShoppingCartService.Models.Coupons;
using System;

namespace ShoppingCartServiceTests.Builders
{
    internal class FreeShippingCouponBuilder
    {
        private string _id = "3c50f9943db8415c44a84c7a";
        private DateTime _expirationDate = new DateTime(2024, 1, 1);

        public FreeShippingCouponBuilder WithExpirationDate(DateTime expirationDate)
        {
            _expirationDate = expirationDate;
            return this;
        }

        public FreeShippingCoupon Build()
        {
            return new FreeShippingCoupon(_id, _expirationDate);
        }
    }
}
