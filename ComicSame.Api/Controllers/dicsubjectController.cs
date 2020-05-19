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
    public class dicsubjectController : ApiController
    {
        private static dicsubjectManager dicsubjectManager = new dicsubjectManager();

        /// <summary>
        /// 插入科目字典信息
        /// </summary>
        /// <param name="dto">成绩信息</param>
        /// <returns></returns>
        [HttpPost]
        public bool Insert(dicsubject dto)
        {
            dto.Create();
            return dicsubjectManager.Insert(dto);
        }

        [HttpPost]
        public bool InsertTest()
        {
            List<string> lstsubject = new List<string>()
            {
                "1000米跑_速度",
                "3000米跑_速度",
                "爬绳_速度",
                "单杠引体向上_速度",
                "单杠3练习_力量",
                "双杠3练习_力量",
                "单杠卷身上_力量",
                "双杠摆动臂屈伸_力量",
                "3公里武装越野_耐力",
                "400米障碍_耐力",
                "进阶跑_耐力",
                "携枪通过100米障碍_耐力",
                "仰卧起坐_柔韧性",
                "木马1练习_柔韧性",
                "木马2练习_柔韧性",
                "徒手组合练习_柔韧性",
                "30米×2蛇形跑_灵敏度",
                "救护组合练习_灵敏度",
                "负重组合练习_灵敏度",
                "基础体能组合1_灵敏度",
                "基础体能组合2_灵敏度",
                "格斗术1至5组合_灵敏度"
            };
            List<dicsubject> dicsubjects = new List<dicsubject>();
            foreach (var item in lstsubject)
            {
                string[] str = item.Split('_');
                dicsubjects.Add(new dicsubject()
                {
                    Guid = Guid.NewGuid().ToString(),
                    SubjectName = str[0],
                    SubType = str[1]
                });
            }
             return dicsubjectManager.Insert(dicsubjects);
        }

        /// <summary>
        /// 查询所有查询科目字典信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<dicsubject> GetAll()
        {
            return dicsubjectManager.GetList();
        }

        /// <summary>
        /// 根据类别查询科目字典信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public List<dicsubject> GetDicSubject(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return new List<dicsubject>();
            }
            return dicsubjectManager.GetList(t => t.SubType.Equals(type));
        }

        /// <summary>
        /// 新增或者更新人员信息表
        /// </summary>
        /// <param name="dicsubject"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Save(dicsubject dicsubject)
        {
            if (string.IsNullOrEmpty(dicsubject.Guid))
            {
                dicsubject.Create();
                return dicsubjectManager.Insert(dicsubject);
            }
            else if (dicsubjectManager.GetById(dicsubject.Guid) != null)
                return dicsubjectManager.Update(dicsubject);
            else
            {
                return dicsubjectManager.Insert(dicsubject);
            }
        }


    }
}