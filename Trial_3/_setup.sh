#!/usr/bin/env bash
export PATH="$PATH:/home/ethan/.dotnet/tools"

dotnet new mvc --no-https
dotnet new globaljson

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
# Changed files (See commit #9485fd4)
dotnet ef migrations add Product
dotnet ef database update