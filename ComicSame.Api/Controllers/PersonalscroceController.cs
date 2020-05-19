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
    public class PersonalscroceController : ApiController
    {
        private static personalscroceManager personalscroceManager = new personalscroceManager();
        private static personalfilesManager personalfilesManager = new personalfilesManager();
        private static dicsubjectManager dicsubjectManager = new dicsubjectManager();

        /// <summary>
        /// 插入个人成绩信息
        /// </summary>
        /// <param name="dto">成绩信息</param>
        /// <returns></returns>
        [HttpPost]
        public bool Insert(personalscroce dto)
        {
            dto.Create();
            return personalscroceManager.Insert(dto);
        }

        /// <summary>
        /// 插入数据（初始化测试数据用）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public bool InsertTest()
        {            
            var person= personalfilesManager.GetList();
            List<DateTime> dates = new List<DateTime>()
            { 
               new DateTime(2018,1,2),
               new DateTime(2018,1,8),
               new DateTime(2018,1,15),
               new DateTime(2018,1,17),
               new DateTime(2018,1,25),
               new DateTime(2018,2,3),
               new DateTime(2018,2,8),
               new DateTime(2018,2,13),
               new DateTime(2018,2,25),
               new DateTime(2018,2,28),
               new DateTime(2018,3,5),
               new DateTime(2018,3,9),
               new DateTime(2018,3,18)
            };
            List<dicsubject> subjects = dicsubjectManager.GetList();
           
            Random random = new Random();
            List<personalscroce> lst = new List<personalscroce>();
            foreach (var per in person)
            {
                foreach (var date in dates)
                {
                    foreach (var subject in subjects)
                    {
                        int score = random.Next(55, 100);
                        lst.Add(new personalscroce()
                        {
                            AchieveDate = date,
                            PGuid = per.Guid,
                            Score = score,
                            Subject = subject.SubjectName,
                            SubjectType=subject.SubType,
                            SubjectGuid=subject.Guid,
                            Guid = Guid.NewGuid().ToString()
                        });
                    }
                }
            }

            return personalscroceManager.Insert(lst);
        }

        /// <summary>
        /// 查询成绩信息
        /// </summary>
        /// <param name="pid">人员ID（不传不筛选）</param>
        /// <param name="subject">科目信息</param>
        /// <param name="dateBegin">考试开始时间</param>
        /// <param name="dateEnd">考试结束时间</param>
        /// <returns></returns>
        [HttpGet]
        public List<personalscroce> GetScroces(string pid, string subject, DateTime? dateBegin, DateTime? dateEnd)
        {
            return personalscroceManager.GetPersonalscroces(pid, subject, dateBegin, dateEnd);
        }

        /// <summary>
        /// 查询所有成绩信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<personalscroce> GetAll()
        {
           return personalscroceManager.GetList();
        }

        /// <summary>
        /// 新增或者更新成绩信息
        /// </summary>
        /// <param name="personalscroce"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Save(personalscroce personalscroce)
        {
            if (string.IsNullOrEmpty(personalscroce.Guid))
            {
                personalscroce.Create();
                return personalscroceManager.Insert(personalscroce);
            }
            else if(personalscroceManager.GetById(personalscroce.Guid) != null)
                return personalscroceManager.Update(personalscroce);
            else
            {
                return personalscroceManager.Insert(personalscroce);
            }
        }

        /// <summary>
        /// 导入成绩Excel文件信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object ImportPersonalScoreExcel()
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
                List<dicsubject> dicsubjects = dicsubjectManager.GetList();
                List<personalfiles> personalfiles = personalfilesManager.GetList();

                List<personalscroce> lstInsertFiles = new List<personalscroce>();
                List<personalscroce> lstUpdateFiles = new List<personalscroce>();
                foreach (string sheetName in sheetNames)
                {
                    var sheetNameTemp = sheetName.Trim('\'').TrimEnd('$');
                    var dicsubject = dicsubjects.Where(t => t.SubjectName == sheetNameTemp).FirstOrDefault();
                    if (dicsubject != null)
                    {
                        DataTable dt = ExcelReader.GetExcelContext(filePath, sheetNameTemp + "$");
                        if (!dt.Columns.Contains("姓名"))
                        {
                            Error += $"表单【{sheetNameTemp}】不包含姓名列，模板不能识别";
                            continue;
                        }
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (i == 0)
                                    continue;
                                DataRow dataRow = dt.Rows[i];
                                foreach (DataColumn colunm in dt.Columns)
                                {
                                    string pName = dataRow["姓名"].ToString();

                                    try
                                    {
                                        var pInfo = personalfiles.Where(t => t.Name == pName).FirstOrDefault();
                                        if (pInfo == null)
                                        {
                                            Error += $"表单【{sheetNameTemp}】姓名【{pName}】行未找到基本信息，跳过导入";
                                            continue;
                                        }
                                        DateTime dateTime = DateTime.Now;
                                        if (DateTime.TryParse(colunm.ColumnName, out dateTime))
                                        {
                                            int myscore= int.Parse(dataRow[colunm.ColumnName].ToString()); 
                                            var score = personalscroceManager.GetList(t => t.PGuid == pInfo.Guid && t.AchieveDate == dateTime && t.SubjectGuid == dicsubject.Guid).FirstOrDefault();
                                            if (score != null)
                                            {
                                                score.Score = myscore;
                                                lstUpdateFiles.Add(score);
                                            }
                                            else
                                            {
                                                lstInsertFiles.Add(new personalscroce()
                                                {
                                                    Guid = Guid.NewGuid().ToString(),
                                                    Score = myscore,
                                                    AchieveDate = dateTime,
                                                    PGuid = pInfo.Guid,
                                                    SubjectGuid = dicsubject.Guid,
                                                    Subject = dicsubject.SubjectName,
                                                    SubjectType = dicsubject.SubType
                                                });
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Error += $"表单【{sheetNameTemp}】姓名【{pName}】导入成绩异常【{ex.Message}】";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Error += $"表单【{sheetNameTemp}】科目信息未找到，跳过导入";
                    }
                }
                if (lstInsertFiles.Count > 0)
                {
                    personalscroceManager.Insert(lstInsertFiles);
                }
                if (lstUpdateFiles.Count > 0)
                {
                    personalscroceManager.Update(lstUpdateFiles);
                }

                Message = $"导入成功,新增成绩信息{lstInsertFiles.Count}条，更新成绩信息{lstUpdateFiles.Count}条";
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
    }
}