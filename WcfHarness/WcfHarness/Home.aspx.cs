using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Thinktecture.IdentityModel.Clients;

namespace Tavisca.Vexiere.WcfHarness
{
    public partial class Home : System.Web.UI.Page
    {

        #region Services
        private List<string> serviceList = new List<string>()
        {
             "AccessPattern",   
             "APIKey",
             "AuthorizationGrant",
            "Organization",
            "User",
            "UserGroup",
            "Application",
            "Directory",
            "DirectoryType",
            "Role",
            "Scope",
            "Permission",                 
            "OpenIdConnectClient",
            "Hierarchy",
            "Info",
            "Identity"
        };
        #endregion

        #region Authorization Grant
        private List<string> authorizationGrantOperations = new List<string>()
        {
            "GetAuthorizationGrants",
            "DeleteAuthorizationGrant",
        };
        private List<string> getAuthorizationGrantsSamples = new List<string>()
        {
            "GetAuthorizationGrants"
        };
        private List<string> deleteAuthorizationGrantSamples = new List<string>()
        {
            "DeleteAuthorizationGrant_SoftDelete",
            "DeleteAuthorizationGrant_HardDelete"
        };
        #endregion

        #region Access Pattern
        private List<string> accessPatternOperations = new List<string>()
        {
            "RegisterAccessPattern",
            "UpdateAccessPattern",
            "DeleteAccessPattern",
            "GetAccessPattern",
            "ResolveApplication"
        };
        private List<string> registerAccessPatternSamples = new List<string>()
        {
            "RegisterAccessPattern"
        };
        private List<string> updateAccessPatternSamples = new List<string>()
        {
            "UpdateAccessPattern"
        };
        private List<string> deleteAccessPatternSamples = new List<string>()
        {
            "DeleteAccessPattern"
        };
        private List<string> getAccessPatternSamples = new List<string>()
        {
            "GetAccessPattern"
        };
        private List<string> resolveApplicationSamples = new List<string>()
        {
            "ResolveApplication_ByUrl",
            "ResolveApplication_ByOrganizationCode"
        };
        #endregion

        #region APIKey
        private List<string> apikeyOperations = new List<string>()
        {
            "CreateAPIKey",
            "DeleteAPIKey",
            "UpdateAPIKey",
            "GetAPIKeys",
            "ManageAPIKeyRoles",
            "GetAPIKeyRoles"
        };
        private List<string> createAPIKeySamples = new List<string>()
        {
            "CreateAPIKey"
        };
        private List<string> updateAPIKeySamples = new List<string>()
        {
            "UpdateAPIKey"
        };
        private List<string> deleteAPIKeySamples = new List<string>()
        {
            "DeleteAPIKey"
        };
        private List<string> getAPIKeySamples = new List<string>()
        {
            "GetAPIKeys"
        };
        private List<string> manageAPIKeyRoleSamples = new List<string>()
        {
            "ManageAPIKeyRoles"
        };
        private List<string> getAPIKeyRolesSamples = new List<string>()
        {
            "GetAPIKeyRoles"
        };


        #endregion

        #region Application
        private List<string> applicationOperations = new List<string>()
        {
            "CreateApplication",
            "DeleteApplication",
            "UpdateApplication",
            "GetApplications"
        };
        private List<string> createApplicationSamples = new List<string>()
        {
            "CreateApplication"
        };
        private List<string> updateApplicationSamples = new List<string>()
        {
            "UpdateApplication"
        };
        private List<string> deleteApplicationSamples = new List<string>()
        {
            "DeleteApplication_HardDelete",
             "DeleteApplication_SoftDelete"
        };
        private List<string> getApplicationSamples = new List<string>()
        {
            "GetApplications_ById",
            "GetApplications_ByName"
        };

        #endregion

        #region AuditLog
        //private List<string> auditLogOperations = new List<string>()
        //{
        //    "GetPreviousModifiedState"
        //};

        //private List<string> getPreviousModifiedStateSamples = new List<string>()
        //{
        //    "GetPreviousModifiedState"
        //};
        #endregion

        #region Organization
        private List<string> organizationOperations = new List<string>()
        {
            "CreateOrganization",
            "DeleteOrganization",
            "UpdateOrganization",
            "GetOrganizations"
        };
        private List<string> createOrganizationSamples = new List<string>()
        {
            "CreateOrganization"
        };
        private List<string> updateOrganizationSamples = new List<string>()
        {
            "UpdateOrganization"
        };
        private List<string> deleteOrganizationSamples = new List<string>()
        {
            "DeleteOrganization_HardDelete",
             "DeleteOrganization_SoftDelete"
        };
        private List<string> getOrganizationSamples = new List<string>()
        {
            "GetOrganizations_ById",
            "GetOrganizations_ByName"
        };

        #endregion

