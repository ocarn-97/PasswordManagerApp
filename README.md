# PasswordManagerApp

PasswordManagerApp is a basic REST API built with C# and .NET. This application allows users to create, read, update, and delete (CRUD) accounts while demonstrating foundational backend engineering concepts. **This application is insecure and not intended for production use.**

## Features
- **Account Management:** CRUD operations for account records.
- **Code Structure:** Organized into controllers, models, interfaces, and repositories.
- **Docker Support:** Easily run the application using Docker.

## Prerequisites
To run this project locally, ensure you have the following installed:
- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Docker](https://www.docker.com/) (for containerized execution)

## Getting Started

### Clone the Repository
```bash
git clone https://github.com/ocarn-97/PasswordManagerApp.git
cd PasswordManagerApp
```

### Build and Run the Application
#### Running Locally
1. Open the project in your preferred code editor.
2. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. The API will be available at `http://localhost:5000` (or another specified port).

#### Running with Docker
1. Build the Docker image:
   ```bash
   docker build -t passwordmanagerapp .
   ```
2. Run the Docker container:
   ```bash
   docker run -p 5000:5000 passwordmanagerapp
   ```
3. The API will be available at `http://localhost:5000`.

## Project Structure
The project follows a standard C#/.NET structure:

```
PasswordManagerApp/
|-- Controllers/        # Handles incoming API requests
|-- Models/             # Defines data structures
|-- Interfaces/         # Declares service/repository contracts
|-- Repositories/       # Implements data operations
|-- Program.cs          # Application entry point
```

### Key Components
- **Controllers:** Contain the logic for handling HTTP requests.
  - Example: `AccountController` for managing accounts.
- **Models:** Represent the data structures used in the application.
- **Interfaces:** Define the contracts for repositories and services.
- **Repositories:** Handle data operations, such as creating or fetching account records.

## API Endpoints
Below are examples of the API endpoints:

### Account Management
- `GET /api/accounts` - Retrieve all accounts.
- `GET /api/accounts/{id}` - Retrieve a specific account by ID.
- `POST /api/accounts` - Add a new account.
- `PUT /api/accounts/{id}` - Update an existing account.
- `DELETE /api/accounts/{id}` - Delete an account.

## Security Disclaimer
This application does not implement secure password storage, encryption, or other necessary security measures for a production environment. It is intended solely for learning purposes.

## License
This project is licensed under the [Apache License 2.0](LICENSE).

## Acknowledgments
- Built as part of a backend engineering learning journey.
- Inspired by REST API best practices.
- Created using guidance from various YouTube tutorials.

---
Feel free to raise issues or provide feedback to improve the application.

