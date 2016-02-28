
#r "../packages/Fsharp.Data.2.2.5/lib/net40/Fsharp.Data.dll"
open System.Net
open FSharp.Data
let address = "https://api.telegram.org/bot"
let token = "188654328:AAEUweZorPX1FjIKwX3xjlwcXICGB40hksQ"
let useMethod = "getUpdates"
let sep = "/"
let client = new WebClient();
let data = client.DownloadString(address + token + sep + useMethod)

type updateMessage = JsonProvider<data>
let json = updateMessage.