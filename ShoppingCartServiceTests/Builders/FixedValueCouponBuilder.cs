using ShoppingCartService.Models.Coupons;
using System;

namespace ShoppingCartServiceTests.Builders
{
    public class FixedValueCouponBuilder
    {
        private string _id = "46bbe0662cbfc13d50eabc56";
        private DateTime _expirationDate = new DateTime(2024, 1, 1);
        private double _value = 1.00;

        public FixedValueCouponBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public FixedValueCouponBuilder WithExpirationDate(DateTime expirationDate)
        {
            _expirationDate = expirationDate;
            return this;
        }

        public FixedValueCouponBuilder WithValue(double value)
        {
            _value = value;
            return this;
        }

        public FixedValueCoupon Build()
        {
            return new FixedValueCoupon(_id, _expirationDate, _value);
        }
    }
}
