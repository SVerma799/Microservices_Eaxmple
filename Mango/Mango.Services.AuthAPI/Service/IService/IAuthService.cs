using Mango.Services.AuthAPI.Models.Dto;

namespace Mango.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        /// <summary>
        /// Registers the specified registration request dto.
        /// </summary>
        /// <param name="registrationRequestDto">The registration request dto.</param>
        /// <returns></returns>
        Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
        /// <summary>
        /// Logins the specified login request dto.
        /// </summary>
        /// <param name="loginRequestDto">The login request dto.</param>
        /// <returns></returns>
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
