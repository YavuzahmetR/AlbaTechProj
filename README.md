# AlbaTechProj - CRM Operations Management System

N-Layer architecture web application developed during my internship. The project replicates and optimizes internal software tools utilized by the Customer Relationship Management (CRM) department to manage corporate operations, data caching, and service-driven processes.

## 🚀 Key Features

* **Multi-Layer Architecture:** Developed with strict adherence to SoC (Separation of Concerns) using Core, Repository, Service, Caching, API, and MVC layers.
* **RESTful API & MVC Integration:** A robust backend Web API decoupled from the presentation layer (MVC Client), ensuring high maintainability.
* **Distributed Memory Caching:** Implemented a dedicated caching layer (`Layer.Caching`) to store frequently accessed CRM configurations and lower database bottlenecks.
* **Repository & Unit of Work Patterns:** Abstracted data access logic to facilitate modular testing and reliable transaction handling.

## 🛠️ Tech Stack & Architecture

* **Backend Framework:** .NET 6 (C#)
* **Architecture:** N-Layer Architecture (Domain-Driven Setup)
* **Design Patterns:** Repository Pattern, Service-Repository Pattern
* **Caching:** In-Memory / Distributed Caching Strategies
* **API Consumer:** HttpClient & JSON Serialization/Deserialization
* **UI/UX:** ASP.NET Core MVC (Razor Views)

## 📁 Project Structure

```text
├── AlbaAPI             # RESTful API Endpoints exposing CRM services
├── AlbaTechProj        # Main solution file & core shared assets
├── AlbaMVC             # ASP.NET Core MVC Web Application (Presentation Layer)
├── Layer.Caching       # Independent data caching abstraction & logic
├── Layer.Repositories  # Entity Framework Core configurations & database contexts
└── Layer.Service       # Business logic validation, processing, and rules
```
