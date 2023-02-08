using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpicification<T> : ISpecification<T>
    {
        public BaseSpicification(Expression<Func<T, bool>> criteria, List<Expression<Func<T, object>>> includes)
        {
            Criteria = criteria;
            Includes = includes;
        }
//updated2
        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = 
            new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);

        }
    }
}