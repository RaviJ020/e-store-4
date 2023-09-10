using ShoppingCartService.Controllers.Models;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models.Coupons;
using System;

namespace ShoppingCartService.Controllers.Extensions
{
    public static class CreateCouponDtoExtensions
    {
        public static ICoupon ToModel(this CreateCouponDto dto)
        {
            return dto.CouponType switch
            {
                CouponType.FixedValueCoupon => new FixedValueCoupon(null, dto.ExpirationDate, dto.Amount.Value),
                CouponType.PercentageCoupon => new PercentageCoupon(null, dto.ExpirationDate, dto.Amount.Value),
                CouponType.FreeShipping => new FreeShippingCoupon(null, dto.ExpirationDate),
                _ => throw new InvalidOperationException($"Unsupported coupon type: {dto.CouponType}")
            };
        }
    }
}
