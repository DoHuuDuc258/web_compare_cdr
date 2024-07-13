// Program.cs
using TodoAPI.AppDataContext;
using TodoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



 // Add  This to in the Program.cs file
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings")); // Add this line
builder.Services.AddSingleton<TodoDbContext>(); // Add this line

var app = builder.Build();

// Add this line

{
    using var scope = app.Services.CreateScope(); // Add this line
    var context = scope.ServiceProvider; // Add this line
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthorization();

app.MapControllers();

app.Run();