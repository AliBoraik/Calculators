using System;
using System.Linq.Expressions;

namespace Calculator_ExpTrees.Models
{
    public interface IParser<TResult>
    {
        Expression<Func<TResult>> Parse(string input);
    }
}