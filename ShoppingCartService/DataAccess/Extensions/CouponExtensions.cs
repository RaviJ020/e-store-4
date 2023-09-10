using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models.Coupons;
using System;
using static MongoDB.Driver.WriteConcern;

namespace ShoppingCartService.DataAccess.Extensions
{
    using System;

    namespace ShoppingCartService.DataAccess.Extensions
    {
        public static class CouponExtensions
        {
            public static CouponDal ToDal(this ICoupon model)
            {
                return model switch
                {
                    FixedValueCoupon fixedValue => CreateCouponDal(model, fixedValue.Value, CouponType.FixedValueCoupon),
                    PercentageCoupon percentage => CreateCouponDal(model, percentage.Percentage, CouponType.PercentageCoupon),
                    FreeShippingCoupon => CreateCouponDal(model, null, CouponType.FreeShipping),
                    _ => throw new InvalidOperationException("Unsupported coupon type.")
                };
            }

            private static CouponDal CreateCouponDal(ICoupon model, double? amount, CouponType type)
            {
                return new CouponDal
                {
                    Id = model.Id,
                    ExpirationDate = model.ExpirationDate,
                    Amount = amount,
                    CouponType = type
                };
            }
        }
    }

}
