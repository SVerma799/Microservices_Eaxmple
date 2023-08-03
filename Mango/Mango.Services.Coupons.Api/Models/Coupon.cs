using System.ComponentModel.DataAnnotations;

namespace Mango.Services.Coupons.Api.Models
{
    /// <summary>
    /// Coupon Class
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// Gets or sets the coupon identifier.
        /// </summary>
        /// <value>
        /// The coupon identifier.
        /// </value>
        [Key]
        public Guid CouponId { get; set; }
        /// <summary>
        /// Gets or sets the coupon code.
        /// </summary>
        /// <value>
        /// The coupon code.
        /// </value>
        [Required]
        public string CouponCode { get; set; }
        /// <summary>
        /// Gets or sets the discount amont.
        /// </summary>
        /// <value>
        /// The discount amont.
        /// </value>
        [Required]
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
