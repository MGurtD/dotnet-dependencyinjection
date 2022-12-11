using DiApi.Middleware;
using DiApi.Utility;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();

var app = builder.Build();

app.UseCustomMiddleware();
app.UseHttpsRedirection();

app.MapGet("/", (IOperationTransient transient, IOperationScoped scoped, IOperationSingleton singleton) =>
{
    var data = new
    {
        SingletonId = singleton.OperationId,
        ScopedId = scoped.OperationId,
        TransientId = transient.OperationId
    };

    return Results.Ok(data);

});

app.Run();
