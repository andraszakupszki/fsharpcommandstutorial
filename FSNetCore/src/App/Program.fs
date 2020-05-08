﻿// Learn more about F# at http://fsharp.org

open System
open System.IO

let printTotalFileBytes path =
        async {
            let! bytes = File.ReadAllBytesAsync(path) |> Async.AwaitTask
            let fileName = Path.GetFileName(path)
            printfn "File %s has %dbytes" fileName bytes.Length
        }

[<EntryPoint>]
let main argv =
    printfn "Nice command-line arguments! Here's what JSON>NET has to say about them: "
    argv
    |> Array.map Library.getJsonNetJson
    |> Array.iter (printfn "%s")

    printTotalFileBytes "App.fsproj"
    |> Async.RunSynchronously
    0 // return an integer exit code

    