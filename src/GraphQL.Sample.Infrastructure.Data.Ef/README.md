## Migrations commands

To load your datbase use the following commands:

### To apply the latest(s) migrations into your database:
```
update-database -p GraphQL.Sample.Infrastructure.Data.Ef
```

### To add new migration/change of the Database models/configurations
```
add-migration "Migration Name" -p GraphQL.Sample.Infrastructure.Data.Ef
```

### To remove the latest migrations:
```
remove-migration -p GraphQL.Sample.Infrastructure.Data.Ef
```








