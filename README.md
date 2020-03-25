# covid19
This Web application is developed using ASP.NET Core 3.1 technology.

The objective of this application is to provide an online assessment for employees in an organization during the COVID-19 crisis.

## Tools
### Linux
* Ubuntu 18.04.3 (LTS) x64 (We tested on this version)
* Docker
* Docker Compose
* Azure Data Studio (or any which can be manipulate data)
### Windows Server
* Visual Studio 2019 Community Edition (or any which can build .NET core)
* SQL Server 2017 Express Edition
* Azure Data Studio or SQL Server Management Studio (or any which can be manipulate data)

## Build & Deploy
### Linux
1. Clone repository into your prefered directory
1. Change database `SA_PASSWORD` in **docker-compose.yml** to your desired value
1. Adjust volume setting for SQL Server Express installation to your desire
1. Simply run `docker-compose build` then `docker-compose up -d`
1. Connect to database and run SQL scripts we provided in order
   1. **1_create_database.sql** -> Database name **[covid19_db]** will be created in your SQL Server
   1. **2_create_table_and_stored_procedure.sql** -> Tables and Stored Procedures will be created in your **[covid19_db]**
   1. **3_lut_data.sql** -> Necessary lookup data will be inserted into tables
1. Adjust `SA_PASSWORD` in connection string by editing **Covid19\appsettings.Staging.json** according to what you've done in step 2
### Windows Server
1. Clone repository into your prefered directory
1. Connect to database and run SQL scripts we provided in order
   1. **1_create_database.sql** -> Database name **[covid19_db]** will be created in your SQL Server
   1. **2_create_table_and_stored_procedure.sql** -> Tables and Stored Procedures will be created in your **[covid19_db]**
   1. **3_lut_data.sql** -> Necessary lookup data will be inserted into tables
1. Adjust connection string to point to your database server by editing **Covid19\appsettings.json** (Or any environment settings you desire)
1. Publish web application using your prefered tools (We recommend Visual Studio 2019 Community Edition latest version for your convenient)
1. Copy published application to your designated web server

> If you have any problem while hosting your applicaton onto IIS, [Host ASP.NET Core on Windows with IIS](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-3.1) article from Micrsoft could help you through.

## Published application
For windows server, we publish the application with options:

Deployment Mode : Framework-Dependent

Target Runtime: Portable

[Published Application](https://bit.ly/2UiKR0k)

You can download and adjust connection string to point to your database server by editing **Covid19\appsettings.json** (Or any environment settings you desire) then copy to your web server
> If you have any problem while hosting your applicaton onto IIS, [Host ASP.NET Core on Windows with IIS](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-3.1) article from Micrsoft could help you through.

