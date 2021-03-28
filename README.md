# GraphQL-Sample
GraphQL Sample project with Hotchocolate and GraphQL .NET

## Requirements

The project required a connection to a database, to apply the migrations required

For now the Connection String needs to be set on the `Startup.cs` file 
```
options.UseSqlServer("Server=.,1433;Database=NewDb;User Id=sa;Password=[InsertYourPasswordHere]");

```
