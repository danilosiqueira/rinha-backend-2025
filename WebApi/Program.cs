var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapHealthChecks("/healthz");
app.UseHttpsRedirection();

app.MapPost("/payments", (Payment payment) =>
{
    return Results.Ok(payment);
});

app.Run();

record Payment(string CorrelationId, decimal Amount) {}
