"ECommerceAPI is an ASP.NET Core Web API project built with .NET 6 and Entity Framework.
In this project, a local database connection string is specified in the appsettings.json file. 
To run this project successfully, please configure your own connection string in the appsettings.json file."

To migrate tables to the database using Entity Framework Core, you can use the following commands in the Package Manager Console:
1.  Add-Migration YourMigrationName
Replace YourMigrationName with a meaningful name for your migration. This command generates the necessary code files in the "Migrations" folder.
2.  Update-Database
This command applies the pending migrations to the database, creating or updating the tables based on your model.

Ensure that your Package Manager Console is set to the correct default project, which should be your project containing the DbContext.

Please refer the below attached files for further refernce
[API_EndPoints_Details.xlsx](https://github.com/anusiyap24/ECommerceAPI/files/13798824/API_EndPoints_Details.xlsx)
[Output Document.docx](https://github.com/anusiyap24/ECommerceAPI/files/13798826/Output.Document.docx)
