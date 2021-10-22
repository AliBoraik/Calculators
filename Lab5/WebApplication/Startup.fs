module Startup

open CalculatorF
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Microsoft.AspNetCore.Http
open MyCalculator
open Handler

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

let webApp =
    choose [ GET
             >=> choose [ route "/ping" >=> text "pong"
                          route "/" >=> htmlFile "WebRoot\Home\index.html"
                          route "/process" >=> submitParameter ]
             setStatusCode 400
             >=> htmlFile "WebRoot\Error\NotFoundPage.html" ]


type Startup() =
    member __.ConfigureServices(services: IServiceCollection) =
        // Register default Giraffe dependencies
        services.AddGiraffe() |> ignore

    member _.Configure (app: IApplicationBuilder) (_: IHostEnvironment) (_: ILoggerFactory) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseStaticFiles().UseGiraffe(webApp)
