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
        /// Desc:科目
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Subject { get; set; }

        /// <summary>
        /// Desc:科目类型
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
        /// Desc:得分
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Score { get; set; }

        public void Create()
        {
            this.Guid = System.Guid.NewGuid().ToString();
        }

    }
}
