module Tests

open Xunit
open CalculatorF.MyCalculator

[<Fact>]
let ``My test`` () = Assert.True(true)

[<Theory>]
[<InlineData("2", "+", "4", "6")>]
[<InlineData("12", "-", "4", "8")>]
[<InlineData("14", "*", "4", "56")>]
[<InlineData("21", "/", "3", "7")>]
let TestProces_ProcesMethod_ReturnResult (n1: string, operation: string, n2: string, result: string) =
    Assert.Equal(Proces(n1, operation, n2), result)

[<Theory>]
[<InlineData("2", "2", "4")>]
[<InlineData("2", "12", "14")>]
[<InlineData("22134567809876543", "123456789876543", "22258024599753086")>]
let TestClaculator_AddMethod_ReturnSum (n1: string, n2: string, result: string) = Assert.Equal(Add(n1, n2), result)

[<Theory>]
[<InlineData("2", "2", "1")>]
[<InlineData("4", "2", "2")>]
[<InlineData("1000", "2", "500")>]
let TestClaculator_DivMethod_ReturnDiv (n1: string, n2: string, result: string) = Assert.Equal(Div(n1, n2), result)
