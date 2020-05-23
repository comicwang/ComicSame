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
    /// 人员信息管理接口Api
    /// </summary>
    public class PersonalfilesController : WebApiControllerBase
    {
        private personalfilesManager personalfilesManager = new personalfilesManager();

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
        /// 根据ID查询个人信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet]
        public personalfiles GetById(string guid)
        {
            return personalfilesManager.GetById(guid);
        }

        /// <summary>
        /// 根据名称模糊查询个人信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>个人信息（返回名称和guid）</returns>
        [HttpGet]
        public List<personalfiles> GetList(string name)
        {
            return personalfilesManager.CurrentDb.AsQueryable().Where(t=>t.Name.Contains(name)).Select(t => new personalfiles()
            {
                Guid = t.Guid,
                Name = t.Name
            }).ToList();
        }

        /// <summary>
        /// 分页查询个人信息列表
        /// </summary>
        /// <param name="pageModel"></param>
        /// <param name="queryJson"></param>
        /// <param name="orderby">排序信息，例如"field desc"</param>
        /// <returns></returns>
        [HttpGet]
        public object GetPersonalList([FromUri]PageModel pageModel, string queryJson, string orderby = null)
        {
            var result = personalfilesManager.GetPageList(queryJson, pageModel, orderby);

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

        /// <summary>
        /// 新增或者更新人员信息表
        /// </summary>
        /// <param name="personalfiles"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Save(personalfiles personalfiles)
        {
            if (string.IsNullOrEmpty(personalfiles.Guid))
            {
                personalfiles.Create();
                return personalfilesManager.Insert(personalfiles);
            }
            else if(personalfilesManager.GetById(personalfiles.Guid) != null)
                return personalfilesManager.Update(personalfiles);
            else
            {
                return personalfilesManager.Insert(personalfiles);
            }
        }

        /// <summary>
        /// 导入人员Excel文件信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object ImportPersonalfileExcel()
        {
            string Message = string.Empty;
            string Error = string.Empty;
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            if (files.Count > 0)
            {
                var file = files[0];
                string dir = HttpContext.Current.Server.MapPath("/Temp");
                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }
                string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                file.SaveAs(filePath);
                List<string> sheetNames = ExcelReader.GetExcelSheetName(filePath);
                DataTable dt = ExcelReader.GetExcelContext(filePath, "基础数据$");
                if (dt != null && dt.Rows.Count > 0)
                {
                    List<personalfiles> lstInsertFiles = new List<personalfiles>();
                    List<personalfiles> lstUpdateFiles = new List<personalfiles>();
                    int index = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[0] == null || row[0].ToString() == "")
                            continue;
                        try
                        {
                            personalfiles personalfiles = new personalfiles()
                            {
                                Name = row[0].ToString(),
                                Company = row[1].ToString(),
                                Department = row[2].ToString(),
                                Duty = row[3].ToString(),
                                Level = row[4].ToString(),
                                BrithDate = DateTime.Parse(row[5].ToString()),
                                Age = int.Parse(row[6].ToString()),
                                EnlistedDate = DateTime.Parse(row[7].ToString()),
                                PoliticalFace = row[8].ToString(),
                                Education = row[9].ToString(),
                                Nation = row[10].ToString(),
                                NavtivePlace = row[11].ToString(),
                                Height = double.Parse(row[12].ToString()),
                                Weight = int.Parse(row[13].ToString()),
                                Bust = int.Parse(row[14].ToString()),
                                Waist = int.Parse(row[15].ToString()),
                                BMI = double.Parse(row[16].ToString()),
                                PBF = double.Parse(row[17].ToString()),
                                ModyfiedDate = DateTime.Now
                            };
                            //姓名年龄一致判断为重复数据，更新
                            personalfiles temp = personalfilesManager.GetList(t => t.Name == personalfiles.Name && t.Age.Value == personalfiles.Age.Value).FirstOrDefault();
                            if (temp == null)
                            {
                                personalfiles.Create();
                                personalfiles.CreateDate = DateTime.Now;
                                lstInsertFiles.Add(personalfiles);
                            }
                            else
                            {
                                personalfiles.Guid = temp.Guid;
                                lstUpdateFiles.Add(personalfiles);
                            }
                            index++;
                        }
                        catch (Exception ex)
                        {
                            Error += $"导入第{index}行数据异常:{ex.Message}";
                            Error += Environment.NewLine;
                        }
                    }
                    if (lstInsertFiles.Count > 0)
                    {
                        personalfilesManager.Insert(lstInsertFiles);
                    }
                    if (lstUpdateFiles.Count > 0)
                    {
                        personalfilesManager.Update(lstUpdateFiles);
                    }
                    Message = $"导入成功,新增人员信息{lstInsertFiles.Count}条，更新人员信息{lstUpdateFiles.Count}条";
                }
                else
                {
                    Error += "模板中未找到人员信息";
                }
            }
            else
            {
                Error = "请求参数错误！";
                throw new ArgumentNullException(typeof(HttpPostedFile).Name);
            }
            return new
            {
                Message = Message,
                Error = Error
            };
        }

        /// <summary>
        /// 删除个人信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete(string guid)
        {
            return personalfilesManager.DeleteById(guid);
        }

        /// <summary>
        /// 获取所有单位列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<string> GetDepartList()
        {
           return personalfilesManager.CurrentDb.AsQueryable().GroupBy(t => t.Department).Select(t => t.Department).ToList();
        }

        /// <summary>
        /// 根据部门名称（全匹配）获取部门级别信息
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpGet]
        public List<string> GetLevelByDepartment(string department)
        {
            return personalfilesManager.CurrentDb.AsQueryable().GroupBy(t => t.Level).Where(t => t.Department == department).Select(t => t.Level).ToList();
        }

        /// <summary>
        /// 随机选取一个人员信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public personalfiles GetRandomPersonalfile()
        {
            return personalfilesManager.Db.Ado.SqlQuery<personalfiles>("select  *  from  personalfiles order by rand() limit 1").First();
        }
    }
}