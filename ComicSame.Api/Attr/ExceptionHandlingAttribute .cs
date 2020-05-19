using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace ComicSame.Api
{
    /// <summary>
    /// 异常日志记录
    /// </summary>
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["logLevel"].ToLower() == "error")
            {
                var exception = context.Exception;
                if (exception != null)
                {
                    Log.WriteLog(exception.Message, exception);
                }
            }
        }
    }
}