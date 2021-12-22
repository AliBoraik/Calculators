using System;
using System.Linq.Expressions;
using Sprache;

namespace WebApplication.Models
{
    public class ExpressionDynamic : IParser<double>
    {
        public Expression<Func<double>> Parse(dynamic input)
        {
            var result = Syntax.ParseLambda(new Input(input));

            if (!result.WasSuccessful) throw new Exception(result.Message);

            return result.Value;
        }
    }
}