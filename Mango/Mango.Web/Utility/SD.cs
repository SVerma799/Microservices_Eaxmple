using System.ComponentModel;

namespace Mango.Web.Utility
{
    /// <summary>
    /// Static  Detail class for the Request Enums
    /// </summary>
    public class SD
    {
        /// <summary>
        /// Gets or sets the coupon base API.
        /// </summary>
        /// <value>
        /// The coupon base API.
        /// </value>
        public static string CouponBaseApi { get; set; }

        /// <summary>
        /// Api Type for Request.
        /// </summary>
        public enum APIType
        {
            /// <summary>
            /// The get
            /// </summary>
            [Description("GET")]
            GET,
            /// <summary>
            /// The post
            /// </summary>
            [Description("POST")]
            POST,
            /// <summary>
            /// The put
            /// </summary>
            [Description("PUT")]
            PUT,
            /// <summary>
            /// The delete
            /// </summary>
            [Description ("DELETE")]
            DELETE,
        }
    }
}
