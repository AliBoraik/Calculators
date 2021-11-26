using System;
using System.Linq.Expressions;
using Sprache;

namespace Calculator_ExpTrees.Models
{
    public class ExpressionParser : IParser<double>
    {
        public Expression<Func<double>> Parse(string input)
        {
            var result = Syntax.ParseLambda(new Input(input));

            if (!result.WasSuccessful) throw new Exception(result.Message);

            return result.Value;
        }
    }
}