        #region User
        private List<string> userOperations = new List<string>()
        {
            "CreateUser",
            "DeleteUser",
            "UpdateUser",
            "GetUsers",
            "ManageUserRoles",
            "GetUserRoles"

        };
        private List<string> createUserSamples = new List<string>()
        {
            "CreateUser"
        };
        private List<string> updateUserSamples = new List<string>()
        {
            "UpdateUser"
        };
        private List<string> deleteUserSamples = new List<string>()
        {
            "DeleteUser_HardDelete",
             "DeleteUser_SoftDelete"
        };
        private List<string> getUserSamples = new List<string>()
        {
            "GetUsers_ById",
            "GetUsers_ByName",
            "GetUsers_ByUserToken"
        };
        private List<string> manageUserRolesSamples = new List<string>()
        {
            "ManageUserRoles"
        };
        private List<string> getUserRolesSamples = new List<string>()
        {
            "GetUserRoles"
        };
        #endregion

        #region Directory
        private List<string> directoryOperations = new List<string>()
        {
            "CreateDirectory",
            "DeleteDirectory",
            "UpdateDirectory",
            "GetDirectories"
        };
        private List<string> createDirectorySamples = new List<string>()
        {
            "CreateDirectory"
        };
        private List<string> updateDirectorySamples = new List<string>()
        {
            "UpdateDirectory"
        };
        private List<string> deleteDirectorySamples = new List<string>()
        {
            "DeleteDirectory_HardDelete",
             "DeleteDirectory_SoftDelete"
        };
        private List<string> getDirectorySamples = new List<string>()
        {
            "GetDirectories_ById",
            "GetDirectories_ByName"
        };

        #endregion

        #region DirectoryType
        private List<string> directoryTypeOperations = new List<string>()
        {
            "CreateDirectoryType",
            "DeleteDirectoryType",
            "UpdateDirectoryType",
            "GetDirectoryTypes"
        };
        private List<string> createDirectoryTypeSamples = new List<string>()
        {
            "CreateDirectoryType"
        };
        private List<string> updateDirectoryTypeSamples = new List<string>()
        {
            "UpdateDirectoryType"
        };
        private List<string> deleteDirectoryTypeSamples = new List<string>()
        {
            "DeleteDirectoryType_HardDelete",
             "DeleteDirectoryType_SoftDelete"
        };
        private List<string> getDirectoryTypeSamples = new List<string>()
        {
            "GetDirectoryTypes_ById",
            "GetDirectoryTypes_ByName"
        };

        #endregion

        #region Identity
        private List<string> identityOperations = new List<string>()
        {
            "ResetPassword",
            "GenerateOTP",
            "ChangePassword"
        };

        private List<string> resetPasswordSample = new List<string>()
        {
            "ResetPassword"
        };

        private List<string> generateOTPSamples = new List<string>()
        {

            "GenerateOTP_By_SecurityAnswerBasedRq",
            "GenerateOTP_By_UserIdentifier_BasedRq"
        };

        private List<string> changePasswordSamples = new List<string>()
        {

            "ChangePassword_ByUserId"
        };
        #endregion

        #region UserGroup
        private List<string> userGroupOperations = new List<string>()
        {
            "CreateUserGroup",
            "DeleteUserGroup",
            "UpdateUserGroup",
            "GetUserGroups",
            "ManageUserGroups",
            "ManageUserGroupRoles",
            "GetUserGroupRoles"
        };
        private List<string> createUserGroupSamples = new List<string>()
        {
            "CreateUserGroup"
        };
        private List<string> updateUserGroupSamples = new List<string>()
        {
            "UpdateUserGroup"
        };
        private List<string> deleteUserGroupSamples = new List<string>()
        {
            "DeleteUserGroup_HardDelete",
             "DeleteUserGroup_SoftDelete"
        };
        private List<string> getUserGroupSamples = new List<string>()
        {
            "GetUserGroups_ById",
            "GetUserGroups_ByName",
            "GetUserGroups_ByUserToken"
        };
        private List<string> manageUserGroupsSamples = new List<string>()
        {
            "ManageUserGroups"
        };
        private List<string> manageUserGroupRolesSamples = new List<string>()
        {
            "ManageUserGroupRoles"
        };
        private List<string> getUserGroupRolesSamples = new List<string>()
        {
            "GetUserGroupRoles"
        };
        #endregion

