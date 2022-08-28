# NetCore
This is new netCore


.net Core using Sqlite


for setting up sqlite look at here
https://github.com/CuriousDrive/EFCore.AllDatabasesConsidered/blob/main/SQLite/Steps.txt

for source sqlite look at here
https://github.com/CuriousDrive/EFCore.AllDatabasesConsidered/tree/main/SQLite/Database


How to Connect SQLite with .netCore
```
Add Connection String =>
Data source=../Database/youtubenetcore.sqlite

Packages to install =>
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson

Install & Update dotnet EF tool =>
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

Scaffold SQLite Database =>
dotnet ef dbcontext scaffold Name=YoutubeNetCoreDB Microsoft.EntityFrameworkCore.Sqlite --output-dir Models --context-dir Data --namespace YoutubeNetCoreDB.Models --context-namespace data.Data --context YoutubeNetCoreDBContext -f --no-onconfiguring
```
