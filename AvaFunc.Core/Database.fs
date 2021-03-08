namespace AvaFunc.Core

module Database =
    open LiteDB
    open LiteDB.FSharp
    open System
    open System.IO

    let getDatabase (path: string) =
        let mapper = FSharpBsonMapper()
        new LiteDatabase(path, mapper)

    let dbpath =
        let appData = Environment.GetFolderPath Environment.SpecialFolder.LocalApplicationData
        let folder = Path.Combine (appData, "AvaFunc")
        match Directory.Exists folder with
        | true -> ()
        | false -> Directory.CreateDirectory folder |> ignore
        let path = Path.Combine(folder, "AvaFunc.db")
        sprintf "Filename=%s;Async=true" path
