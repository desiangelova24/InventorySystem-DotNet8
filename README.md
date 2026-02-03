# Scalable Inventory Management System

This is a secure Inventory Management API built with .NET 8, designed for scalability and performance.

## 🚀 Live Demo & Hosting
The application is professionally hosted and live for review:
- **Cloud Provider:** Hosted on **MonsterASP.net** servers.
- **URL:** [https://scalable-inventory.runasp.net/](https://scalable-inventory.runasp.net/)
- **Security:** Protected by custom Middleware Authentication.
- 
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

---
## 🌐 Infrastructure & Hosting
This project is professionally hosted on **MonsterASP.net**. 

[![MonsterASP.net](https://img.shields.io/badge/Hosted%20on-MonsterASP.net-green?style=for-the-badge&logo=microsoftazure&logoColor=white)](https://www.monsterasp.net/)

*Reliable .NET Cloud Hosting used for the live deployment of this API.*
