using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace ShoppingCartService.Models.Coupons
{
    public class PercentageCoupon : ICoupon
    {
        public string Id { get; }
        public DateTime ExpirationDate { get; }
        public double Percentage { get; }

        public PercentageCoupon(string id, DateTime experationDate, double percentage)
        {
            if (percentage < 0)
            {
                throw new ArgumentException("Value is negative.");
            }

            if (percentage > 100)
            {
                throw new ArgumentException("Value is larger than 100.");
            }

            ExpirationDate = experationDate.Date;
            Percentage = percentage;
        }

        public double CalculateDiscount(double totalCost, double shippingCost)
        {
            throw new NotImplementedException();
        }
    }
}
