using ShoppingCartService.BusinessLogic.Exceptions;
using ShoppingCartService.Controllers.Models;
using ShoppingCartService.DataAccess;
using ShoppingCartService.Models.Coupons;
using System;

namespace ShoppingCartService.BusinessLogic
{
    public class CouponManager : ICouponManager
    {
        private readonly ICouponRepository _repository;
        public CouponManager(ICouponRepository repository)
        {
            _repository = repository;
        }

        public ICoupon CreateCoupon(ICoupon coupon)
        {
            return _repository.CreateCoupon(coupon);
        }

        public ICoupon FindById(string id)
        {
            return _repository.FindById(id);
        }

        public void DeleteCoupon(string id)
        {
            var coupon = _repository.FindById(id);
            if (coupon == null)
            {
                throw new CouponNotFoundException();
            }

            _repository.DeleteCoupon(id);
        }
    }
}
