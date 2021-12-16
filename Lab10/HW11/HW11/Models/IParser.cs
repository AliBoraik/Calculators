using System;
using System.Linq.Expressions;

namespace HW11.Models
{
    public interface IParser<TResult>
    {
        Expression<Func<TResult>> Parse(dynamic input);
    }
}