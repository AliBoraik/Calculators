using System;
using System.Linq.Expressions;

namespace HW10.Models
{
    public interface IParser<TResult>
    {
        Expression<Func<TResult>> Parse(string input);
    }
}