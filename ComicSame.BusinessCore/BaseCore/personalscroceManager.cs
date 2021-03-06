﻿using Sugar.Enties;
using SqlSugar;
using System;
using System.Collections.Generic;
public class personalscroceManager : DbContext<personalscroce>
{

    //当前类已经继承了 DbContext增、删、查、改的方法

    //这里面写的代码不会给覆盖,如果要重新生成请删除 personalscroceManager.cs

    /// <summary>
    /// 查询成绩信息
    /// </summary>
    /// <param name="department"></param>
    /// <param name="name"></param>
    /// <param name="pid"></param>
    /// <param name="subject"></param>
    /// <param name="dateBegin"></param>
    /// <param name="dateEnd"></param>
    /// <returns></returns>
    public List<personalscroce> GetPersonalscroces(string department,string name,string pid,string subject,DateTime? dateBegin,DateTime? dateEnd)
    {
        var expression = LinqExpression.True<personalscroce>();
        List<IConditionalModel> conModels = new List<IConditionalModel>();
        //人员ID
        if (!string.IsNullOrEmpty(pid))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName= "PGuid",
                FieldValue=pid,
                ConditionalType=ConditionalType.Equal
            });
            expression = expression.And(t => t.PGuid.Equals(pid));
        }
        //人员名称
        if (!string.IsNullOrEmpty(name))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "Name",
                FieldValue = name,
                ConditionalType = ConditionalType.Like
            });
            expression = expression.And(t => t.PGuid.Equals(pid));
        }
        //单位
        if (!string.IsNullOrEmpty(department))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "Department",
                FieldValue = department,
                ConditionalType = ConditionalType.Like
            });
            expression = expression.And(t => t.PGuid.Equals(pid));
        }
        //人员ID
        if (!string.IsNullOrEmpty(pid))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "PGuid",
                FieldValue = pid,
                ConditionalType = ConditionalType.Equal
            });
            expression = expression.And(t => t.PGuid.Equals(pid));
        }
        //科目GUID
        if (!string.IsNullOrEmpty(subject))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "SubjectGuid",
                FieldValue = subject,
                ConditionalType = ConditionalType.Equal
            });
            expression = expression.And(t => t.Subject.Equals(subject));
        }
        //考试日期开始
        if (dateBegin.HasValue)
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "AchieveDate",
                FieldValue = dateBegin.Value.ToString("yyyy-MM-dd"),
                ConditionalType = ConditionalType.GreaterThanOrEqual,
                FieldValueConvertFunc = t => { return DateTime.Parse(t); }
            });
            expression = expression.And(t => t.AchieveDate.Value >= dateBegin);
        }
        //考试日期结束
        if (dateEnd.HasValue)
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "AchieveDate",
                FieldValue = dateEnd.Value.ToString("yyyy-MM-dd"),
                ConditionalType = ConditionalType.LessThanOrEqual,
                FieldValueConvertFunc = t => { return DateTime.Parse(t); }
            });
            expression = expression.And(t => t.AchieveDate.Value >= dateEnd);
        }

        return Db.Queryable<personalscroce, personalfiles,dicsubject>((t1, t2,t3) => t1.PGuid == t2.Guid&&t3.Guid==t1.SubjectGuid).Where(conModels).OrderBy((t1, t2,t3) => new { t2.Name, t1.AchieveDate }, OrderByType.Asc).Select((t1, t2,t3) => new personalscroce { AchieveDate = t1.AchieveDate, Guid = t1.Guid, PGuid = t1.PGuid, Subject = t3.SubjectName, Score = t1.Score, SubjectType = t3.SubType, Name = t2.Name,SubjectGuid=t3.Guid,Department=t2.Department,Duty=t2.Duty }).ToList();
    }

    /// <summary>
    /// 查询成绩信息
    /// </summary>
    /// <param name="department"></param>
    /// <param name="name"></param>
    /// <param name="pid"></param>
    /// <param name="subject"></param>
    /// <param name="dateBegin"></param>
    /// <param name="dateEnd"></param>
    /// <returns></returns>
    public List<personalscroce> GetPagePersonalscroces(PageModel pageModel, string department, string name, string pid, string subject, DateTime? dateBegin, DateTime? dateEnd, string orderby = null)
    {
        var expression = LinqExpression.True<personalscroce>();
        List<IConditionalModel> conModels = new List<IConditionalModel>();
        //人员ID
        if (!string.IsNullOrEmpty(pid))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "PGuid",
                FieldValue = pid,
                ConditionalType = ConditionalType.Equal
            });
            expression = expression.And(t => t.PGuid.Equals(pid));
        }
        //人员名称
        if (!string.IsNullOrEmpty(name))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "Name",
                FieldValue = name,
                ConditionalType = ConditionalType.Like
            });
            expression = expression.And(t => t.PGuid.Equals(pid));
        }
        //单位
        if (!string.IsNullOrEmpty(department))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "Department",
                FieldValue = department,
                ConditionalType = ConditionalType.Like
            });
            expression = expression.And(t => t.PGuid.Equals(pid));
        }
        //人员ID
        if (!string.IsNullOrEmpty(pid))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "PGuid",
                FieldValue = pid,
                ConditionalType = ConditionalType.Equal
            });
            expression = expression.And(t => t.PGuid.Equals(pid));
        }
        //科目GUID
        if (!string.IsNullOrEmpty(subject))
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "SubjectGuid",
                FieldValue = subject,
                ConditionalType = ConditionalType.Equal
            });
            expression = expression.And(t => t.Subject.Equals(subject));
        }
        //考试日期开始
        if (dateBegin.HasValue)
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "AchieveDate",
                FieldValue = dateBegin.Value.ToString("yyyy-MM-dd"),
                ConditionalType = ConditionalType.GreaterThanOrEqual,
                FieldValueConvertFunc = t => { return DateTime.Parse(t); }
            });
            expression = expression.And(t => t.AchieveDate.Value >= dateBegin);
        }
        //考试日期结束
        if (dateEnd.HasValue)
        {
            conModels.Add(new ConditionalModel()
            {
                FieldName = "AchieveDate",
                FieldValue = dateEnd.Value.ToString("yyyy-MM-dd"),
                ConditionalType = ConditionalType.LessThanOrEqual,
                FieldValueConvertFunc = t => { return DateTime.Parse(t); }
            });
            expression = expression.And(t => t.AchieveDate.Value >= dateEnd);
        }
        int pageCount = 0;
        bool isorder = !string.IsNullOrEmpty(orderby);
        var result = Db.Queryable<personalscroce, personalfiles, dicsubject>((t1, t2, t3) => t1.PGuid == t2.Guid && t3.Guid == t1.SubjectGuid).Where(conModels).OrderByIF(isorder, orderby).Select((t1, t2, t3) => new personalscroce { AchieveDate = t1.AchieveDate, Guid = t1.Guid, PGuid = t1.PGuid, Subject = t3.SubjectName, Score = t1.Score, SubjectType = t3.SubType, Name = t2.Name, SubjectGuid = t3.Guid, Department = t2.Department, Duty = t2.Duty }).ToPageList(pageModel.PageIndex, pageModel.PageSize, ref pageCount);
        pageModel.PageCount = pageCount;
        return result;
    }

    #region 教学方法
    /// <summary>
    /// 如果DbContext中的增删查改方法满足不了你，你可以看下具体用法
    /// </summary>
    public void Study()
    {
	     
	   /*********查询*********/

        var data1 = personalscroceDb.GetById(1);//根据ID查询
        var data2 = personalscroceDb.GetList();//查询所有
        var data3 = personalscroceDb.GetList(it => 1 == 1);  //根据条件查询  
        //var data4 = personalscroceDb.GetSingle(it => 1 == 1);//根据条件查询一条,如果超过一条会报错

        var p = new PageModel() { PageIndex = 1, PageSize = 2 };// 分页查询
        var data5 = personalscroceDb.GetPageList(it => 1 == 1, p);
        Console.Write(p.PageCount);//返回总数

        var data6 = personalscroceDb.GetPageList(it => 1 == 1, p, it => SqlFunc.GetRandom(), OrderByType.Asc);// 分页查询加排序
        Console.Write(p.PageCount);//返回总数
     
        List<IConditionalModel> conModels = new List<IConditionalModel>(); //组装条件查询作为条件实现 分页查询加排序
        conModels.Add(new ConditionalModel() { FieldName = typeof(personalscroce).GetProperties()[0].Name, ConditionalType = ConditionalType.Equal, FieldValue = "1" });//id=1
        var data7 = personalscroceDb.GetPageList(conModels, p, it => SqlFunc.GetRandom(), OrderByType.Asc);

        personalscroceDb.AsQueryable().Where(x => 1 == 1).ToList();//支持了转换成queryable,我们可以用queryable实现复杂功能

        //我要用事务
        var result = Db.Ado.UseTran(() =>
         {
            //写事务代码
        });
        if (result.IsSuccess)
        {
            //事务成功
        }

        //多表查询地址 http://www.codeisbug.com/Doc/8/1124



        /*********插入*********/
        var insertData = new personalscroce() { };//测试参数
        var insertArray = new personalscroce[] { insertData };
        personalscroceDb.Insert(insertData);//插入
        personalscroceDb.InsertRange(insertArray);//批量插入
        var id = personalscroceDb.InsertReturnIdentity(insertData);//插入返回自增列
        personalscroceDb.AsInsertable(insertData).ExecuteCommand();//我们可以转成 Insertable实现复杂插入



		/*********更新*********/
	    var updateData = new personalscroce() {  };//测试参数
        var updateArray = new personalscroce[] { updateData };//测试参数
        personalscroceDb.Update(updateData);//根据实体更新
        personalscroceDb.UpdateRange(updateArray);//批量更新
        //personalscroceDb.Update(it => new personalscroce() { Name = "a", CreateTime = DateTime.Now }, it => it.id==1);// 只更新Name列和CreateTime列，其它列不更新，条件id=1
        personalscroceDb.AsUpdateable(updateData).ExecuteCommand();



		/*********删除*********/
	    var deldata = new personalscroce() {  };//测试参数
        personalscroceDb.Delete(deldata);//根据实体删除
        personalscroceDb.DeleteById(1);//根据主键删除
        personalscroceDb.DeleteById(new int[] { 1,2});//根据主键数组删除
        personalscroceDb.Delete(it=>1==2);//根据条件删除
        personalscroceDb.AsDeleteable().Where(it=>1==2).ExecuteCommand();//转成Deleteable实现复杂的操作
    } 
    #endregion

 
 
}