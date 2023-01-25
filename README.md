# Finder WebApi

## Prerequisites

### Project dependency

Run from `AI.Finder.BE.sln` folder `dotnet restore`

### Run project

1. Project `cd .\AI.Finder.BE.Service\` folder
2. Run API `dotnet run`

### Testing

1. Run `dotnet watch run` swagger will open

### Entity framework

1. Migration : Run `dotnet ef migrations add '<add migration details/comment>'`
2. Update: Run `dotnet ef database update`

### Project standards

``` Structure
|- Features[Folder]
    |- <Feature name>s[Folder]
        |- <Feature name>Controller.cs [Controller]
        |- <Feature name>Model.cs [Data Model]
        |- <Feature name>ModelConfiguration.cs [Data Model Configuration]
        |- <Feature name>Dto.cs [Data Transfer Object]
```
# Finder WebApi Unit Testing

## Prerequisites

### Project dependency

### Test project

1. Project `cd .\AI.Finder.BE.Test\AI.Finder.BE.Test.Unit` folder
2. Run test `dotnet test`

### Project standards

``` Structure
|- Features[Folder]
    |- <Feature name>s[Folder]
        |- <Feature name>TestController.cs [Controller]
        |- <Feature name>TestData.cs [Data Model]
```