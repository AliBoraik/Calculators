module Handler

open System
open CalculatorF
open Giraffe
open Microsoft.AspNetCore.Http
open MyCalculator


let resultHandler (result: Decimal) : HttpHandler =
    let result = result.ToString("G29")

    setStatusCode 200 >=> text $"Result = {result}"


let errorHandler (erroeMassege: String) : HttpHandler =
    setStatusCode 404
    >=> text $"sorry something is wrong try aging! error {erroeMassege}"

[<CLIMutable>]
type Parameter =
    { n1: string
      n2: string
      opre: string }

let submitParameter: HttpHandler =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        let pr = ctx.TryBindQueryString<Parameter>()

        match pr with
        | Ok v ->
            let res = getCodeForReturn (v.n1, v.opre, v.n2)

            match res with
            | Ok res -> resultHandler res next ctx
            | Error err -> errorHandler err next ctx
        | Error err -> (setStatusCode 400 >=> json err) next ctx
