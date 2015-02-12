using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using Tavisca.Vexiere.DotNetOpenAuth.VexiereClient.Extension;
using Tavisca.Vexiere.DotNetOpenAuth.VexiereClient.Models;
//using Tavisca.Vexiere.DotNetOpenAuth.VexiereOAuth2;

namespace Tavisca.Vexiere.DotNetOpenAuth.VexiereClient
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
            OAuthWebSecurity.RegisterClient(new VexiereOAuth2Client(ConfigurationManager.AppSettings["clientId"], ConfigurationManager.AppSettings["clientSecret"], ConfigurationManager.AppSettings["scope"]), "Vexiere", null);
        }
    }
}
