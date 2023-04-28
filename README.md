

# .NET 6 MVC Interns Management Project

This project is a web application built using .NET 6 and MVC architecture for managing interns and their assignments. The project allows CRUD (Create, Read, Update, Delete) operations for assigning interns to internships and supervisors who can evaluate the interns on their assignments.

## Technologies Used

The following technologies have been used to build this project:

- .NET 6
- C#
- Entity Framework Core
- MVC
- HTML
- CSS
- JavaScript

## Installation

1. Install [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
2. Clone the repository to your local machine using Git.
```
git clone https://github.com/<your-username>/interns-management.git
```
3. Navigate to the project directory.
```
cd interns-management
```
4. Install the required dependencies by running the following command in the terminal.
```
dotnet restore
```
5. Build the project using the following command.
```
dotnet build
```

## Running the Project

1. Navigate to the project directory.
```
cd interns-management
```
2. Run the following command to start the project.
```
dotnet run
```
3. Open your browser and go to `http://localhost:5000` to access the application.

## Usage

The project provides the following functionalities:

- **Interns Management**: CRUD operations to manage interns and their details such as name, email, phone number, and internship assignment.
- **Supervisors Management**: CRUD operations to manage supervisors and their details such as name, email, and phone number.
- **Assignments Management**: CRUD operations to manage assignments and their details such as title, description, deadline, and assigned supervisor.
- **Interns Assignments**: Assign intern to an assignment and track the progress.
- **Supervisor Assignments**: Assign supervisor to an assignment and evaluate intern's progress.

## Contributing

If you want to contribute to this project, feel free to submit a pull request. However, please ensure that your code follows the [C# Coding Guidelines](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions).

## License

This project is licensed under the [MIT License](https://github.com/<your-username>/interns-management/blob/main/LICENSE).
