namespace WebApplication

open CalculatorF
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Handler

module Initialize =
    let webApp =
        choose [ GET
                 >=> choose [ route "/ping" >=> text "pong"
                              route "/" >=> htmlFile "WebRoot\Home\index.html"
                              route "/process" >=> submitParameter ]
                 setStatusCode 404
                 >=> htmlFile "WebRoot\Error\NotFoundPage.html" ]


type Startup() =
    member __.ConfigureServices(services: IServiceCollection) =
        // Register default Giraffe dependencies
        services.AddGiraffe() |> ignore

    member _.Configure (app: IApplicationBuilder) (_: IHostEnvironment) (_: ILoggerFactory) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseStaticFiles().UseGiraffe(Initialize.webApp)
