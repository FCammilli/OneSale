using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddContainer("sqlserver", "mcr.microsoft.com/mssql/server:2022-latest")
    .WithEnvironment("ACCEPT_EULA", "Y")
    .WithEnvironment("SA_PASSWORD", "Your_password123")
    .WithEndpoint(name: "sql", port: 1433, targetPort: 1433)
    .WithContainerRuntimeArgs("--health-cmd", "exit 0");


var sqlString = "Server=127.0.0.1,1433;Database=OneSaleDb;User Id=sa;Password=Your_password123;Encrypt=False";

var api = builder.AddProject<OneSale_Web>("OneSale")
    .WithEnvironment("ConnectionStrings__DefaultConnection", sqlString)
    .WithEnvironment("EF_AUTO_MIGRATE", "true")
    .WaitFor(sql);

builder.Build().Run();
