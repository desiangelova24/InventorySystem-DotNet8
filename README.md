# Scalable Inventory Management System

This is a secure Inventory Management API built with .NET 8, designed for scalability and performance.

## 🚀 Live Demo
You can access the live API documentation here:
**[https://scalable-inventory.runasp.net/](https://scalable-inventory.runasp.net/)**

> **Note:** Access is restricted. Please use the following credentials:
> - **Username:** admin
> - **Password:** Password123!

## 🛠 Features
- **Clean Architecture:** Divided into API, Core, Infrastructure, and Services for better maintainability.
- **Security:** Implemented HTTP Basic Authentication middleware to protect sensitive endpoints.
- **Database:** MS SQL Server integrated via Entity Framework Core with full Migration history.
- **Soft Delete:** Logic implemented to ensure data safety.
- **Currency:** Fully updated to support **EUR**.

## ⚙️ Setup & Installation
1. Clone the repository.
2. Update `appsettings.json` with your local SQL Server connection string.
3. Run `dotnet ef database update` to apply migrations.
4. Launch the project and navigate to `/index.html` for Swagger documentation.
