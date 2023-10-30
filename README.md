# Application Solution 

## Blazor Project in .Net 8 (RC.2)
Settings used:
* **int**, set to Auto - Uses Server while downloading WebAssembly assets, then uses WebAssembly
* **au**, set to Individual - Individual authentication
* **ai**, set to true - Enables all interactive option
* **use-program-main**, set to true - Uses Program.Main as the entry point of the application
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

## User Secrets
Add a user secret to the project
```dos
dotnet user-secrets set "ConnectionStrings:IdentityConnection" "DataSource=Data/Databases/appIdentity.sqlite;Cache=Shared"
```

To retrieve the user secret
```csharp
builder.Configuration.GetConnectionString("ConnectionStrings:IdentityConnection"))
```

To list stored user secrets
```dos
dotnet user-secrets list
```

## Internal Libraries

* [Email Sender Service](Library/Services/EmailSenderService/README.md)


## External Libraries[^1]
* [nLog](https://nlog-project.org/)
* [Bootstrap Icons](https://icons.getbootstrap.com/#install)


[^1]: Libraries installed and in use by App Server