using System;
using System.Collections.Generic;
using System.Web;

namespace Tavisca.Vexiere.WcfHarness
{
    public class Constant
    {
        public static readonly string LOGIN_SUCCESSFUL = "Logged In Successfully!!";
        public static readonly string LOGIN_ERROR = "Invalid Credentials.";
        public static readonly string SELECTION_ERROR = "Select SERVICE,METHOD and SAMPLE first.";
        public static readonly string SERVICE_ERROR = "Unexpected Error Occured.";
        public static readonly string INVALID_XML_ERROR = "Improper request xml Error.";
        public static readonly string INVALID_URL_ERROR = "Invalid Url Error.";
        public static readonly string INVALID_REQUEST = "Error occured while parsing request";
        public static readonly string INVALID_USERNAME = "Invalid User Name";
        public static readonly string INVALID_PASSWORD = "Invalid Password";
        public static readonly string INVALID_APIKEY = "Invalid APIKey";
        public static readonly string INVALID_ROOT_ID = "Invalid Root Id";
        public static readonly string INVALID_ACCESS_TOKEN_END_POINT = "Invalid Access Token End Point";
        public static readonly string OPERATION_SUCCESSFUL = "Operation Successful.";
    }
}