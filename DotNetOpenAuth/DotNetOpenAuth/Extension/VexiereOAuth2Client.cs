using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using DotNetOpenAuth.AspNet;
using Newtonsoft.Json.Linq;

namespace Tavisca.Vexiere.DotNetOpenAuth.VexiereClient.Extension
{
    public class VexiereOAuth2Client : IAuthenticationClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _scope;

        private readonly string _baseUrl;
        private readonly string _tokenUrl;
        private readonly string _userinfoUrl;

        private string idToken;

        public VexiereOAuth2Client(string clientId, string clientSecret, string scope)
        {
            this._clientId = clientId;
            this._clientSecret = clientSecret;
            this._scope = scope;
            this._baseUrl = ConfigurationManager.AppSettings["authorize"];
            this._tokenUrl = ConfigurationManager.AppSettings["token"];
            this._userinfoUrl = ConfigurationManager.AppSettings["userInfo"];
        }

        public string ProviderName
        {
            get { return "Vexiere"; }
        }

        public void RequestAuthentication(HttpContextBase context, Uri returnUrl)
        {
            string url = _baseUrl + "?client_id=" + _clientId + "&redirect_uri=" + HttpUtility.UrlEncode(returnUrl.ToString()) + "&scope=" + HttpUtility.UrlEncode(_scope) + "&response_type=code&realm=vexieredb";
            context.Response.Redirect(url);
        }

        public AuthenticationResult VerifyAuthentication(HttpContextBase context)
        {
            string code = context.Request.QueryString["code"];

            if (context.Request.Url != null)
            {
                string rawUrl = context.Request.Url.ToString();
                //From this we need to remove code portion
                rawUrl = Regex.Replace(rawUrl, "&code=[^&]*", "");
                rawUrl = Regex.Replace(rawUrl, "&session_state=[^&]*", "");
                IDictionary<string, string> userData = GetUserData(code, rawUrl);

                if (userData == null)
                    return new AuthenticationResult(false, ProviderName, null, null, null);

                string id = userData["id"];
                string username = userData["userName"];
                userData.Remove("id");
                userData.Remove("userName");

                var extraData = new Dictionary<string, string>();
                AuthenticationResult result = new AuthenticationResult(true, ProviderName, id, username, userData);
                return result;
            }
            return null;
        }

        private IDictionary<string, string> GetUserData(string accessCode, string redirectUri)
        {

            string token = QueryAccessToken(new Uri(_tokenUrl), redirectUri, accessCode);
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }
            var userData = GetUserData(token);
            return userData;
        }



        public static Dictionary<string, string> GetUserInfoClaimsAsync(Uri userInfoEndpoint, string accessToken)
        {
            ServicePointManager
.ServerCertificateValidationCallback +=
(sender, cert, chain, sslPolicyErrors) => true;
            var httpClient = new HttpClient
            {
                BaseAddress = userInfoEndpoint
            };

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = httpClient.GetAsync("").Result;
            response.EnsureSuccessStatusCode();

            var dictionary = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;


            return dictionary;
        }

        private IDictionary<string, string> GetUserData(string accessToken)
        {


            var userData = new Dictionary<string, string>();
            var userClaims = GetUserInfoClaimsAsync(new Uri(_userinfoUrl),
                accessToken);

            userData.Add("id", userClaims.FirstOrDefault(item => item.Key.Equals("http://vexier.tavisca.com/claims/vexierUserName")).Value);
            userData.Add("userName", userClaims.FirstOrDefault(item => item.Key.Equals("http://vexier.tavisca.com/claims/vexierUserName")).Value);
            userData.Add("firstName", userClaims.FirstOrDefault(item => item.Key.Equals("http://vexier.tavisca.com/claims/vexierUserFirstName")).Value);
            userData.Add("lastName", userClaims.FirstOrDefault(item => item.Key.Equals("http://vexier.tavisca.com/claims/vexierUserLastName")).Value);
            userData.Add("role", userClaims.FirstOrDefault(item => item.Key.Equals("http://vexier.tavisca.com/claims/vexierUserRole")).Value);
            userData.Add("oAuthProvider", userClaims.FirstOrDefault(item => item.Key.Equals("http://vexier.tavisca.com/claims/oAuthProvider")).Value);
            userData.Add("oAuthAccessToken", userClaims.FirstOrDefault(item => item.Key.Equals("http://vexier.tavisca.com/claims/oAuthAccessToken")).Value);
            userData.Add("vexiereToken", userClaims.FirstOrDefault(item => item.Key.Equals("http://vexier.tavisca.com/claims/vexierToken")).Value);
            userData.Add("idToken", idToken);

            return userData;
        }

        public string QueryAccessToken(Uri tokenEndpoint, string redirectUri, string code)
        {
            ServicePointManager
.ServerCertificateValidationCallback +=
(sender, cert, chain, sslPolicyErrors) => true;
            var client = new HttpClient
            {
                BaseAddress = tokenEndpoint
            };


            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
                string.Format("{0}:{1}", this._clientId, this._clientSecret))));


            var parameter = new Dictionary<string, string>
                {
                    { "grant_type", "authorization_code" },
                    { "code", code },
                    { "redirect_uri", redirectUri }
                };

            var response = client.PostAsync("", new FormUrlEncodedContent(parameter)).Result;
            response.EnsureSuccessStatusCode();

            var json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            dynamic data = json.ToObject<object>();
            idToken = data.id_token.Value;
            return data.access_token.Value;

        }



        private static readonly string[] UriRfc3986CharsToEscape = new[] { "!", "*", "'", "(", ")" };
        private static string EscapeUriDataStringRfc3986(string value)
        {
            StringBuilder escaped = new StringBuilder(Uri.EscapeDataString(value));

            // Upgrade the escaping to RFC 3986, if necessary.
            for (int i = 0; i < UriRfc3986CharsToEscape.Length; i++)
            {
                escaped.Replace(UriRfc3986CharsToEscape[i], Uri.HexEscape(UriRfc3986CharsToEscape[i][0]));
            }

            // Return the fully-RFC3986-escaped string.
            return escaped.ToString();
        }

        private static string CreateQueryString(IEnumerable<KeyValuePair<string, string>> args)
        {
            if (!args.Any())
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder(args.Count() * 10);

            foreach (var p in args)
            {
                sb.Append(EscapeUriDataStringRfc3986(p.Key));
                sb.Append('=');
                sb.Append(EscapeUriDataStringRfc3986(p.Value));
                sb.Append('&');
            }
            sb.Length--; // remove trailing &

            return sb.ToString();
        }
    }
}
