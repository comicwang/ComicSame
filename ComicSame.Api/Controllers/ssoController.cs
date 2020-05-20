using ComicSame.SSO.SSOValidate;
using Newtonsoft.Json.Linq;
using SqlSugar;
using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ComicSame.Api.Controllers
{
    /// <summary>
    /// 科目类别管理接口Api
    /// </summary>
    public class ssoController : WebApiControllerBase
    {
        /// <summary>
        /// 根据token获取用户信息
        /// </summary>
        /// <param name="token">token信息</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public SSOUser GetUserInfoByToken(string token)
        {
           return SSO.SSOProvider.GetUserInfoByToken(token);
        }

        /// <summary>
        /// 根据用户名和密码获取token信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public string GetToken(string userName,string password)
        {
            return SSO.SSOProvider.GetToken(userName, password);
        }
    }
}