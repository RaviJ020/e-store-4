using ShoppingCartService.BusinessLogic.Exceptions;
using ShoppingCartService.Controllers.Models;
using ShoppingCartService.Models.Coupons;
using System;

namespace ShoppingCartService.BusinessLogic
{
    public class CouponEngine
    {
        private readonly Func<DateTime> _getNow;

        public CouponEngine(Func<DateTime> getNow) 
        {
            _getNow = getNow;
        }

        public double CalculateDiscount(CheckoutDto checkoutDto, ICoupon coupon)
        {
            if (coupon == null)
            {
                return 0;
            }

            if (coupon.ExpirationDate < _getNow()) 
            {
                throw new CouponExpiredException("Expiration date of coupon is before today.");
            }

            return coupon.CalculateDiscount(checkoutDto.Total, checkoutDto.ShippingCost);
        }
    }
}
