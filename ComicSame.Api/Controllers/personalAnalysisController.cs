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
    /// 个人军事训练成绩分析接口Api
    /// </summary>
    public class personalAnalysisController : WebApiControllerBase
    {
        private static dicsubjectManager dicsubjectManager = new dicsubjectManager();
        private static personalscroceManager personalscroceManager = new personalscroceManager();
        private static personalfilesManager personalfilesManager = new personalfilesManager();

    }
}