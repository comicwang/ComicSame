using Newtonsoft.Json.Linq;
using SqlSugar;
using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComicSame.Api.Controllers
{
    public class PersonalfilesController : ApiController
    {
        private static personalfilesManager personalfilesManager = new personalfilesManager();

        /// <summary>
        /// 插入个人信息
        /// </summary>
        /// <param name="dto">个人信息</param>
        /// <returns></returns>
        [HttpPost]
        public bool Insert(personalfiles dto)
        {
            dto.Create();
            if (dto.Height == null)
            {
                Random random = new Random();
                dto.Height = 1 + random.Next(6, 9) * 0.1 + random.Next(0, 9) * 0.01;
            }
            return personalfilesManager.Insert(dto);
        }

        /// <summary>
        /// 查询所有个人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<personalfiles> GetAll()
        {
           return personalfilesManager.GetList();
        }

        /// <summary>
        /// 分页查询个人信息列表
        /// </summary>
        /// <param name="pageModel"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetPersonalList([FromUri]PageModel pageModel, string queryJson)
        {
            var result = personalfilesManager.GetPageList(queryJson, pageModel);

            return new
            {
                data = result,
                pageModel = pageModel
            };
        }

        /// <summary>
        /// 批量导入人员信息
        /// </summary>
        /// <param name="personalfiles">人员信息列表</param>
        /// <returns></returns>
        [HttpPost]
        public bool InsertAll(List<personalfiles> personalfiles)
        {
            return personalfilesManager.Insert(personalfiles);
        }
    }
}