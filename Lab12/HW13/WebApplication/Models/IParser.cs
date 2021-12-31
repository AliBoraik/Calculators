using System;
using System.Linq.Expressions;

namespace WebApplication.Models
{
    public interface IParser<TResult>
    {
        Expression<Func<TResult>> Parse(dynamic input);
    }
}