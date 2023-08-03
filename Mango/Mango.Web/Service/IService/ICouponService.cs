using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    /// <summary>
    /// ICoupon Service 
    /// </summary>
    public interface ICouponService 
    {
        /// <summary>
        /// Gets the coupon asynchronous.
        /// </summary>
        /// <param name="couponCode">The coupon code.</param>
        /// <returns></returns>
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        /// <summary>
        /// Gets all coupons asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto?> GetAllCouponsAsync();
        /// <summary>
        /// Gets the coupon by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ResponseDto?> GetCouponByIdAsync(Guid id);
        /// <summary>
        /// Creates the coupon asynchronous.
        /// </summary>
        /// <param name="coupon">The coupon.</param>
        /// <returns></returns>
        Task<ResponseDto?> CreateCouponAsync(CouponDto coupon);
        /// <summary>
        /// Updates the coupon asynchronous.
        /// </summary>
        /// <param name="coupon">The coupon.</param>
        /// <returns></returns>
        Task<ResponseDto?> UpdateCouponAsync(CouponDto coupon);
        /// <summary>
        /// Deletes the coupon asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ResponseDto?> DeleteCouponAsync(Guid id);


    }
}
