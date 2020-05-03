// Learn more about F# at http://fsharp.org

open System
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

module Parsing = 
    open System
    let getNums  (str: string) (delim: char) = 
        let idx = str.IndexOf(delim)
        let first = Int64.Parse(str.Substring(0, idx))
        let second = Int64.Parse(str.Substring(idx+1))
        first, second
    
    let getNumsFaster (str: string) (delim: char) = 
        let sp = str.AsSpan()
        let idx = sp.IndexOf(delim)
        let first = Int64.Parse(sp.Slice(0, idx))
        let second = Int64.Parse(sp.Slice(idx+1))
        struct(first, second)

[<MemoryDiagnoser>]
type ParsingBench() = 
    let str = "123234567898,4564567890"
    let delim = ','
    [<Benchmark(Baseline=true)>]
    member _.GetNums() = 
        Parsing.getNums str delim |> ignore
    
    [<Benchmark>]
    member _.GetNumsFaster() =
        Parsing.getNumsFaster str delim |> ignore

[<EntryPoint>]
let main argv =
    let summary =  BenchmarkRunner.Run<ParsingBench>()
    printfn "%A" summary
    0 // return an integer exit code
