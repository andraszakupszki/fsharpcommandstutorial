// Learn more about F# at http://fsharp.org
// Tutorial and commands from: https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/september/fsharp-do-it-all-with-fsharp-on-net-core 

open System

[<EntryPoint>]
let main argv =
    printfn "Nice command-line arguments! Here's what JSON>NET has to say about them: "
    argv
    |> Array.map Library.getJsonNetJson
    |> Array.iter (printfn "%s")
    0 // return an integer exit code
