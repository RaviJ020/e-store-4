

using FluentAssertions;
using MongoDB.Driver;
using ShoppingCartService.Config;
using ShoppingCartService.DataAccess;
using ShoppingCartService.Models.Coupons;
using ShoppingCartServiceTests.Builders;
using ShoppingCartServiceTests.Fixtures;
using System;
using Xunit;

namespace ShoppingCartServiceTests.DataAccess
{
    [Collection("Dockerized MongoDB collection")]
    public class CouponRepositoryIntegrationTests : IDisposable
    {
        private readonly ShoppingCartDatabaseSettings _databaseSettings;

        public CouponRepositoryIntegrationTests(DockerMongoFixture fixture)
        {
            _databaseSettings = fixture.GetDatabaseSettings();
        }

        [Fact]
        public void CreateCoupon_HappyPath()
        {
            // Assign
            var coupon = new FixedValueCouponBuilder().WithId(null).Build();
            var repository = new CouponRepository(_databaseSettings);

            // Act
            var result = repository.CreateCoupon(coupon);

            // Assert
            Assert.NotNull(result.Id);
            Assert.IsType<FixedValueCoupon>(result);
            Assert.Equal(coupon.ExpirationDate, result.ExpirationDate);
            Assert.Equal(coupon.Value, ((FixedValueCoupon)result).Value);
        }

        [Fact]
        public void FindById_HappyPath()
        {
            // Assign
            var coupon = new FixedValueCouponBuilder().Build();
            var repository = new CouponRepository(_databaseSettings);
            _ = repository.CreateCoupon(coupon);

            // Act
            var result = repository.FindById(coupon.Id);

            // Assert
            result.Should().BeEquivalentTo(coupon);
        }

        [Fact]
        public void DeleteCoupon_HappPath()
        {
            // Assign
            var coupon = new FixedValueCouponBuilder().Build();
            var repository = new CouponRepository(_databaseSettings);
            _ = repository.CreateCoupon(coupon);

            // Act
            repository.DeleteCoupon(coupon.Id);
            var result = repository.FindById(coupon.Id);

            // Assert
            Assert.Null(result);
        }

        public void Dispose()
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            client.DropDatabase(_databaseSettings.DatabaseName);
        }
    }
}
