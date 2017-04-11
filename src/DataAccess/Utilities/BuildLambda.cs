using System;
using System.Linq.Expressions;

namespace DataAccess.Utilities
{
    public static class BuildLambda
    {
        public static Expression<Func<TEntity, bool>> ForFindById<TEntity>(int id)
        {
            ParameterExpression item = Expression.Parameter(typeof(TEntity), "entity");
            MemberExpression prop = Expression.Property(item, typeof(TEntity).Name + "Id");
            ConstantExpression value = Expression.Constant(id);
            BinaryExpression equal = Expression.Equal(prop, value);
            Expression<Func<TEntity, bool>> lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }
    }
}
