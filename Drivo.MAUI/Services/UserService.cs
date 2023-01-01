using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drivo.MAUI.Services
{
    public class UserService
    {
        public UserService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<SignInResponse> SignInAsync(SignInRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync("/Users/SignIn", request, JsonSerializerOptions);
            
            return await response.Content.ReadFromJsonAsync<SignInResponse>(JsonSerializerOptions);
        }

        public async Task<UserEntity> GetUserByUserName()
        {
            return await HttpClient.GetFromJsonAsync<UserEntity>("/Users", JsonSerializerOptions);
        }
        public async Task SignOutAsync()
        {
            SecureStorage.RemoveAll();

            await Shell.Current.GoToAsync("//SignInPage");
        }
    }
}
