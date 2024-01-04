using CodigoBarrasDemo.Interfaces;
using CodigoBarrasDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarrasDemo.Services
{
    public class AuthenticateService : IAuthenticateService
    {

        public async Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel data) 
        {
            Uri RequestUri = new Uri("http://5.161.49.20:9096/AppKepler/api/AuthenticateContollers/AuthenticateUser");
            AuthenticateResponseModel responseData = new AuthenticateResponseModel();
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(data);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<AuthenticateResponseModel>(content);
                dataResponse.isSucces = true;
                responseData = dataResponse;
            }
            else {

                responseData = new AuthenticateResponseModel { 
                    data = null,
                    isSucces = false,
                    message = "Usuario o contraseña incorrectos"
                }; 
            }
            return responseData;
        }

    }
}
