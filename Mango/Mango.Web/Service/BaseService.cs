using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Mango.Web.Service
{
    /// <summary>
    /// Base Service class to send the HTTP Request.
    /// </summary>
    /// <seealso cref="Mango.Web.Service.IService.IBaseService" />
    public class BaseService : IBaseService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        // SV: Earlier we use to inject the normal HTTP Client  as a dependancy Injection.
        // Newer version of .Net they have moved from this to IHttpClient factory.
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Sends the asynchronous.
        /// </summary>
        /// <param name="requestDto">The request dto.</param>
        /// <returns></returns>
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoApi");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                //token

                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");


                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case Utility.SD.APIType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case Utility.SD.APIType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Utility.SD.APIType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Utility.SD.APIType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                }

                apiResponse = await client.SendAsync(message);


                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Unauthorized:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unauthorized"
                        };
                    case HttpStatusCode.Forbidden:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Forbidden"
                        };
                    case HttpStatusCode.InternalServerError:
                        return new() { Message = "Error", IsSuccess = false };

                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto();
                dto.IsSuccess = false;
                dto.Message = ex.Message;
                return dto;
            }


        }
    }
}
