using ExceptionHandlingMiddleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ExceptionHandlingMiddleware", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
}

/// <summary>
/// Catches and logs unhandled exceptions so we don't need to log exceptions.
/// 
/// </summary>
app.UseExceptionHandler("/exception-handler");
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExceptionHandlingMiddleware v1"));

app.UseRouting();
app.MapControllers();

app.Run();
