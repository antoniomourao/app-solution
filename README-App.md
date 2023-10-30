# Application Solution structure

This is the project structure:

* **AppServer**, Blazor server project.Main project that handles the startup and all authentication and base solution requirements

* **AppServer.Client**, Blazor WebAssembly project. This project is the main client project that will be used to manage and contain all the base solution required components

* **Library folder**, Class library project. This project will contain all the classes that will be used by the server and client projects 

    * **AppShared**, Shared project. This project will contain all the shared interfaces, components and classes that will be used by the server and client projects.

    * **Services** folder Library/Services, Class library project. This project will contain all the services that will be shared by the server and client projects.
* **Domains** Folder. This folder will contain all the domains that will be used by the server and client projects.

    * **DomainToDo**, Class library project. This project will contain all the classes that will have all the server logic for this domain.

    * **DomainToDo.Client**, Blazor WebAssembly project. This project is the main client project that will be used to manage and contain all the domain solution required components.

