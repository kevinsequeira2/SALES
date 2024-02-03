# API ASP.NET CORE

## CREATE DATABASE FOR PROVIDE API

### Add dependencies of Nugget Package

#### PACKAGE ADDED

* Entity framework CORE sql server
* Entity framewor CORE tools


#### Add class and depencies class `CAPA`

### Enable model how principal project

##### Execute this command on console in the model to generate models class

```
Scaffold-DbContext "Server=DESKTOP-RR8UJ9E\SQLEXPRESS; DataBase=DB_SALES; Trusted_Connection=True; 
TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer
```

#### Confuration Connection SQL. `OCI, DALL AND DTO`

 1. Configure DB context class
 2. Configure dependences class
 3. Configure Appsettings.json 

 ## Implement interfaces in DAL with repositories






