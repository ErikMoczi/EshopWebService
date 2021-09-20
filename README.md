# EshopWebService

Project consist of Product API service, allowing to cache date partialy from DB to memory to save processing time and resources of DB. Basic solution is using CQRS (MediatR library) pattern along with SOLID principles.

Main storage for data is Microsoft SQL Server, for Development purposes can be used InMemory DB. To communicate with DB is used ORM framework called EntityFramework Core. To run migration againts DB run following command prompt in the */src* folder:

```console
dotnet ef migrations add NameOfMigration -p ./Infrastructure/EshopWebService.Infrastructure -s ./Presentation/EshopWebService.Api -c ApplicationDbContext
```

Solution contains also integration tests for basic functionality. To run integration tests run following command prompt in the */tests/EshopWebService.IntegrationTests* folder:

```console
dotnet test
```

## Pre-requites
- .Net 5
- local MSSQL DB

## ToDO
- cache paged data - regex search / or meta data
- unit testing of EshopWebService.Application project
- add logging library for better logs data
- better integration tests - how to prepare data
- authentication