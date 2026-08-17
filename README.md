# 🛒 E-Commerce API (.NET + Clean Architecture)

Projeto prático para desenvolvimento de uma API de e-commerce robusta utilizando C#/.NET, PostgreSQL, LocalStack (S3, SQS, SNS) e testes unitários.

## 🚀 Tecnologias
- .NET 8 / ASP.NET Core
- PostgreSQL + Entity Framework Core / Dapper
- AWS LocalStack (S3, SQS, SNS) via Docker Compose
- xUnit + Moq + FluentAssertions

## ⚙️ Como rodar o ambiente local
1. Subir a infraestrutura:
   `docker compose up -d`
2. Executar as migrations:
   `dotnet ef database update --project src/Ecommerce.Infrastructure --startup-project src/Ecommerce.API`
3. Rodar a aplicação:
   `dotnet run --project src/Ecommerce.API`
