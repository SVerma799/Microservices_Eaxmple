using System.ComponentModel.DataAnnotations;

namespace Mango.Services.Coupons.Api.Models.Dto
{
    /// <summary>
    /// Coupon Dto to be used as an Api Response.
    /// </summary>
    public class CouponDto
    {
        /// <summary>
        /// Gets or sets the coupon identifier.
        /// </summary>
        /// <value>
        /// The coupon identifier.
        /// </value>
        public Guid CouponId { get; set; }
        /// <summary>
        /// Gets or sets the coupon code.
        /// </summary>
        /// <value>
        /// The coupon code.
        /// </value>
        public string CouponCode { get; set; }
        /// <summary>
        /// Gets or sets the discount amont.
        /// </summary>
        /// <value>
        /// The discount amont.
        /// </value>
        public double DiscountAmont { get; set; }
        /// <summary>
        /// Gets or sets the minimum amount.
        /// </summary>
        /// <value>
        /// The minimum amount.
        /// </value>
        public int MinAmount { get; set; }
        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>
        /// The last updated.
        /// </value>
        public DateTime LastUpdated { get; set; }
    }
}
