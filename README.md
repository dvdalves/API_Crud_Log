# API_Crud_Log

This is a simple ASP.NET Core Web API project that demonstrates basic CRUD (Create, Read, Update, Delete) operations using Entity Framework Core with an in-memory database. Additionally, it includes logging functionalities using the ILogger interface.

# Features
- CRUD operations on products.
- In-memory database for easy setup and testing.
- Logging at various levels (Trace, Debug, Information, Warning, Error, Critical).

# Prerequisites
- .NET 8.0 SDK
- Visual Studio or any other code editor
- Postman or any other API testing tool

# Setup
- Clone the repository:
git clone https://github.com/yourusername/API_Crud_Log.git
cd API_Crud_Log

- Restore the dependencies:
dotnet restore

- Build the project:
dotnet build

- Run the project:
dotnet run

# Usage
You can access the Swagger UI to test the API endpoints at https://localhost:5001/swagger or http://localhost:5000/swagger.

# Endpoints
## Products
- GET /api/Products
Retrieve all products.

- GET /api/Products/{id}
Retrieve a product by ID.

- POST /api/Products
Create a new product.

- PUT /api/Products/{id}
Update an existing product by ID.

- DELETE /api/Products/{id}
Delete a product by ID.

## Logs
- GET /api/LogsTest
Writes logs at various levels (Trace, Debug, Information, Warning, Error, Critical) and returns a confirmation message.
