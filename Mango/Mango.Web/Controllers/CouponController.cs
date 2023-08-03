using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    /// <summary>
    /// Coupon Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class CouponController : Controller
    {

        /// <summary>
        /// The coupon service
        /// </summary>
        private readonly ICouponService _couponService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponController"/> class.
        /// </summary>
        /// <param name="couponService">The coupon service.</param>
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        /// <summary>
        /// returns all the coupons.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> couponLists = new();
            ResponseDto? res = await _couponService.GetAllCouponsAsync();
            if (res != null && res.IsSuccess)
                couponLists = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(res.Result));
            else
                TempData["error"] = res?.Message;

            return View(couponLists);
        }

        /// <summary>
        /// Returns the Coupon Create Page.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        /// <summary>
        /// Create the Coupons.
        /// </summary>
        /// <param name="coupon">The coupon.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto coupon)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? res = await _couponService.CreateCouponAsync(coupon);

                if (res != null && res.IsSuccess)
                {
                    TempData["sucess"] = "Coupon added successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                    TempData["error"] = res?.Message;
            }
            return View(coupon);
        }

        /// <summary>
        /// Delete the coupons.
        /// </summary>
        /// <param name="couponId">The coupon identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> CouponDelete(Guid couponId)
        {
            ResponseDto? res = await _couponService.DeleteCouponAsync(couponId);
            if (res != null && res.IsSuccess)
            {
                TempData["sucess"] = "Coupon deleted successfully";
                return RedirectToAction("CouponIndex");
            }
            else
                TempData["error"] = res?.Message;

            return View();
        }
    }
}
