using ShoppingCartService.Controllers.Models;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models.Coupons;
using System;

namespace ShoppingCartService.Controllers.Extensions
{
    public static class CouponExtensions
    {
        public static CouponDto ToDto(this ICoupon model)
        {
            return model switch
            {
                FixedValueCoupon fixedValue => CreateCouponDto(model, fixedValue.Value, CouponType.FixedValueCoupon),
                PercentageCoupon percentage => CreateCouponDto(model, percentage.Percentage, CouponType.PercentageCoupon),
                FreeShippingCoupon => CreateCouponDto(model, null, CouponType.FreeShipping),
                _ => throw new InvalidOperationException("Unsupported coupon type.")
            };
        }

        private static CouponDto CreateCouponDto(ICoupon model, double? amount, CouponType type)
        {
            return new CouponDto
            {
                Id = model.Id,
                ExpirationDate = model.ExpirationDate,
                Amount = amount,
                CouponType = type
            };
        }
    }
}
