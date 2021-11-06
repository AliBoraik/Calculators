namespace Calculator.Program

open CalculatorF
open CalculatorF.CalculatorConstants
open MyCalculator

module public Main =
    [<EntryPoint>]
   
    let main argv =

        if argv.Length = 3 then
            let number_one = argv.[0]
            let operation = argv.[1]
            let number_two = argv.[2]

            let re =
                getCodeForReturn (number_one, operation, number_two)

            match re with
            | Ok code -> code
            | Error codeError -> codeError
        else
            SetError(ArgumentErrorMassage)
            ArgumentErrorCode
