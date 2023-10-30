# Domains
The domains are created all inside the **Domains** folder of the solution. The solution name should start with the Domain name. Example for a ToDo project:
- DomainToDo
- DomainToDo.Client

To Create a domain class lib
    

    dotnet new classlib -o <domain name>
    

To Create a domain client WebAssembly project


    dotnet new blazorwasm -o <domain name>.Client
    