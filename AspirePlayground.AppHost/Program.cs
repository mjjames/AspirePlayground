var builder = DistributedApplication.CreateBuilder(args);

var localstack = builder.AddContainer("localstack", "localstack/localstack");

var testas = builder.AddProject<Projects.AspirePlayground_TestAS>("testas")
    .WaitFor(localstack);

builder.AddProject<Projects.AspirePlayground_Blazor>("app")
    .WithReference(testas)
    .WaitFor(testas);

builder.Build().Run();
