# MVC API

This project is a simple MVC API built in C# using ASP.NET Core framework. It provides endpoints to perform CRUD operations on user data.

## Project Overview

This MVC API project is designed to serve as a learning tool for understanding how to create APIs using C# and ASP.NET Core. It implements basic CRUD (Create, Read, Update, Delete) operations for managing user data.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- **.NET SDK**: Install the [.NET SDK](https://dotnet.microsoft.com/download) appropriate for your operating system.
- **IDE**: You can use any text editor or IDE of your choice. [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) are recommended for C# development.
- **Database**: This project assumes the use of a SQL database. Ensure you have a SQL database available or configure the project to use an in-memory database for testing purposes.

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
