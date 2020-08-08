rd src /s /q
md src
cd src
dotnet new globaljson --sdk-version 3.1.300

rem create the solution
dotnet new sln -n AutoLot  
rem create the ASP.NET Core Web App project and add it to the solution
dotnet new mvc -n AutoLot.Web -au none -o .\AutoLot.Web
dotnet sln AutoLot.sln add AutoLot.Web
rem create the Data Access Layer class library, and add to the solution
dotnet new classlib -n AutoLot.Dal -o .\AutoLot.Dal -f netcoreapp3.1
dotnet sln AutoLot.sln add AutoLot.Dal
rem create the class library for the Models and add it to the solution
dotnet new classlib -n AutoLot.Models -o .\AutoLot.Models -f netcoreapp3.1
dotnet sln AutoLot.sln add AutoLot.Models
rem create the Data Access Layer XUnit project and add it to the solution
dotnet new xunit -n AutoLot.Dal.Tests -o .\AutoLot.Dal.Tests
dotnet sln AutoLot.sln add AutoLot.Dal.Tests

rem add project references
dotnet add AutoLot.Web reference AutoLot.Models
dotnet add AutoLot.Web reference AutoLot.Dal

dotnet add AutoLot.Dal reference AutoLot.Models

dotnet add AutoLot.Dal.Tests reference AutoLot.Models
dotnet add AutoLot.Dal.Tests reference AutoLot.Dal

dotnet add AutoLot.Web package AutoMapper
dotnet add AutoLot.Web package LigerShark.WebOptimizer.Core
dotnet add AutoLot.Web package Microsoft.Web.LibraryManager.Build
dotnet add AutoLot.Web package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.6
dotnet add AutoLot.Web package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add AutoLot.Web package System.Text.Json

dotnet add AutoLot.Dal package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.6 
dotnet add AutoLot.Dal package Microsoft.EntityFrameworkCore.Design -v 3.1.6

dotnet add AutoLot.Models package Microsoft.EntityFrameworkCore.Abstractions -v 3.1.6
dotnet add AutoLot.Models package AutoMapper
dotnet add AutoLot.Models package System.Text.Json

dotnet add AutoLot.Dal.Tests package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.6
dotnet add AutoLot.Dal.Tests package Microsoft.NET.Test.Sdk
dotnet add AutoLot.Dal.Tests package xunit
dotnet add AutoLot.Dal.Tests package xunit.runner.visualstudio
dotnet add AutoLot.Dal.Tests package coverlet.collector

cd ..




