using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ComicSame.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["logLevel"].ToLower() == "error")
            {
                Exception ex = Server.GetLastError().GetBaseException(); //获取异常源 
                Log.WriteLog(ex.Message, ex);
            }
        }
    }
}
