using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FPTest.CodeAndData
{
    class ConvertToSql
    {
        public static string ConvertExpressToTSQL(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    return ConvertLambdaExpressionToTSQL((LambdaExpression)expression);
                case ExpressionType.Call:
                    return ConvertMethodCallExpressionToTSQL((MethodCallExpression)expression);
                case ExpressionType.Constant:
                    return ConvertConstantExpressionToTSQL((ConstantExpression)expression);
                case ExpressionType.MemberAccess:
                    return ConvertMemberExpressionToTSQL((MemberExpression)expression);
                default:
                    return "Unsupported expression type";
            }
        }

        static string ConvertLambdaExpressionToTSQL(LambdaExpression lambdaExpression)
        {
            return ConvertExpressToTSQL(lambdaExpression.Body);
        }

        static string ConvertMethodCallExpressionToTSQL(MethodCallExpression methodCallExpression)
        {
            var stringContainsMethodInfo = typeof(string).GetMethod("Contains");
            if (methodCallExpression.Method == stringContainsMethodInfo)
            {
                return
                    $"CHARINDEX(\"{ConvertExpressToTSQL(methodCallExpression.Arguments[0])}\", {ConvertExpressToTSQL(methodCallExpression.Object)}) > 0";
            }
            return ConvertUnknownMethodCallExpressionToTSQL(methodCallExpression.Method.Name,
                methodCallExpression.Arguments);
        }

        static string ConvertConstantExpressionToTSQL(ConstantExpression constantExpression)
        {
            return constantExpression.Value.ToString();
        }

        static string ConvertMemberExpressionToTSQL(MemberExpression memberExpression)
        {
            return memberExpression.Member.Name;
        }

        private static string ConvertUnknownMethodCallExpressionToTSQL(string methodName, ReadOnlyCollection<Expression> methodArguments)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UnsupportedMethod{0}(", methodName);
            bool firstArg = true;
            foreach (var argument in methodArguments)
            {
                if (!firstArg)
                {
                    sb.Append(",");
                }
                else
                {
                    firstArg = false;
                }
                sb.Append(ConvertExpressToTSQL(argument));
            }
            sb.Append(")");
            return sb.ToString();
        }
    }
}
