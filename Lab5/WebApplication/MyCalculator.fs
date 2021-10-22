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
        let t, r = Decimal.TryParse a

        if t = true then
            Ok r
        else
            Error NotIntegerErrorMassage

    let CheckNumberTwo (a: String, op: String) =
        let t, r = Decimal.TryParse a

        if op.Equals(Divide) && int r = 0 then
            Error DivideByZero
        else if t = true then
            Ok r
        else
            Error NotIntegerErrorMassage

    let CheckOperation (operation: String, number_one: Decimal) =
        match operation with
        | Addition
        | Subtract
        | Multiply
        | Divide -> Ok number_one
        | _ -> Error OperationErrorMassage

    let Add (s1: Decimal, s2: Decimal) =
        let result = s1 + s2
        result

    let Sub (s1: Decimal, s2: Decimal) =
        let result = s1 - s2
        result

    let Mult (s1: Decimal, s2: Decimal) =
        let result = s1 * s2
        result

    let Div (s1: Decimal, s2: Decimal) =
        let result = s1 / s2
        result

    let Proces (n1: Decimal, oper: string, n2: Decimal) : Decimal =
        match oper with
        | Addition -> Add(n1, n2)
        | Subtract -> Sub(n1, n2)
        | Multiply -> Mult(n1, n2)
        | Divide -> Div(n1, n2)
        | _ -> failwith "todo"

    let getCodeForReturn (n1: String, op: String, n2: String) : Result<Decimal, String> =
        maybe {
            let! num1 = CheckNumber n1
            let! _opr = CheckOperation(op, num1)
            let! num2 = CheckNumberTwo(n2, op)
            return Proces(num1, op, num2)
        }
