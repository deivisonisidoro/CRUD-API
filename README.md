# MVC API

This project is a simple MVC API built in C# using ASP.NET Core framework. It provides endpoints to perform CRUD operations on user data.

## Project Overview

This MVC API project is designed to serve as a learning tool for understanding how to create APIs using C# and ASP.NET Core. It implements basic CRUD (Create, Read, Update, Delete) operations for managing user data.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- **.NET SDK**: Install the [.NET SDK](https://dotnet.microsoft.com/download) appropriate for your operating system.
- **IDE**: You can use any text editor or IDE of your choice. [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) are recommended for C# development.
- **MySQL Database**: This project uses MySQL as the database. Make sure you have MySQL installed on your system or have access to a MySQL database server. You can download and install MySQL from the [official website](https://dev.mysql.com/downloads/).
- **Connection String**: Update the connection string in the `appsettings.json` file with your MySQL database connection details.

## MySQL Connection String

Before running the project, make sure to update the connection string in the `appsettings.json` file with the appropriate MySQL database connection details. Here's an example of how the connection string should look:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=mydatabase;user=myuser;password=mypassword;"
  }
}
```
Replace localhost, 3306, mydatabase, myuser, and mypassword with your MySQL server hostname or IP address, port number, database name, username, and password respectively.

## Installation

To install and run this project locally, follow these steps:

1. Clone the repository:

    ```bash
    git clone https://github.com/deivisonisidoro/CRUD-API.git
    ```

2. Navigate to the project directory:

    ```bash
    cd MVC-API
    ```

3. Restore project dependencies:

    ```bash
    dotnet restore
    ```

4. Build the project:

    ```bash
    dotnet build
    ```

## Usage

To run the project locally, use the following command:

```bash
dotnet run
```


By default, the API will be accessible at `http://localhost:5029`.

## Swagger Documentation

This project uses Swagger for API documentation. Once the project is running locally, you can access the Swagger UI to explore and interact with the API endpoints. Open your web browser and navigate to:

```http://localhost:5029/swagger```


## Docker and Docker Compose

This application utilizes Docker and Docker Compose for containerization and orchestration.

### Dockerfile

A Dockerfile is included in the project, which defines the environment for the application. This Dockerfile is used to build an image of the application.

### Docker Compose

The project includes two Docker Compose files:

- `docker-compose.yml`: This file defines the services needed to run the application. It includes configurations for both the MVC application (`mvc`) and the MySQL database (`db`).

- `docker-compose.override.yml`: This file is used to override settings defined in the base `docker-compose.yml` file. It is typically used for development-specific settings.

### Running Docker

To run the application with Docker, follow these steps:

1. Make sure you have Docker and Docker Compose installed on your system.

2. Open a terminal and navigate to the project directory.

3. Run the following command to start the Docker containers in detached mode:

    ```bash
    docker-compose up -d
    ```

    This command will create and start the containers defined in the `docker-compose.yml` file.

4. Once the containers are running, you can access the MVC application at `http://localhost::55078`.

5. To stop the containers, run:

    ```bash
    docker-compose down
    ```

    This will stop and remove the containers, but preserve the data volumes.

By using Docker and Docker Compose, you can easily manage the development and deployment environment for the application, ensuring consistency and reproducibility across different environments.
