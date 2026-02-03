# 🚀 Microservices Inventory & Catalog System (2026)

This project is a high-performance backend solution for managing warehouse stocks and product catalogs, built with scalability and security in mind.
## 📝 Project Overview
This system is designed as a robust backend for managing complex product catalogs and real-time inventory tracking. It is currently **under active development**, focusing on high scalability and preparation for the Euro transition.

### 🎯 What the system does:
* **Product Management:** Full CRUD operations for global product catalogs.
* **Inventory Tracking:** Real-time monitoring of stock levels across different warehouse locations.
* **Current Core Currency:** The system is fully operational using **EUR** as the primary currency for all inventory and catalog transactions.
* **Secure Access:** Integrated custom Middleware Security to ensure only authorized administrators can manage sensitive inventory data.

### 🛠 Ongoing Development (Roadmap):
* [Planned] **Multi-Currency Engine:** Adding dynamic switching between EUR, USD, and GBP.
* [Planned] **API Gateway:** Centralized entry point for microservices.
* [Planned] **Frontend Integration:** Developing a Blazor/React dashboard for real-time tracking.

## 🛠 Tech Stack & Patterns
* **Framework:** **ASP.NET Core Web API (.NET 8)**
* **Database:** **MS SQL Server 2025** (High-performance relational database)
* **Hosting:** Professionally hosted on [MonsterASP.net](https://www.monsterasp.net/)
* **Patterns:** Repository Pattern, Unit of Work, and Dependency Injection.
* **Security:** Custom Middleware for HTTP Basic Authentication
* **Documentation:** Swagger / OpenAPI with Middleware Security
  
## 🌟 Key Features
* **Massive Data Handling:** Optimized logic for processing 1000+ records with high efficiency.
* **Architecture:** Clean Repository Pattern & Service Layer for decoupled and maintainable code.
* **Security:** Integrated HTTP Basic Authentication to protect sensitive API endpoints.
* **Data Integrity:** Professional SQL Migrations and Soft Delete logic for advanced data safety.
* **Dependency Injection (DI):** Implemented throughout the project to ensure loose coupling and high testability of all services.
* **Repository Pattern:** Used to abstract the data layer, making the system cleaner and independent of the specific data source.
* **Clean Architecture:** Strict separation of concerns between API, Core (Entities), Infrastructure (Data), and Service layers.
* **Soft Delete Logic:** Advanced data safety mechanism ensuring no accidental data loss in the SQL database.
---

## 🚀 Live Demo & Hosting
The application is professionally hosted and live for review:
* **Cloud Provider:** Hosted on **MonsterASP.net** servers.
* **URL:** [https://scalable-inventory.runasp.net/](https://scalable-inventory.runasp.net/)
* **Security:** Protected by custom Middleware Authentication.

> **Credentials for Review:**
> - **Username:** `admin`
> - **Password:** `Password123!`

---

## ⚙️ Setup & Installation
1. Clone the repository.
2. Update `appsettings.json` with your local SQL Server connection string.
3. Run `dotnet ef database update` to apply migrations.
4. Launch the project and navigate to `/index.html` for Swagger documentation.

[![MonsterASP.net](https://img.shields.io/badge/Hosted%20on-MonsterASP.net-green?style=for-the-badge&logo=microsoftazure&logoColor=white)](https://www.monsterasp.net/)
