using ShoppingCartService.Models.Coupons;

namespace ShoppingCartService.DataAccess
{
    public interface ICouponRepository
    {
        public ICoupon CreateCoupon(ICoupon coupon);

        public ICoupon FindById(string id);

        public void DeleteCoupon(string id);
    }
}
