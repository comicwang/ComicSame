using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Insert(personalfiles dto)
        {
            dto.Create();
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
    }
}