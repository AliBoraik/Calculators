namespace CalculatorF

open System
open CalculatorConstants

type ErrorBuilder() =

    member this.Bind(x, f) =
        match x with
        | Ok x -> f x
        | Error _ -> x

    member b.Combine(x, f) = f x

    member this.Return(x) = Ok x

module public MyCalculator =
    let SetError (error: string) = printfn $"%s{error}"

    let maybe = ErrorBuilder()

    let CheckNumber (a: String) =
        let t, _ = Decimal.TryParse a

        if t = true then
            Ok Ok_Code
        else
            SetError(NotIntegerErrorMassage)
            Error NumbersErrorCode
    let CheckNumberTwo (a: String, op: String) =
        let t, r = Decimal.TryParse a

        if op.Equals(Divide) && int r = 0 then
            SetError(DivideByZero)
            Error NumbersErrorCode
        else if t = true then
            Ok Ok_Code
        else
            SetError(NotIntegerErrorMassage)
            Error NumbersErrorCode        

    let CheckOperation (operation: String) =
        match operation with
        | Addition
        | Subtract
        | Multiply
        | Divide -> Ok Ok_Code
        | _ ->
            SetError(OperationErrorMassage)
            Error OperationErrorCode

    let Add (s1: string, s2: string) : int =
        let r = Decimal.Parse s1 + Decimal.Parse s2
        let result = "Result = " + r.ToString("G29")
        printfn $"{result}"
        Ok_Code

    let Sub (s1: string, s2: string) : int =
        let r = Decimal.Parse s1 - Decimal.Parse s2
        let result = "Result = " + r.ToString("G29")
        printfn $"{result}"
        Ok_Code

    let Mult (s1: string, s2: string) : int =
        let r = Decimal.Parse s1 * Decimal.Parse s2
        let result = "Result = " + r.ToString("G29")
        printfn $"{result}"
        Ok_Code

    let Div (s1: string, s2: string) : int =
        let r = Decimal.Parse s1 / Decimal.Parse s2
        let result = "Result = " + r.ToString("G29")
        printfn $"{result}"
        Ok_Code

    let Proces (n1: string, oper: string, n2: string) : int =
        match oper with
        | Addition -> Add(n1, n2)
        | Subtract -> Sub(n1, n2)
        | Multiply -> Mult(n1, n2)
        | Divide -> Div(n1, n2)
        | _ -> failwith "todo"

    let getCodeForReturn (n1: String, op: String, n2: String) : Result<int, int> =
        maybe {
            let! _num1 = CheckNumber n1
            let! _opr = CheckOperation op
            let! _num2 = CheckNumberTwo(n2,op)
            return Proces(n1, op, n2)
        }
