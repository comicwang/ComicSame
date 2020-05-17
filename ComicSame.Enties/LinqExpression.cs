using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public static class LinqExpression
{
    public static Expression<Func<T, bool>> True<T>()
    {
        return t => true;
    }

    public static Expression<Func<T, bool>> False<T>()
    {
        return t => false;
    }

    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> sencond)
    {
        var invokedExpr = Expression.Invoke(sencond, first.Parameters.Cast<Expression>());
        return Expression.Lambda<Func<T, bool>>
              (Expression.And(first.Body, invokedExpr), first.Parameters);
    }

    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> sencond)
    {
        var invokedExpr = Expression.Invoke(sencond, first.Parameters.Cast<Expression>());
        return Expression.Lambda<Func<T, bool>>
              (Expression.Or(first.Body, invokedExpr), first.Parameters);
    }
}