        #region Role
        private List<string> roleOperations = new List<string>()
        {
            "CreateRole",
            "DeleteRole",
            "UpdateRole",
            "GetRoles",
            "ManageRoleScopes",
            "GetRoleScopes",
            "ManageRoleMappings",
            "GetRoleMappings"
        };
        private List<string> createRoleSamples = new List<string>()
        {
            "CreateRole"
        };
        private List<string> updateRoleSamples = new List<string>()
        {
            "UpdateRole"
        };
        private List<string> deleteRoleSamples = new List<string>()
        {
            "DeleteRole_HardDelete",
             "DeleteRole_SoftDelete"
        };
        private List<string> getRoleSamples = new List<string>()
        {
            "GetRoles",
        };
        private List<string> manageRoleScopesSamples = new List<string>()
        {
            "ManageRoleScopes"
        };
        private List<string> getRoleScopesSamples = new List<string>()
        {
            "GetRoleScopes"
        };
        private List<string> manageRoleMappingsSamples = new List<string>()
        {
            "ManageRoleMappings"
        };
        private List<string> getRoleMappingsSamples = new List<string>()
        {
            "GetRoleMappings"
        };
        #endregion

        #region Permission
        private List<string> permissionOperations = new List<string>()
        {
            "CreatePermission",
            "DeletePermission",
            "UpdatePermission",
            "GetPermissions"
        };
        private List<string> createPermissionSamples = new List<string>()
        {
            "CreatePermission"
        };
        private List<string> updatePermissionSamples = new List<string>()
        {
            "UpdatePermission"
        };
        private List<string> deletePermissionSamples = new List<string>()
        {
            "DeletePermission_HardDelete",
             "DeletePermission_SoftDelete"
        };
        private List<string> getPermissionSamples = new List<string>()
        {
            "GetPermissions_ByOrganizationId",
            "GetPermissions_ByApplicationId"
        };

        #endregion

        #region Scope
        private List<string> scopeOperations = new List<string>()
        {
            "CreateScope",
            "DeleteScope",
            "UpdateScope",
            "GetScopes",
            "ManageScopePermissions",
            "GetScopePermissions"
        };
        private List<string> createScopeSamples = new List<string>()
        {
            "CreateScope"
        };
        private List<string> updateScopeSamples = new List<string>()
        {
            "UpdateScope"
        };
        private List<string> deleteScopeSamples = new List<string>()
        {
            "DeleteScope_HardDelete",
             "DeleteScope_SoftDelete"
        };
        private List<string> getScopeSamples = new List<string>()
        {
            "GetScopes_ByOrganizationId",
            "GetScopes_ByApplicationId"
        };
        private List<string> manageScopePermissionsSamples = new List<string>()
        {
            "ManageScopePermissions"
        };
        private List<string> getScopePermissionsSamples = new List<string>()
        {
            "GetScopePermissions"
        };

        #endregion

        #region OpenIdConnectClient
        private List<string> openIdConnectClientOperations = new List<string>()
        {
          
            "CreateOpenIdConnectClient",
            "DeleteOpenIdConnectClient",
            "UpdateOpenIdConnectClient",
            "GetOpenIdConnectClient"
        };
        private List<string> createOpenIdConnectClientSamples = new List<string>()
        {
         
            "CreateOpenIdConnectClient"
        };
        private List<string> updateOpenIdConnectClientSamples = new List<string>()
        {
            "UpdateOpenIdConnectClient"
        };
        private List<string> deleteOpenIdConnectClientSamples = new List<string>()
        {
            "DeleteOpenIdConnectClient"
        };
        private List<string> getOpenIdConnectClientSamples = new List<string>()
        {
            "GetOpenIdConnectClient"
        };

        #endregion

        #region Hierarchy
        private List<string> hierarchyOperations = new List<string>()
        {
          
            "GetNodes",
            "GetHierarchy",
        };

        private List<string> getNodesSamples = new List<string>()
        {
         
            "GetNodes"
        };

        private List<string> getHierarchy = new List<string>()
        {
            "GetDownlineHierarchy",
            "GetUplineHierarchy"
        };

        #endregion

        #region Info
        private List<string> infoOperations = new List<string>()
        {
            "ResolveOrganizationNames",
            "ResolveUsernames"
        };

        private List<string> resolveOrganizationNamesSamples = new List<string>()
        {
            "ResolveOrganizationNames"            
        };

