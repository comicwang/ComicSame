using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("dicsubject")]
    public partial class dicsubject
    {
        public dicsubject()
        {


        }
        /// <summary>
        /// Desc:科目
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string SubjectName { get; set; }

        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string Guid { get; set; }

        /// <summary>
        /// Desc:科目类别
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string SubType { get; set; }
      
        public void Create()
        {
            this.Guid = System.Guid.NewGuid().ToString();
        }

    }
}
