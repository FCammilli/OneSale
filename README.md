# OneSale Solution

## Overview
The OneSale solution is a .NET 8-based application designed to manage orders, products, users, and related entities. It is structured into multiple projects, each serving a specific purpose within the application. The solution follows a clean architecture pattern, ensuring separation of concerns and maintainability.

## Projects

### 1. OneSale.Application
- **Path**: `OneSale.Application\OneSale.Application.csproj`
- **Purpose**: Contains application logic, including commands, queries, and DTOs.
- **Key Features**:
  - Commands and handlers for creating and managing orders.
  - Data Transfer Objects (DTOs) for communication between layers.

### 2. OneSale.Web
- **Path**: `OneSale.Web\OneSale.Web.csproj`
- **Purpose**: Acts as the entry point for the web application.
- **Key Features**:
  - Controllers for handling HTTP requests.
  - Configuration files for application settings.

### 3. OneSale.Infrastructure
- **Path**: `OneSale.Infrastructure\OneSale.Infrastructure.csproj`
- **Purpose**: Provides infrastructure-related implementations, such as database access.
- **Key Features**:
  - Entity Framework Core DbContext and migrations.
  - Repository implementations for data access.

### 4. OneSale.Domain
- **Path**: `OneSale.Domain\OneSale.Domain.csproj`
- **Purpose**: Contains core domain entities and interfaces.
- **Key Features**:
  - Entities: `User`, `Product`, `Order`, `Item`.
  - Value objects and domain services.

### 5. OneSale.AppHost
- **Path**: `OneSale.AppHost\OneSale.AppHost.csproj`
- **Purpose**: Hosts the application, configuring and running the necessary services.
- **Key Features**:
  - Application startup and dependency injection configuration.

### 6. OneSale.Test
- **Path**: `OneSale.Test\OneSale.Test.csproj`
- **Purpose**: Contains unit and integration tests for the solution.
- **Key Features**:
  - xUnit-based test cases for entities, repositories, and services.
  - In-memory database setup for testing.

## Architecture
The solution follows the Clean Architecture pattern, which emphasizes separation of concerns and independence of frameworks. Below is a high-level diagram of the architecture:

```
+-------------------+
|   Presentation    |
| (OneSale.Web)     |
+-------------------+
         |
         v
+-------------------+
|   Application     |
| (OneSale.Application) |
+-------------------+
         |
         v
+-------------------+
|     Domain        |
| (OneSale.Domain)  |
+-------------------+
         |
         v
+-------------------+
|   Infrastructure  |
| (OneSale.Infrastructure) |
+-------------------+
```

## Key Features
- **Domain-Driven Design**: Core business logic resides in the `Domain` project.
- **Testability**: Comprehensive test coverage using xUnit.
- **Scalability**: Modular design allows for easy extension.

## How to Run
1. Clone the repository.
2. Restore NuGet packages.
3. Build the solution.
4. Run the `OneSale.AppHost` project.

## How to Test
1. Navigate to the `OneSale.Test` project.
2. Run the tests using the test runner of your choice.

## Dependencies
- .NET 8
- Entity Framework Core
- xUnit

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License.# OneSale