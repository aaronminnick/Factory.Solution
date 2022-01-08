## Factory Database Management
#### _by Aaron Minnick_

### Technologies Used:
* C# / ASP .NET Core
* Razor / HTML / CSS
* JS / jQuery
* Entity Framework / LINQ / MySql

This is the week 4 independent project for the C# curriculum at [Epicodus](https://www.epicodus.com). The objective was to create an database application demonstrating a many-to-many relationship. The program should let a factory manager add engineers and machines, and track which engineers are licensed to repair each machine.

Beyond baseline requirements, I explored partial views in cobmination with jQuery to perform editing, join table linking, and deleting of records via the details page for a more compact layout with less navigating between pages.

## Setup Instructions:
_(Please note, the below instructions are using gitbash on a Windows computer. Commands may vary if you are using a different OS or terminal program.)_
* You will need [.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0).

* You will need to download and install [MySQL Community Server](https://dev.mysql.com/downloads/) and configure your local server to allow .NET's Entity Framework to construct the database.

* Clone this repository to your local repository (the link may be easily got using the green "Code" button on the github page):
```
$ git clone https://github.com/aaronminnick/Factory.Solution.git
```
* **Or** you may use the same button to download the files to your computer.

* Configure appsettings.json as described below.

* Use console commands to navigate to the main project folder and download dependencies:
```
$ cd Factory
$ dotnet restore
```
* Once your appsettings.json has been configured, use the following command to build the database:
```
$ dotnet ef database update
```
* Build and run the project:
```
$ dotnet build
$ dotnet run
```
* Using a web browser, navigate to:
```
localhost:5000/
```

### appsettings.json
In order for Entity Framework to construct your database correctly, you will need to create a file appsettings.json in the Factory project directory, with the following contents:

```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=aaron_minnick;uid=root;pwd=[YOUR PASSWORD HERE];"
  }
}
```
Be sure to replace the password value with your actual password. Depending on how you have configured your MySql server, you may need to make additional edits to properties in this file.

### Known Bugs/Issues:
* Leaving name blank when creating objects will cause the homepage not to load (need to add validation to form fields to prevent.)

_Thanks for reading! Please feel free to contact me with feedback!_
***
#### [License: MIT](https://opensource.org/licenses/MIT)
#### Copyright (c) 2021 Aaron Minnick
