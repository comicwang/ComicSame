using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("personalfiles")]
    public partial class personalfiles
    {
        public personalfiles()
        {


        }
        /// <summary>
        /// Desc:名字
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string Guid { get; set; }

        /// <summary>
        /// Desc:部门
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Department { get; set; }

        /// <summary>
        /// Desc:职务
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Duty { get; set; }

        /// <summary>
        /// Desc:公司
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Company { get; set; }

        /// <summary>
        /// Desc:级别（军衔）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Level { get; set; }

        /// <summary>
        /// Desc:出生年月
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? BrithDate { get; set; }

        /// <summary>
        /// Desc:年龄
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Age { get; set; }

        /// <summary>
        /// Desc:入伍年月
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? EnlistedDate { get; set; }

        /// <summary>
        /// Desc:政治面貌
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string PoliticalFace { get; set; }

        /// <summary>
        /// Desc:文化程度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Education { get; set; }

        /// <summary>
        /// Desc:民族
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Nation { get; set; }

        /// <summary>
        /// Desc:籍贯
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string NavtivePlace { get; set; }

        /// <summary>
        /// Desc:身高
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double? Height { get; set; }

        /// <summary>
        /// Desc:体重
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Weight { get; set; }

        /// <summary>
        /// Desc:胸围
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Bust { get; set; }

        /// <summary>
        /// Desc:腰围
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Waist { get; set; }

        /// <summary>
        /// Desc:体重指数
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double? BMI { get; set; }

        /// <summary>
        /// Desc:体脂百分比（%）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double? PBF { get; set; }

        /// <summary>
        /// Desc:二维码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public byte[] QRCode { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Desc:修改时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? ModyfiedDate { get; set; }


        public void Create()
        {
            this.Guid = System.Guid.NewGuid().ToString();
        }

    }
}
