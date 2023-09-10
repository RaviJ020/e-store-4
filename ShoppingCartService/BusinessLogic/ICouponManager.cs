using ShoppingCartService.Models.Coupons;

namespace ShoppingCartService.BusinessLogic
{
    public interface ICouponManager
    {
        ICoupon CreateCoupon(ICoupon coupon);
        ICoupon FindById(string id);
        void DeleteCoupon(string id);
    }
}
