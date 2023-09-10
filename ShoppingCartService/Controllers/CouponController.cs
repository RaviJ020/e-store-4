using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.BusinessLogic.Exceptions;
using ShoppingCartService.Controllers.Extensions;
using ShoppingCartService.Controllers.Models;
using System;

namespace ShoppingCartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponManager _couponManager;

        public CouponController(ICouponManager couponManager)
        {
            _couponManager = couponManager;
        }

        /// <summary>
        /// Create a new coupon
        /// </summary>
        [HttpPost]
        public ActionResult<CouponDto> Create([FromBody] CreateCouponDto createCouponDto)
        {
            var result = _couponManager.CreateCoupon(createCouponDto.ToModel()).ToDto();

            return CreatedAtRoute("GetCoupon", new { id = result.Id }, result);

        }

        /// <summary>
        /// Get coupon by id
        /// </summary>
        /// <param name="id">Coupon id</param>
        [HttpGet("{id:length(24)}", Name = "GetCoupon")]
        public ActionResult<CouponDto> FindById(string id)
        {
            var coupon = _couponManager.FindById(id);
            if (coupon == null)
            {
                return NotFound();
            }

            return coupon.ToDto();
        }

        /// <summary>
        /// Remove coupon
        /// </summary>
        /// <param name="id">Coupon id</param>
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteCoupon(string id)
        {
            try
            {
                _couponManager.DeleteCoupon(id);

                return Ok();
            }
            catch (CouponNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
