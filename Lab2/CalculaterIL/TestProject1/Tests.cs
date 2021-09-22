using System;
using Xunit;

namespace TestProject1
{
    public class Tests
    {
        [Theory]
        [InlineData(new []{"3"+"+"+"3"},"0")]
        [InlineData(new []{"3"+"-"+"3"},"0")]
        [InlineData(new []{"3"+"*"+"3"},"0")]
        [InlineData(new []{"3"+"/"+"3"},"0")]
        public static void TestMain_Result_Main(string[] args,int restult)
        {
            Assert.Equal(restult,CalculaterIL.Program.Main(args));
        }
        
        [Theory]
        [InlineData(new []{"3"+"&"+"3"},"1")]
        [InlineData(new []{"dfg"+"-"+"3"},"1")]
        [InlineData(new []{"3"+"*"+"hbgvf"},"1")]
        [InlineData(new []{"3"+" "+"3"},"1")]
        public static void TestMain_ReturmOne(string[] args,int restult)
        {
            Assert.Equal(restult,CalculaterIL.Program.Main(args));
        }
    }
}