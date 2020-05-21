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

        /// <summary>
        /// 获取个人军事成绩体能分析信息
        /// </summary>
        /// <param name="pguid">个人Guid</param>
        /// <returns></returns>
        [HttpGet]
        public object GetPersonAnalysisInfo(string pguid)
        {
            var pInfo = personalfilesManager.GetById(pguid);
            var dicInfo = dicsubjectManager.GetList();
            var dicSpeed = dicInfo.Where(d => d.SubType == "速度").Select(s => s.Guid);
            var dicPower = dicInfo.Where(d => d.SubType == "力量").Select(s => s.Guid);
            var dicsensitivity = dicInfo.Where(d => d.SubType == "灵敏度").Select(s => s.Guid);
            var dicendurance = dicInfo.Where(d => d.SubType == "耐力").Select(s => s.Guid);
            var dicflexibility = dicInfo.Where(d => d.SubType == "柔韧性").Select(s => s.Guid);
            var scoreInfo = personalscroceManager.GetList(t => t.PGuid == pguid && t.Score > 0);
            if (scoreInfo == null || scoreInfo.Count == 0)
                return "分析失败，请录入成绩信息";
            //获取各项指标信息
            //速度
            double speed = scoreInfo.Where(t =>dicSpeed.Contains(t.SubjectGuid)).Average(t => t.Score).Value;
            //力量
            double power = scoreInfo.Where(t => dicPower.Contains(t.SubjectGuid)).Average(t => t.Score).Value;
            //灵敏度
            double sensitivity = scoreInfo.Where(t => dicsensitivity.Contains(t.SubjectGuid)).Average(t => t.Score).Value;
            //耐力
            double endurance = scoreInfo.Where(t => dicendurance.Contains(t.SubjectGuid)).Average(t => t.Score).Value;
            //柔韧性
            double flexibility = scoreInfo.Where(t => dicflexibility.Contains(t.SubjectGuid)).Average(t => t.Score).Value;
            //塔山战力 各项指标平均值
            double fightCapacity = (speed + power + sensitivity + endurance + flexibility) / 5;
            //提升潜力  各项指标最大平均值-各项指标平均值+50
            var maxInfo= scoreInfo.GroupBy(t => t.SubjectGuid).Select(t => new { sguid = t.Key, max = t.Max(s => s.Score) });
            double maxSpeed= maxInfo.Where(t => dicSpeed.Contains(t.sguid)).Average(s => s.max).Value;
            double maxPower = maxInfo.Where(t => dicPower.Contains(t.sguid)).Average(s => s.max).Value;
            double maxsensitivity = maxInfo.Where(t => dicsensitivity.Contains(t.sguid)).Average(s => s.max).Value;
            double maxendurance = maxInfo.Where(t => dicendurance.Contains(t.sguid)).Average(s => s.max).Value;
            double maxflexibility = maxInfo.Where(t => dicflexibility.Contains(t.sguid)).Average(s => s.max).Value;
            //提升潜力
            double promoteCapacity = (maxSpeed + maxPower + maxsensitivity + maxendurance + maxflexibility) / 5 - fightCapacity + 50;
            //成长值  (各项指标最大值-各项指标最小值（非0）)/指标数
            double grow = scoreInfo.GroupBy(g => g.SubjectGuid).Select(t => new { sguid = t.Key, grow = (t.Max(m => m.Score) - t.Min(i => i.Score)) }).Average(a => a.grow).Value;
            //坚持指数  绝对值（各项指标的数据-各项指标的平均值）>5为0，否则20*其值，然后求平均
            var averageInfo = scoreInfo.GroupBy(t => t.SubjectGuid).Select(t => new { sguid = t.Key, av = t.Average(s => s.Score) });
            double insis = scoreInfo.Select(t => new { guid = t.Guid, sguid = t.SubjectGuid, insist = Math.Abs((int)(t.Score - (int)(averageInfo.Where(a => a.sguid == t.SubjectGuid).Select(s => s.av).FirstOrDefault()))) }).Where(t => t.insist < 5).GroupBy(t => t.sguid).Select(s => new { sguid = s.Key, av = s.Average(a => a.insist * 20) }).Average(t => t.av);

            return new
            {
                pInfo = pInfo,  //个人信息
                speed =Math.Round(speed,0),  //速度
                power = Math.Round(power, 0),  //力量
                sensitivity = Math.Round(sensitivity, 0), //灵敏度
                endurance = Math.Round(endurance, 0), //耐力
                flexibility = Math.Round(flexibility, 0),  //柔韧性
                fightCapacity = Math.Round(fightCapacity, 0),  //塔山战力
                promoteCapacity = Math.Round(promoteCapacity, 0), //提示潜力
                grow = Math.Round(grow, 0), //成长值
                insis = Math.Round(insis,0) //坚持指数
            };
        }

        /// <summary>
        /// 获取个人成绩排名
        /// </summary>
        /// <param name="pguid">个人GUID</param>
        /// <returns></returns>
        [HttpGet]
        public object GetLatesRank(string pguid)
        {
            var pInfo = personalfilesManager.GetById(pguid);
            var dicInfo = dicsubjectManager.GetList();
            var scoreInfo = personalscroceManager.GetList(t => t.PGuid == pguid && t.Score > 0);
            //最佳成绩
            int maxScore= scoreInfo.GroupBy(t => t.AchieveDate).Select(t => t.Sum(s => s.Score)).Max().Value;
            //个人弱项科目及其平均成绩
            var weakest= scoreInfo.GroupBy(t => t.SubjectGuid).Select(t => new { sguid = t.Key, av = t.Average(s => s.Score) });
            double weakScore = weakest.Min(t => t.av).Value;
            string weakSubject = string.Join("#", dicInfo.Where(t => weakest.Where(s => s.av.Value == weakScore).Select(s => s.sguid).Contains(t.Guid)).Select(t => t.SubjectName));
            //运动建议（根据最弱科目类型输出模板）
            string weakType = dicInfo.Where(t => weakest.Where(s => s.av.Value == weakScore).Select(s => s.sguid).Contains(t.Guid)).Select(t => t.SubType).FirstOrDefault();
            string sportSuggest = string.Empty;
            switch (weakType)
            {
                case "速度":
                    sportSuggest = "建议加强速度性训练，多参加百米冲刺、接力跑、蛙跳等下肢力量课目的练习，运动后注意及时放松；";
                    break;
                case "力量":
                    sportSuggest = "建议多进行力量性的训练，如原地的俯卧撑，双腿深蹲等，借助器材如哑铃，臂力器等器械，每晚坚持3个100等内容的训练；";
                    break;
                case "耐力":
                    sportSuggest = "建议加强耐力训练，进行如五千米长跑，十公里长跑等训练，每日可进行1 - 3分钟的潜水闭气训练，增强肺活量；	";
                    break;
                case "柔韧性":
                    sportSuggest = "建议在每次训练前进行五到十分钟的热身活动，训练结束后利用士到十五分钟进行韧带拉伸运动，包括有下肢韧带拉伸、上肢韧带拉伸、颈部腰部等部位韧带拉伸，拉伸同时不可用力过猛，以免受伤；";
                    break;
                case "灵敏度":
                    sportSuggest = "建议进行灵敏度训练，如30m * 2折返跑、格斗等，多参加球类等运动项目，增强自身灵敏程度；";
                    break;
                default:
                    break;
            }
            //速度	建议加强速度性训练，多参加百米冲刺、接力跑、蛙跳等下肢力量课目的练习，运动后注意及时放松；																			
            //力量 建议多进行力量性的训练，如原地的俯卧撑，双腿深蹲等，借助器材如哑铃，臂力器等器械，每晚坚持3个100等内容的训练；																			
            //耐力 建议加强耐力训练，进行如五千米长跑，十公里长跑等训练，每日可进行1 - 3分钟的潜水闭气训练，增强肺活量；																			
            //柔韧性 建议在每次训练前进行五到十分钟的热身活动，训练结束后利用士到十五分钟进行韧带拉伸运动，包括有下肢韧带拉伸、上肢韧带拉伸、颈部腰部等部位韧带拉伸，拉伸同时不可用力过猛，以免受伤；	

            //灵敏度 建议进行灵敏度训练，如30m * 2折返跑、格斗等，多参加球类等运动项目，增强自身灵敏程度；		

            //饮食建议（根据BMI计算）
            //胖 你太胖了！注意控制饮食，多吃蔬菜水果，避免过量食用高热量、高蛋白、糖分多的食物，建议每次饭前先喝汤或吃水果在进食，同时加强体育锻炼，早晚有一天你会瘦成一道省电！！（PS：那是不存在的）；					
            //中 很完美！注意保持，应注意不要过多食用高热量的食物，注意加强体育锻炼，塑造健美身形，撩妹什么的都不在话下（PS：前提你得先有一身傲人的肌肉）					
            //瘦 太瘦了！注意加强锻炼身体，运动后及时补充蛋白质，氨基酸等营养（PS: 就是大米饭，肉，蔬菜等食物，其他什么高大上的不存在），早睡早起身体好！				
            string eatSuggest = string.Empty;
            if (pInfo.BMI >= 30) //胖
                eatSuggest = "你太胖了！注意控制饮食，多吃蔬菜水果，避免过量食用高热量、高蛋白、糖分多的食物，建议每次饭前先喝汤或吃水果在进食，同时加强体育锻炼，早晚有一天你会瘦成一道省电！！（PS：那是不存在的）；";
            else if (pInfo.BMI < 30 && pInfo.BMI >= 20)
                eatSuggest = "很完美！注意保持，应注意不要过多食用高热量的食物，注意加强体育锻炼，塑造健美身形，撩妹什么的都不在话下（PS：前提你得先有一身傲人的肌肉）";
            else
                eatSuggest = "太瘦了！注意加强锻炼身体，运动后及时补充蛋白质，氨基酸等营养（PS: 就是大米饭，肉，蔬菜等食物，其他什么高大上的不存在），早睡早起身体好！";

            //计算排名
            string whersql = $"and t1.Brigade='{pInfo.Brigade}'";
            string sumsql = $"select PGuid,MAX(Score) as Score from (select g.PGuid as PGuid,g.AchieveDate as AchieveDate,Sum(g.Score) as Score from (select t.PGuid,t.Score,t.AchieveDate from personalscroce t JOIN personalfiles t1 ON t.PGuid=t1.Guid {whersql}) g GROUP BY g.PGuid,g.AchieveDate) s GROUP BY PGuid ORDER BY Score desc";
           
            //旅排名
            int BrigadeRank = personalscroceManager.Db.Ado.GetInt($"SELECT Rank from (SELECT PGuid,Score,(SELECT COUNT(DISTINCT Score) from ({sumsql}) m where m.Score>=l.Score) Rank from ({sumsql}) l) k WHERE PGuid='{pguid}'");

            //营排名
            whersql= $"and t1.Brigade='{pInfo.Camp}' and t1.Brigade='{pInfo.Brigade}'";
            int CampRank= personalscroceManager.Db.Ado.GetInt($"SELECT Rank from (SELECT PGuid,Score,(SELECT COUNT(DISTINCT Score) from ({sumsql}) m where m.Score>=l.Score) Rank from ({sumsql}) l) k WHERE PGuid='{pguid}'");

            //连排名
            whersql = $"and t1.Brigade='{pInfo.Even}' and t1.Brigade='{pInfo.Camp}' and t1.Brigade='{pInfo.Brigade}'";
            int EvenRank = personalscroceManager.Db.Ado.GetInt($"SELECT Rank from (SELECT PGuid,Score,(SELECT COUNT(DISTINCT Score) from ({sumsql}) m where m.Score>=l.Score) Rank from ({sumsql}) l) k WHERE PGuid='{pguid}'");

            //级别
            string Level = string.Empty;
            if (BrigadeRank<=10)
            {
                Level = "一级";
            }
            else if (CampRank <= 10)
            {
                Level = "二级";
            }
            else if(EvenRank<=10)
            {
                Level = "三级";
            }
            else
            {
                Level = "四级";
            }

            return new
            {
                EvenRank = EvenRank,  //连排名
                CampRank = CampRank, //营排名
                BrigadeRank = BrigadeRank, //旅排名
                Level = Level, //级别
                maxScore = maxScore, //个人最佳成绩
                weakSubject = weakSubject, //个人弱科项目
                weakScore = weakScore, //个人弱科项目均分
                sportSuggest = sportSuggest, //运动建议
                eatSuggest = eatSuggest //饮食建议
            };
        }

        /// <summary>
        /// 获取近十次个人运动记录
        /// </summary>
        /// <param name="pguid">个人guid</param>
        /// <param name="subguid">科目guid</param>
        /// <returns></returns>
        public object GetSportRecord(string pguid, string subguid)
        {
            var pInfo = personalfilesManager.GetById(pguid);
            //获取近十次考核时间
            List<DateTime?> dateTimes = personalscroceManager.CurrentDb.AsQueryable().GroupBy(t=>t.AchieveDate).Where(t => t.SubjectGuid == subguid).OrderBy(t => t.AchieveDate, OrderByType.Desc).Select(t =>t.AchieveDate).ToPageList(1, 11);  //最后一次单次名次需要上次成绩，故为11
            var scoreInfo = personalscroceManager.CurrentDb.AsQueryable().Where(t => t.PGuid == pguid && t.SubjectGuid == subguid).OrderBy(t => t.AchieveDate, OrderByType.Desc).ToPageList(1, 11);
            List<personalscroce> result = new List<personalscroce>();
            //获取今年第一次考试分数
            DateTime startDate = new DateTime(dateTimes.Min().Value.Year, 1, 1);
            DateTime endDate = new DateTime(dateTimes.Max().Value.Year, 12, 31);
            int firstScore = personalscroceManager.CurrentDb.AsQueryable().Where(t => t.SubjectGuid == subguid && t.PGuid == pguid && t.AchieveDate >= startDate && t.AchieveDate <= endDate).OrderBy(t => t.AchieveDate, OrderByType.Asc).Select(t => t.Score).First().Value;

            //获取今年第一次考试旅排名
            string whersql = $"and t1.Brigade='{pInfo.Brigade}' and t.SubjectGuid='{subguid}' and t.AchieveDate >= '{dateTimes.Min().Value.Year}-1-1' and t.AchieveDate <= '{dateTimes.Max().Value.Year}-12-31'";
            string sumsql = $"select PGuid,MAX(Score) as Score from (select g.PGuid as PGuid,g.AchieveDate as AchieveDate,Sum(g.Score) as Score from (select t.PGuid,t.Score,t.AchieveDate from personalscroce t JOIN personalfiles t1 ON t.PGuid=t1.Guid {whersql}) g GROUP BY g.PGuid,g.AchieveDate) s GROUP BY PGuid ORDER BY Score desc";
            int firstBrigadeRank = personalscroceManager.Db.Ado.GetInt($"SELECT Rank from (SELECT PGuid,Score,(SELECT COUNT(DISTINCT Score) from ({sumsql}) m where m.Score>=l.Score) Rank from ({sumsql}) l) k WHERE PGuid='{pguid}'");

            foreach (var date in dateTimes)
            {
                var temp = scoreInfo.Where(t => t.AchieveDate.Value == date.Value).FirstOrDefault();
                if (temp == null)
                {
                    temp = new personalscroce()
                    {
                        AchieveDate = date,
                        Score = 0
                    };
                }
                else
                {
                    //获取旅排名
                    whersql = $"and t1.Brigade='{pInfo.Brigade}' and t.SubjectGuid='{subguid}' and t.AchieveDate = '{date.Value.ToString("yyyy-MM-dd")}'";
                    sumsql = $"select PGuid,MAX(Score) as Score from (select g.PGuid as PGuid,g.AchieveDate as AchieveDate,Sum(g.Score) as Score from (select t.PGuid,t.Score,t.AchieveDate from personalscroce t JOIN personalfiles t1 ON t.PGuid=t1.Guid {whersql}) g GROUP BY g.PGuid,g.AchieveDate) s GROUP BY PGuid ORDER BY Score desc";

                    //旅排名
                    int BrigadeRank = personalscroceManager.Db.Ado.GetInt($"SELECT Rank from (SELECT PGuid,Score,(SELECT COUNT(DISTINCT Score) from ({sumsql}) m where m.Score>=l.Score) Rank from ({sumsql}) l) k WHERE PGuid='{pguid}'");
                    temp.Rank = BrigadeRank;
                }
                temp.Evaluate = GetEvaluate(temp.Score.Value);  //评定
                temp.YearProScore = temp.Score.Value - firstScore; //年度进步分数
                temp.YearProRank = temp.Rank - firstBrigadeRank; //年度进步名次
                result.Add(temp);
            }

            //计算单次进步名次
            for (int i = 0; i < 10; i++)
            {
                result[i].CurrentProScore = (result[i].Score - result[i + 1].Score).Value;
                result[i].CurrentProRank = result[i].Rank - result[i + 1].Rank;
            }
            return result;
        }

        /// <summary>
        /// 获取评定
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        private string GetEvaluate(int score)
        {
            if (score >= 90)
                return "优秀";
            else if (score < 90 && score >= 80)
                return "良好";
            else if (score < 80 && score >= 60)
                return "及格";
            else if (score > 0)
                return "未及格";
            else
                return "缺考";
        }
    }
}