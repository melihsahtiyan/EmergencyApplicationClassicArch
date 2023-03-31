# Emergency Application Backend Classic Architectured

This is a web application written using C# .NET 6.

### About The App
This is an application that helps people by allowing them to ask for help instanteniously. User can select a category of the accident and also they can give more information using images, videos, text or audio. Those Information are then shown on the call center side and authorities can evaluate the situation. Platform is easy to use and location information is automatically sent with the request.

Introducing our revolutionary application designed to help people in times of emergency. Our platform enables users to request immediate assistance in case of an accident or emergency. With just a few taps, users can select the type of emergency and provide crucial information such as images, videos, text or audio to help first responders better assess the situation.

Our app's advanced technology ensures that the information provided by the user is immediately conveyed to the call center and relevant authorities who can take swift action to address the situation. This enables first responders to respond to emergencies more quickly and with greater accuracy.

---
Complete project is built by:
- [Atakan Yiğit Çengeloğlu](https://github.com/AtakanYigit)
- [Melih Sahtiyan](https://github.com/melihsahtiyan)
- [Burak Tırman](https://github.com/buraktirman)
- [Edvin Davulcu](https://github.com/CentEDO)

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

---
Other Repositories For This Project
- [Mobile App (React-Native)] (https://github.com/melihsahtiyan/Emergency-Application-React-Native)
- [Front-End  (React)]        (https://github.com/AtakanYigit/Emergency-Application-Call-Center-Front-End)
