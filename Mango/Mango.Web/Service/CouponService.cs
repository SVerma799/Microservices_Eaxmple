using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    /// <summary>
    /// Coupon Service imlpementing IcouponService
    /// </summary>
    /// <seealso cref="Mango.Web.Service.IService.ICouponService" />
    public class CouponService : ICouponService
    {
        /// <summary>
        /// The base service Instance called using Constructor Dependancy Injection.
        /// </summary>
        readonly IBaseService _baseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponService"/> class.
        /// </summary>
        /// <param name="baseService">The base service.</param>
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Creates the coupon asynchronous.
        /// </summary>
        /// <param name="coupon">The coupon.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto coupon)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.APIType.POST,
                Url = SD.CouponBaseApi,
                Data = coupon
            });
        }

        /// <summary>
        /// Deletes the coupon asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ResponseDto?> DeleteCouponAsync(Guid id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.APIType.DELETE,
                Url = SD.CouponBaseApi ,
                Data = id
            });
        }

        /// <summary>
        /// Gets all coupons asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.APIType.GET,
                Url = SD.CouponBaseApi
            });
        }

        /// <summary>
        /// Gets the coupon asynchronous.
        /// </summary>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.APIType.GET,
                Url = SD.CouponBaseApi + "GetByCode/" + couponCode
            });
        }

        /// <summary>
        /// Gets the coupon by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ResponseDto?> GetCouponByIdAsync(Guid id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.APIType.GET,
                Url = SD.CouponBaseApi + id
            });
        }

        /// <summary>
        /// Updates the coupon asynchronous.
        /// </summary>
        /// <param name="coupon">The coupon.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto coupon)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.APIType.PUT,
                Url = SD.CouponBaseApi,
                Data = coupon
            });
        }
    }
}
