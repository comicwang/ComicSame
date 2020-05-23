using Newtonsoft.Json.Linq;
using SqlSugar;
using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComicSame.Api.Controllers
{
    /// <summary>
    /// 部门综合实力分析Api
    /// </summary>
    public class departmentAnalysisController : WebApiControllerBase
    {
        private dicsubjectManager dicsubjectManager = new dicsubjectManager();
        private personalscroceManager personalscroceManager = new personalscroceManager();
        private personalfilesManager personalfilesManager = new personalfilesManager();

        /// <summary>
        /// 获取该部门的综合实力指标
        /// </summary>
        /// <param name="department">部门名称(全字匹配)，根据接口获取下拉选择</param>
        /// <param name="Level">人员级别（全字匹配，根据接口获取下拉选择）</param>
        /// <returns></returns>
        [HttpGet]
        public object GetDepartmentAnalysisInfo(string department,string Level)
        {
            List<IConditionalModel> conModels = new List<IConditionalModel>();
            //部门名称
            if (!string.IsNullOrEmpty(department))
            {
                conModels.Add(new ConditionalModel()
                {
                    FieldName = "Department",
                    FieldValue = department,
                    ConditionalType = ConditionalType.Equal
                });
            }
            //人员级别
            if (!string.IsNullOrEmpty(Level))
            {
                conModels.Add(new ConditionalModel()
                {
                    FieldName = "Level",
                    FieldValue = Level,
                    ConditionalType = ConditionalType.Equal
                });
            }
            //获取平均值和最高最低值
            var result= personalscroceManager.Db.Queryable<personalscroce, personalfiles, dicsubject>((t1, t2, t3) => t1.PGuid == t2.Guid && t1.SubjectGuid == t3.Guid).Where(conModels).GroupBy((t1, t2, t3) => new { t1.SubjectGuid }).Select((t1, t2, t3) => new { SubjectGuid = t3.Guid, Subject = t3.SubjectName, SubjectType = t3.SubType, ScoreAvg = SqlFunc.AggregateAvg<double>((double)t1.Score), ScoreMax = SqlFunc.AggregateMax(t1.Score), ScoreMin = SqlFunc.AggregateMin(t1.Score)}).ToList();
            JArray jArray = new JArray();
            //获取最高得分者
            foreach (var item in result)
            {
                JObject jObject = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(item));
                List<IConditionalModel> conditionalModels = new List<IConditionalModel>();
                conditionalModels.Add(new ConditionalModel()
                {
                    FieldName = "Score",
                    FieldValue = item.ScoreMax.Value.ToString(),
                    ConditionalType = ConditionalType.Equal
                });
                conditionalModels.Add(new ConditionalModel()
                {
                    FieldName = "SubjectGuid",
                    FieldValue = item.SubjectGuid,
                    ConditionalType = ConditionalType.Equal
                });
                conditionalModels.AddRange(conModels);
                var names = personalfilesManager.Db.Queryable<personalscroce, personalfiles>((t1, t2) => t1.PGuid == t2.Guid).Where(conditionalModels).Select((t1, t2) => t2.Name).ToList().Distinct();
                //最高得分者名称
                string maxScoreName = string.Join("#", names);
                jObject["maxScoreName"] = maxScoreName;

                //获取历史最高得分
                string sql = $"	SELECT DISTINCT(`Name`),Score from personalscroce t1 JOIN personalfiles t2 ON t1.PGuid=t2.Guid  where SubjectGuid='{item.SubjectGuid}' and Score= (SELECT MAX(Score) from personalscroce where SubjectGuid='{item.SubjectGuid}')";
                var dt = personalscroceManager.Db.Ado.GetDataTable(sql);
                int maxHistoryScore = 0;
                List<string> maxHistoryScoreName = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    maxHistoryScore = int.Parse(row[1].ToString());
                    maxHistoryScoreName.Add(row[0].ToString());

                }
                jObject["maxHistoryScoreName"] = string.Join("#", maxHistoryScoreName);
                jObject["maxHistoryScore"] = maxHistoryScore;

                jArray.Add(jObject);
            }

            //获取单位指标
            double power = jArray.Where(t => t["SubjectType"].ToString() == "力量").Average(t => double.Parse(t["ScoreAvg"].ToString()));
            double speed = jArray.Where(t => t["SubjectType"].ToString() == "速度").Average(t => double.Parse(t["ScoreAvg"].ToString()));
            double sensitivity = jArray.Where(t => t["SubjectType"].ToString() == "灵敏度").Average(t => double.Parse(t["ScoreAvg"].ToString()));
            double endurance = jArray.Where(t => t["SubjectType"].ToString() == "耐力").Average(t => double.Parse(t["ScoreAvg"].ToString()));
            double flexibility = jArray.Where(t => t["SubjectType"].ToString() == "柔韧性").Average(t => double.Parse(t["ScoreAvg"].ToString()));
           
            Dictionary<string, double> keyValuePairs = new Dictionary<string, double>();
            keyValuePairs.Add("力量", power);
            keyValuePairs.Add("速度", speed);
            keyValuePairs.Add("灵敏度", sensitivity);
            keyValuePairs.Add("耐力", endurance);
            keyValuePairs.Add("柔韧性", flexibility);

            string advanceSubject = keyValuePairs.Where(t => t.Value == keyValuePairs.Max(g => g.Value)).Select(t => t.Key).FirstOrDefault();
            string weakSubject = keyValuePairs.Where(t => t.Value == keyValuePairs.Min(g => g.Value)).Select(t => t.Key).FirstOrDefault();


            return new 
            { 
                data=jArray,
                power=Math.Round(power,1),
                speed =Math.Round(speed,1),
                sensitivity =Math.Round(sensitivity,1),
                endurance =Math.Round(endurance,1),
                flexibility = Math.Round(flexibility,1),
                advanceSubject = advanceSubject,
                weakSubject = weakSubject
            };
        }

        /// <summary>
        /// 获取成绩分布表
        /// </summary>
        /// <param name="department"></param>
        /// <param name="Level"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetSubjectDistribution(string department,string Level)
        {
            int flag = 0;
            JArray jArray = new JArray();
            for (int i = 0; i < 5; i++)
            {
                var temp = personalscroceManager.Db.Queryable<personalscroce, dicsubject, personalfiles>((t1, t2, t3) => t1.SubjectGuid == t2.Guid && t1.PGuid == t3.Guid).WhereIF(!string.IsNullOrEmpty(department), (t1, t2, t3) => t3.Department == department).WhereIF(!string.IsNullOrEmpty(Level), (t1, t2, t3) => t3.Level == Level).WhereIF(flag == 0, t1 => t1.Score > 0 && t1.Score < 60).WhereIF(flag == 1, t1 => t1.Score >= 60 && t1.Score < 70).WhereIF(flag == 2, t1 => t1.Score >= 70 && t1.Score < 80).WhereIF(flag == 3, t1 => t1.Score >= 80 && t1.Score < 90).WhereIF(flag == 4, t1 => t1.Score >= 90 && t1.Score <= 100).GroupBy(t1 => t1.SubjectGuid).Select((t1, t2, t3) => new { SubjectName = t2.SubjectName, Count = SqlFunc.AggregateCount(t1.Score), Flag = flag }).ToList();
                foreach (var item in temp)
                {
                    JObject jObject = new JObject();
                    jObject["SubjectName"] = item.SubjectName;
                    jObject["Count"] = item.Count;
                    jObject["Flag"] = item.Flag;
                    jArray.Add(jObject);
                }
                flag++;
            }           
            return jArray.GroupBy(t=>t["Flag"]).Select(t=>new { X = t.Key, Y = t });
        }

        /// <summary>
        /// 获取最近一次科目平均成绩
        /// </summary>
        /// <param name="department"></param>
        /// <param name="Level"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetLatesSubjectScore(string department,string Level)
        {
            DateTime? dateTime= personalscroceManager.CurrentDb.AsQueryable().OrderBy(t => t.AchieveDate, OrderByType.Desc).Select(t => t.AchieveDate).First();

            return personalscroceManager.Db.Queryable<personalscroce, dicsubject, personalfiles>((t1, t2, t3) => t1.SubjectGuid == t2.Guid && t1.PGuid == t3.Guid).WhereIF(!string.IsNullOrEmpty(department), (t1, t2, t3) => t3.Department == department).WhereIF(!string.IsNullOrEmpty(Level), (t1, t2, t3) => t3.Level == Level).Where((t1, t2, t3) => t1.AchieveDate == dateTime).GroupBy((t1, t2, t3) => t2.SubjectName).Select((t1, t2, t3) => new { SubjectName = t2.SubjectName, Avg = SqlFunc.AggregateAvg((double)(t1.Score)) }).ToList();
        }
    }
}