        private List<string> resolveUserNameSamples = new List<string>()
        {
            "ResolveUsernames"
        };
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (rbLogin.Checked)
                {
                    idLoginCredentials.Visible = true;
                    idTbToken.Visible = false;
                }
                else if (rbToken.Checked)
                {
                    idLoginCredentials.Visible = false;
                    idTbToken.Visible = true;
                }
                tbAccessTokenEndPoint.Text = ConfigurationManager.AppSettings["AccessTokenEndPoint"].ToString();
                BindDropDownListFromXML();
            }
        }

        private void BindDropDownListFromXML()
        {
            try
            {
                BindServiceDropdown(serviceList.OrderBy(element => element).ToList());
                ddlService.Items.Insert(0, new ListItem("-- Select --", "0"));
                ddlOperation.Items.Insert(0, new ListItem("-- Select Service First--", "0"));
                ddlSamples.Items.Insert(0, new ListItem("-- Select Service First--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }

        private void BindServiceDropdown(List<string> items)
        {
            ddlService.DataSource = items.OrderBy(element => element).ToList();
            ddlService.DataBind();
        }

        private void BindOperationDropdown(List<string> items)
        {
            ddlOperation.DataSource = items.OrderBy(element => element).ToList();
            ddlOperation.DataBind();
        }

        private void BindSampleDropdown(List<string> items)
        {
            ddlSamples.DataSource = items.OrderBy(element => element).ToList();
            ddlSamples.DataBind();

        }

        private void PostWebRequest(string service, string operation, string url, string token)
        {
            var doc = new XmlDocument();
            HttpWebRequest request=null;
            if (string.IsNullOrEmpty(tbRequestXml.Text))
            {
                lblLoginStatus.Text = Constant.SELECTION_ERROR;
                lblLoginStatus.Visible = true;
                lblLoginStatus.ForeColor = Color.Red;
            }
            else
            {
                try
                {
                    doc.LoadXml(tbRequestXml.Text);
                }
                catch (Exception e)
                {
                    lblLoginStatus.Text = Constant.INVALID_XML_ERROR; 
                    lblLoginStatus.Visible = true;
                    lblLoginStatus.ForeColor = Color.Red;
                }

                try
                {
                    request = (HttpWebRequest) WebRequest.Create(url);
                    if (service.Equals("IAccessPattern"))
                    {
                        request.Headers.Add("SOAPAction",
                            "\"http://www.tavisca.com/Vexiere/IAccount/2013/01/" + service + "/" + operation + "\"");
                    }
                    else
                    {
                        request.Headers.Add("SOAPAction",
                            "\"http://www.tavisca.com/Vexiere/" + service + "/2013/01/" + service + "/" + operation +
                            "\"");
                    }
                    request.Headers.Add("Authorization", "Bearer " + token);
                    request.ContentType = "text/xml;charset=utf-8";
                    request.Method = "POST";
                }
                catch (Exception exception)
                {
                    lblLoginStatus.Visible = true;
                    lblLoginStatus.Text = Constant.INVALID_URL_ERROR;
                    lblLoginStatus.ForeColor = Color.Red;
                }

                try
                {
                    Stream stream = request.GetRequestStream();
                    doc.Save(stream);
                    stream.Close();
                }
                catch (Exception exception)
                {
                    lblLoginStatus.Visible = true;
                    lblLoginStatus.Text = Constant.INVALID_REQUEST;
                    lblLoginStatus.ForeColor = Color.Red;
                }

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                        {
                            string responseXML = rd.ReadToEnd();
                            tbResponseXml.Text = PrintXML(responseXML);
                            lblLoginStatus.Text = Constant.OPERATION_SUCCESSFUL;
                            lblLoginStatus.ForeColor = Color.Green;
                            lblLoginStatus.Visible = true;

                        }
                    }
                }
                catch (Exception ex)
                {
                    lblLoginStatus.Visible = true;
                    lblLoginStatus.Text = Constant.SERVICE_ERROR;
                    lblLoginStatus.ForeColor = Color.Red;
                }
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            tbResponseXml.Text = "";
            if (rbLogin.Checked && string.IsNullOrEmpty(tbUrl.Text))
            {
                lblLoginStatus.Text = "Insert Url";
                lblLoginStatus.Visible = true;
                lblLoginStatus.ForeColor = Color.Red;
            }
            else if (rbToken.Checked && string.IsNullOrEmpty(tbAccessToken.Text))
            {
                lblLoginStatus.Text = "Insert Token";
                lblLoginStatus.Visible = true;
                lblLoginStatus.ForeColor = Color.Red;
            }
            else
            {
                string service = "I" + ddlService.SelectedValue;
                string operation = ddlOperation.SelectedValue;
                PostWebRequest(service, operation, tbUrl.Text, tbAccessToken.Text);
            }
        }

        private static String PrintXML(String XML)
        {
            String Result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                document.LoadXml(XML);

                writer.Formatting = Formatting.Indented;

                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                mStream.Position = 0;

                StreamReader sReader = new StreamReader(mStream);

                String FormattedXML = sReader.ReadToEnd();

                Result = FormattedXML;
            }
            catch (XmlException)
            {
            }

            mStream.Close();
            writer.Close();

            return Result;
        }

        protected void rbLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLogin.Checked)
            {
                idLoginCredentials.Visible = true;
                if(string.IsNullOrEmpty(tbAccessToken.Text))
                    idTbToken.Visible = false;
            }
        }

        protected void rbToken_CheckedChanged(object sender, EventArgs e)
        {
            if (rbToken.Checked)
            {
                idTbToken.Visible = true;
                idLoginCredentials.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            tbAccessToken.Text = "";
            if (string.IsNullOrEmpty(tbUserName.Text))
            {
                lblLoginStatus.Text = Constant.INVALID_USERNAME;
                lblLoginStatus.ForeColor = Color.Red;
                lblLoginStatus.Visible = true;
            }
            else if (string.IsNullOrEmpty(tbPassword.Text))
            {
                lblLoginStatus.Text = Constant.INVALID_PASSWORD;
                lblLoginStatus.ForeColor = Color.Red;
                lblLoginStatus.Visible = true;
            }
            else if (string.IsNullOrEmpty(tbAPIKey.Text))
            {
                lblLoginStatus.Text = Constant.INVALID_APIKEY;
                lblLoginStatus.ForeColor = Color.Red;
                lblLoginStatus.Visible = true;
            }
            else if (string.IsNullOrEmpty(tbRootId.Text))
            {
                lblLoginStatus.Text = Constant.INVALID_ROOT_ID;
                lblLoginStatus.ForeColor = Color.Red;
                lblLoginStatus.Visible = true;
            }
            else if (string.IsNullOrEmpty(tbAccessTokenEndPoint.Text))
            {
                lblLoginStatus.Text = Constant.INVALID_ACCESS_TOKEN_END_POINT;
                lblLoginStatus.ForeColor = Color.Red;
                lblLoginStatus.Visible = true;
            }
            else
            {

                string userName = tbUserName.Text;
                string password = tbPassword.Text;
                string baseScope = ConfigurationManager.AppSettings["BaseScopes"].ToString();
                string tokenUrl = tbAccessTokenEndPoint.Text;
                Uri tokenEndpoint = new Uri(tokenUrl);
                string clientId = tbRootId.Text;
                string clientSecret = tbAPIKey.Text;

                try
                {
                    OAuth2Client client = new OAuth2Client(tokenEndpoint, clientId, clientSecret);
                    var tokenResponse = client.RequestAccessTokenUserName(userName, password, baseScope);
                    if (tokenResponse != null)
                    {
                        tbAccessToken.Visible = true;
                        string accessToken = tokenResponse.AccessToken;
                        tbAccessToken.Text = accessToken;
                        lblLoginStatus.Text = Constant.LOGIN_SUCCESSFUL;
                        lblLoginStatus.ForeColor = Color.Green;
                        lblLoginStatus.Visible = true;
                        idTbToken.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblLoginStatus.Text = Constant.LOGIN_ERROR;
                    lblLoginStatus.ForeColor = Color.Red;
                    lblLoginStatus.Visible = true;
                }
            }
        }

        #region ddlService
        protected void ddlService_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbRequestXml.Text = "";
            tbResponseXml.Text = "";

            switch (ddlService.SelectedValue)
            {
                case "Organization":
                    BindOperationDropdown(organizationOperations);
                    break;
                case "User":
                    BindOperationDropdown(userOperations);
                    break;
                case "Application":
                    BindOperationDropdown(applicationOperations);
                    break;
                case "Directory":
                    BindOperationDropdown(directoryOperations);
                    break;
                case "DirectoryType":
                    BindOperationDropdown(directoryTypeOperations);
                    break;
                case "UserGroup":
                    BindOperationDropdown(userGroupOperations);
                    break;
                case "Role":
                    BindOperationDropdown(roleOperations);
                    break;
                case "Scope":
                    BindOperationDropdown(scopeOperations);
                    break;
                case "Permission":
                    BindOperationDropdown(permissionOperations);
                    break;
                case "OpenIdConnectClient":
                    BindOperationDropdown(openIdConnectClientOperations);
                    break;
                case "AccessPattern":
                    BindOperationDropdown(accessPatternOperations);
                    break;
                case "APIKey":
                    BindOperationDropdown(apikeyOperations);
                    break;
                case "Hierarchy":
                    BindOperationDropdown(hierarchyOperations);
                    break;
                case "Identity":
                    BindOperationDropdown(identityOperations);
                    break;
                case "Info":
                    BindOperationDropdown(infoOperations);
                    break;
                case "AuthorizationGrant":
                    BindOperationDropdown(authorizationGrantOperations);
                    break;
            }
            ddlOperation.Items.Insert(0, new ListItem("--Select--"));
        }

        #endregion

        #region ddlOperation
        protected void ddlOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbRequestXml.Text = "";
            tbResponseXml.Text = "";

            switch (ddlOperation.SelectedValue)
            {
                case "CreateOrganization":
                    BindSampleDropdown(createOrganizationSamples);
                    break;
                case "DeleteOrganization":
                    BindSampleDropdown(deleteOrganizationSamples);
                    break;

                case "UpdateOrganization":
                    BindSampleDropdown(updateOrganizationSamples);
                    break;

                case "GetOrganizations":
                    BindSampleDropdown(getOrganizationSamples);
                    break;

                case "CreateUser":
                    BindSampleDropdown(createUserSamples);
                    break;

                case "DeleteUser":
                    BindSampleDropdown(deleteUserSamples);
                    break;

                case "UpdateUser":
                    BindSampleDropdown(updateUserSamples);
                    break;

                case "GetUsers":
                    BindSampleDropdown(getUserSamples);
                    break;
                case "ManageUserRoles":
                    BindSampleDropdown(manageUserRolesSamples);
                    break;
                case "GetUserRoles":
                    BindSampleDropdown(getUserRolesSamples);
                    break;
                case "CreateDirectory":
                    BindSampleDropdown(createDirectorySamples);
                    break;
                case "DeleteDirectory":
                    BindSampleDropdown(deleteDirectorySamples);
                    break;
                case "UpdateDirectory":
                    BindSampleDropdown(updateDirectorySamples);
                    break;
                case "GetDirectories":
                    BindSampleDropdown(getDirectorySamples);
                    break;
                case "CreateDirectoryType":
                    BindSampleDropdown(createDirectoryTypeSamples);
                    break;
                case "DeleteDirectoryType":
                    BindSampleDropdown(deleteDirectoryTypeSamples);
                    break;
                case "UpdateDirectoryType":
                    BindSampleDropdown(updateDirectoryTypeSamples);
                    break;
                case "GetDirectoryTypes":
                    BindSampleDropdown(getDirectoryTypeSamples);
                    break;
                case "CreateApplication":
                    BindSampleDropdown(createApplicationSamples);
                    break;
                case "DeleteApplication":
                    BindSampleDropdown(deleteApplicationSamples);
                    break;
                case "UpdateApplication":
                    BindSampleDropdown(updateApplicationSamples);
                    break;
                case "GetApplications":
                    BindSampleDropdown(getApplicationSamples);
                    break;
                case "CreateUserGroup":
                    BindSampleDropdown(createUserGroupSamples);
                    break;
                case "DeleteUserGroup":
                    BindSampleDropdown(deleteUserGroupSamples);
                    break;
                case "UpdateUserGroup":
                    BindSampleDropdown(updateUserGroupSamples);
                    break;
                case "GetUserGroups":
                    BindSampleDropdown(getUserGroupSamples);
                    break;
                case "ManageUserGroups":
                    BindSampleDropdown(manageUserGroupsSamples);
                    break;
                case "ManageUserGroupRoles":
                    BindSampleDropdown(manageUserGroupRolesSamples);
                    break;
                case "GetUserGroupRoles":
                    BindSampleDropdown(getUserGroupRolesSamples);
                    break;
                case "CreateRole":
                    BindSampleDropdown(createRoleSamples);
                    break;
                case "DeleteRole":
                    BindSampleDropdown(deleteRoleSamples);
                    break;
                case "UpdateRole":
                    BindSampleDropdown(updateRoleSamples);
                    break;
                case "GetRoles":
                    BindSampleDropdown(getRoleSamples);
                    break;
                case "ManageRoleScopes":
                    BindSampleDropdown(manageRoleScopesSamples);
                    break;
                case "GetRoleScopes":
                    BindSampleDropdown(getRoleScopesSamples);
                    break;
                case "ManageRoleMappings":
                    BindSampleDropdown(manageRoleMappingsSamples);
                    break;
                case "GetRoleMappings":
                    BindSampleDropdown(getRoleMappingsSamples);
                    break;
                case "CreatePermission":
                    BindSampleDropdown(createPermissionSamples);
                    break;
                case "DeletePermission":
                    BindSampleDropdown(deletePermissionSamples);
                    break;
                case "UpdatePermission":
                    BindSampleDropdown(updatePermissionSamples);
                    break;
                case "GetPermissions":
                    BindSampleDropdown(getPermissionSamples);
                    break;
                case "CreateScope":
                    BindSampleDropdown(createScopeSamples);
                    break;
                case "DeleteScope":
                    BindSampleDropdown(deleteScopeSamples);
                    break;
                case "UpdateScope":
                    BindSampleDropdown(updateScopeSamples);
                    break;
                case "GetScopes":
                    BindSampleDropdown(getScopeSamples);
                    break;
                case "ManageScopePermissions":
                    BindSampleDropdown(manageScopePermissionsSamples);
                    break;
                case "GetScopePermissions":
                    BindSampleDropdown(getScopePermissionsSamples);
                    break;
                case "CreateOpenIdConnectClient":
                    BindSampleDropdown(createOpenIdConnectClientSamples);
                    break;
                case "DeleteOpenIdConnectClient":
                    BindSampleDropdown(deleteOpenIdConnectClientSamples);
                    break;
                case "UpdateOpenIdConnectClient":
                    BindSampleDropdown(updateOpenIdConnectClientSamples);
                    break;
                case "GetOpenIdConnectClient":
                    BindSampleDropdown(getOpenIdConnectClientSamples);
                    break;
                case "GetNodes":
                    BindSampleDropdown(getNodesSamples);
                    break;
                case "GetHierarchy":
                    BindSampleDropdown(getHierarchy);
                    break;
                case "RegisterAccessPattern":
                    BindSampleDropdown(registerAccessPatternSamples);
                    break;
                case "UpdateAccessPattern":
                    BindSampleDropdown(updateAccessPatternSamples);
                    break;
                case "DeleteAccessPattern":
                    BindSampleDropdown(deleteAccessPatternSamples);
                    break;
                case "GetAccessPattern":
                    BindSampleDropdown(getAccessPatternSamples);
                    break;
                case "ResolveApplication":
                    BindSampleDropdown(resolveApplicationSamples);
                    break;
                case "CreateAPIKey":
                    BindSampleDropdown(createAPIKeySamples);
                    break;
                case "DeleteAPIKey":
                    BindSampleDropdown(deleteAPIKeySamples);
                    break;
                case "UpdateAPIKey":
                    BindSampleDropdown(updateAPIKeySamples);
                    break;
                case "GetAPIKeys":
                    BindSampleDropdown(getAPIKeySamples);
                    break;
                case "GetAPIKeyRoles":
                    BindSampleDropdown(getAPIKeyRolesSamples);
                    break;
                case "ManageAPIKeyRoles":
                    BindSampleDropdown(manageAPIKeyRoleSamples);
                    break;

                case "ResetPassword":
                    BindSampleDropdown(resetPasswordSample);
                    break;
                case "GenerateOTP":
                    BindSampleDropdown(generateOTPSamples);
                    break;
                case "ChangePassword":
                    BindSampleDropdown(changePasswordSamples);
                    break;
                case "ResolveOrganizationNames":
                    BindSampleDropdown(resolveOrganizationNamesSamples);
                    break;
                case "ResolveUsernames":
                    BindSampleDropdown(resolveUserNameSamples);
                    break;
                case "GetAuthorizationGrants":
                    BindSampleDropdown(getAuthorizationGrantsSamples);
                    break;
                case "DeleteAuthorizationGrant":
                    BindSampleDropdown(deleteAuthorizationGrantSamples);
                    break;
            }
            ddlSamples.Items.Insert(0, new ListItem("--Select--"));
        }

        #endregion

        #region ddlSamples
        protected void ddlSamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlService.SelectedValue))
            {
                string defaultUrl = ConfigurationManager.AppSettings["DefaultUrl"].ToString() + ddlService.SelectedValue +".svc";
                tbUrl.Text = defaultUrl;
            }
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader textStreamReader;
            string fileContent;
            switch (ddlSamples.SelectedValue)
            {
                case "CreateOrganization":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.CreateOrganization.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateOrganization":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateOrganization.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteOrganization_HardDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteOrganization_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteOrganization_SoftDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteOrganization_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetOrganizations_ById":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetOrganizations_ById.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetOrganizations_ByName":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetOrganizations_ByName.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreateUser":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.CreateUser.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteUser_HardDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteUser_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteUser_SoftDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteUser_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateUser":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateUser.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetUsers_ById":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetUsers_ById.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetUsers_ByName":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetUsers_ByName.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetUsers_ByUserToken":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetUsers_ByUserToken.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ManageUserRoles":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ManageUserRoles.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetUserRoles":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetUserRoles.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreateApplication":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.CreateApplication.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteApplication_HardDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteApplication_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteApplication_SoftDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteApplication_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateApplication":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateApplication.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetApplications_ById":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetApplications_ById.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetApplications_ByName":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetApplications_ByName.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreateDirectory":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.CreateDirectory.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteDirectory_HardDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteDirectory_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteDirectory_SoftDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteDirectory_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateDirectory":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateDirectory.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetDirectories_ById":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetDirectories_ById.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetDirectories_ByName":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetDirectories_ByName.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreateDirectoryType":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.CreateDirectoryType.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteDirectoryType_HardDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteDirectoryType_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteDirectoryType_SoftDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteDirectoryType_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateDirectoryType":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateDirectoryType.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetDirectoryTypes_ById":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetDirectoryTypes_ById.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetDirectoryTypes_ByName":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetDirectoryTypes_ByName.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreateUserGroup":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.CreateUserGroup.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteUserGroup_HardDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteUserGroup_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteUserGroup_SoftDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteUserGroup_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateUserGroup":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateUserGroup.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetUserGroups_ById":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetUserGroups_ById.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetUserGroups_ByName":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetUserGroups_ByName.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ManageUserGroups":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ManageUserGroups.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ManageUserGroupRoles":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ManageUserGroupRoles.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetUserGroupRoles":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetUserGroupRoles.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreateRole":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.CreateRole.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateRole":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateRole.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteRole":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteRole.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetRoles":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.GetRoles.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ManageRoleScopes":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ManageRoleScopes.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetRoleScopes":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetRoleScopes.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ManageRoleMappings":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ManageRoleMappings.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetRoleMappings":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetRoleMappings.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteRole_HardDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteRole_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteRole_SoftDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteRole_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreateScope":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.CreateScope.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateScope":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateScope.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteScope_HardDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteScope_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteScope_SoftDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteScope_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetScopes_ByOrganizationId":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.GetScopes_ByOrganizationId.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetScopes_ByApplicationId":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.GetScopes_ByApplicationId.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ManageScopePermissions":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ManageScopePermissions.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetScopePermissions":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetScopePermissions.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreatePermission":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.CreatePermission.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdatePermission":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.UpdatePermission.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeletePermission_HardDelete":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeletePermission_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeletePermission_SoftDelete":
                    textStreamReader =
                     new StreamReader(
                         assembly.GetManifestResourceStream(
                             "Tavisca.Vexiere.WcfHarness.RequestXmls.DeletePermission_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetPermissions_ByOrganizationId":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetPermissions_ByOrganizationId.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetPermissions_ByApplicationId":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetPermissions_ByApplicationId.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreateOpenIdConnectClient":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.CreateOpenIdConnectClient.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateOpenIdConnectClient":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateOpenIdConnectClient.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteOpenIdConnectClient":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteOpenIdConnectClient.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetOpenIdConnectClient":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetOpenIdConnectClient.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetNodes":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.GetNodes.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetUplineHierarchy":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetUplineHierarchy.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetDownlineHierarchy":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetDownlineHierarchy.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "RegisterAccessPattern":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.RegisterAccessPattern.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateAccessPattern":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateAccessPattern.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetAccessPattern":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetAccessPattern.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteAccessPattern":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteAccessPattern.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ResolveApplication_ByUrl":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ResolveApplication_ByUrl.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ResolveApplication_ByOrganizationCode":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ResolveApplication_ByOrganizationCode.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "CreateAPIKey":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.CreateAPIKey.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "UpdateAPIKey":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.UpdateAPIKey.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteAPIKey":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteAPIKey.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetAPIKeys":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.GetAPIKeys.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ManageAPIKeyRoles":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ManageAPIKeyRoles.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "GetAPIKeyRoles":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.GetAPIKeyRoles.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ResetPassword":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ResetPassword.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;

                case "GenerateOTP_By_SecurityAnswerBasedRq":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.GenerateOTP_By_SecurityAnswerBasedRq.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;

                case "GenerateOTP_By_UserIdentifier_BasedRq":
                    textStreamReader =
                       new StreamReader(
                           assembly.GetManifestResourceStream("Tavisca.Vexiere.WcfHarness.RequestXmls.GenerateOTP_By_UserIdentifier_BasedRq.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ChangePassword_ByUserId":
                    textStreamReader =
                        new StreamReader(
                            assembly.GetManifestResourceStream(
                                "Tavisca.Vexiere.WcfHarness.RequestXmls.ChangePassword_ByUserId.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ResolveOrganizationNames":
                    textStreamReader =
                      new StreamReader(
                          assembly.GetManifestResourceStream(
                              "Tavisca.Vexiere.WcfHarness.RequestXmls.ResolveOrganizationNames.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "ResolveUsernames":
                    textStreamReader =
                       new StreamReader(
                           assembly.GetManifestResourceStream(
                               "Tavisca.Vexiere.WcfHarness.RequestXmls.ResolveUserNames.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;

                case "GetAuthorizationGrants":
                    textStreamReader =
                       new StreamReader(
                           assembly.GetManifestResourceStream(
                               "Tavisca.Vexiere.WcfHarness.RequestXmls.GetAuthorizationGrants.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteAuthorizationGrant_HardDelete":
                    textStreamReader =
                       new StreamReader(
                           assembly.GetManifestResourceStream(
                               "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteAuthorizationGrant_HardDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
                case "DeleteAuthorizationGrant_SoftDelete":
                    textStreamReader =
                       new StreamReader(
                           assembly.GetManifestResourceStream(
                               "Tavisca.Vexiere.WcfHarness.RequestXmls.DeleteAuthorizationGrant_SoftDelete.xml"));
                    fileContent = textStreamReader.ReadToEnd().ToString(CultureInfo.CurrentCulture);
                    tbRequestXml.Text = fileContent;
                    break;
            }
            
        }

        #endregion

      
    }
}

