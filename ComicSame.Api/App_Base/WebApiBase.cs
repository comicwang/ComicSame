using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ComicSame.Api
{
    /// <summary>
    /// WebApi的基类（用于加载拦截器）
    /// </summary>
    [RequestAuthorize]
    public abstract class WebApiControllerBase : ApiController
    {
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public virtual string ToJsonResult(object data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public virtual WebApiResult Success(string message)
        {
            return new WebApiResult { type = ResultType.success, message = message };
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public virtual WebApiResult Success(string message, object data)
        {
            return new WebApiResult { type = ResultType.success, message = message, resultdata = data };
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public virtual WebApiResult Error(string message)
        {
            return new WebApiResult { type = ResultType.error, message = message };
        }

        public string Options()
        {
            return null;
        }
    }

    /// <summary>
    /// WebAPi结果
    /// </summary>
    public class WebApiResult
    {
        /// <summary>
        /// 获取操作结果类型
        /// </summary>
        public ResultType type { get; set; }

        /// <summary>
        /// 获取操作结果编码
        /// </summary>
        public int resultcode { get; set; }

        /// <summary>
        /// 获取消息内容
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 获取返回数据
        /// </summary>
        public object resultdata { get; set; }
    }

    public enum ResultType
    {
        info = 0,
        success = 1,
        warning = 2,
        error = 3
    }
}