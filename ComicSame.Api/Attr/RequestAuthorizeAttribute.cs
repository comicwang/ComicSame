using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ComicSame.Api
{
    /// <summary>
    /// 接口授权认证
    /// </summary>
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        //重写基类的验证方式，加入我们自定义的Ticket验证//验证WebApi的
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            if (System.Configuration.ConfigurationManager.AppSettings["tokenAuth"].ToLower()=="false")
            {
                base.OnAuthorization(actionContext);
            }

            var attributesA = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
            var attributesC = actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
            bool isAnonymousA = attributesA.Any(a => a is AllowAnonymousAttribute);
            bool isAnonymousC = attributesC.Any(a => a is AllowAnonymousAttribute);
            if (isAnonymousA || isAnonymousC)
            {
                base.OnAuthorization(actionContext);
            }
            else
            {

                var authorization = actionContext.Request.Headers.Authorization;
                //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
                if (authorization == null)
                {
                    var headers = actionContext.Request.Headers.ToList();
                    var auth = headers.Where(t => t.Key == "Authorization").Select(t => t.Value).FirstOrDefault();
                    if (auth != null && auth.Count() > 0)
                    {
                        if (ValidateTicket(auth.ToList()[0]))
                        {
                            base.IsAuthorized(actionContext);
                        }
                        else
                        {
                            HandleUnauthorizedRequest(actionContext);
                        }
                    }
                    else
                    {


                        HandleUnauthorizedRequest(actionContext);

                    }

                }
                else
                {
                    //解密用户ticket,并校验用户名密码是否匹配
                    string encryptTicket = "";
                    if (authorization != null)
                    {
                        encryptTicket = authorization.ToString();
                    }
                    if (authorization.Parameter != null)
                    {
                        encryptTicket = authorization.Parameter;
                    }
                    if (ValidateTicket(encryptTicket))
                    {
                        base.IsAuthorized(actionContext);
                    }
                    else
                    {
                        HandleUnauthorizedRequest(actionContext);
                    }
                }
            }
        }

        private bool ValidateTicket(string token)
        {
            return SSO.SSOProvider.ValidatToken(token);
        }

        /// <summary>
        /// 处理未登录的异常相应
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
            var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Forbidden;
            response.Content = new ObjectContent<ForbiddenResponse>(new ForbiddenResponse() {Message="Token已过期，请重新登录" }, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
        }
    }

    /// <summary>
    /// 403回应
    /// </summary>
    public class ForbiddenResponse
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code = (int)HttpStatusCode.Forbidden;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}
