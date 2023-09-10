using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace ShoppingCartService.Models.Coupons
{
    public class FreeShippingCoupon : ICoupon
    {
        public string Id { get; }
        public DateTime ExpirationDate { get; }

        public FreeShippingCoupon(string id, DateTime experationDate)
        {
            ExpirationDate = experationDate.Date;
        }

        public double CalculateDiscount(double totalCost, double shippingCost)
        {
            return shippingCost;
        }
    }
}
