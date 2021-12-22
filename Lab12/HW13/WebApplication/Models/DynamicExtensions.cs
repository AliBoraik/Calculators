namespace WebApplication.Models
{
    public static class DynamicExtensions
    {
        public static TResult Execute<TResult>(this IParser<TResult> parser, dynamic input)
        {
            return parser.Parse(input).Compile().Invoke();
        }
    }
}