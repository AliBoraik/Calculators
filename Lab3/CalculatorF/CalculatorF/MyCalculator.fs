namespace CalculatorF

open System
open System.Numerics
open CalculatorConstants

module public MyCalculator =

    let Add (s1: string, s2: string) : string =
        BigInteger
            .Add(BigInteger.Parse(s1), BigInteger.Parse(s2))
            .ToString()

    let Sub (s1: string, s2: string) : string =
        BigInteger
            .Subtract(BigInteger.Parse(s1), BigInteger.Parse(s2))
            .ToString()

    let Mult (s1: string, s2: string) : string =
        BigInteger
            .Multiply(BigInteger.Parse(s1), BigInteger.Parse(s2))
            .ToString()

    let Div (s1: string, s2: string) : string =
        (Double.Parse(s1) / Double.Parse(s2)).ToString()

    let SetError (error: string) = printfn $"%s{error}"

    let isNumbers (n1: string, n2: string) : bool =
        let couldParse1, _ = BigInteger.TryParse(n1)
        let couldParse2, _ = BigInteger.TryParse(n2)
        // if first is not number than show massage error
        if couldParse1 = false then
            SetError(FirstArgumenError)
        // if second is not number than show massage error
        if couldParse2 = false then
            SetError(SecondArgumenError)

        if couldParse1 && couldParse2 = true then
            true
        else
            false

    let IsOperation (opreation: string) : bool =
        match opreation with
        | Addition
        | Subtract
        | Multiply
        | Divide -> true
        | _ ->
            SetError(OperationError)
            false

    let Proces (n1: string, oper: string, n2: string) : string =
        match oper with
        | Addition -> Add(n1, n2)
        | Subtract -> Sub(n1, n2)
        | Multiply -> Mult(n1, n2)
        | Divide -> Div(n1, n2)
