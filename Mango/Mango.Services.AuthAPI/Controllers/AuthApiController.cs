using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    /// <summary>
    /// Authorization Api Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/auth")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        /// <summary>
        /// The authentication service
        /// </summary>
        private readonly IAuthService _authService;
        protected ResponseDto _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthApiController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        public AuthApiController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

        /// <summary>
        /// Registers the specified registration request dto.
        /// </summary>
        /// <param name="registrationRequestDto">The registration request dto.</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationRequestDto registrationRequestDto)
        {
            var errorMessage = await _authService.Register(registrationRequestDto);
            if(!string.IsNullOrEmpty(errorMessage)) {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            else
                return Ok(_response);
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if(loginResponse == null)
                return BadRequest(_response);
           
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }

        /// <summary>
        /// Assigns the role.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if(!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered.";
                return BadRequest(_response);   
            }
            return Ok(_response);
        }
    }
}
