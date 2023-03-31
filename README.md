# Emergency Application Backend Classic Architectured

This is a web application written using C# .NET 6.

## Packages Used

This project uses the following packages:

- [AspNet.Core](https://www.nuget.org/packages/Microsoft.AspNetCore/)
- [AspNet.EntityFramework](https://www.nuget.org/packages/Microsoft.AspNetCore.EntityFramework/)
- [AspNet.WebApi](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.WebApiCompatShim/)
- [AspNetCore.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/)
- [Autofac.DynamicProxy](https://www.nuget.org/packages/Autofac.Extras.DynamicProxy/)
- [Autofac.DependencyInjection](https://www.nuget.org/packages/Autofac.Extensions.DependencyInjection/)
- [EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)
- [EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/)
- [EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
- [FluentValidation](https://www.nuget.org/packages/FluentValidation/)
- [JQuerry](https://www.nuget.org/packages/jQuery/)
- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/)

## Installation

To use the project, follow these steps:

1. Clone or download the project.
2. Run the `dotnet restore` command to install the required dependencies.
3. Run the `dotnet ef database update` command to create the database.
4. Use the `dotnet run` command to start the project.

## Usage

After starting the project, the application will run at `https://localhost:5001`. You can use Postman or a similar tool to access the API. Additionally, you can view the API documentation at `https://localhost:5001/swagger/index.html`.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more information.
