using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace ClientCredentialFlow
{
    class Program
    {
        private const string EndpointKey = "Endpoint";
        private const string ClientSecretKey = "ClientSecret";
        private const string ClientIdKey = "ClientId";
        private const string ScopeKey = "Scope";
        private const string ApplicationNameKey = "ApplicationName";
        private const string ScopeApplicationNamePrefix = "http://www.vexiere.com/oauth/app_name/";

        private static string ClientId = "";
        private static string ClientSecret = "";
        private static string Endpoint = "";
        private static string Scope = "";
        private static string ApplicationNameScope = "";

        static void Main(string[] args)
        {

            Endpoint = ConfigurationManager.AppSettings[EndpointKey];
            ClientSecret = ConfigurationManager.AppSettings[ClientSecretKey];
            ClientId = ConfigurationManager.AppSettings[ClientIdKey];

            Scope = ConfigurationManager.AppSettings[ScopeKey];
            ApplicationNameScope = ScopeApplicationNamePrefix + ConfigurationManager.AppSettings[ApplicationNameKey].Replace(' ', '_');

            Scope += ' ' + ApplicationNameScope;

            ClientCredentialFlow();

            Console.ReadKey();
        }


        private static void ClientCredentialFlow()
        {
            Console.WriteLine("Processing client credential flow" + Environment.NewLine);

            var client = new OAuth2Client(new Uri(Endpoint + "/issue/oidc/token"), ClientId, ClientSecret);

            var taks = client.RequestClientCredentialsAsync(Scope);
            taks.Wait();
            var tokenResponse = taks.Result;

            Console.WriteLine("Access token received .. " + Environment.NewLine);

            Console.WriteLine(tokenResponse.AccessToken + Environment.NewLine);


            Console.WriteLine("Calling refresh token endpoint" + Environment.NewLine);


            Task<TokenResponse> refreshTokenResponse = client.RequestRefreshTokenAsync(tokenResponse.RefreshToken);
            refreshTokenResponse.Wait();
            tokenResponse = refreshTokenResponse.Result;

            Console.WriteLine("Access token received using refresh token .. " + Environment.NewLine);

            Console.WriteLine(tokenResponse.AccessToken + Environment.NewLine);

            RevokeToken(tokenResponse.AccessToken, "access_token");
        }

        private static void RevokeToken(string token, string tokenType)
        {
            Console.WriteLine("Calling revoke  token .. " + Environment.NewLine);


            var client = new HttpClient()
            {
                BaseAddress = new Uri(Endpoint + "/issue/oidc/revoke")
            };

            var byteArray = Encoding.ASCII.GetBytes(ClientId + ":" + ClientSecret);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var parameter = new Dictionary<string, string>
                {
                    { "token", token},
                    { "token_type_hint", tokenType }
                };

            var response = client.PostAsync("", new FormUrlEncodedContent(parameter)).Result;
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Access token revoked.. " + Environment.NewLine);
        }
    }
}
