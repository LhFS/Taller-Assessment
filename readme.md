# ApiDataLogger

ApiDataLogger is a simple console application that retrieves data from an API, formats the data into markdown, logs it to the console, and saves it to a file. Additionally, the project includes unit tests to verify the functionality of the data retrieval and formatting logic.

## Project Structure

ApiDataLogger
├── ApiDataLogger
│ ├── ApiDataLogger.csproj
│ ├── Program.cs
│ └── ApiService.cs
├── ApiDataLogger.Tests
│ ├── ApiDataLogger.Tests.csproj
│ └── FetchEndpointAndCheckData.cs
├── .gitignore
└── README.md

- **ApiDataLogger/**: Contains the main application code.
  - `ApiDataLogger.csproj`: Project file for the main application.
  - `Program.cs`: Entry point of the application.
  - `ApiService.cs`: Service class that handles data fetching and processing.
- **ApiDataLogger.Tests/**: Contains the unit tests for the application.
  - `ApiDataLogger.Tests.csproj`: Project file for the test project.
  - `FetchEndpointAndCheckData.cs`: Contains the unit tests for the `ApiService` class.
- **.gitignore**: Specifies which files and directories to ignore in the Git repository.
- **README.md**: This file, which provides an overview and instructions for the project.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or above)

## Setup

1. **Clone the repository**:

   ```sh
   git clone https://github.com/LhFS/Taller-Assessment.git
   cd ApiDataLogger

   ```

2. **Restore dependencies**:

```sh
dotnet restore

```

## Running the Application

3. **Navigate to the main project directory**:

```sh
cd ApiDataLogger

```

4. **Build the project and Run the project**:

```sh
dotnet build
dotnet run

```

This will execute the application, fetch data from the specified API, format it into markdown, log it to the console, and save it to api_data.md.

## Running the Tests

5. **Navigate to the test project directory and Build the test project:**:

```sh
cd ApiDataLogger.Tests
dotnet build
```

## Run the tests:

```sh
dotnet test
```

This will execute the unit tests in FetchEndpointAndCheckData.cs and provide the results in the console.
