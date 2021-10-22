module Handler

open System
open Giraffe


let resultHandler (result: Decimal) : HttpHandler =
    let result = result.ToString("G29")

    setStatusCode 200 >=> text $"Result = {result}"


let errorHandler (erroeMassege: String) : HttpHandler =
    setStatusCode 404
    >=> text $"sorry something is wrong try aging! error {erroeMassege}"
