using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CtorArgumentChecker.Extensions
{
    public static class GenericExtensions
    {
        public static void ThrowArgumentNullException<T>(this T parameter, string parameterName)
            where T : class
        {
            if (parameter is null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static TProperty GetProperty<T, TProperty>(this T source, Expression<Func<T, TProperty>> expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression is null)
            {
                throw new ArgumentException(nameof(memberExpression));
            }

            var memberInfo = memberExpression.Member;
            if (memberInfo is null)
            {
                throw new ArgumentException(nameof(memberInfo));
            }

            var function = expression.Compile();
            return function.Invoke(source);
        }

    }
}
