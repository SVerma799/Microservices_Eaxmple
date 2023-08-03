using AutoMapper;
using Mango.Services.Coupons.Api.Models;
using Mango.Services.Coupons.Api.Models.Dto;

namespace Mango.Services.Coupons.Api
{
    /// <summary>
    /// Adding Config for auto mapper which will map my Model to Dto
    /// </summary>
    public class MappingConfig
    {
        /// <summary>
        /// Registers the maps.
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration RegisterMaps()
        {
            /// SV: This is used here to configure the mapping between the CouponDto and Coupon.
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            
            return mappingConfig;
        }
    }
}
