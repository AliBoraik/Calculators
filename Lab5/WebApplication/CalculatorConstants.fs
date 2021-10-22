namespace CalculatorF


module public CalculatorConstants =
    [<Literal>]
    let Addition = "add"

    [<Literal>]
    let Subtract = "sub"

    [<Literal>]
    let Multiply = "mul"

    [<Literal>]
    let Divide = "div"

    [<Literal>]
    let NotIntegerErrorMassage = "Argument is not numbers or so long..."

    [<Literal>]
    let DivideByZero = "Attempted to divide by zero."

    [<Literal>]
    let OperationErrorMassage = "Operation is not correct!!"

    [<Literal>]
    let ArgumentErrorMassage = "неверное количество аргументов !!"

    [<Literal>]
    let Ok_Code = 0

    [<Literal>]
    let OperationErrorCode = 1

    [<Literal>]
    let NumbersErrorCode = 2

    [<Literal>]
    let ArgumentErrorCode = 3
