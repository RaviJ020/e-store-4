using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.Config;
using ShoppingCartService.Controllers;
using ShoppingCartService.Controllers.Models;
using ShoppingCartService.DataAccess;
using ShoppingCartServiceTests.Builders;
using ShoppingCartServiceTests.Fixtures;
using System;
using Xunit;

namespace ShoppingCartServiceTests.Controllers
{
    [Collection("Dockerized MongoDB collection")]
    public class CouponControllerIntegrationTests : IDisposable
    {
        private readonly ShoppingCartDatabaseSettings _databaseSettings;

        public CouponControllerIntegrationTests(DockerMongoFixture fixture)
        {
            _databaseSettings = fixture.GetDatabaseSettings();
        }

        [Fact]
        public void CreateCoupon_HappyPath()
        {
            // Assign
            var createCouponDto = new CreateCouponDtoBuilder().Build();
            var controller = CreateController();

            // Act
            var result = (CreatedAtRouteResult)controller.Create(createCouponDto).Result;
            var value = (CouponDto)result.Value;

            // Assert
            Assert.NotNull(value.Id);
            Assert.Equal(createCouponDto.ExpirationDate, value.ExpirationDate);
            Assert.Equal(createCouponDto.Amount, value.Amount);
            Assert.Equal(createCouponDto.CouponType, value.CouponType);
        }

        [Fact]
        public void FindById_HappyPath()
        {
            // Assign
            var createCouponDto = new CreateCouponDtoBuilder().Build();
            var controller = CreateController();
            var createResult = (CreatedAtRouteResult)controller.Create(createCouponDto).Result;
            var createValue = (CouponDto)createResult.Value;

            // Act
            var findResult = controller.FindById(createValue.Id);
            var findValue = findResult.Value;

            // Assert
            Assert.Equal(createCouponDto.ExpirationDate, findValue.ExpirationDate);
            Assert.Equal(createCouponDto.Amount, findValue.Amount);
            Assert.Equal(createCouponDto.CouponType, findValue.CouponType);
        }

        [Fact]
        public void DeleteCoupon_HappPath()
        {
            // Assign
            var createCouponDto = new CreateCouponDtoBuilder().Build();
            var controller = CreateController();
            var createdResult = (CreatedAtRouteResult)controller.Create(createCouponDto).Result;
            var createdValue = (CouponDto)createdResult.Value;

            // Act
            controller.DeleteCoupon(createdValue.Id);
            var findResult = controller.FindById(createdValue.Id);

            // Assert
            Assert.IsType<NotFoundResult>(findResult.Result);
        }

        private CouponController CreateController()
        {
            var couponRepository = new CouponRepository(_databaseSettings);
            var couponManager = new CouponManager(couponRepository);
            return new CouponController(couponManager);
        }

        public void Dispose()
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            client.DropDatabase(_databaseSettings.DatabaseName);
        }
    }
}
