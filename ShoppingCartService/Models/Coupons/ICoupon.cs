using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace ShoppingCartService.Models.Coupons
{
    public interface ICoupon
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; }
        public DateTime ExpirationDate { get; }
        public double CalculateDiscount(double totalCost, double shippingCost);
    }
}
