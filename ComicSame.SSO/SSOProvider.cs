using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicSame.SSO
{
    /// <summary>
    /// SSO接口类
    /// </summary>
    public class SSOProvider
    {
        public static bool ValidatToken(string token)
        {
            SSOValidate.AuthTokenServiceSoapClient authTokenServiceSoapClient = new SSOValidate.AuthTokenServiceSoapClient();
            var result = authTokenServiceSoapClient.ValidateToken(token);
            return result != null;
        }

        public static SSO.SSOValidate.SSOUser GetUserInfoByToken(string token)
        {
            SSOValidate.AuthTokenServiceSoapClient authTokenServiceSoapClient = new SSOValidate.AuthTokenServiceSoapClient();
            var result = authTokenServiceSoapClient.ValidateToken(token);
            if (result != null)
                return result.User;
            return null;
        }

        public static string GetToken(string userName,string password)
        {
            SSOValidate.AuthTokenServiceSoapClient authTokenServiceSoapClient = new SSOValidate.AuthTokenServiceSoapClient();
            return authTokenServiceSoapClient.GetToken(userName, password);
        }
    }
}
