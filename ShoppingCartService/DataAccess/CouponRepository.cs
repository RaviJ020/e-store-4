using MongoDB.Driver;
using ShoppingCartService.Config;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.DataAccess.Extensions;
using ShoppingCartService.DataAccess.Extensions.ShoppingCartService.DataAccess.Extensions;
using ShoppingCartService.Models.Coupons;

namespace ShoppingCartService.DataAccess
{
    public class CouponRepository : ICouponRepository
    {
        private readonly IMongoCollection<CouponDal> _coupons;

        public CouponRepository(IShoppingCartDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _coupons = database.GetCollection<CouponDal>(settings.CollectionName);
        }

        public ICoupon CreateCoupon(ICoupon coupon)
        {
            var dal = coupon.ToDal();
            _coupons.InsertOne(dal);

            return dal.ToModel();
        }

        public void DeleteCoupon(string id)
        {
            _coupons.DeleteOne(x => x.Id == id);
        }

        public ICoupon FindById(string id)
        {
            return _coupons.Find(x => x.Id == id).SingleOrDefault().ToModel();
        }
    }
}
