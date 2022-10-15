

using ApiTasksMinimal.Endpoints;
using ApiTasksMinimal.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPersistence();

var app= builder.Build();

app.MapTasksEndPoints();

app.Run();