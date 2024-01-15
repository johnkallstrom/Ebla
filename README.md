# Ebla

### Table of Contents
- [About the project](#about-the-project)
- [Built with](#built-with)
- [Getting started](#getting-started)
- [Use cases](#use-cases)
- [Backend](#backend)
- [Frontend](#frontend)
- [Unit testing](#unit-testing)
- [GitHub Actions](#github-actions)

### About the project

### Built with
- [.NET](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio)
- [JSON Web Token](https://jwt.io/introduction)
- [CQRS](https://martinfowler.com/bliki/CQRS.html)
- [MediatR](https://github.com/jbogard/MediatR)
- [Swagger](https://swagger.io/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/aspnet.html)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
- [MudBlazor](https://mudblazor.com/)
### Getting started

### Use cases

### Backend

### Unit testing
At the moment all tests are written against the application layer since this is where all logic / use cases lives.
An example of some part of the code being tested is: 
- Create a new loan
- Update an existing book
- Get all authors

Some nuget packages are used to help out with writing the tests.

- [xUnit](https://xunit.net/)
- [moq](https://github.com/devlooped/moq)
- [Fluent Assertions](https://fluentassertions.com/)

### Frontend

### GitHub Actions
