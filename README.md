# Project and task manager v1


## Preparation

1. Application is based on C# ASP.Net v6;
2. The following technologies were used:
	- СУБД PostgreSQL;
	- Microsoft.EntityFrameworkCore;
	- Microsoft.EntityFrameworkCore.Design;
	- Npgsql.EntityFrameworkCore.PostgreSQL;
	- Swashbuckle.AspNetCore.Swagger;
	- Swashbuckle.AspNetCore.SwaggerGen;
	- Swashbuckle.AspNetCore.SwaggerUI;
3. In ConnectionStrings (Default) object of the appsettings.json the PostgreSQL user settings should be changed to relevant settings;
4. Migration commands should be entered within the project console (e.g. "dotnet ef migrations add <name>" and dotnet ef database update).
5. Initially project was created at the following repository: https://gitlab.com/bula86kz/projectsandtasksmanager.
