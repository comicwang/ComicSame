using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("personalscroce")]
    public partial class personalscroce
    {
        public personalscroce()
        {


        }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string Guid { get; set; }

        /// <summary>
        /// Desc:人员主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string PGuid { get; set; }

        /// <summary>
        /// Desc:科目名称（存留原名称）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Subject { get; set; }

        /// <summary>
        /// Desc:科目类型（存留原类别）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string SubjectType { get; set; }

        /// <summary>
        /// Desc:考试时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? AchieveDate { get; set; }

        /// <summary>
        /// Desc:科目
        /// Default:
        /// Nullable:True
        /// </summary>
        public string SubjectGuid { get; set; }

        /// <summary>
        /// Desc:得分
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Score { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(IsIgnore =true)]
        public string Name { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string Department { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string Duty { get; set; }

        /// <summary>
        /// 评定
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string Evaluate { get; set; }

        /// <summary>
        /// 排名
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int Rank { get; set; }

        /// <summary>
        /// 单次进步分数
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int CurrentProScore { get; set; }

        /// <summary>
        /// 单次进步名次
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int CurrentProRank { get; set; }

        /// <summary>
        /// 年度进步分数
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int YearProScore { get; set; }

        /// <summary>
        /// 年度进步名次
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int YearProRank { get; set; }

        public void Create()
        {
            this.Guid = System.Guid.NewGuid().ToString();
        }

    }
}
