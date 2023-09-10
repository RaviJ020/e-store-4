using ShoppingCartService.BusinessLogic;
using ShoppingCartService.BusinessLogic.Exceptions;
using ShoppingCartServiceTests.Builders;
using System;
using Xunit;

namespace ShoppingCartServiceTests.BusinessLogic
{
    public class CouponEngineUnitTests
    {
        [Fact]
        public void CalculateDiscount_NullCoupon_Returns0()
        {
            // Assign
            Func<DateTime> getNow = () => new DateTime(2023, 1, 1);
            var checkout = new CheckoutDtoBuilder().Build();
            var engine = new CouponEngine(getNow);

            // Act
            double result = engine.CalculateDiscount(checkout, null);

            // Assert
            Assert.Equal(0.0, result);
        }

        [Fact]
        public void CalculateDiscount_ExpiredCoupon_ThrowsException()
        {
            // Assign
            Func<DateTime> getNow = () => new DateTime(2023, 1, 1);
            var expirationDate = new DateTime(2022, 12, 31);
            
            var checkout = new CheckoutDtoBuilder().Build();
            var coupon = new FixedValueCouponBuilder().WithExpirationDate(expirationDate).Build();
            var engine = new CouponEngine(getNow);

            // Act, Assert
            Assert.Throws<CouponExpiredException>(() => engine.CalculateDiscount(checkout, coupon));
        }
    }
}
