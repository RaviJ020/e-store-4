using ShoppingCartService.Models.Coupons;
using System;

namespace ShoppingCartServiceTests.Builders
{
    public class PercentageCouponBuilder
    {
        private string _id = "2fdbb69e0111372fde1e7883";
        private DateTime _expirationDate = new DateTime(2024, 1, 1);
        private double _percentage = 1.00;

        public PercentageCouponBuilder WithExpirationDate(DateTime expirationDate)
        {
            _expirationDate = expirationDate;
            return this;
        }

        public PercentageCouponBuilder WithPercentage(double percentage)
        {
            _percentage = percentage;
            return this;
        }

        public PercentageCoupon Build()
        {
            return new PercentageCoupon(_id, _expirationDate, _percentage);
        }
    }
}
