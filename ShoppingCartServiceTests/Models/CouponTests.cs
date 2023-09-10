using ShoppingCartService.BusinessLogic.Exceptions;
using ShoppingCartServiceTests.Builders;
using System;
using Xunit;

namespace ShoppingCartServiceTests.BusinessLogic
{
    public class CouponTests
    {
        [Fact]
        public void FixedValueCoupon_ValueIsNegative_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FixedValueCouponBuilder().WithValue(-0.0001).Build());
        }

        [Theory]
        [InlineData(0.0, 0.0)]
        [InlineData(5.0, 5.0)]
        [InlineData(500.0, 500.0)]
        public void FixedValueCoupon_CalculateDiscount_ReturnsAbsoluteValue(double couponValue, double expectedDiscount)
        {
            // Assign
            var coupon = new FixedValueCouponBuilder().WithValue(couponValue).Build();

            // Act
            double result = coupon.CalculateDiscount(500.0, 50.0);

            // Assert
            Assert.Equal(expectedDiscount, result);
        }

        [Fact]
        public void FixedValueCoupon_CalculateDiscount_TotalIsLowerThanCouponValue_ThrowsException()
        {
            // Assign
            var coupon = new FixedValueCouponBuilder().WithValue(1.000001).Build();

            // Act, Assert
            Assert.Throws<InvalidCouponException>(() => coupon.CalculateDiscount(1, 0.5));
        }

        [Fact]
        public void PercentageCoupon_PercentageMoreThan100_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PercentageCouponBuilder().WithPercentage(100.0001).Build());
        }

        [Fact]
        public void PercentageCoupon_PercentageIsNegative_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PercentageCouponBuilder().WithPercentage(-0.0001).Build());
        }

        [Theory]
        [InlineData(0.0, 0.0)]
        [InlineData(5.0, 5.0)]
        public void FreeShippingCoupon_CalculateDiscount_ReturnsAbsoluteValue(double shippingCost, double expectedDiscount)
        {
            // Assign
            var coupon = new FreeShippingCouponBuilder().Build();

            // Act
            double result = coupon.CalculateDiscount(500.0, shippingCost);

            // Assert
            Assert.Equal(expectedDiscount, result);
        }
    }
}
