using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace ResourceOwnerFlow
{
    class Program
    {
        private const string ClientSecretKey = "APIKey";
        private const string EndpointKey = "Endpoint";
        private const string ClientIdKey = "ClientId";
        private const string UserNameKey = "UserName";
        private const string PasswordKey = "Password";
        private const string ScopesKey = "Scopes";

        private static string APIKey = ""; 
        private static string Endpoint = "";
        private static string ClientId = "";
        private static string UserName = "";
        private static string Password = "";
        private static string Scopes = "";

        static void Main(string[] args)
        {
            APIKey = ConfigurationManager.AppSettings[ClientSecretKey];
            Endpoint = ConfigurationManager.AppSettings[EndpointKey];
            ClientId = ConfigurationManager.AppSettings[ClientIdKey];
            UserName = ConfigurationManager.AppSettings[UserNameKey];
            Password = ConfigurationManager.AppSettings[PasswordKey];
            Scopes = ConfigurationManager.AppSettings[ScopesKey];

            ResourceOwnerFlow();

            Console.ReadKey();
        }

        private static void RevokeToken(string token, string tokenType)
        {
            Console.WriteLine("Calling revoke  token .. ");
            Console.WriteLine("");
            Console.WriteLine("");

            var client = new HttpClient()
              {
                  BaseAddress = new Uri(Endpoint + "/issue/oidc/revoke")
              };

            var byteArray = Encoding.ASCII.GetBytes("1" + ":" + APIKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var parameter = new Dictionary<string, string>
                {
                    { "token", token},
                    { "token_type_hint", tokenType }
                };

            var response = client.PostAsync("", new FormUrlEncodedContent(parameter)).Result;
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Access token revoked.. ");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void ResourceOwnerFlow()
        {
            Console.WriteLine("Processing Resource owner password flow");
            Console.WriteLine("");
            Console.WriteLine("");
            var client = new OAuth2Client(new Uri(Endpoint + "/issue/oidc/token"), ClientId, APIKey);
            var taks = client.RequestResourceOwnerPasswordAsync(UserName, Password, Scopes);
            taks.Wait(new TimeSpan(1, 0, 0));
            var tokenResponse = taks.Result;

            Console.WriteLine("Access token received .. ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(tokenResponse.AccessToken);

            Console.WriteLine("Calling user info endpoint");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(Endpoint + "/issue/oidc/userinfo")
            };

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
            
            var response = httpClient.GetAsync("").Result;
            response.EnsureSuccessStatusCode();

            var dictionary = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;
            foreach (var pair in dictionary)
            {
                Console.WriteLine(pair.Key + " ----> " + pair.Value);
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Calling refresh token  endpoint");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Task<TokenResponse> refreshTokenResponse = client.RequestRefreshTokenAsync(tokenResponse.RefreshToken);
            refreshTokenResponse.Wait();
            tokenResponse = refreshTokenResponse.Result;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Access token received using refresh token .. ");
            Console.WriteLine("");
            Console.WriteLine(tokenResponse.AccessToken);
            Console.WriteLine("");
            Console.WriteLine("");
            RevokeToken(tokenResponse.AccessToken, "access_token");


            Console.WriteLine("");
        }
    }
}
