using ShoppingCartService.DataAccess.Entities;
using System;

namespace ShoppingCartService.Controllers.Models
{
    public class CouponDto
    {
        public string Id { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double? Amount { get; set; }

        public CouponType CouponType { get; set; }
    }
}
