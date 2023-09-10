using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartServiceTests.Builders
{
    using ShoppingCartService.Controllers.Models;
    using ShoppingCartService.DataAccess.Entities;
    using System;

    public class CreateCouponDtoBuilder
    {
        private DateTime _expirationDate = new DateTime(2024, 1, 1);
        private double? _amount = 10;
        private CouponType _couponType = CouponType.FixedValueCoupon;

        public CreateCouponDtoBuilder WithExpirationDate(DateTime expirationDate)
        {
            _expirationDate = expirationDate;
            return this;
        }

        public CreateCouponDtoBuilder WithAmount(double? amount)
        {
            _amount = amount;
            return this;
        }

        public CreateCouponDtoBuilder WithCouponType(CouponType couponType)
        {
            _couponType = couponType;
            return this;
        }

        public CreateCouponDto Build()
        {
            return new CreateCouponDto
            {
                ExpirationDate = _expirationDate,
                Amount = _amount,
                CouponType = _couponType
            };
        }
    }

}
