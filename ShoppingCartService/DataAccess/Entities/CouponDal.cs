using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace ShoppingCartService.DataAccess.Entities
{
    public class CouponDal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ExpirationDate { get; set; }

        public double? Amount { get; set; }

        public CouponType CouponType { get; set; }
    }
}
