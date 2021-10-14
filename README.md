
# Validata Shopping API

# Description

Shopping list tracking app with implementation based on .Net Core REST API CQRS and DDD.

# Technology stack, Frameworks and Tools

- C# programming langugage
- .Net 5.0
- Swagger for Web API
- Microsoft Identity for Authentication/Authorization
- Microsoft Sql Database
- Moq for mocking in Unit testing
- NUnit framework for Unit testing
- MediatR for CQRS
- Restful API
- Dapper
- EntityFramework Core (code first migration)

# Solution Layers

- Web Api (ValidataShopping.API) => Shopping Web Api endpoints located here
- Test (ValidataShopping.Tests) => All Unit tests located here
- Domain (ValidataShopping.Domain) => All Domain classes and repository interfaces located here
- Application (ValidataShopping.Application) => All CQRS Queries and Command handlers located here
- Infrastructure (ValidataShopping.Infrastructure) => All Repositories, database configurations and UnitofWork implementation located here
- Authentication/Authorization (ValidataShopping.Authentication) => I use here Microsoft Identity for Authentication/Authorization (JWT Bearer Token)

==============================

Before calling endpoints I use [Authorize] attribute for authorizing users. For Creating,Deleting and Updating only users with JWT Bearer Token can do
# How to run the solution ?

Steps:

1. In ValidataShopping.API and ValidataShopping.Authentication project in appsettings config file change Sql database connection string to your installed database
2. Start running ValidataShopping.API and ValidataShopping.Authentication projects 
- Database will be created after update-database
- Test values you can insert in database with 'GET ​/api​/Service'
3. When you will run web api Swagger UI will open authomatically and you will see all endpoints there
4. First you have to create user (ValidataShopping.Authentication) => 'POST /Identity​/Register'
5. If you want to avoid Authentication/Authorization just comment [Authorize]  attributes
example: //[Authorize]
