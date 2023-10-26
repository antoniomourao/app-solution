# Application Solution 

## Blazor Project in .Net 8 (RC.2)
Settings used:
* int, set to Auto - Uses Server while downloading WebAssembly assets, then uses WebAssembly
* au, set to Individual - Individual authentication
* ai, set to true - Enables all interactive option
* use-program-main, set to true - Uses Program.Main as the entry point of the application
```dos
dotnet new blazor -int Auto -au Individual -ai --use-program-main --name AppServer
```

## Create a new project
Create the project
```dos
dotnet new blazorserver -o MyBlazorProject
```	

Run the project and watch any changes
```dos
dotnet watch run --project MyBlazorProject
```

Add a new page to the project
```dos
dotnet new razorcomponent -n Todo -o Pages
```

### Add a new component class library to the project
```dos
dotnet new razorclasslib -o MyBlazorProjectLibrary
```	

#### Reference the class library from the project
Then add the reference to the project.
From your Pages/Index.razor file, add a using statement at the top of the file.
```cs
@using MyBlazorProjectLibrary
```

Setting sub-directories inside "Pages" and "Shared":
To make those folders content visible to the project, add the following to the ``_import.razor``  file:
```cs
@using MyBlazorProjectLibrary.Shared/Pages.<folder name>
```	

Add a reference to another project
```dos
dotnet <target project> add reference <project to reference>
```

## Libraries
### Bootstrap
Icons can be found [here](https://icons.getbootstrap.com/#install)


## Application Server
Backend Blasor Server application with Individual authentication with all interactive option enabled. Use of server components while downloading WebAssembly assets and then uses WebAssembly.[^1]

### Installation


[^1]: This is the first footnote.