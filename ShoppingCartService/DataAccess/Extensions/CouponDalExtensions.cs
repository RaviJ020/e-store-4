using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models.Coupons;
using System;

namespace ShoppingCartService.DataAccess.Extensions
{
    using System;

    public static class CouponDalExtensions
    {
        public static ICoupon ToModel(this CouponDal dal)
        {
            if (dal == null)
            {
                return null;
            }

            return dal.CouponType switch
            {
                CouponType.FixedValueCoupon => new FixedValueCoupon(dal.Id, dal.ExpirationDate, dal.Amount.Value),
                CouponType.PercentageCoupon => new PercentageCoupon(dal.Id, dal.ExpirationDate, dal.Amount.Value),
                CouponType.FreeShipping => new FreeShippingCoupon(dal.Id, dal.ExpirationDate),
                _ => throw new InvalidOperationException($"Unsupported coupon type: {dal.CouponType}")
            };
        }
    }
}

