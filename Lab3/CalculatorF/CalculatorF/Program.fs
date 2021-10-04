namespace Calculator.Program


open CalculatorF
open CalculatorF.CalculatorConstants
open MyCalculator

module Main =

    [<EntryPoint>]
    let main argv =
        if argv.Length = 3 then
            let number_one = argv.[0]
            let operation = argv.[1]
            let number_two = argv.[2]

            let result: int =
                if isNumbers (number_one, number_two) = true then
                    if IsOperation(operation) = true then
                        printfn $"%s{Proces(number_one, operation, number_two)}"
                        Ok
                    else
                        OpreationError
                else
                    NumbersErrors

            result
        else
            SetError(ArgumentErrorMassage)
            ArgumenError
