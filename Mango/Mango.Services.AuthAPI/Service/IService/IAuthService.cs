using Mango.Services.AuthAPI.Models.Dto;

namespace Mango.Services.AuthAPI.Service.IService
{
    /// <summary>
    /// Authentication Service Interface.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registers the specified registration request dto.
        /// </summary>
        /// <param name="registrationRequestDto">The registration request dto.</param>
        /// <returns></returns>
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        /// <summary>
        /// Logins the specified login request dto.
        /// </summary>
        /// <param name="loginRequestDto">The login request dto.</param>
        /// <returns></returns>
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        /// <summary>
        /// Assigns the role.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        Task<bool> AssignRole(string email, string roleName); 
    }
}
