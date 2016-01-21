namespace Probel.Mvvm.Toolkit.Tools
{
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class ExpressionExtensions
    {
        #region Methods

        public static MemberInfo GetMemberInfo(this Expression expression)
        {
            var lambda = (LambdaExpression)expression;

            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
                memberExpression = (MemberExpression)lambda.Body;

            return memberExpression.Member;
        }

        #endregion Methods
    }
}