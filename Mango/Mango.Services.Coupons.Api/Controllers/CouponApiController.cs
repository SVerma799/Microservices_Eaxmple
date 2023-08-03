using AutoMapper;
using Mango.Services.Coupons.Api.Data;
using Mango.Services.Coupons.Api.Models;
using Mango.Services.Coupons.Api.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.Coupons.Api.Controllers
{
    /// <summary>
    /// Api Controller from Coupon.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {

        // SV: We have tried to do the Code-based Approach using the Entity Framework here.
        // SV: Secondly after doing tall the migration stuff. We have added the DbContext here as a result of Dependancy Injection which ASP.Net Core supports internally.
        /// <summary>
        /// The application database context
        /// </summary>
        private readonly AppDbContext _appDbContext;
        private ResponseDto _response;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponApiController"/> class.
        /// </summary>
        /// <param name="appDbContext">The application database context.</param>
        public CouponApiController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _response = new();
        }

        /// <summary>
        /// Gets the coupons list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _appDbContext.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        /// <summary>
        /// Gets the specified Coupon.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public object Get(Guid id)
        {
            try
            {
                Coupon coupon = _appDbContext.Coupons.First(x => x.CouponId.Equals(id));
                _response.Result = _mapper.Map<CouponDto>(coupon);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon obj = _appDbContext.Coupons.First(s => s.CouponCode.Equals(code));
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<CouponDto>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;

            }
        }

        /// <summary>
        /// Creates the specified coupon.
        /// </summary>
        /// <param name="coupon">The coupon.</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseDto Create([FromBody] CouponDto coupon)
        {
            try
            {
                // Create the CouponObj from the Coupon got from the Context.
                Coupon obj = _mapper.Map<Coupon>(coupon);
                _appDbContext.Coupons.Add(obj);
                _appDbContext.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        /// <summary>
        /// Updates the specified coupon.
        /// </summary>
        /// <param name="coupon">The coupon.</param>
        /// <returns></returns>
        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto coupon)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(coupon);
                _appDbContext.Coupons.Update(obj);
                _appDbContext.SaveChanges();
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<CouponDto>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        /// <summary>
        /// Deletes the specified coupon from DB.
        /// </summary>
        /// <param name="couponId">The coupon identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public ResponseDto Delete([FromBody] Guid couponId)
        {
            try
            {
                Coupon coupon = _appDbContext.Coupons.First(s => s.CouponId.Equals(couponId));
                _appDbContext.Coupons.Remove(coupon);
                _appDbContext.SaveChanges();
                _response.IsSuccess = true;
                _response.Message = "Deleted Successfully.";
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }
    }
}
