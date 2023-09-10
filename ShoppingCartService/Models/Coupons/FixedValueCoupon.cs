using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ShoppingCartService.BusinessLogic.Exceptions;
using System;

namespace ShoppingCartService.Models.Coupons
{
    public class FixedValueCoupon : ICoupon
    {
        public string Id { get; }
        public DateTime ExpirationDate { get; }
        public double Value { get; }

        public FixedValueCoupon(string id, DateTime expirationDate, double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Value is negative.");
            }

            Id = id;    
            ExpirationDate = expirationDate.Date;
            Value = value;
        }

        public double CalculateDiscount(double totalCost, double shippingCost)
        {
            if (Value > totalCost)
            {
                throw new InvalidCouponException("Value of coupon is higher than total cost.");
            }

            return Value;
        }
    }
}
